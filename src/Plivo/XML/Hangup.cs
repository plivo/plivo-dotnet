using dict = System.Collections.Generic.Dictionary<string, string>;
using list = System.Collections.Generic.List<string>;

namespace Plivo.XML
{
    public class Hangup : PlivoElement
    {
        public Hangup(dict attributes)
            : base(attributes)
        {
            Nestables = new list() {""};
            ValidAttributes = new list()
            {
                "schedule",
                "reason"
            };
            addAttributes();
        }
    }
}