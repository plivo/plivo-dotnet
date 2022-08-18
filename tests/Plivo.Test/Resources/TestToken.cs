using System.Collections.Generic;
using NUnit.Framework;
using Plivo.Http;
using Plivo.Resource;
using Plivo.Resource.Token;
using Plivo.Utilities;

namespace Plivo.Test.Resources {
    [TestFixture]
    public class TestToken : BaseTestCase {
        [Test]
        public void TestTokenCreate () {
            var data = new Dictionary<string, object> () { { "iss", "MAXXXXXXXXXXXXXXXXXX" } };

            var request =
                new PlivoRequest (
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/JWT/Token/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText (
                    SOURCE_DIR + @"Mocks/tokenCreateResponse.json"
                );
            Setup<TokenCreateResponse> (
                200,
                response
            );
            Assert.IsEmpty (
                ComparisonUtilities.Compare (
                    response,
                    Api.Token.Create ("MAXXXXXXXXXXXXXXXXXX")));
            AssertRequest (request);
        }
    }
}