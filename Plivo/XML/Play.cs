using System.Collections.Generic;

namespace Plivo.XML
{
    public class Play : PlivoElement
    {
        public Play(string body, Dictionary<string, string> attributes)
            : base(body, attributes)
        {
            Nestables = new List<string>() { "" };
            ValidAttributes = new List<string>()
                {   "loop"
                };
            addAttributes();
        }
    }
}