using dict = System.Collections.Generic.Dictionary<string, string>;
using list = System.Collections.Generic.List<string>;
using System.Xml.Linq;
using System.Linq;

namespace Plivo.XML
{
    public class Cont : PlivoElement
    {
        public Cont(string body) : base(body) {}
    }
}