using System.Collections.Generic;

namespace Plivo.XML
{
    public class PreAnswer : PlivoElement
    {
        public PreAnswer()
            : base()
        {
            Nestables = new List<string>()
                {   "Play", "Speak", "GetDigits", "Wait", "Redirect", "Message", "DTMF"
                };
            ValidAttributes = new List<string>() { "" };
        }
    }
}