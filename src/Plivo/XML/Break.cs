using dict = System.Collections.Generic.Dictionary<string, string>;
using list = System.Collections.Generic.List<string>;

namespace Plivo.XML
{
    public class Break : PlivoElement
    {
        public Break(dict parameters): base(parameters)
        {
            Nestables = new list() { "" };
            ValidAttributes = new list()
            {
                "strength",
                "time",
            };
            addAttributes();
            Element.Name = GetType().Name.ToLower();
        }
    }
}