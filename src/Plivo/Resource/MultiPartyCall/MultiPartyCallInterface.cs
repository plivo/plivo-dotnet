using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Plivo.Client;
using Plivo.Exception;
using Plivo.Http;

namespace Plivo.Resource.MultiPartyCall
{
    public class MultiPartyCallInterface : ResourceInterface
    {
        public MultiPartyCallInterface(HttpClient client) : base(client)
        {
            Uri = "Account/" + Client.GetAuthId() + "/MultiPartyCall/";
        }
        
    }
}