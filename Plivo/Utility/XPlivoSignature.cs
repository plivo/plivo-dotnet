using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Plivo.Utility
{
    public class XPlivoSignature
    {
        public static bool Verify(string uri, Dictionary<string, string> plivoHttpParams, string xPlivoSignature, string authToken)
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
}