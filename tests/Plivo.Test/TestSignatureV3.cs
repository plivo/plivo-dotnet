using System;
using NUnit.Framework;

namespace Plivo.Test
{
    [TestFixture]
    public class TestSignature
    {
        [Test]
        public void TestSignatureV3Pass1()
        {
            string url = "https://plivobin.non-prod.plivops.com/api/v1/validate_signature03.xml/?a=b&c=d";
            string nonce = "31627761595286130198";
            string signature = "k7Pusd4OxCIjR5IfA9iedDNu/h/gbdYqdzG/MiYtd1c=";
            string authToken = "Y2Q2ZDgxZmY5YWRiOTI5YmQ1Njg0MTAxZWIyOTc4";
            string method = "POST";
            Dictionary<string, string> params = new Dictionary<string, string>();
            parameters.Add("Direction", "outbound");
            parameters.Add("From", "19792014278");
            parameters.Add("ALegUUID", "3e82ae9d-2c78-4d85-b1a4-6eae7dbafb36");
            parameters.Add("SessionStart", "2020-04-08 11:34:33.238707");
            parameters.Add("BillRate", "0.002");
            parameters.Add("ParentAuthID", "MANWVLYTK4ZWU1YTY4QA");
            parameters.Add("To", "sip:PlivoSignature382029104058171078704104@phone-qa.voice.plivodev.com");
            parameters.Add("RequestUUID", "3e82ae9d-2c78-4d85-b1a4-6eae7dbafb36");
            parameters.Add("ALegRequestUUID", "3e82ae9d-2c78-4d85-b1a4-6eae7dbafb36");
            parameters.Add("CallUUID", "3e82ae9d-2c78-4d85-b1a4-6eae7dbafb36");
            parameters.Add("SIP-H-To", "<sip:PlivoSignature382029104058171078704104@52.9.11.55;transport=udp>;tag=1");
            parameters.Add("CallStatus", "in-progress");
            parameters.Add("Event", "StartApp");
            Assert.True(Utilities.XPlivoSignatureV3.VerifySignature(url, nonce, signature, authToken, params, method));
        }

        [Test]
        public void TestSignatureV3Pass2()
        {
            string url = "https://plivobin.non-prod.plivops.com/api/v1/validate_signature03.xml";
            string nonce = "31627761595286130198";
            string signature = "UBq8jAtd32wR8EK9VgxbBn4n5rpI/l1H9iN4WfSEHFQ=";
            string authToken = "Y2Q2ZDgxZmY5YWRiOTI5YmQ1Njg0MTAxZWIyOTc4";
            string method = "GET";
            Dictionary<string, string> params = new Dictionary<string, string>();
            parameters.Add("Direction", "outbound");
            parameters.Add("From", "19792014278");
            parameters.Add("ALegUUID", "3e82ae9d-2c78-4d85-b1a4-6eae7dbafb36");
            parameters.Add("SessionStart", "2020-04-08 11:34:33.238707");
            parameters.Add("BillRate", "0.002");
            parameters.Add("ParentAuthID", "MANWVLYTK4ZWU1YTY4QA");
            parameters.Add("To", "sip:PlivoSignature382029104058171078704104@phone-qa.voice.plivodev.com");
            parameters.Add("RequestUUID", "3e82ae9d-2c78-4d85-b1a4-6eae7dbafb36");
            parameters.Add("ALegRequestUUID", "3e82ae9d-2c78-4d85-b1a4-6eae7dbafb36");
            parameters.Add("CallUUID", "3e82ae9d-2c78-4d85-b1a4-6eae7dbafb36");
            parameters.Add("SIP-H-To", "<sip:PlivoSignature382029104058171078704104@52.9.11.55;transport=udp>;tag=1");
            parameters.Add("CallStatus", "in-progress");
            parameters.Add("Event", "StartApp");
            Assert.True(Utilities.XPlivoSignatureV3.VerifySignature(url, nonce, signature, authToken, params, method));
        }
        
        [Test]
        public void TestSignatureV3Pass3()
        {
            string url = "https://plivobin.non-prod.plivops.com/api/v1/validate_signature03.xml";
            string nonce = "31627761595286130198";
            string signature = "iAjE5QqI37mbkYe4w3jTMudqEzbDufdqi7sYwTu64e0=";
            string authToken = "Y2Q2ZDgxZmY5YWRiOTI5YmQ1Njg0MTAxZWIyOTc4";
            string method = "POST";
            Dictionary<string, string> params = new Dictionary<string, string>();
            parameters.Add("Direction", "outbound");
            parameters.Add("From", "19792014278");
            parameters.Add("ALegUUID", "3e82ae9d-2c78-4d85-b1a4-6eae7dbafb36");
            parameters.Add("SessionStart", "2020-04-08 11:34:33.238707");
            parameters.Add("BillRate", "0.002");
            parameters.Add("ParentAuthID", "MANWVLYTK4ZWU1YTY4QA");
            parameters.Add("To", "sip:PlivoSignature382029104058171078704104@phone-qa.voice.plivodev.com");
            parameters.Add("RequestUUID", "3e82ae9d-2c78-4d85-b1a4-6eae7dbafb36");
            parameters.Add("ALegRequestUUID", "3e82ae9d-2c78-4d85-b1a4-6eae7dbafb36");
            parameters.Add("CallUUID", "3e82ae9d-2c78-4d85-b1a4-6eae7dbafb36");
            parameters.Add("SIP-H-To", "<sip:PlivoSignature382029104058171078704104@52.9.11.55;transport=udp>;tag=1");
            parameters.Add("CallStatus", "in-progress");
            parameters.Add("Event", "StartApp");
            Assert.True(Utilities.XPlivoSignatureV3.VerifySignature(url, nonce, signature, authToken, params, method));
        }
        
        [Test]
        public void TestSignatureV3Pass4()
        {
            string url = "https://plivobin.non-prod.plivops.com/api/v1/validate_signature03.xml";
            string nonce = "31627761595286130198";
            string signature = "i/MQsaQSAd6fiKhOh2qeeeLHZ9faldADSb3/7+Akfbc=";
            string authToken = "Y2Q2ZDgxZmY5YWRiOTI5YmQ1Njg0MTAxZWIyOTc4";
            string method = "GET";
            Dictionary<string, string> params = new Dictionary<string, string>();
            parameters.Add("Direction", "outbound");
            parameters.Add("From", "19792014278");
            parameters.Add("ALegUUID", "3e82ae9d-2c78-4d85-b1a4-6eae7dbafb36");
            parameters.Add("SessionStart", "2020-04-08 11:34:33.238707");
            parameters.Add("BillRate", "0.002");
            parameters.Add("ParentAuthID", "MANWVLYTK4ZWU1YTY4QA");
            parameters.Add("To", "sip:PlivoSignature382029104058171078704104@phone-qa.voice.plivodev.com");
            parameters.Add("RequestUUID", "3e82ae9d-2c78-4d85-b1a4-6eae7dbafb36");
            parameters.Add("ALegRequestUUID", "3e82ae9d-2c78-4d85-b1a4-6eae7dbafb36");
            parameters.Add("CallUUID", "3e82ae9d-2c78-4d85-b1a4-6eae7dbafb36");
            parameters.Add("SIP-H-To", "<sip:PlivoSignature382029104058171078704104@52.9.11.55;transport=udp>;tag=1");
            parameters.Add("CallStatus", "in-progress");
            parameters.Add("Event", "StartApp");
            Assert.True(Utilities.XPlivoSignatureV3.VerifySignature(url, nonce, signature, authToken, params, method));
        }
    }
}
