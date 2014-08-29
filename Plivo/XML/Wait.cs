using System.Collections.Generic;

namespace Plivo.XML
{
    public class Wait : PlivoElement
    {
        public Wait(Dictionary<string, string> attributes)
            : base(attributes)
        {
            Nestables = new List<string>() { "" };
            ValidAttributes = new List<string>()
                {   "length", "silence","minSilence"
                };
            addAttributes();
        }
    }
}