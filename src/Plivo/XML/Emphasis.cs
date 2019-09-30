using dict = System.Collections.Generic.Dictionary<string, string>;
using list = System.Collections.Generic.List<string>;

namespace Plivo.XML
{
    public class Emphasis : PlivoElement
    {
        public Emphasis(string body, dict parameters)
            : base(body, parameters)
        {
            Nestables = new list()
            {
                "Break",
                "Cont",
                "Emphasis",
                "Lang",
                "Phoneme",
                "Prosody",
                "SayAs",
                "Sub",
                "W"
            };
            ValidAttributes = new list()
            {
                "level"
            };
            addAttributes();
            Element.Name = GetType().Name.ToLower();
        }
    }
}