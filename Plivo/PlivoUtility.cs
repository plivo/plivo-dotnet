using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Security.Cryptography;
using dict = System.Collections.Generic.Dictionary<string, string>;

namespace Plivo.Utility
{
    class PlivoUtility
    {
        static bool ValidateSignature(string uri, dict plivoHttpParams, string signature, string auth_token)
        {
            var isMatch = false;
            foreach (KeyValuePair<string, string> kvp in plivoHttpParams.OrderBy(key => key.Key))
                uri += kvp.Key + kvp.Value;

            var enc = Encoding.ASCII;
            HMACSHA1 myhmacsha1 = new HMACSHA1(enc.GetBytes(auth_token));
            byte[] byteArray = Encoding.ASCII.GetBytes(uri);
            MemoryStream stream = new MemoryStream(byteArray);
            byte[] hashValue = myhmacsha1.ComputeHash(stream);

            if (signature.Equals(hashValue.ToString())) 
                isMatch = true;
            return isMatch;
        }
    }
}
