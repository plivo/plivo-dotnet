using dict = System.Collections.Generic.Dictionary<string, string>;
using list = System.Collections.Generic.List<string>;

namespace Plivo.XML
{
    public class Sub : PlivoElement
    {
        public Sub(string body, dict parameters)
            : base(body, parameters)
        {
            Nestables = new list() {""};
            ValidAttributes = new list()
            {
                "alias",
            };
            addAttributes();
        }
    }
}