using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
// using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Plivo.Utilities;

namespace Plivo
{
    /// <summary>
    /// Util.
    /// </summary>
    public class Util
    {
        /// <summary>
        /// XPlivoSignature
        /// </summary>
        public class XPlivoSignature
        {
            /// <summary>
            /// Verify the signature
            /// </summary>
            /// <param name="uri"></param>
            /// <param name="plivoHttpParams"></param>
            /// <param name="xPlivoSignature"></param>
            /// <param name="authToken"></param>
            /// <returns></returns>
            public static bool Verify(string uri, Dictionary<string, object> plivoHttpParams, string xPlivoSignature, string authToken)
            {
                return false;
            }
        }

        /// <summary>
        /// HtmlEntity.
        /// </summary>
        public class HtmlEntity
        {
            /// <summary>
            /// Escapes unicode characters in input string
            /// </summary>
            /// <param name="inputText"></param>
            /// <returns></returns>
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
}
