using System.Collections.Generic;

namespace Plivo.XML
{
    public class Message : PlivoElement
    {
        public Message(string body, Dictionary<string, string> attributes)
            : base(body, attributes)
        {
            Nestables = new List<string>() { "" };
            ValidAttributes = new List<string>()
                {   "src", "dst", "type", "callbackUrl", "callbackMethod"
                };
            addAttributes();
        }
    }
}