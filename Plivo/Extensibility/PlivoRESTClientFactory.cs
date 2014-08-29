using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plivo.Extensibility
{
    public class PlivoRESTClientFactory:IPlivoClientFactory
    {
        public PlivoClient CreateClient(string authId, string authToken, string version)
        {
            PlivoRESTClient client = new PlivoRESTClient(authId,authToken,version);
            return client;
        }
    }
}
