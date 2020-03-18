using System;
using NUnit.Framework;

namespace Plivo.Test
{
    [TestFixture]
    public class TestSignature
    {
        [Test]
        public void TestSignatureV3Pass()
        {
            string url = "https://answer.url";
            string nonce = "12345";
            string signature = "rXj4UwTSVxH6Kj+W0qX8LaCvVOOvmzPGzY8sQVn3d1I=";
            string authToken = "my_auth_token";
            string method = "GET";
            Dictionary<string, string> params = new Dictionary<string, string>();
            params.Add("CallUUID", "97ceeb52-58b6-11e1-86da-77300b68f8bb");
            params.Add("Duration", "300");

            Assert.True(Utilities.XPlivoSignatureV3.VerifySignature(url, nonce, signature, authToken, params, method));
        }

        [Test]
        public void TestSignatureV3Fail()
        {
            string url = "https://answer.url";
            string nonce = "12345";
            string signature = "rXj4UwTSVxH6Kj+W0qX8LaCvVOOvmzPGzY8sQVn3d1I+";
            string authToken = "my_auth_token";
            string method = "GET";
            Dictionary<string, string> params = new Dictionary<string, string>();
            params.Add("CallUUID", "97ceeb52-58b6-11e1-86da-77300b68f8bb");
            params.Add("Duration", "300");

            Assert.False(Utilities.XPlivoSignatureV3.VerifySignature(url, nonce, signature, authToken, params, method));
        }
    }
}
