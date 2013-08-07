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
                Element.SetAttributeValue(key,val);
        }

        protected PlivoElement Add(PlivoElement element)
        {
                Element.Add(element.Element);
                return element;
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
        public Response() : base()
        {
        }
        public Speak AddSpeak(string text)
        {
            return (Speak)Add(new Speak(text));
        }
        public Play AddPlay(string url)
        {
            return (Play)Add(new Play(url));
        }
        public GetDigits AddGetDigits()
        {
            return (GetDigits) Add( new GetDigits());
        }
        public Record AddRecord()
        {
            return (Record)Add( new Record());
        }
        public Dial AddDial()
        {
            return (Dial)Add( new Dial());
        }
        public Message AddMessage(string text)
        {
            return (Message)Add( new Message(text));
        }
        public Redirect AddRedirect(string body)
        {
            return (Redirect)Add(new Redirect(body));
        }
        public Wait AddWait()
        {
            return (Wait)Add(new Wait());
        }
        public Hangup AddHangup()
        {
            return (Hangup)Add(new Hangup());
        }
        public PreAnswer AddPreAnswer()
        {
            return (PreAnswer)Add(new PreAnswer());
        }
        public Conference AddConference(string body)
        {
            return (Conference)Add(new Conference(body));
        }
        public DTMF AddDTMF(string body)
        {
            return (DTMF)Add(new DTMF(body));
        }
    }

    public class Dial : PlivoElement
    {
        public Dial() : base()
        {
        }
        public Number AddNumber(string body)
        {
            return (Number)Add(new Number(body));
        }
        public User AddUser(string body)
        {
            return (User)Add(new User(body));
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
        public void SetCallbackMethod(string callbackMethod)
        {
            this.Set("callbackMethod", callbackMethod);
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
        public Number(string body) : base(body)
        {
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
        public User(string body) : base(body)
        {
        }
		public void SetSendDigits(string sendDigits)
        {
            this.Set("sendDigits", sendDigits);
        }
		public void SetSendOnPreanswer(bool sendOnPreanswer)
        {
            this.Set("sendOnPreanswer", sendOnPreanswer);
        }
		public void SetSipHeaders(string sipHeaders)
        {
            this.Set("sipHeaders", sipHeaders);
        }
    }

    public class Conference : PlivoElement
    {
        public Conference(string body) : base(body)
        {
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
        public void SetRecord(bool record)
        {
            this.Set("record", record);
        }
        public void SetRecordFileFormat(string recordFileFormat)
        {
            this.Set("recordFileFormat", recordFileFormat);
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
        public GetDigits() : base()
        {
        }
        public Speak AddSpeak(string body)
        {
            return (Speak)Add(new Speak(body));
        }
        public Play AddPlay(string body)
        {
            return (Play)Add(new Play(body));
        }
        public Wait AddWait()
        {
            return (Wait)Add(new Wait());
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
        public void SetRedirect(bool redirect)
        {
            this.Set("redirect", redirect);
        }
        public void SetPlayBeep(bool playBeep)
        {
            this.Set("playBeep", playBeep);
        }
        public void SetValidDigits(string validDigits)
        {
            this.Set("validDigits", validDigits);
        }
        public void SetInvalidDigitsSound(string invalidDigitsSound)
        {
            this.Set("invalidDigitsSound", invalidDigitsSound);
        }
    }

    public class Speak : PlivoElement
    {
        public Speak(string body) : base(body)
        {
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
        public Play(string body) : base(body)
        {
        }
		public void SetLoop(int loop)
        {
            this.Set("loop", loop);
        }
    }

    public class Wait : PlivoElement
    {
        public Wait() : base()
        {
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
        public Redirect(string body) : base(body)
        {
        }
		public void SetMethod(string method)
        {
            this.Set("method", method);
        }
    }

    public class Hangup : PlivoElement
    {
        public Hangup() : base()
        {
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
        public Record() : base()
        {
        }
		public void SetAction(string action)
        {
            this.Set("action", action);
        }
		public void SetMethod(string method)
        {
            this.Set("method", method);
        }
        public void SetFileFormat(string fileFormat)
        {
            this.Set("fileFormat", fileFormat);
        }
        public void SetRedirect(bool redirect)
        {
            this.Set("redirect", redirect);
        }
		public void SetTimeout(int timeout)
        {
            this.Set("timeout", timeout);
        }
        public void SetMaxLength(int maxLength)
        {
            this.Set("maxLength", maxLength);
        }
        public void SetPlayBeep(bool playBeep)
        {
            this.Set("playBeep", playBeep);
        }
		public void SetFinishOnKey(string finishOnKey)
        {
            this.Set("finishOnKey", finishOnKey);
        }
		public void SetRecordSession(bool recordSession)
        {
            this.Set("recordSession", recordSession);
        }
		public void SetStartOnDialAnswer(bool startOnDialAnswer)
        {
            this.Set("startOnDialAnswer", startOnDialAnswer);
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
		public void SetCallbackUrl(string callbackUrl)
        {
            this.Set("callbackUrl", callbackUrl);
        }
		public void SetCallbackMethod(string callbackMethod)
        {
            this.Set("callbackMethod", callbackMethod);
        }
    }

    public class PreAnswer : PlivoElement
    {
        public PreAnswer()  : base()
        {
        }
        public Play AddPlay(string body)
        {
            return (Play)Add(new Play(body));
        }
        public Speak AddSpeak(string body)
        {
            return (Speak)Add(new Speak(body));
        }
        public GetDigits AddGetDigits()
        {
            return (GetDigits)Add(new GetDigits());
        }
        public Wait AddWait()
        {
            return (Wait)Add(new Wait());
        }
        public Redirect AddRedirect(string body)
        {
            return (Redirect)Add(new Redirect(body));
        }
        public Message AddMessage(string body)
        {
            return (Message)Add(new Message(body));
        }
        public DTMF AddDTMF(string body)
        {
            return (DTMF)Add(new DTMF(body));
        }
    }

    public class Message : PlivoElement
    {
        public Message(string body) : base(body)
        {
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
        public DTMF(string body) : base(body)
        {
        }
    }
}
