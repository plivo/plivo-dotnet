using System.Collections.Generic;

namespace Plivo.XML
{
    public class Hangup : PlivoElement
    {
        public Hangup(Dictionary<string, string> attributes)
            : base(attributes)
        {
            Nestables = new List<string>() { "" };
            ValidAttributes = new List<string>()
                {   "schedule", "reason"
                };
            addAttributes();
        }
    }
}