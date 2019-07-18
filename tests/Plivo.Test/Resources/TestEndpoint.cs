using System.Collections.Generic;
using NUnit.Framework;
using Plivo.Http;
using Plivo.Resource;
using Plivo.Resource.Endpoint;
using Plivo.Utilities;

namespace Plivo.Test.Resources {
    [TestFixture]
    public class TestEndpoint : BaseTestCase {
        [Test]
        public void TestEndpointCreate () {
            var data = new Dictionary<string, object> () { { "username", "user" }, { "password", "pass" }, { "alias", "alias" }
                };

            var request =
                new PlivoRequest (
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Endpoint/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText (
                    SOURCE_DIR + @"Mocks/endpointCreateResponse.json"
                );
            Setup<EndpointCreateResponse> (
                201,
                response
            );
            Assert.IsEmpty (
                ComparisonUtilities.Compare (
                    response,
                    Api.Endpoint.Create ("user", "pass", "alias")));
            AssertRequest (request);
        }

        [Test]
        public void TestEndpointList () {
            var data = new Dictionary<string, object> () { { "limit", 10 }
                };
            var request =
                new PlivoRequest (
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Endpoint/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText (
                    SOURCE_DIR + @"Mocks/endpointListResponse.json"
                );
            Setup<ListResponse<Endpoint>> (
                200,
                response
            );
            Assert.IsEmpty (
                ComparisonUtilities.Compare (
                    response,
                    Api.Endpoint.List (limit: 10)));

            AssertRequest (request);
        }

        [Test]
        public void TestEndpointGet () {
            var id = "abcabcabc";
            var request =
                new PlivoRequest (
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Endpoint/" + id + "/",
                    "");

            var response =
                System.IO.File.ReadAllText (
                    SOURCE_DIR + @"Mocks/endpointGetResponse.json"
                );
            Setup<Endpoint> (
                200,
                response
            );
            Assert.IsEmpty (
                ComparisonUtilities.Compare (
                    response,
                    Api.Endpoint.Get (id)));

            AssertRequest (request);
        }

        [Test]
        public void TestEndpointUpdate () {
            var id = "abcabcabc";
            var data = new Dictionary<string, object> () { { "alias", "alalaalalala" }
                };

            var request =
                new PlivoRequest (
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Endpoint/" + id + "/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText (
                    SOURCE_DIR + @"Mocks/endpointUpdateResponse.json"
                );
            Setup<UpdateResponse<Endpoint>> (
                202,
                response
            );
            Assert.IsEmpty (
                ComparisonUtilities.Compare (
                    response,
                    Api.Endpoint.Update (id, alias: "alalaalalala")));
            AssertRequest (request);
        }

        [Test]
        public void TestEndpointDelete () {
            var id = "abcabcabc";
            var request =
                new PlivoRequest (
                    "DELETE",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Endpoint/" + id + "/",
                    "");

            var response = System.IO.File.ReadAllText (
                SOURCE_DIR + @"Mocks/endpointUpdateResponse.json"
            );
            Setup<UpdateResponse<Endpoint>> (
                204,
                response
            );
            Assert.IsNull (Api.Endpoint.Delete (id));
            AssertRequest (request);
        }
    }
}