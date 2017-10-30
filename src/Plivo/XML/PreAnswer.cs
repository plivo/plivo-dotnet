using dict = System.Collections.Generic.Dictionary<string, string>;
using list = System.Collections.Generic.List<string>;

namespace Plivo.XML
{
    public class PreAnswer : PlivoElement
    {
        public PreAnswer()
            : base()
        {
            Nestables = new list()
            {   "Play", "Speak", "GetDigits", "Wait", "Redirect", "Message", "DTMF"
            };
            ValidAttributes = new list() { "" };
        }
    }
}
