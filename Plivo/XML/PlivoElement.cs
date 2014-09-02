using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Plivo.Exceptions;
using Plivo.Utility;

namespace Plivo.XML
{
    public abstract class PlivoElement
    {
        protected List<string> Nestables { get; set; }
        protected List<string> ValidAttributes { get; set; }
        protected XElement Element { get; set; }
        protected Dictionary<string, string> Attributes { get; set; }

        public PlivoElement(string body, Dictionary<string, string> attributes)
        {
            Element = new XElement(this.GetType().Name, HtmlEntity.Convert(body));
            Attributes = attributes;
        }

        public PlivoElement(Dictionary<string, string> attributes)
        {
            Element = new XElement(this.GetType().Name);
            Attributes = attributes;
        }

        public PlivoElement(string body)
        {
            Element = new XElement(this.GetType().Name, HtmlEntity.Convert(body));
        }

        public PlivoElement()
        {
            Element = new XElement(this.GetType().Name);
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
                    throw new PlivoException(String.Format("Invalid attribute {0} for {1}", key, this.GetType().Name));
            }
        }

        private string _convert_values(string value)
        {
            string val = "";
            switch (value.ToLower())
            {
                case "true": val = value.ToLower();
                    break;
                case "false": val = value.ToLower();
                    break;
                case "get": val = value.ToUpper();
                    break;
                case "post": val = value.ToUpper();
                    break;
                case "man": val = value.ToUpper();
                    break;
                case "woman": val = value.ToUpper();
                    break;
                default: val = value;
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
                throw new PlivoException(String.Format("Element {0} cannot be nested within {1}", element.GetType().Name, this.GetType().Name));
        }

        public PlivoElement AddSpeak(string body, Dictionary<string, string> parameters)
        {
            return Add(new Speak(body, parameters));
        }

        public PlivoElement AddPlay(string body, Dictionary<string, string> parameters)
        {
            return Add(new Play(body, parameters));
        }

        public PlivoElement AddGetDigits(Dictionary<string, string> parameters)
        {
            return Add(new GetDigits("", parameters));
        }

        public PlivoElement AddRecord(Dictionary<string, string> parameters)
        {
            return Add(new XML.Record(parameters));
        }

        public PlivoElement AddDial(Dictionary<string, string> parameters)
        {
            return Add(new Dial(parameters));
        }

        public PlivoElement AddNumber(string body, Dictionary<string, string> parameters)
        {
            return Add(new XML.Number(body, parameters));
        }

        public PlivoElement AddUser(string body, Dictionary<string, string> parameters)
        {
            return Add(new User(body, parameters));
        }

        public PlivoElement AddRedirect(string body, Dictionary<string, string> parameters)
        {
            return Add(new Redirect(body, parameters));
        }

        public PlivoElement AddWait(Dictionary<string, string> parameters)
        {
            return Add(new Wait(parameters));
        }

        public PlivoElement AddHangup(Dictionary<string, string> parameters)
        {
            return Add(new Hangup(parameters));
        }

        public PlivoElement AddPreAnswer()
        {
            return Add(new PreAnswer());
        }

        public PlivoElement AddConference(string body, Dictionary<string, string> parameters)
        {
            return Add(new XML.Conference(body, parameters));
        }

        public PlivoElement AddMessage(string body, Dictionary<string, string> parameters)
        {
            return Add(new XML.Message(body, parameters));
        }

        public PlivoElement AddDTMF(string body, Dictionary<string, string> attributes)
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