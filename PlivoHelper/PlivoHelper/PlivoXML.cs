using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Plivo.XML
{
    public class PlivoException : InvalidOperationException
    {
        public PlivoException(string message) : base(message) { }
    }

    public abstract class PlivoElement
    {
        public List<string> Nestables { get; set; }
        public List<string> ValidAttributes { get; set; }
        protected XElement Element { get; set; }
        protected Dictionary<string, string> Attributes { get; set; }
        protected string Name { get; set; }

        public PlivoElement(string body, Dictionary<string, string> attributes)
        {
            Name = this.GetType().Name;
            Element = new XElement(Name, body);
            Attributes = attributes;   
        }

        public PlivoElement(Dictionary<string, string> attributes)
        {
            Name = this.GetType().Name;
            Element = new XElement(Name);
            Attributes = attributes;   
        }

        public PlivoElement(string body)
        {
            Name = this.GetType().Name;
            Element = new XElement(Name, body);
        }

        public PlivoElement()
        {
            Name = this.GetType().Name;
            Element = new XElement(Name);
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
                    throw new PlivoException(String.Format("Invalid attribute {0} for {1}", key, Name));
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
            int posn = Nestables.FindIndex(n => n == element.Name);
            if (posn >= 0)
            {
                Element.Add(element.Element);
                return this;
            }
            else
                throw new PlivoException(String.Format("Element {0} cannot be nested within {1}", element.Name, Name));
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
            Nestables = new List<string>();
            Nestables.Add("Speak");
            Nestables.Add("Play");
            Nestables.Add("GetDigits");
            Nestables.Add("Record");
            Nestables.Add("Dial");
            Nestables.Add("Message");
            Nestables.Add("Redirect");
            Nestables.Add("Wait");
            Nestables.Add("Hangup");
            Nestables.Add("PreAnswer");
            Nestables.Add("Conference");
            Nestables.Add("DTMF");
            ValidAttributes = new List<string>();
            ValidAttributes.Add("");
        }
    }    

    public class Dial : PlivoElement
    {
        public Dial(Dictionary<string, string> parameters)
            : base(parameters)
        {
            Nestables = new List<string>();
            Nestables.Add("Number");
            Nestables.Add("User");
            ValidAttributes = new List<string>();
            ValidAttributes.Add("action");
            ValidAttributes.Add("method");
            ValidAttributes.Add("hangupOnStar");
            ValidAttributes.Add("timeLimit");
            ValidAttributes.Add("timeout");
            ValidAttributes.Add("callerId");
            ValidAttributes.Add("callerName");
            ValidAttributes.Add("confirmSound");
            ValidAttributes.Add("confirmKey");
            ValidAttributes.Add("dialMusic");
            ValidAttributes.Add("callbackUrl");
            ValidAttributes.Add("callbackMethod");
            ValidAttributes.Add("redirect");
            ValidAttributes.Add("digitsMatch");
            ValidAttributes.Add("sipHeaders");
            addAttributes();
        }
    }

    public class Number : PlivoElement
    {
        public Number(string body, Dictionary<string, string> parameters)
            : base(body, parameters)
        {
            Nestables = new List<string>();
            Nestables.Add("");
            ValidAttributes = new List<string>();
            ValidAttributes.Add("sendDigits");
            ValidAttributes.Add("sendOnPreAnswer");
            addAttributes();
        }
    }

    public class User : PlivoElement
    {
        public User(string body, Dictionary<string, string> parameters)
            : base(body, parameters)
        {
            Nestables = new List<string>();
            Nestables.Add("");
            ValidAttributes = new List<string>();
            ValidAttributes.Add("sendDigits");
            ValidAttributes.Add("sendOnPreAnswer");
            ValidAttributes.Add("sipHeaders");
            addAttributes();
        }
    }

    public class Conference : PlivoElement
    {
        public Conference(string body, Dictionary<string, string> parameters)
            : base(body, parameters)
        {
            Nestables = new List<string>();
            Nestables.Add("");
            ValidAttributes = new List<string>();
            ValidAttributes.Add("sendDigits");
            ValidAttributes.Add("muted");
            ValidAttributes.Add("enterSound");
            ValidAttributes.Add("exitSound");
            ValidAttributes.Add("startConferenceOnEnter");
            ValidAttributes.Add("endConferenceOnExit");
            ValidAttributes.Add("stayAlone");
            ValidAttributes.Add("waitSound");
            ValidAttributes.Add("maxMembers");
            ValidAttributes.Add("timeLimit");
            ValidAttributes.Add("hangupOnStar");
            ValidAttributes.Add("action");
            ValidAttributes.Add("method");
            ValidAttributes.Add("callbackUrl");
            ValidAttributes.Add("callbackMethod");
            ValidAttributes.Add("digitsMatch");
            ValidAttributes.Add("floorEvent");
            ValidAttributes.Add("redirect");
            addAttributes();
        }
    }

    public class GetDigits : PlivoElement
    {
        public GetDigits(string body, Dictionary<string, string> parameters)
            : base(body, parameters)
        {
            Nestables = new List<string>();
            Nestables.Add("Speak");
            Nestables.Add("Play");
            Nestables.Add("Wait");
            ValidAttributes = new List<string>();
            ValidAttributes.Add("action");
            ValidAttributes.Add("method");
            ValidAttributes.Add("timeout");
            ValidAttributes.Add("finishOnKey");
            ValidAttributes.Add("numDigits");
            ValidAttributes.Add("retries");
            ValidAttributes.Add("invalidDigitsSound");
            ValidAttributes.Add("validDigits");
            ValidAttributes.Add("playBeep");
            ValidAttributes.Add("redirect");
            addAttributes();
        }
    }

    public class Speak : PlivoElement
    {
        public Speak(string body, Dictionary<string, string> attributes)
            : base(body, attributes)
        {
            Nestables = new List<string>();
            Nestables.Add("");
            ValidAttributes = new List<string>();
            ValidAttributes.Add("loop");
            ValidAttributes.Add("language");
            ValidAttributes.Add("voice");
            addAttributes();
        }
    }

    public class Play : PlivoElement
    {
        public Play(string body, Dictionary<string, string> attributes)
            : base(body, attributes)
        {
            Nestables = new List<string>();
            Nestables.Add("");
            ValidAttributes = new List<string>();
            ValidAttributes.Add("loop");
            addAttributes();
        }
    }

    public class Wait : PlivoElement
    {
        public Wait(Dictionary<string, string> attributes)
            : base(attributes)
        {
            Nestables = new List<string>();
            Nestables.Add("");
            ValidAttributes = new List<string>();
            ValidAttributes.Add("length");
            addAttributes();
        }
    }

    public class Redirect : PlivoElement
    {
        public Redirect(string body, Dictionary<string, string> attributes)
            : base(body, attributes)
        {
            Nestables = new List<string>();
            Nestables.Add("");
            ValidAttributes = new List<string>();
            ValidAttributes.Add("method");
            addAttributes();
        }
    }

    public class Hangup : PlivoElement
    {
        public Hangup(Dictionary<string, string> attributes)
            : base(attributes)
        {
            Nestables = new List<string>();
            Nestables.Add("");
            ValidAttributes = new List<string>();
            ValidAttributes.Add("schedule");
            ValidAttributes.Add("reason");
            addAttributes();
        }
    }

    public class Record : PlivoElement
    {
        public Record(string body, Dictionary<string, string> attributes)
            : base(body, attributes)
        {
            Nestables = new List<string>();
            Nestables.Add("");
            ValidAttributes = new List<string>();
            ValidAttributes.Add("action");
            ValidAttributes.Add("method");
            ValidAttributes.Add("timeout");
            ValidAttributes.Add("finishOnKey");
            ValidAttributes.Add("maxLength");
            ValidAttributes.Add("playBeep");
            ValidAttributes.Add("recordSession");
            ValidAttributes.Add("startOnDialAnswer");
            ValidAttributes.Add("redirect");
            ValidAttributes.Add("fileFormat");
            addAttributes();
        }
    }

    public class PreAnswer : PlivoElement
    {
        public PreAnswer()
            : base()
        {
            Nestables = new List<string>();
            Nestables.Add("Play");
            Nestables.Add("Speak");
            Nestables.Add("GetDigits");
            Nestables.Add("Wait");
            Nestables.Add("Redirect");
            Nestables.Add("Message"); 
            Nestables.Add("DTMF'");
            ValidAttributes = new List<string>();
            ValidAttributes.Add("");
        }
    }

    public class Message : PlivoElement
    {
        public Message(string body, Dictionary<string, string> attributes)
            : base(body, attributes)
        {
            Nestables = new List<string>();
            Nestables.Add("");
            ValidAttributes = new List<string>();
            ValidAttributes.Add("src");
            ValidAttributes.Add("dst");
            ValidAttributes.Add("type");
            ValidAttributes.Add("callbackUrl");
            ValidAttributes.Add("callbackMethod");
            addAttributes();
        }
    }

    public class DTMF : PlivoElement
    {
        public DTMF(string body)
            : base(body)
        {
            Nestables = new List<string>();
            Nestables.Add("");
            ValidAttributes = new List<string>();
            ValidAttributes.Add("");
        }
    }
}
