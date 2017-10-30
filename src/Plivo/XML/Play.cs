using dict = System.Collections.Generic.Dictionary<string, string>;
using list = System.Collections.Generic.List<string>;

namespace Plivo.XML
{
    public class Play : PlivoElement
    {
        public Play(string body, dict attributes)
            : base(body, attributes)
        {
            Nestables = new list() { "" };
            ValidAttributes = new list()
            {   "loop"
            };
            addAttributes();
        }
    }
}
