using System;
using System.Collections.Generic;
using Xunit;
using Plivo.Utilities;

namespace Plivo.NetCore.Test
{
    public class TestSignatureV3Scoped
    {
        private static readonly string Token1 = "PLV" + "obLD1OX2BxgpOktcbX6PkBEiM0RVZneImaq7zN3u_wA";
        private static readonly string Token2 = "PLV" + new string('A', 43);
        private const string AuthToken = "test-auth-token";
        private const string Nonce = "01456268273535255990";
        private const string PostUrl = "https://acme.example.com/sms/status";
        private const string PostSig = "Kxo1ZuQEWE578HnfEhiJvLjXNzZXYPvkZDKNq9s4kvk=";
        private const string GetUrl = "https://acme.example.com/answer?From=14155550100&CallUUID=abc";
        private const string GetSig = "nr+QWHZTVoEP0rWEEWMeWjgKRzfOOuBhJvJqQQ8ZC2s=";

        private static Dictionary<string, string> PostParams(string status = "delivered")
        {
            return new Dictionary<string, string>
            {
                {"MessageUUID", "6f1c2a90-0d7e-4b1e-9c11-1d2e3f4a5b6c"},
                {"Status", status},
                {"To", "14155550100"}
            };
        }

        private static string Hex(byte[] b)
        {
            return BitConverter.ToString(b).Replace("-", "").ToLowerInvariant();
        }

        [Fact]
        public void DeriveSigningKeyMatchesVectors()
        {
            Assert.Equal("e55b316ef14f5830de74d2cc2ae794b87c6c349f577d2fabd648884afba6c7ca", Hex(XPlivoSignatureV3.DeriveSigningKey(Token1)));
            Assert.Equal("c89d8ad56ac99e1a8def8cecce07ffb55332fe813673be81df8b1297d1206368", Hex(XPlivoSignatureV3.DeriveSigningKey(Token2)));
        }

        [Fact]
        public void ValidatesPostAndGet()
        {
            Assert.True(XPlivoSignatureV3.VerifySignatureScoped(PostUrl, Nonce, PostSig, Token1, "POST", PostParams()));
            Assert.True(XPlivoSignatureV3.VerifySignatureScoped(GetUrl, Nonce, GetSig, Token1, "GET"));
        }

        [Fact]
        public void RejectsWrongTokenOrTamperedParams()
        {
            Assert.False(XPlivoSignatureV3.VerifySignatureScoped(PostUrl, Nonce, PostSig, Token2, "POST", PostParams()));
            Assert.False(XPlivoSignatureV3.VerifySignatureScoped(PostUrl, Nonce, PostSig, Token1, "POST", PostParams("failed")));
        }

        [Fact]
        public void AcceptsAnyOfMultipleSignatures()
        {
            Assert.True(XPlivoSignatureV3.VerifySignatureScoped(PostUrl, Nonce, "bogus," + PostSig, Token1, "POST", PostParams()));
        }

        [Fact]
        public void AuthTokenValidatorAcceptsScopedToken()
        {
            Assert.True(XPlivoSignatureV3.VerifySignature(PostUrl, Nonce, PostSig + "," + AuthSig(), Token1, "POST", PostParams()));
            Assert.False(XPlivoSignatureV3.VerifySignature(PostUrl, Nonce, AuthSig(), Token1, "POST", PostParams()));
        }

        private static string AuthSig()
        {
            return XPlivoSignatureV3.ComputeSignature(PostUrl, Nonce, AuthToken, PostParams(), "POST");
        }

        private static bool VerifyKeys(string header, IEnumerable<string> keys)
        {
            return XPlivoSignatureV3.VerifySignatureScoped(PostUrl, Nonce, header, keys, "POST", PostParams());
        }

        [Fact]
        public void KeyListAcceptsScopedSignature()
        {
            Assert.Equal(PostSig, XPlivoSignatureV3.ComputeSignatureScoped(PostUrl, Nonce, Token1, PostParams(), "POST"));
            Assert.True(VerifyKeys(PostSig, new[] {Token1, AuthToken}));
        }

        [Fact]
        public void KeyListAcceptsAuthTokenSignature()
        {
            Assert.True(VerifyKeys(AuthSig(), new[] {Token1, AuthToken}));
        }

        [Fact]
        public void KeyListMatchesAuthTokenAmongMultipleSignatures()
        {
            Assert.True(VerifyKeys(PostSig + "," + AuthSig(), new[] {Token2, AuthToken}));
        }

        [Fact]
        public void KeyListRejectsWrongScopedToken()
        {
            Assert.False(VerifyKeys(PostSig, new[] {Token2}));
        }

        [Fact]
        public void KeyListEmptyOrWithBlankEntries()
        {
            Assert.False(VerifyKeys(PostSig, new string[0]));
            Assert.True(VerifyKeys(PostSig, new[] {null, "", Token1}));
        }
    }
}
