using System;
using System.Security.Cryptography;
using System.Text;

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
        public static string GenerateUrl(string uri, Dictionary<string, string> params, string method)
        {
          var url = new Uri(uri);
          var paramString = "";
          if (method == "GET"){
            var keys = params.Keys;
            for(string key in keys){
              paramString += key + "=" + params[key] + "&";
            }
            paramString.Trim("&");
            if(url.Query){
              uri += "&" + paramString;
            }
            else{
              uri += "/?" + paramString;
            }
          }
          else{
            var keys = params.Keys;
            Array.Sort(keys);
            for(string key in keys){
              paramString += key + params[key];
            }
            uri += "." + paramString;
          }
          return uri;
        }

        public static string ComputeSignature(string uri, string nonce, string authToken, Dictionary<string, string> params, string method)
        {
            var url = new Uri(uri);
            string absolutePath = url.AbsolutePath;

            string pathToAppend = "";

            int pathExists = uri.Replace(url.Scheme + "://" + url.Host, "")
                .IndexOf(absolutePath, StringComparison.CurrentCulture);

            if (pathExists > -1)
            {
                pathToAppend = absolutePath;
            }
            else
            {
                pathToAppend = absolutePath.Remove(absolutePath.Length - 1);
            }

            string baseUrl = url.Scheme + "://" + url.Host + pathToAppend;
            if (!url.IsDefaultPort)
            {
                baseUrl = url.Scheme + "://" + url.Host + ":" + url.Port + pathToAppend;
            }
            string payload = GenerateUrl(uri, params, method) + "." + nonce;
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
        public static bool VerifySignature(string uri, string nonce, string xPlivoSignature, string authToken, Dictionary<string, string> params, string method)
        {
            string computedSignature = ComputeSignature(uri, nonce, authToken, params, method);
            signatures = xPlivoSignature.split(",");
            for(string signature in signatures){
              if (computedSignature == signature)
              {
                  return true;
              }
            }
            return false;
        }
    }
}
