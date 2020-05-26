using System;
using System.Collections.Generic;
using JWT.Algorithms;
using JWT.Builder;
using Plivo.Authentication;
using Plivo.Exception;

namespace Plivo
{
    public class AccessToken
    {
        protected BasicAuth BasicAuth;
        public String Username;

        public DateTime ValidFrom;
        public TimeSpan Lifetime;

        public String Uid;

        public Dictionary<string, Dictionary<string, object>> Grants= new Dictionary<string, Dictionary<string, object>>();

        public AccessToken(String authId, String authToken, String username)
        {
            BasicAuth = new BasicAuth(authId, authToken);
            if (username.Length == 0) {
                throw new PlivoValidationException("username empty");
            }
            Username = username;
        }

        public AccessToken WithValidFrom(DateTime validFrom)
        {
            ValidFrom = validFrom;
            return this;
        }

        public AccessToken WithLifetime(TimeSpan lifetime)
        {
            if (lifetime.TotalSeconds < 180 || lifetime.TotalSeconds > 86400)
            {
                throw new PlivoValidationException("lifetime out of [180, 86400]");
            }
            Lifetime = lifetime;
            return this;
        }

        public AccessToken WithValidTill(DateTime validTill)
        {
            if (ValidFrom == default(DateTime) && Lifetime == default(TimeSpan)) {
                throw new PlivoValidationException("define either one of validFrom or lifetime as well");
            }
            if (ValidFrom != default(DateTime) && Lifetime != default(TimeSpan)) {
                throw new PlivoValidationException("define either one of validFrom or lifetime only");
            }
            if (Lifetime != default(TimeSpan)) {
                validTill.AddMilliseconds(-Lifetime.TotalMilliseconds);
                ValidFrom = validTill;
            } else {
                Lifetime = validTill.Subtract(ValidFrom);
            }
            return this;
        }

        public AccessToken WithUid(String uid)
        {
            Uid = uid;
            return this;
        }

        public AccessToken WithIncoming(Boolean allow)
        {
            if (!Grants.ContainsKey("voice")) Grants.Add("voice", new Dictionary<string, object>());
            Grants["voice"].Add("incoming_allow", allow);
            return this;
        }

        public AccessToken WithOutgoing(Boolean allow)
        {
            if (!Grants.ContainsKey("voice")) Grants.Add("voice", new Dictionary<string, object>());
            Grants["voice"].Add("outgoing_allow", allow);
            return this;
        }

        public String ToJwt()
        {
            if (ValidFrom == default(DateTime)) ValidFrom = DateTime.UtcNow;
            if (Lifetime == default(TimeSpan)) Lifetime = TimeSpan.FromHours(24);
            var validFromEpoch = ValidFrom.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
            if (Uid == default(String)) Uid = Username + "-" + validFromEpoch.ToString();
            return new JwtBuilder()
                .WithAlgorithm(new HMACSHA256Algorithm())
                .WithSecret(BasicAuth.AuthToken)
                .AddHeader(HeaderName.ContentType, "plivo;v=1")
                .AddClaims(new Dictionary<string, object>
                    {
                        { "jti", Uid },
                        { "iss", BasicAuth.AuthId },
                        { "sub", Username },
                        { "nbf", Math.Ceiling(validFromEpoch) },
                        { "exp", Math.Floor(validFromEpoch + Lifetime.TotalSeconds) },
                        { "grants", Grants }
                    })
                .Encode();
        }


}
}
