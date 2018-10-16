using dict = System.Collections.Generic.Dictionary<string, string>;
using list = System.Collections.Generic.List<string>;

namespace Plivo.XML
{
    public class Prosody : PlivoElement
    {
        public Prosody(string body, dict parameters)
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
                "volume",
                "rate",
                "pitch"
            };
            addAttributes();
        }
    }
}