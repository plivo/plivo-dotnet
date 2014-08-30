using System.Collections.Generic;

namespace Plivo.XML
{
    public class GetDigits : PlivoElement
    {
        public GetDigits(string body, Dictionary<string, string> parameters)
            : base(body, parameters)
        {
            Nestables = new List<string>()
                {   "Speak", "Play", "Wait"
                };
            ValidAttributes = new List<string>()
                {   "action", "method", "timeout", "digitTimeout","finishOnKey", "numDigits",
                    "retries", "invalidDigitsSound", "validDigits", "playBeep", "redirect", "log"
                };
            addAttributes();
        }
    }
}