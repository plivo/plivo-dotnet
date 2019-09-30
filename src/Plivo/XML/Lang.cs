using dict = System.Collections.Generic.Dictionary<string, string>;
using list = System.Collections.Generic.List<string>;
using System.Xml.Linq;
using System.Linq;

namespace Plivo.XML
{
    public class Lang : PlivoElement
    {
        public Lang(string body, dict parameters)
            : base(body, parameters)
        {
            Nestables = new list()
            {
                "Break",
                "Cont",
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
                "xmllang"
            };
            addAttributes();
            var oldAttribute = Element.Attribute("xmllang");
            var attributeList = Element.Attributes().ToList();
            XAttribute newAttribute = new XAttribute(XNamespace.Xml + "lang", oldAttribute.Value);
            attributeList.Add(newAttribute);
            attributeList.Remove(oldAttribute);
            Element.ReplaceAttributes(attributeList);
            Element.Name = GetType().Name.ToLower();
        }
    }
}