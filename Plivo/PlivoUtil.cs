using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Security.Cryptography;
using dict = System.Collections.Generic.Dictionary<string, string>;

namespace Plivo.Util
{
    public class XPlivoSignature
    {
        
        /// <summary>
        ///   Verifes signature of a request, specifically for GET requests.
        /// </summary>
        /// <param name="uri">URL received by server</param>
        /// <param name="originalUri">Original URL sent to Plivo or configured in application</param>
        /// <param name="xPlivoSignature">Expected Signature obtained from 'X-Plivo-Signature' header</param>
        /// <param name="authToken">Plivo Auth token</param>
        /// <returns>true if signature matches, false otherwise</returns>
        public static bool Verify(string uri, string originalUri, string xPlivoSignature, string authToken)
        {
            var qs = new Uri(uri).Query;
            var qsDict = System.Web.HttpUtility.ParseQueryString(qs);
            
            var getParams = qsDict.AllKeys.ToDictionary(item => item, item => qsDict[item]);
            
            // use original url 
            foreach (KeyValuePair<string, string> kvp in getParams.OrderBy(key => key.Key, StringComparer.Ordinal))
                originalUri += kvp.Key + kvp.Value;

            var sha1 = new HMACSHA1(Encoding.UTF8.GetBytes(authToken));
            var hashValue = sha1.ComputeHash(Encoding.UTF8.GetBytes(originalUri));
            var generatedSignature = Convert.ToBase64String(hashValue);

            return xPlivoSignature.Equals(generatedSignature);
        }
        
        
        public static bool Verify(string uri, dict plivoHttpParams, string xPlivoSignature, string authToken)
        {
            var isMatch = false;
            foreach (KeyValuePair<string, string> kvp in plivoHttpParams.OrderBy(key => key.Key, StringComparer.Ordinal))
                uri += kvp.Key + kvp.Value;

            var enc = Encoding.ASCII;
            HMACSHA1 myhmacsha1 = new HMACSHA1(enc.GetBytes(authToken));
            byte[] byteArray = Encoding.ASCII.GetBytes(uri);
            MemoryStream stream = new MemoryStream(byteArray);
            byte[] hashValue = myhmacsha1.ComputeHash(stream);
            string generatedSignature = Convert.ToBase64String(hashValue);

            if (xPlivoSignature.Equals(generatedSignature))
                isMatch = true;
            return isMatch;
        }
    }

    class HtmlEntity
    {
        public static string Convert(string inputText)
        {
            StringBuilder builder = new StringBuilder();
            foreach (char c in inputText)
            {
                if ((int)c > 127)
                {
                    builder.Append("&#");
                    builder.Append((int)c);
                    builder.Append(";");
                }
                else
                {
                    builder.Append(c);
                }
            }
            return builder.ToString();
        }
    }
}
