using dict = System.Collections.Generic.Dictionary<string, string>;
using list = System.Collections.Generic.List<string>;
using System.Xml.Linq;

namespace Plivo.XML
{
    public class Lang : PlivoElement
    {
        public Lang(string body, dict parameters)
            : base(body, parameters)
        {
            Nestables = new list()
            {
                "Break",
                "Emphasis",
                "Lang",
                "P",
                "Phoneme",
                "Prosody",
                "S",
                "SayAs",
                "Sub",
                "W"
            };
            ValidAttributes = new list()
            {
                "xmllang"
            };
            addAttributes();
        }
    }
}