using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Plivo.Util;
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

        public PlivoElement(string body)
        {
            Element = new XElement(this.GetType().Name, HtmlEntity.Convert(body));
        }

        public PlivoElement()
        {
            Element = new XElement(this.GetType().Name);
        }

        protected void Set(string key, int val)
        {
            Set(key,val.ToString());
        }
        protected void Set(string key, bool val)
        {
            Set(key, val.ToString());
        }

        protected void Set(string key, string val)
        {
            int posn = ValidAttributes.FindIndex(k => k == key);
            if (posn >= 0)
                Element.SetAttributeValue(key,val);
            else
                throw new PlivoException(String.Format("Invalid attribute {0} for {1}", key, this.GetType().Name));
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
        public Dial()
            : base()
        {
            Nestables = new list() 
            {   "Number", "User" 
            };
            ValidAttributes = new list() 
            {   "action", "method", "hangupOnStar", "timeLimit", "timeout", "callerId",
                "callerName", "confirmSound", "confirmKey", "dialMusic", "callbackUrl", 
                "callbackMethod", "redirect", "digitsMatch", "sipHeaders" 
            };
        }
        public void SetAction(string action)
        {
            this.Set("action", action);
        }
        public void SetMethod(string method)
        {
            this.Set("method", method);
        }
        public void SetHangupOnStar(bool hangupOnStar)
        {
            this.Set("hangupOnStar", hangupOnStar);
        }
        public void SetTimeLimit(int timeLimit)
        {
            this.Set("timeLimit", timeLimit);
        }
        public void SetTimeout(int timeout)
        {
            this.Set("timeout", timeout);
        }
        public void SetCallerId(string callerId)
        {
            this.Set("callerId", callerId);
        }
        public void SetCallerName(string callerName)
        {
            this.Set("callerName", callerName);
        }
		public void SetConfirmSound(string confirmSound)
        {
            this.Set("confirmSound", confirmSound);
        }
		public void SetConfirmKey(string confirmKey)
        {
            this.Set("confirmKey", confirmKey);
        }
		public void SetDialMusic(string dialMusic)
        {
            this.Set("dialMusic", dialMusic);
        }
		public void SetCallbackUrl(string callbackUrl)
        {
            this.Set("callbackUrl", callbackUrl);
        }
		public void SetRedirect(bool redirect)
        {
            this.Set("redirect", redirect);
        }
		public void SetDigitsMatch(string digitsMatch)
        {
            this.Set("digitsMatch", digitsMatch);
        }
		public void SetSipHeaders(string sipHeaders)
        {
            this.Set("sipHeaders", sipHeaders);
        }
    }

    public class Number : PlivoElement
    {
        public Number(string body)
            : base(body)
        {
            Nestables = new list() { "" };
            ValidAttributes = new list()
            {   "sendDigits", "sendOnPreAnswer", "sendDigitsMode"
            };
        }
		public void SetSendDigits(string sendDigits)
        {
            this.Set("sendDigits", sendDigits);
        }
		public void SetSendOnPreAnswer(bool sendOnPreAnswer)
        {
            this.Set("sendOnPreAnswer", sendOnPreAnswer);
        }
		public void SetSendDigitsMode(string sendDigitsMode)
        {
            this.Set("sendDigitsMode", sendDigitsMode);
        }
    }

    public class User : PlivoElement
    {
        public User(string body)
            : base(body)
        {
            Nestables = new list() { "" };
            ValidAttributes = new list()
            {   "sendDigits","sendOnPreAnswer", "sipHeaders"
            };
        }
		public void SetSendDigits(string sendDigits)
        {
            this.Set("sendDigits", sendDigits);
        }
		public void SetSendOnPreAnswer(bool sendOnPreAnswer)
        {
            this.Set("sendOnPreAnswer", sendOnPreAnswer);
        }
		public void SetSipHeaders(string sipHeaders)
        {
            this.Set("sipHeaders", sipHeaders);
        }
    }

    public class Conference : PlivoElement
    {
        public Conference(string body)
            : base(body)
        {
            Nestables = new list() { "" };
            ValidAttributes = new list()
            {   "sendDigits", "muted", "enterSound", "exitSound", "startConferenceOnEnter", 
                "endConferenceOnExit", "stayAlone", "waitSound", "maxMembers", "timeLimit", 
                "hangupOnStar", "action", "method", "callbackUrl", "callbackMethod", "digitsMatch",
                "floorEvent", "redirect", "record", "recordFileFormat","recordWhenAlone", "transcriptionType", "transcriptionUrl",
                "transcriptionMethod"
            };
        }
		public void SetSendDigits(string sendDigits)
        {
            this.Set("sendDigits", sendDigits);
        }
		public void SetMuted(bool muted)
        {
            this.Set("muted", muted);
        }
		public void SetEnterSound(string enterSound)
        {
            this.Set("enterSound", enterSound);
        }
		public void SetExitSound(string exitSound)
        {
            this.Set("exitSound", exitSound);
        }
		public void SetStartConferenceOnEnter(bool startConferenceOnEnter)
        {
            this.Set("startConferenceOnEnter", startConferenceOnEnter);
        }
		public void SetEndConferenceOnExit(bool endConferenceOnExit)
        {
            this.Set("endConferenceOnExit", endConferenceOnExit);
        }
		public void SetStayAlone(bool stayAlone)
        {
            this.Set("stayAlone", stayAlone);
        }
		public void SetWaitSound(string waitSound)
        {
            this.Set("waitSound", waitSound);
        }
		public void SetMaxMembers(int maxMembers)
        {
            this.Set("maxMembers", maxMembers);
        }
		public void SetTimeLimit(int timeLimit)
        {
            this.Set("timeLimit", timeLimit);
        }
		public void SetHangupOnStar(bool hangupOnStar)
        {
            this.Set("hangupOnStar", hangupOnStar);
        }
		public void SetAction(string action)
        {
            this.Set("action", action);
        }
		public void SetMethod(string method)
        {
            this.Set("method", method);
        }
		public void SetCallbackUrl(string callbackUrl)
        {
            this.Set("callbackUrl", callbackUrl);
        }
		public void SetCallbackMethod(string callbackMethod)
        {
            this.Set("callbackMethod", callbackMethod);
        }
		public void SetDigitsMatch(string digitsMatch)
        {
            this.Set("digitsMatch", digitsMatch);
        }
		public void SetFloorEvent(bool floorEvent)
        {
            this.Set("floorEvent", floorEvent);
        }
		public void SetRedirect(bool redirect)
        {
            this.Set("redirect", redirect);
        }
		public void SetRecord(bool record)
        {
            this.Set("record", record);
        }
		public void SetRecordFileFormat(string recordFileFormat)
        {
            this.Set("recordFileFormat", recordFileFormat);
        }
		public void SetRecordWhenAlone(string recordWhenAlone)
        {
            this.Set("recordWhenAlone", recordWhenAlone);
        }
		public void SetTranscriptionType(string transcriptionType)
        {
            this.Set("transcriptionType", transcriptionType);
        }
		public void SetTranscriptionUrl(string transcriptionUrl)
        {
            this.Set("transcriptionUrl", transcriptionUrl);
        }
		public void SetTranscriptionMethod(string transcriptionMethod)
        {
            this.Set("transcriptionMethod", transcriptionMethod);
        }
    }

    public class GetDigits : PlivoElement
    {
        public GetDigits()
            : base()
        {
            Nestables = new list()
            {   "Speak", "Play", "Wait"
            };
            ValidAttributes = new list()
            {   "action", "method", "timeout", "digitTimeout","finishOnKey", "numDigits", 
                "retries", "invalidDigitsSound", "validDigits", "playBeep", "redirect"
            };
        }
		public void SetAction(string action)
        {
            this.Set("action", action);
        }
		public void SetMethod(string method)
        {
            this.Set("method", method);
        }
		public void SetTimeout(int timeout)
        {
            this.Set("timeout", timeout);
        }
		public void SetDigitTimeout(int digitTimeout)
        {
            this.Set("digitTimeout", digitTimeout);
        }
		public void SetFinishOnKey(string finishOnKey)
        {
            this.Set("finishOnKey", finishOnKey);
        }
		public void SetNumDigits(int numDigits)
        {
            this.Set("numDigits", numDigits);
        }
		public void SetRetries(int retries)
        {
            this.Set("retries", retries);
        }
		public void SetInvalidDigitsSound(string invalidDigitsSound)
        {
            this.Set("invalidDigitsSound", invalidDigitsSound);
        }
		public void SetValidDigits(string validDigits)
        {
            this.Set("validDigits", validDigits);
        }
		public void SetPlayBeep(bool playBeep)
        {
            this.Set("playBeep", playBeep);
        }
		public void SetRedirect(bool redirect)
        {
            this.Set("redirect", redirect);
        }
    }

    public class Speak : PlivoElement
    {
        public Speak(string body)
            : base(body)
        {
            Nestables = new list() { "" };
            ValidAttributes = new list()
            {   "loop", "language", "voice" 
            };
        }
		public void SetLoop(int loop)
        {
            this.Set("loop", loop);
        }
		public void SetLanguage(string language)
        {
            this.Set("language", language);
        }
		public void SetVoice(string voice)
        {
            this.Set("voice", voice);
        }
    }

    public class Play : PlivoElement
    {
        public Play(string body)
            : base(body)
        {
            Nestables = new list() { "" };
            ValidAttributes = new list()
            {   "loop"
            };
        }
		public void SetLoop(int loop)
        {
            this.Set("loop", loop);
        }
    }

    public class Wait : PlivoElement
    {
        public Wait()
            : base()
        {
            Nestables = new list() { "" };
            ValidAttributes = new list()
            {   "length", "silence", "minSilence"
            };
        }
		public void SetLength(int length)
        {
            this.Set("length", length);
        }
		public void SetSilence(bool silence)
        {
            this.Set("silence", silence);
        }
        public void SetMinSilence(int minSilence)
        {
            this.Set("minSilence", minSilence);
        }
    }

    public class Redirect : PlivoElement
    {
        public Redirect(string body)
            : base(body)
        {
            Nestables = new list() { "" };
            ValidAttributes = new list()
            {   "method"
            };
        }
		public void SetMethod(string method)
        {
            this.Set("method", method);
        }
    }

    public class Hangup : PlivoElement
    {
        public Hangup()
            : base()
        {
            Nestables = new list() { "" };
            ValidAttributes = new list()
            {   "schedule", "reason"
            };
        }
		public void SetSchedule(int schedule)
        {
            this.Set("schedule", schedule);
        }
		public void SetReason(string reason)
        {
            this.Set("reason", reason);
        }
    }

    public class Record : PlivoElement
    {
        public Record()
            : base()
        {
            Nestables = new list() { "" };
            ValidAttributes = new list()
            {   "action", "method", "timeout", "finishOnKey", "maxLength", "playBeep",
                "recordSession", "startOnDialAnswer", "redirect", "fileFormat",
                "callbackUrl", "callbackMethod", "transcriptionType", "transcriptionUrl",
                "transcriptionMethod"
            };
        }
		public void SetAction(string action)
        {
            this.Set("action", action);
        }
		public void SetMethod(string method)
        {
            this.Set("method", method);
        }
		public void SetTimeout(int timeout)
        {
            this.Set("timeout", timeout);
        }
		public void SetFinishOnKey(string finishOnKey)
        {
            this.Set("finishOnKey", finishOnKey);
        }
		public void SetMaxLength(int maxLength)
        {
            this.Set("maxLength", maxLength);
        }
		public void SetPlayBeep(bool playBeep)
        {
            this.Set("playBeep", playBeep);
        }
		public void SetRecordSession(bool recordSession)
        {
            this.Set("recordSession", recordSession);
        }
		public void SetStartOnDialAnswer(bool startOnDialAnswer)
        {
            this.Set("startOnDialAnswer", startOnDialAnswer);
        }
		public void SetRedirect(bool redirect)
        {
            this.Set("redirect", redirect);
        }
		public void SetFileFormat(string fileFormat)
        {
            this.Set("fileFormat", fileFormat);
        }
		public void SetCallbackUrl(string callbackUrl)
        {
            this.Set("callbackUrl", callbackUrl);
        }
		public void SetCallbackMethod(string callbackMethod)
        {
            this.Set("callbackMethod", callbackMethod);
        }
		public void SetTranscriptionType(string transcriptionType)
        {
            this.Set("transcriptionType", transcriptionType);
        }
		public void SetTranscriptionUrl(string transcriptionUrl)
        {
            this.Set("transcriptionUrl", transcriptionUrl);
        }
		public void SetTranscriptionMethod(string transcriptionMethod)
        {
            this.Set("transcriptionMethod", transcriptionMethod);
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
        public Message(string body)
            : base(body)
        {
            Nestables = new list() { "" };
            ValidAttributes = new list()
            {   "src", "dst", "type", "callbackUrl", "callbackMethod"
            };
        }
		public void SetSource(string src)
        {
            this.Set("src", src);
        }
		public void SetDestination(string dst)
        {
            this.Set("dst", dst);
        }
		public void SetType(string type)
        {
            this.Set("type", type);
        }
		public void SetCallbackUrl(string callbackUrl)
        {
            this.Set("callbackUrl", callbackUrl);
        }
		public void SetCallbackMethod(string callbackMethod)
        {
            this.Set("callbackMethod", callbackMethod);
        }
    }

    public class DTMF : PlivoElement
    {
        public DTMF(string body)
            : base(body)
        {
            Nestables = new list() { "" };
            ValidAttributes = new list() { "" };
        }
    }
}
