using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Plivo.Util;
using dict = System.Collections.Generic.Dictionary<string, string>;
using list = System.Collections.Generic.List<string>;

namespace Plivo.XML
{
    public class PlivoException : Exception
    {
        public PlivoException(string message) : base(message) { }
    }

    public abstract class PlivoElement
    {
        protected list Nestables { get; set; }
        protected list ValidAttributes { get; set; }
        protected XElement Element { get; set; }
        protected dict Attributes { get; set; }

        public PlivoElement(string body, dict attributes)
        {
            Element = new XElement(this.GetType().Name, HtmlEntity.Convert(body));
            Attributes = attributes;
        }

        public PlivoElement(dict attributes)
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

        public PlivoElement AddSpeak(string body, dict parameters)
        {
            return Add(new Speak(body, parameters));
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

    public class Response : PlivoElement
    {
        public Response()
            : base()
        {
            Nestables = new list()
            {   "Speak", "Play", "GetDigits", "Record", "Dial", "Message", "Redirect",
                "Wait", "Hangup", "PreAnswer", "Conference", "DTMF"
            };
            ValidAttributes = new list() { "" };
        }
    }

    public class Dial : PlivoElement
    {
        public Dial(dict parameters)
            : base(parameters)
        {
            Nestables = new list()
            {   "Number", "User"
            };
            ValidAttributes = new list()
            {   "action", "method", "hangupOnStar", "timeLimit", "timeout", "callerId",
                "callerName", "confirmSound", "confirmKey", "dialMusic", "callbackUrl",
                "callbackMethod", "redirect", "digitsMatch", "digitsMatchBLeg", "sipHeaders"
            };
            addAttributes();
        }
    }

    public class Number : PlivoElement
    {
        public Number(string body, dict parameters)
            : base(body, parameters)
        {
            Nestables = new list() { "" };
            ValidAttributes = new list()
            {   "sendDigits", "sendOnPreAnswer", "sendDigitsMode"
            };
            addAttributes();
        }
    }

    public class User : PlivoElement
    {
        public User(string body, dict parameters)
            : base(body, parameters)
        {
            Nestables = new list() { "" };
            ValidAttributes = new list()
            {   "sendDigits","sendOnPreAnswer", "sipHeaders"
            };
            addAttributes();
        }
    }

    public class Conference : PlivoElement
    {
        public Conference(string body, dict parameters)
            : base(body, parameters)
        {
            Nestables = new list() { "" };
            ValidAttributes = new list()
            {   "sendDigits", "muted", "enterSound", "exitSound", "startConferenceOnEnter",
                "endConferenceOnExit", "stayAlone", "waitSound", "maxMembers", "timeLimit",
                "hangupOnStar", "action", "method", "callbackUrl", "callbackMethod", "digitsMatch",
                "floorEvent", "redirect", "record", "recordFileFormat","recordWhenAlone", "transcriptionType", "transcriptionUrl",
                "transcriptionMethod","relayDTMF"
            };
            addAttributes();
        }
    }

    public class GetDigits : PlivoElement
    {
        public GetDigits(string body, dict parameters)
            : base(body, parameters)
        {
            Nestables = new list()
            {   "Speak", "Play", "Wait"
            };
            ValidAttributes = new list()
            {   "action", "method", "timeout", "digitTimeout","finishOnKey", "numDigits",
                "retries", "invalidDigitsSound", "validDigits", "playBeep", "redirect", "log"
            };
            addAttributes();
        }
    }

    public class Speak : PlivoElement
    {
        public Speak(string body, dict attributes)
            : base(body, attributes)
        {
            Nestables = new list() { "" };
            ValidAttributes = new list()
            {   "loop", "language", "voice"
            };
            addAttributes();
        }
    }

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

    public class Redirect : PlivoElement
    {
        public Redirect(string body, dict attributes)
            : base(body, attributes)
        {
            Nestables = new list() { "" };
            ValidAttributes = new list()
            {   "method"
            };
            addAttributes();
        }
    }

    public class Hangup : PlivoElement
    {
        public Hangup(dict attributes)
            : base(attributes)
        {
            Nestables = new list() { "" };
            ValidAttributes = new list()
            {   "schedule", "reason"
            };
            addAttributes();
        }
    }

    public class Record : PlivoElement
    {
        public Record(dict attributes)
            : base(attributes)
        {
            Nestables = new list() { "" };
            ValidAttributes = new list()
            {   "action", "method", "timeout", "finishOnKey", "maxLength", "playBeep",
                "recordSession", "startOnDialAnswer", "redirect", "fileFormat",
                "callbackUrl", "callbackMethod", "transcriptionType", "transcriptionUrl",
                "transcriptionMethod"
            };
            addAttributes();
        }
    }

    public class PreAnswer : PlivoElement
    {
        public PreAnswer()
            : base()
        {
            Nestables = new list()
            {   "Play", "Speak", "GetDigits", "Wait", "Redirect", "Message", "DTMF"
            };
            ValidAttributes = new list() { "" };
        }
    }

    public class Message : PlivoElement
    {
        public Message(string body, dict attributes)
            : base(body, attributes)
        {
            Nestables = new list() { "" };
            ValidAttributes = new list()
            {   "src", "dst", "type", "callbackUrl", "callbackMethod"
            };
            addAttributes();
        }
    }

    public class DTMF : PlivoElement
    {
        public DTMF(string body, dict attributes)
            : base(body, attributes)
        {
            Nestables = new list() { "" };
            ValidAttributes = new list() { "async" };
            addAttributes();
        }
    }
}
