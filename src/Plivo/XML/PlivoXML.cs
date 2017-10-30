using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Plivo.Exception;
using dict = System.Collections.Generic.Dictionary<string, string>;
using list = System.Collections.Generic.List<string>;

namespace Plivo.XML
{
    public class PlivoXML
    {
        public Response Response { get; set; }

        public PlivoXML(Response response)
        {
            Response = response ?? throw new ArgumentNullException(nameof(response));
        }
    }
}
