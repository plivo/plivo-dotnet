using dict = System.Collections.Generic.Dictionary<string, string>;
using list = System.Collections.Generic.List<string>;

namespace Plivo.XML
{
    public class SayAs : PlivoElement
    {
        public SayAs(string body, dict parameters)
            : base(body, parameters)
        {
            Nestables = new list() {""};
            ValidAttributes = new list()
            {
                "interpret-as",
                "format"
            };
            addAttributes();
            Element.Name = "say-as";
        }
    }
}