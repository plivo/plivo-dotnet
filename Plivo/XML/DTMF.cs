using System.Collections.Generic;

namespace Plivo.XML
{
    public class DTMF : PlivoElement
    {
        public DTMF(string body, Dictionary<string, string> attributes)
            : base(body, attributes)
        {
            Nestables = new List<string>() { "" };
            ValidAttributes = new List<string>() { "async" };
            addAttributes();
        }
    }
}