using System.Collections.Generic;

namespace Plivo.XML
{
    public class Number : PlivoElement
    {
        public Number(string body, Dictionary<string, string> parameters)
            : base(body, parameters)
        {
            Nestables = new List<string>() { "" };
            ValidAttributes = new List<string>()
                {   "sendDigits", "sendOnPreAnswer", "sendDigitsMode"
                };
            addAttributes();
        }
    }
}