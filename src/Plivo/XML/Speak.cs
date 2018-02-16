using dict = System.Collections.Generic.Dictionary<string, string>;
using list = System.Collections.Generic.List<string>;

namespace Plivo.XML
{
    public class Speak : PlivoElement
    {
        public Speak(string body, dict attributes)
            : base(body, attributes)
        {
            Nestables = new list() {""};
            ValidAttributes = new list()
            {
                "loop",
                "language",
                "voice"
            };
            addAttributes();
        }
    }
}