using dict = System.Collections.Generic.Dictionary<string, string>;
using list = System.Collections.Generic.List<string>;

namespace Plivo.XML
{
    public class GetDigits : PlivoElement
    {
        public GetDigits(string body, dict parameters)
            : base(body, parameters)
        {
            Nestables = new list()
            {
                "Speak",
                "Play",
                "Wait"
            };
            ValidAttributes = new list()
            {
                "action",
                "method",
                "timeout",
                "digitTimeout",
                "finishOnKey",
                "numDigits",
                "retries",
                "invalidDigitsSound",
                "validDigits",
                "playBeep",
                "redirect",
                "log"
            };
            addAttributes();
        }
    }
}