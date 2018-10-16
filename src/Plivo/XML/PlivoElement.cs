using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;
using Plivo.Exception;
using Plivo.Utilities;
using dict = System.Collections.Generic.Dictionary<string, string>;
using list = System.Collections.Generic.List<string>;

namespace Plivo.XML
{
    public abstract class PlivoElement
    {
        protected list Nestables { get; set; }
        protected list ValidAttributes { get; set; }
        protected XElement Element { get; set; }
        protected dict Attributes { get; set; }

        public PlivoElement(string body, dict attributes)
        {
            Element = new XElement(GetType().Name, HtmlEntity.Convert(body));
            Attributes = attributes;
        }

        public PlivoElement(dict attributes)
        {
            Element = new XElement(GetType().Name);
            Attributes = attributes;
        }

        public PlivoElement(string body)
        {
            Element = new XElement(GetType().Name, HtmlEntity.Convert(body));
        }

        public PlivoElement()
        {
            Element = new XElement(GetType().Name);
        }

        protected void addAttributes()
        {
            foreach (KeyValuePair<string, string> kvp in Attributes)
            {
                string key = kvp.Key;
                string val = kvp.Value;
                int posn = ValidAttributes.FindIndex(k => k == key);
                if (posn >= 0)
                    Element.SetAttributeValue(key, _convert_values(val));
                else
                    throw new PlivoXMLException($"Invalid attribute {key} for {GetType().Name}");
            }
        }

        private string _convert_values(string value)
        {
            string val = "";
            switch (value.ToLower())
            {
                case "true":
                    val = value.ToLower();
                    break;
                case "false":
                    val = value.ToLower();
                    break;
                case "get":
                    val = value.ToUpper();
                    break;
                case "post":
                    val = value.ToUpper();
                    break;
                case "man":
                    val = value.ToUpper();
                    break;
                case "woman":
                    val = value.ToUpper();
                    break;
                default:
                    val = value;
                    break;
            }

            return val;
        }

        public PlivoElement Add(PlivoElement element)
        {
            int posn = Nestables.FindIndex(n => n == element.GetType().Name);
            if (posn >= 0)
            {
                Element.Add(element.Element);
                return element;
            }
            else
                throw new PlivoXMLException(
                    $"Element {element.GetType().Name} cannot be nested within {GetType().Name}");
        }

        public PlivoElement AddSpeak(string body, dict parameters)
        {
            return Add(new Speak(body, parameters));
        }

        public PlivoElement AddBreak(dict parameters)
        {
            PlivoElement elem = new Break(parameters);
            elem.Element.Name = "break";
            return Add(elem);

        }

        public PlivoElement AddEmphasis(string body, dict parameters)
        {
            PlivoElement elem = new Emphasis(body, parameters);
            elem.Element.Name = "emphasis";
            return Add(elem);
        }

        public PlivoElement AddLang(string body, dict parameters)
        {
            PlivoElement elem = new Lang(body, parameters);
            elem.Element.Name = "lang";

            var oldAttribute = elem.Element.Attribute("xmllang");
            var attributeList = elem.Element.Attributes().ToList();
            XAttribute newAttribute = new XAttribute(XNamespace.Xml + "lang", oldAttribute.Value);
            attributeList.Add(newAttribute);
            attributeList.Remove(oldAttribute);
            elem.Element.ReplaceAttributes(attributeList);

            return Add(elem);
        }

        public PlivoElement AddP(string body)
        {
            PlivoElement elem = new P(body);
            elem.Element.Name = "p";
            return Add(elem);
        }

        public PlivoElement AddPhoneme(string body, dict parameters)
        {
            PlivoElement elem = new Phoneme(body, parameters);
            elem.Element.Name = "phoneme";
            return Add(elem);
        }

        public PlivoElement AddProsody(string body, dict parameters)
        {
            PlivoElement elem = new Prosody(body, parameters);
            elem.Element.Name = "prosody";
            return Add(elem);
        }

        public PlivoElement AddS(string body)
        {
            PlivoElement elem = new S(body);
            elem.Element.Name = "s";
            return Add(elem);
        }

        public PlivoElement AddSayAs(string body, dict parameters)
        {
            PlivoElement elem = new SayAs(body, parameters);
            elem.Element.Name = "say-as";
            return Add(elem);
        }

        public PlivoElement AddSub(string body, dict parameters)
        {
            PlivoElement elem = new Sub(body, parameters);
            elem.Element.Name = "sub";
            return Add(elem);
        }

        public PlivoElement AddW(string body, dict parameters)
        {
            PlivoElement elem = new W(body, parameters);
            elem.Element.Name = "w";
            return Add(elem);
        }

        public PlivoElement AddPlay(string body, dict parameters)
        {
            return Add(new Play(body, parameters));
        }

        public PlivoElement AddGetDigits(dict parameters)
        {
            return Add(new GetDigits("", parameters));
        }

        public PlivoElement AddRecord(dict parameters)
        {
            return Add(new Record(parameters));
        }

        public PlivoElement AddDial(dict parameters)
        {
            return Add(new Dial(parameters));
        }

        public PlivoElement AddNumber(string body, dict parameters)
        {
            return Add(new Number(body, parameters));
        }

        public PlivoElement AddUser(string body, dict parameters)
        {
            return Add(new User(body, parameters));
        }

        public PlivoElement AddRedirect(string body, dict parameters)
        {
            return Add(new Redirect(body, parameters));
        }

        public PlivoElement AddWait(dict parameters)
        {
            return Add(new Wait(parameters));
        }

        public PlivoElement AddHangup(dict parameters)
        {
            return Add(new Hangup(parameters));
        }

        public PlivoElement AddPreAnswer()
        {
            return Add(new PreAnswer());
        }

        public PlivoElement AddConference(string body, dict parameters)
        {
            return Add(new Conference(body, parameters));
        }

        public PlivoElement AddMessage(string body, dict parameters)
        {
            return Add(new Message(body, parameters));
        }

        public PlivoElement AddDTMF(string body, dict attributes)
        {
            return Add(new DTMF(body, attributes));
        }

        public override string ToString()
        {
            return SerializeToXML().ToString().Replace("&amp;", "&");
        }

        protected XDocument SerializeToXML()
        {
            return new XDocument(new XDeclaration("1.0", "utf-8", "yes"), Element);
        }
    }
}