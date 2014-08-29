using System.Collections.Generic;

namespace Plivo.XML
{
    public class Response : PlivoElement
    {
        public Response(): base()
        {
            Nestables = new List<string>()
                {   "Speak", "Play", "GetDigits", "Record", "Dial", "Message", "Redirect",
                    "Wait", "Hangup", "PreAnswer", "Conference", "DTMF"
                };
            ValidAttributes = new List<string>() { "" };
        }
    }
}