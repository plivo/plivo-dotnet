using System.Collections.Generic;
using NUnit.Framework;
using Plivo.Http;
using Plivo.Resource;
using Plivo.Resource.MaskingSession;
using Plivo.Utilities;

namespace Plivo.Test.Resources {
    [TestFixture]
    public class TestMaskingSession : BaseTestCase {
        [Test]
        public void TestMaskingSessionCreate () {
            var data = new Dictionary<string, object> () { { "firstParty", "917708772011" }, { "secondParty", "918220568648" }};

            var request =
                new PlivoRequest (
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Masking/Session/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText (
                    SOURCE_DIR + @"Mocks/maskingSessionCreateResponse.json"
                );
            Setup<MaskingSessionCreateResponse> (
                201,
                response
            );
            Assert.IsEmpty (
                ComparisonUtilities.Compare (
                    response,
                    Api.MaskingSession.Create ("917708772011", "918220568648")));
            AssertRequest (request);
        }

        [Test]
        public void TestMaskingSessionList () {
            var data = new Dictionary<string, object> () { { "limit", 10 }
                };
            var request =
                new PlivoRequest (
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Masking/Session/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText (
                    SOURCE_DIR + @"Mocks/maskingSessionListResponse.json"
                );
            Setup<ListResponse<MaskingSession>> (
                200,
                response
            );
            Assert.IsEmpty (
                ComparisonUtilities.Compare (
                    response,
                    Api.MaskingSession.List (limit: 10)));

            AssertRequest (request);
        }

        [Test]
        public void TestMaskingSessionGet () {
            var id = "abcabcabc";
            var request =
                new PlivoRequest (
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Masking/Session/" + id + "/",
                    "");

            var response =
                System.IO.File.ReadAllText (
                    SOURCE_DIR + @"Mocks/maskingSessionGetResponse.json"
                );
            Setup<Endpoint> (
                200,
                response
            );
            Assert.IsEmpty (
                ComparisonUtilities.Compare (
                    response,
                    Api.MaskingSession.Get (id)));

            AssertRequest (request);
        }

        [Test]
        public void TestMaskingSessionUpdate () {
            var id = "abcabcabc";
            var data = new Dictionary<string, object> () { { "917708772011", "918220568648" }
                };

            var request =
                new PlivoRequest (
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Masking/Session/" + id + "/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText (
                    SOURCE_DIR + @"Mocks/maskingSessionUpdateResponse.json"
                );
            Setup<UpdateResponse<MaskingSession>> (
                202,
                response
            );
            Assert.IsEmpty (
                ComparisonUtilities.Compare (
                    response,
                    Api.MaskingSession.Update (id, alias: "918220568648")));
            AssertRequest (request);
        }

        [Test]
        public void TestMaskingSessionDelete () {
            var id = "abcabcabc";
            var request =
                new PlivoRequest (
                    "DELETE",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Masking/Session/" + id + "/",
                    "");

            var response = System.IO.File.ReadAllText (
                SOURCE_DIR + @"Mocks/maskingSessionUpdateResponse.json"
            );
            Setup<UpdateResponse<MaskingSession>> (
                204,
                response
            );
            Assert.IsNull (Api.MaskingSession.Delete (id));
            AssertRequest (request);
        }
    }
}