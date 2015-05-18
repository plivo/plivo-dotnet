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
        public static bool Verify(string uri, dict plivoHttpParams, string xPlivoSignature, string authToken)
        {
            var isMatch = false;
            foreach (KeyValuePair<string, string> kvp in plivoHttpParams.OrderBy(key => key.Key))
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