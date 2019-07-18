using System;
using Xunit;

namespace Plivo.NetCore.Test
{
    public class TestSignature
    {
        [Fact]
        public void TestSignatureV2Pass()
        {
            string url = "https://answer.url";
            string nonce = "12345";
            string signature = "ehV3IKhLysWBxC1sy8INm0qGoQYdYsHwuoKjsX7FsXc=";
            string authToken = "my_auth_token";

            Assert.True(Utilities.XPlivoSignatureV2.VerifySignature(url, nonce, signature, authToken));
        }

        [Fact]
        public void TestSignatureV2Fail()
        {
            string url = "https://answer.url";
            string nonce = "12345";
            string signature = "ehV3IKhLysWBxC1sy8INm0qGoQYdYsHwuoKjsX7FsXc=";
            string authToken = "my_auth_tokens";

            Assert.False(Utilities.XPlivoSignatureV2.VerifySignature(url, nonce, signature, authToken));
        }
    }
}