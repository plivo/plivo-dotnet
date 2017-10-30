using dict = System.Collections.Generic.Dictionary<string, string>;
using list = System.Collections.Generic.List<string>;

namespace Plivo.XML
{
    public class Wait : PlivoElement
    {
        public Wait(dict attributes)
            : base(attributes)
        {
            Nestables = new list() { "" };
            ValidAttributes = new list()
            {   "length", "silence","minSilence","beep"
            };
            addAttributes();
        }
    }
}
