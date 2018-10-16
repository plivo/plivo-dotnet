using dict = System.Collections.Generic.Dictionary<string, string>;
using list = System.Collections.Generic.List<string>;

namespace Plivo.XML
{
    public class W : PlivoElement
    {
        public W(string body, dict parameters)
            : base(body, parameters)
        {
            Nestables = new list() {
                "Break",
                "Emphasis",
                "Phoneme",
                "Prosody",
                "SayAs",
                "Sub"
            };
            ValidAttributes = new list()
            {
                "role",
            };
            addAttributes();
        }
    }
}