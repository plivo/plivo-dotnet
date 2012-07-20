using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Plivo.XML
{
    public class PlivoException : Exception
    {
        public PlivoException(string message) : base(message) { }
    }

    public abstract class PlivoElement
    {
        protected List<string> Nestables { get; set; }
        protected List<string> ValidAttributes { get; set; }
        protected XElement Element { get; set; }
        protected Dictionary<string, string> Attributes { get; set; }

        public PlivoElement(string body, Dictionary<string, string> attributes)
        {
            Element = new XElement(this.GetType().Name, body);
            Attributes = attributes;
        }

        public PlivoElement(Dictionary<string, string> attributes)
        {
            Element = new XElement(this.GetType().Name);
            Attributes = attributes;
        }

        public PlivoElement(string body)
        {
            Element = new XElement(this.GetType().Name, body);
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
                default: val = value.ToLower();
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
                return this;
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
            return Add(new Record("", parameters));
        }

        public PlivoElement AddDial(Dictionary<string, string> parameters)
        {
            return Add(new Dial(parameters));
        }

        public PlivoElement AddNumber(string body, Dictionary<string, string> parameters)
        {
            return Add(new Number(body, parameters));
        }

        public PlivoElement AddUser(string body, Dictionary<string, string> parameters)
        {
            return Add(new User(body, parameters));
        }

        public PlivoElement AddRedirect(string body, Dictionary<string, string> parameters)
        {
            return Add(new Redirect(body, parameters));
        }

        public PlivoElement AddWait(string body, Dictionary<string, string> parameters)
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
            return Add(new Conference(body, parameters));
        }

        public PlivoElement AddMessage(string body, Dictionary<string, string> parameters)
        {
            return Add(new Message(body, parameters));
        }

        public PlivoElement AddDTMF(string body)
        {
            return Add(new DTMF(body));
        }

        public override string ToString()
        {
            return SerializeToXML().ToString();
        }

        public XDocument SerializeToXML()
        {
            return new XDocument(Element);
        }

    }

    public class Response : PlivoElement
    {
        public Response()
            : base()
        {
            Nestables = new List<string>()
            {   "Speak", "Play", "GetDigits", "Record", "Dial", "Message", "Redirect",
                "Wait", "Hangup", "PreAnswer", "Conference", "DTMF"
            };
            ValidAttributes = new List<string>() { "" };
        }
    }

    public class Dial : PlivoElement
    {
        public Dial(Dictionary<string, string> parameters)
            : base(parameters)
        {
            Nestables = new List<string>() 
            {   "Number", "User" 
            };
            ValidAttributes = new List<string>() 
            {   "action", "method", "hangupOnStar", "timeLimit", "timeout", "callerId",
                "callerName", "confirmSound", "confirmKey", "dialMusic", "callbackUrl", 
                "callbackMethod", "redirect", "digitsMatch", "sipHeaders" 
            };
            addAttributes();
        }
    }

    public class Number : PlivoElement
    {
        public Number(string body, Dictionary<string, string> parameters)
            : base(body, parameters)
        {
            Nestables = new List<string>() { "" };
            ValidAttributes = new List<string>()
            {   "sendDigits", "sendOnPreAnswer"
            };
            addAttributes();
        }
    }

    public class User : PlivoElement
    {
        public User(string body, Dictionary<string, string> parameters)
            : base(body, parameters)
        {
            Nestables = new List<string>() { "" };
            ValidAttributes = new List<string>()
            {   "sendDigits","sendOnPreAnswer", "sipHeaders"
            };
            addAttributes();
        }
    }

    public class Conference : PlivoElement
    {
        public Conference(string body, Dictionary<string, string> parameters)
            : base(body, parameters)
        {
            Nestables = new List<string>() { "" };
            ValidAttributes = new List<string>()
            {   "sendDigits", "muted", "enterSound", "exitSound", "startConferenceOnEnter", 
                "endConferenceOnExit", "stayAlone", "waitSound", "maxMembers", "timeLimit", 
                "hangupOnStar", "action", "method", "callbackUrl", "callbackMethod", "digitsMatch",
                "floorEvent", "redirect"
            };
            addAttributes();
        }
    }

    public class GetDigits : PlivoElement
    {
        public GetDigits(string body, Dictionary<string, string> parameters)
            : base(body, parameters)
        {
            Nestables = new List<string>()
            {   "Speak", "Play", "Wait"
            };
            ValidAttributes = new List<string>()
            {   "action", "method", "timeout", "finishOnKey", "numDigits", "retries",
                "invalidDigitsSound", "validDigits", "playBeep", "redirect"
            };
            addAttributes();
        }
    }

    public class Speak : PlivoElement
    {
        public Speak(string body, Dictionary<string, string> attributes)
            : base(body, attributes)
        {
            Nestables = new List<string>() { "" };
            ValidAttributes = new List<string>()
            {   "loop", "language", "voice" 
            };
            addAttributes();
        }
    }

    public class Play : PlivoElement
    {
        public Play(string body, Dictionary<string, string> attributes)
            : base(body, attributes)
        {
            Nestables = new List<string>() { "" };
            ValidAttributes = new List<string>()
            {   "loop"
            };
            addAttributes();
        }
    }

    public class Wait : PlivoElement
    {
        public Wait(Dictionary<string, string> attributes)
            : base(attributes)
        {
            Nestables = new List<string>() { "" };
            ValidAttributes = new List<string>()
            {   "length"
            };
            addAttributes();
        }
    }

    public class Redirect : PlivoElement
    {
        public Redirect(string body, Dictionary<string, string> attributes)
            : base(body, attributes)
        {
            Nestables = new List<string>() { "" };
            ValidAttributes = new List<string>()
            {   "method"
            };
            addAttributes();
        }
    }

    public class Hangup : PlivoElement
    {
        public Hangup(Dictionary<string, string> attributes)
            : base(attributes)
        {
            Nestables = new List<string>() { "" };
            ValidAttributes = new List<string>()
            {   "schedule", "reason"
            };
            addAttributes();
        }
    }

    public class Record : PlivoElement
    {
        public Record(string body, Dictionary<string, string> attributes)
            : base(body, attributes)
        {
            Nestables = new List<string>() { "" };
            ValidAttributes = new List<string>()
            {   "action", "method", "timeout", "finishOnKey", "maxLength", "playBeep",
                "recordSession", "startOnDialAnswer", "redirect", "fileFormat"
            };
            addAttributes();
        }
    }

    public class PreAnswer : PlivoElement
    {
        public PreAnswer()
            : base()
        {
            Nestables = new List<string>()
            {   "Play", "Speak", "GetDigits", "Wait", "Redirect", "Message", "DTMF"
            };
            ValidAttributes = new List<string>() { "" };
        }
    }

    public class Message : PlivoElement
    {
        public Message(string body, Dictionary<string, string> attributes)
            : base(body, attributes)
        {
            Nestables = new List<string>(){ "" };
            ValidAttributes = new List<string>()
            {   "src", "dst", "type", "callbackUrl", "callbackMethod"
            };
            addAttributes();
        }
    }

    public class DTMF : PlivoElement
    {
        public DTMF(string body)
            : base(body)
        {
            Nestables = new List<string>() { "" };
            ValidAttributes = new List<string>() { "" };
        }
    }
}