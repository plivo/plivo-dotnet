using System.Collections.Generic;
using Newtonsoft.Json;
using Plivo.Exception;
using dict = System.Collections.Generic.Dictionary<string, string>;
using list = System.Collections.Generic.List<string>;

namespace Plivo.XML
{
    public class Stream : PlivoElement
    {
        public Stream(string body, dict attributes)
            : base(body, attributes)
        {
            Nestables = new list() {""};
            ValidAttributes = new list()
            {
                "bidirectional",
                "audioTrack",
                "streamTimeout",
                "statusCallbackUrl",
                "statusCallbackMethod",
                "contentType",
                "extraHeaders"
            };

            if (body == null)
            {
                throw new PlivoXMLException("No text set for Stream " + Element.Name);
            }
            var VALID_CALLBACKMETHOD_VALUES = new list() {"GET", "POST"};
            var VALID_AUDIOTRACK_VALUES = new list() {"inbound", "outbound", "both"};

            if (Attributes.ContainsKey("statusCallbackMethod") && !VALID_CALLBACKMETHOD_VALUES.Contains(Attributes["statusCallbackMethod"].ToUpper()))
            {
                throw new PlivoXMLException("Invalid attribute value " + Attributes["statusCallbackMethod"] + " for statusCallbackMethod"); 
            }

            if (Attributes.ContainsKey("audioTrack") && !VALID_AUDIOTRACK_VALUES.Contains(Attributes["audioTrack"]))
            {
                throw new PlivoXMLException("Invalid attribute value " + Attributes["audioTrack"] + " for audioTrack"); 
            }

            if (Attributes.ContainsKey("extraHeaders"))
            {
                //var headers = Attributes["extraHeaders"];
                var headers = JsonConvert.DeserializeObject<Dictionary<string, string>>(Attributes["extraHeaders"]);
                dict headersDict = new Dictionary<string, string>();
                
                foreach(KeyValuePair<string, string> element in headers)
                {
                    if (element.Key.EndsWith("X-PH"))
                    {
                        headersDict.Add(element.Key, element.Value);
                    }
                    else
                    {
                        headersDict.Add(element.Key + "X-PH", element.Value);
                    }
                }
                string headersString = JsonConvert.SerializeObject(headersDict);
                Attributes.Remove("extraHeaders");
                Attributes.Add("extraHeaders", headersString);
            }
            addAttributes();
        }
    }
}
