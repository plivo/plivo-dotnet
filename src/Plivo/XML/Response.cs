using dict = System.Collections.Generic.Dictionary<string, string>;
using list = System.Collections.Generic.List<string>;

namespace Plivo.XML
{
    public class Response : PlivoElement
    {
        public Response()
            : base()
        {
            Nestables = new list()
            {   "Speak", "Play", "GetDigits", "Record", "Dial", "Message", "Redirect",
                "Wait", "Hangup", "PreAnswer", "Conference", "DTMF"
            };
            ValidAttributes = new list() { "" };
        }
    }
}
