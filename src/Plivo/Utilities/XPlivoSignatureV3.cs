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
          var url = new Uri(uri);
          var paramString = "";
          char[] charsToTrim = {'&'};
          var keys = parameters.Keys.ToList();
          keys.Sort();
          if (method == "GET")
          {
            foreach(string key in keys){
              paramString += key + "=" + parameters[key] + "&";
            }
            paramString = paramString.Trim(charsToTrim);
            if(url.Query.Length != 0)
            {
              uri += "&" + paramString;
            }
            else
            {
              uri += "/?" + paramString;
            }
          }
          else
          {
            foreach(string key in keys)
            {
              paramString += key + parameters[key];
            }
            uri += "." + paramString;
          }
          return uri;
        }

        public static string ComputeSignature(string uri, string nonce, string authToken, Dictionary<string,string> parameters, string method)
        {
			      char[] charsToTrim = {'/'};
            uri = uri.Trim(charsToTrim);
            string payload = GenerateUrl(uri, parameters, method) + "." + nonce;
            var hash = new HMACSHA256(Encoding.UTF8.GetBytes(authToken));
            var computedHash = hash.ComputeHash(Encoding.UTF8.GetBytes(payload));
            return Convert.ToBase64String(computedHash);
        }

        /// <summary>
        /// Verify X-Plivo-Signature-V2
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="nonce"></param>
        /// <param name="xPlivoSignature"></param>
        /// <param name="authToken"></param>
        /// <returns></returns>
        public static bool VerifySignature(string uri, string nonce, string xPlivoSignature, string authToken, Dictionary<string,string> parameters, string method)
        {
            string computedSignature = ComputeSignature(uri, nonce, authToken, parameters, method);
			      char[] separator = {','};
            var signatures = xPlivoSignature.Split(separator);
            foreach (string signature in signatures){
              if (computedSignature == signature)
              {
                  return true;
              }
            }
            return false;
        }
    }
}
