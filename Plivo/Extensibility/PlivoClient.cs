using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plivo.Extensibility
{
    public abstract class PlivoClient:IPlivoClient
    {
        public string Version { get; set; }
        public string AuthID { get; set; }
        public string AuthToken { get; set; }

        protected PlivoClient(string authId,string authToken,string version = "v1")
        {
            AuthID = authId;
            AuthToken = authToken;
            Version = version;
        }
    }
}
