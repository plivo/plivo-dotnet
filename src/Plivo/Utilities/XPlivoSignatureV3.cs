using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Plivo.Utilities
{
    public static class XPlivoSignatureV3
    {
        /// <summary>
        /// Compute X-Plivo-Signature-V2
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="nonce"></param>
        /// <param name="authToken"></param>
        /// <returns></returns>
        public static string GenerateUrl(string uri, Dictionary<string, string> parameters, string method)
        {
            uri = uri.Replace("+", "%20");
            var parsedUrl = new Uri(uri);
            uri = parsedUrl.Scheme + "://" + parsedUrl.Host + parsedUrl.LocalPath;
            var parsedUrlQuery = Uri.UnescapeDataString(parsedUrl.Query);
            if (parameters.Any() || parsedUrl.Query.Length > 0)
            {
                uri += "?";
            }

            if (parsedUrl.Query.Length > 0)
            {
                if (method == "GET")
                {
                    var queryParamMap = getMapFromQueryString(parsedUrlQuery.TrimStart('?'));
                    foreach (var param in parameters.Keys)
                    {
                        queryParamMap.Add(param, parameters[param]);
                    }

                    foreach (KeyValuePair<string, string> kvp in queryParamMap)
                    {
                        Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
                    }

                    uri += GetSortedQueryParamString(queryParamMap, true);
                }
                else
                {
                    uri += GetSortedQueryParamString(getMapFromQueryString(parsedUrlQuery.TrimStart('?')), true) +
                           "." + GetSortedQueryParamString(parameters, false);
                    uri = uri.TrimEnd('.');
                }
            }
            else
            {
                if (method == "GET")
                {
                    uri += GetSortedQueryParamString(parameters, true);
                }
                else
                {
                    uri += GetSortedQueryParamString(parameters, false);
                }
            }

            Console.WriteLine(uri);
            return uri;
        }

        public static Dictionary<string, string> getMapFromQueryString(string query)
        {
            Dictionary<string, string> mp = new Dictionary<string, string>();
            if (query.Length == 0)
            {
                return mp;
            }

            string[] keyValuePairs = query.Split('&');
            Array.Sort(keyValuePairs, StringComparer.Ordinal);
            foreach (var pairs in keyValuePairs)
            {
                var pair = pairs.Split(new[] {'='}, 2);
                if (pair.Count() == 2)
                {
                    mp[pair[0]] = pair[1];
                }
            }

            return mp;
        }

        public static string GetSortedQueryParamString(Dictionary<string, string> parameters, bool queryParams)
        {
            var url = "";
            var keys = parameters.Keys.ToList();
            keys.Sort(StringComparer.Ordinal);

            if (queryParams)
            {
                foreach (var key in keys)
                {
                    url += key + "=" + parameters[key] + "&";
                }

                url = url.TrimEnd('&');
            }
            else
            {
                foreach (var key in keys)
                {
                    url += key + parameters[key];
                }
            }

            return url;
        }

        public static string ComputeSignature(string uri, string nonce, string authToken,
            Dictionary<string, string> parameters, string method)
        {
            return Sign(uri, nonce, Encoding.UTF8.GetBytes(authToken), parameters, method);
        }

        private static string Sign(string uri, string nonce, byte[] key,
            Dictionary<string, string> parameters, string method)
        {
            string payload = GenerateUrl(uri, parameters, method) + "." + nonce;
            return Convert.ToBase64String(HmacSha256(key, Encoding.UTF8.GetBytes(payload)));
        }

        private static byte[] HmacSha256(byte[] key, byte[] data)
        {
            using (var hmac = new HMACSHA256(key))
            {
                return hmac.ComputeHash(data);
            }
        }

        /// <summary>
        /// Derive the raw 32-byte webhook signing key for a scoped API token (HKDF-SHA256, RFC 5869)
        /// </summary>
        public static byte[] DeriveSigningKey(string scopedToken)
        {
            if (scopedToken == null)
            {
                throw new ArgumentNullException(nameof(scopedToken));
            }
            var prk = HmacSha256(Encoding.UTF8.GetBytes("plivo-scoped-token-v1"), Encoding.UTF8.GetBytes(scopedToken));
            var info = Encoding.UTF8.GetBytes("plivo-webhook-signing-v1\u0001");
            return HmacSha256(prk, info);
        }

        public static string ComputeSignatureScoped(string uri, string nonce, string scopedToken,
            Dictionary<string, string> parameters, string method)
        {
            return Sign(uri, nonce, DeriveSigningKey(scopedToken), parameters, method);
        }

        /// <summary>
        /// Verify X-Plivo-Signature-V3 on a webhook caused by a scoped API token
        /// </summary>
        public static bool VerifySignatureScoped(string uri, string nonce, string xPlivoSignature, string scopedToken,
            string method, Dictionary<string, string> parameters = null)
        {
            return VerifySignatureScoped(uri, nonce, xPlivoSignature, new[] {scopedToken}, method, parameters);
        }

        /// <summary>
        /// Verify X-Plivo-Signature-V3 against several keys; true if any of them signed the webhook.
        /// Scoped API tokens (46 chars, starting with "PLV") are verified with the HKDF-derived signing key,
        /// any other key is treated as an auth token. Null or empty keys are skipped.
        /// </summary>
        public static bool VerifySignatureScoped(string uri, string nonce, string xPlivoSignature, IEnumerable<string> keys,
            string method, Dictionary<string, string> parameters = null)
        {
            parameters = parameters ?? new Dictionary<string, string>();
            var candidates = xPlivoSignature.Split(',');
            var valid = false;
            foreach (var key in keys)
            {
                if (string.IsNullOrEmpty(key))
                {
                    continue;
                }
                var computed = key.Length == 46 && key.StartsWith("PLV", StringComparison.Ordinal)
                    ? ComputeSignatureScoped(uri, nonce, key, parameters, method)
                    : ComputeSignature(uri, nonce, key, parameters, method);
                var expected = Encoding.UTF8.GetBytes(computed);
                foreach (var signature in candidates)
                {
                    valid |= FixedTimeEquals(expected, Encoding.UTF8.GetBytes(signature.Trim()));
                }
            }
            return valid;
        }

        private static bool FixedTimeEquals(byte[] a, byte[] b)
        {
            if (a.Length != b.Length)
            {
                return false;
            }
            var diff = 0;
            for (var i = 0; i < a.Length; i++)
            {
                diff |= a[i] ^ b[i];
            }
            return diff == 0;
        }

        /// <summary>
        /// Verify X-Plivo-Signature-V3 with an auth token, or with a scoped API token (PLV..., 46 chars) via DeriveSigningKey
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="nonce"></param>
        /// <param name="xPlivoSignature"></param>
        /// <param name="authToken"></param>
        /// <returns></returns>
        public static bool VerifySignature(string uri, string nonce, string xPlivoSignature, string authToken,
            string method, Dictionary<string, string> parameters = null)
        {
            if (authToken != null && authToken.Length == 46 && authToken.StartsWith("PLV", StringComparison.Ordinal))
            {
                return VerifySignatureScoped(uri, nonce, xPlivoSignature, authToken, method, parameters);
            }
            if (parameters == null)
            {
                parameters = new Dictionary<string, string>();
            }
            string computedSignature = ComputeSignature(uri, nonce, authToken, parameters, method);
            Console.WriteLine(computedSignature);
            var signatures = xPlivoSignature.Split(',');
            foreach (string signature in signatures)
            {
                if (computedSignature == signature)
                {
                    return true;
                }
            }

            return false;
        }
    }
}