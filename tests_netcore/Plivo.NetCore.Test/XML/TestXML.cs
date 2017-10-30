using System;
using System.Collections.Generic;
using Xunit;
using Plivo.XML;

namespace Plivo.NetCore.Test.XML
{
    
    public class TestXml
    {
        [Fact]
        public void TestAllXml()
        {
            var resp = new Response();
            resp.AddConference("My room",
                new Dictionary<string, string>()
                {
                    {"callbackUrl", "http://foo.com/confevents/"},
                    {"callbackMethod", "POST"},
                    {"digitsMatch", "#0,99,000"}
                });
            
            Plivo.XML.Dial dial = new Plivo.XML.Dial(new
                Dictionary<string, string>() {
                    {"confirmSound", "http://foo.com/sound/"},
                    {"confirmKey", "3"}
                });
            dial.AddNumber("18217654321",
                new Dictionary<string, string>()
                {
                    {"sendDigits", "wwww2410"}
                });
            dial.AddUser("sip:john1234@phone.plivo.com",
                new Dictionary<string, string>()
                {
                    {"sendDigits", "wwww2410"}
                });
            resp.Add(dial);
            
            Plivo.XML.Dial dial1 = new Plivo.XML.Dial(new
                Dictionary<string, string>() {
                    {"timeout", "20"},
                    {"action", "http://foo.com/dial_action/"}
                });

            dial1.AddNumber("18217654321",
                new Dictionary<string, string>() { });

            Plivo.XML.Dial dial2 = new Plivo.XML.Dial(new
                Dictionary<string, string>()
                { });
            dial2.AddNumber("15671234567",
                new Dictionary<string, string>() { });
            resp.Add(dial1);
            resp.Add(dial2);
            
            resp.AddDTMF("12345", 
                new Dictionary<string, string>() { });
            
            Plivo.XML.GetDigits get_digits = new
                Plivo.XML.GetDigits("",
                    new Dictionary<string, string>()
                    {
                        {"action", "http://www.foo.com/gather_pin/"},
                        { "method", "POST" }
                    });
            resp.Add(get_digits);

            get_digits.AddSpeak("Enter PIN number.",
                new Dictionary<string, string>() { });
            resp.AddSpeak("Input not recieved.",
                new Dictionary<string, string>() { });
            
            resp.AddHangup(new Dictionary<string, string>()
            {
                {"schedule", "60"},
                {"reason", "rejected" }
            });
            resp.AddSpeak("Call will hangup after a min.",
                new Dictionary<string, string>()
                {
                    {"loop", "0"}
                });
            
            resp.AddMessage("Hi, message from Plivo.",
                new Dictionary<string, string>()
                {
                    {"src", "12023222222"},
                    {"dst", "15671234567" } ,
                    {"type", "sms"},
                    {"callbackUrl", "http://foo.com/sms_status/"},
                    {"callbackMethod", "POST"}
                });
            
            resp.AddPlay("https://amazonaws.com/Trumpet.mp3",
                new Dictionary<string, string>() { });
            
            Plivo.XML.PreAnswer answer = new
                Plivo.XML.PreAnswer();
            answer.AddSpeak("This call will cost $2 a min.",
                new Dictionary<string, string>() { });
            resp.Add(answer);
            resp.AddSpeak("Thanks for dropping by.",
                new Dictionary<string, string>() { });
            
            resp.AddRecord(new Dictionary<string, string>() {
                {"action", "http://foo.com/get_recording/"},
                {"startOnDialAnswer", "true"},
                {"redirect", "false"}
            });

            Plivo.XML.Dial dial3 = new Plivo.XML.Dial(new
                Dictionary<string, string>()
                { });

            dial3.AddNumber("15551234567",
                new Dictionary<string, string>() { });
            resp.Add(dial3);
            
            resp.AddSpeak("Leave message after the beep.",
                new Dictionary<string, string>() { });
            resp.AddRecord(new Dictionary<string, string>() {
                {"action", "http://foo.com/get_recording/"},
                {"maxLength", "30"},
                {"finishOnKey", "*"}
            });
            resp.AddSpeak("Recording not received.",
                new Dictionary<string, string>() { });
            
            resp.AddSpeak("Your call is being transferred.", 
                new Dictionary<string, string>() { });
            resp.AddRedirect("http://foo.com/redirect/", 
                new Dictionary<string, string>() { });
            
            resp.AddSpeak("Go green, go plivo.", 
                new Dictionary<string, string>()
                {
                    {"loop", "3"}
                });
            
            resp.AddSpeak("I will wait 7 seconds starting now!", 
                new Dictionary<string, string>() { });
            resp.AddWait(new Dictionary<string, string>()
            {
                {"length", "7"}
            });
            resp.AddSpeak("I just waited 7 seconds.", 
                new Dictionary<string, string>() { });
            
            resp.AddWait(new Dictionary<string, string>()
            {
                {"length", "120"}, {"beep", "true"}
            });
            resp.AddPlay("https://s3.amazonaws.com/abc.mp3", 
                new Dictionary<string, string>() { });
            
            resp.AddWait(new Dictionary<string, string>()
            {
                {"length", "10"}
            });
            resp.AddSpeak("Hello", 
                new Dictionary<string, string>() { });
            
            resp.AddWait(new Dictionary<string, string>()
            {
                {"length", "10"},
                {"silence", "true"}, 
                {"minSilence", "3000"}
            });
            resp.AddSpeak("Hello, welcome to the Jungle.", 
                new Dictionary<string, string>() { });
          
            var output = resp.ToString();
            Console.WriteLine(output);
            Assert.Equal(
                "<Response>\n  <Conference callbackUrl=\"http://foo.com/confevents/\" callbackMethod=\"POST\" digitsMatch=\"#0,99,000\">My room</Conference>\n  <Dial confirmSound=\"http://foo.com/sound/\" confirmKey=\"3\">\n    <Number sendDigits=\"wwww2410\">18217654321</Number>\n    <User sendDigits=\"wwww2410\">sip:john1234@phone.plivo.com</User>\n  </Dial>\n  <Dial timeout=\"20\" action=\"http://foo.com/dial_action/\">\n    <Number>18217654321</Number>\n  </Dial>\n  <Dial>\n    <Number>15671234567</Number>\n  </Dial>\n  <DTMF>12345</DTMF>\n  <GetDigits action=\"http://www.foo.com/gather_pin/\" method=\"POST\">\n    <Speak>Enter PIN number.</Speak>\n  </GetDigits>\n  <Speak>Input not recieved.</Speak>\n  <Hangup schedule=\"60\" reason=\"rejected\" />\n  <Speak loop=\"0\">Call will hangup after a min.</Speak>\n  <Message src=\"12023222222\" dst=\"15671234567\" type=\"sms\" callbackUrl=\"http://foo.com/sms_status/\" callbackMethod=\"POST\">Hi, message from Plivo.</Message>\n  <Play>https://amazonaws.com/Trumpet.mp3</Play>\n  <PreAnswer>\n    <Speak>This call will cost $2 a min.</Speak>\n  </PreAnswer>\n  <Speak>Thanks for dropping by.</Speak>\n  <Record action=\"http://foo.com/get_recording/\" startOnDialAnswer=\"true\" redirect=\"false\" />\n  <Dial>\n    <Number>15551234567</Number>\n  </Dial>\n  <Speak>Leave message after the beep.</Speak>\n  <Record action=\"http://foo.com/get_recording/\" maxLength=\"30\" finishOnKey=\"*\" />\n  <Speak>Recording not received.</Speak>\n  <Speak>Your call is being transferred.</Speak>\n  <Redirect>http://foo.com/redirect/</Redirect>\n  <Speak loop=\"3\">Go green, go plivo.</Speak>\n  <Speak>I will wait 7 seconds starting now!</Speak>\n  <Wait length=\"7\" />\n  <Speak>I just waited 7 seconds.</Speak>\n  <Wait length=\"120\" beep=\"true\" />\n  <Play>https://s3.amazonaws.com/abc.mp3</Play>\n  <Wait length=\"10\" />\n  <Speak>Hello</Speak>\n  <Wait length=\"10\" silence=\"true\" minSilence=\"3000\" />\n  <Speak>Hello, welcome to the Jungle.</Speak>\n</Response>",
                output);
        }
    }
}