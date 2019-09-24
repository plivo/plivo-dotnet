using dict = System.Collections.Generic.Dictionary<string, string>;
using list = System.Collections.Generic.List<string>;

namespace Plivo.XML
{
    public class Phoneme : PlivoElement
    {
        public Phoneme(string body, dict parameters)
            : base(body, parameters)
        {
            Nestables = new list() {""};
            ValidAttributes = new list()
            {
                "alphabet",
                "ph"
            };
            addAttributes();
            Element.Name = GetType().Name.ToLower();
        }
    }
}