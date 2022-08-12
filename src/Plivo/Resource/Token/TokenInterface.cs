using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Plivo.Client;
using Plivo.Http;
using Plivo.Utilities;

namespace Plivo.Resource.Token
{
    /// <summary>
    /// Token interface.
    /// </summary>
    public class TokenInterface : ResourceInterface
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:plivo.Resource.Token.TokenInterface"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        public TokenInterface(HttpClient client) : base(client)
        {
            Uri = "Account/" + Client.GetAuthId() + "/JWT/Token/";
        }

        #region Create

        /// <summary>
        /// Create Token with the specified from iss,sub,nbf,exp,incoming_allow,outgoing_allow,app
        /// </summary>
        /// <returns>The create.</returns>
        /// <param name="iss"></param>
        /// <param name="sub"></param>
        /// <param name="nbf"></param>
        /// <param name="exp"></param>
        /// <param name="incoming_allow"></param>
        /// <param name="outgoing_allow"></param>
        /// <param name="app"></param>
        public TokenCreateResponse Create(
            string iss , string sub = null,int nbf = 0,  int exp = 0,bool incoming_allow = false, bool outgoing_allow = false, string app = null)
            
        {
            var mandatoryParams = new List<string> { "" };
            bool isVoiceRequest = true;
           
           var data = CreateData(
                mandatoryParams,
                new
                {
                    iss,
                    sub,
                    nbf,
                    exp,
                    app,
                    isVoiceRequest
                });
			if (incoming_allow || outgoing_allow )
			{
				if(incoming_allow)
                {
                    data.Add("per", new JObject(new JProperty("voice", new JObject(new JProperty("incoming_allow", true)))));
                }
				if(outgoing_allow)
                {
                    data.Add("per", new JObject(new JProperty("voice", new JObject(new JProperty("outgoing_allow", true)))));
                }
            }

            return ExecuteWithExceptionUnwrap(() =>
            {
                var result = Task.Run(async () => await Client.Update<TokenCreateResponse>(Uri, data).ConfigureAwait(false)).Result;
                result.Object.StatusCode = result.StatusCode;
                return result.Object;
            });
        }

        /// <summary>
        /// Asynchronously create Token with the specified from iss,sub,nbf,exp,incoming_allow,outgoing_allow,app
        /// </summary>
        /// <returns>The create.</returns>
        /// <param name="iss">Iss.</param>
        /// <param name="sub">Sub.</param>
        /// <param name="nbf">Nbf.</param>
        /// <param name="exp">Exp.</param>
        /// <param name="incoming_allow">Incoming_Allow.</param>
        /// <param name="outgoing_allow">Outgoing_Allow.</param>
        /// <param name="app">App.</param>
        public async Task<AsyncResponse> CreateAsync(
            string iss , string sub = null,int nbf = 0,  int exp = 0,bool incoming_allow = false, bool outgoing_allow = false, string app = null)

        {
            var mandatoryParams = new List<string> { "" };
            bool isVoiceRequest = true;
            var data = CreateData(
                mandatoryParams,
                new
                {
                    iss,
                    sub,
                    nbf,
                    exp, 
                    app,
                    incoming_allow,
                    outgoing_allow,
                    isVoiceRequest
                });
            if (incoming_allow || outgoing_allow )
            {
                if(incoming_allow )
                {
                    data.Add("per", new JObject(new JProperty("voice", new JObject(new JProperty("incoming_allow", true)))));
                }
                if(outgoing_allow)
                {
                    data.Add("per", new JObject(new JProperty("voice", new JObject(new JProperty("outgoing_allow", true)))));
                }
            }
            var result = Task.Run(async () => await Client.Update<AsyncResponse>(Uri, data).ConfigureAwait(false))
                .Result;
            await Task.WhenAll();
            result.Object.StatusCode = result.StatusCode;
            JObject responseJson = JObject.Parse(result.Content);
            result.Object.ApiId = responseJson["api_id"].ToString();
            result.Object.Message = responseJson["token"].ToString();
            return result.Object;
        }
        #endregion
    }
}