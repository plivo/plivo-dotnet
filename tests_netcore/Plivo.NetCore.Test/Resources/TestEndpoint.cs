using System.Collections.Generic;
using Xunit;
using Plivo.Http;
using Plivo.Resource;
using Plivo.Resource.Endpoint;
using Plivo.Utilities;

namespace Plivo.NetCore.Test.Resources
{
    public class TestEndpoint : BaseTestCase
    {
        [Fact]
        public void TestEndpointCreate()
        {
            var data = new Dictionary<string, object>()
            {
                {"username", "user"},
                {"password", "pass"},
                {"alias", "alias"},
                {"is_voice_request", true}
            };

            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Endpoint/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/endpointCreateResponse.json"
                );
            Setup<EndpointCreateResponse>(
                201,
                response
            );
            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Endpoint.Create("user", "pass", "alias")));
            AssertRequest(request);
        }
        
        [Fact]
        public void TestEndpointCreateAsync()
        {
            var data = new Dictionary<string, object>()
            {
                {"username", "user"},
                {"password", "pass"},
                {"alias", "alias"},
                {"callback_url", "https://www.google.com"},
                {"callback_method", "POST"},
                {"is_voice_request", true}
            };

            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Endpoint/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/asyncResponse.json"
                );
            Setup<AsyncResponse>(200, response);
            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Endpoint.CreateAsync("user", "pass", "alias",
                        callbackUrl: "https://www.google.com",
                        callbackMethod: "POST"
                        ).Result
                    )
                );
            AssertRequest(request);
        }

        [Fact]
        public void TestEndpointList()
        {
            var data = new Dictionary<string, object>()
            {
                {"limit", 10},
                {"is_voice_request", true}
            };
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Endpoint/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/endpointListResponse.json"
                );
            Setup<ListResponse<Endpoint>>(
                200,
                response
            );
            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Endpoint.List(limit: 10)));

            AssertRequest(request);
        }
        
        [Fact]
        public void TestEndpointListAsync()
        {
            var data = new Dictionary<string, object>()
            {
                {"limit", 10},
                {"callback_url", "https://www.google.com"},
                {"callback_method", "POST"},
                {"is_voice_request", true}
            };
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Endpoint/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/asyncResponse.json"
                );
            Setup<AsyncResponse>(200, response);
            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Endpoint.ListAsync(limit: 10,
                        callbackUrl: "https://www.google.com",
                        callbackMethod: "POST"
                    ).Result));

            AssertRequest(request);
        }

        [Fact]
        public void TestEndpointGet()
        {
            var id = "abcabcabc";
            var data = new Dictionary<string, object>()
            {
                {"is_voice_request", true}
            };
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Endpoint/" + id + "/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/endpointGetResponse.json"
                );
            Setup<Endpoint>(
                200,
                response
            );
            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Endpoint.Get(id)));

            AssertRequest(request);
        }
        
        [Fact]
        public void TestEndpointGetAsync()
        {
            var id = "abcabcabc";
            var data = new Dictionary<string, object>()
            {
                {"callback_url", "https://www.google.com"},
                {"callback_method", "POST"},
                {"is_voice_request", true}
            };
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Endpoint/" + id + "/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/asyncResponse.json"
                );
            Setup<AsyncResponse>(200, response);
            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Endpoint.GetAsync(id,
                        callbackUrl: "https://www.google.com",
                        callbackMethod: "POST"
                    ).Result));

            AssertRequest(request);
        }

        [Fact]
        public void TestEndpointUpdate()
        {
            var id = "abcabcabc";
            var data = new Dictionary<string, object>()
            {
                {"alias", "alalaalalala"},
                {"is_voice_request", true}
            };

            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Endpoint/" + id + "/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/endpointUpdateResponse.json"
                );
            Setup<UpdateResponse<Endpoint>>(
                202,
                response
            );
            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Endpoint.Update(id, alias: "alalaalalala")));
            AssertRequest(request);
        }
        
        [Fact]
        public void TestEndpointUpdateAsync()
        {
            var id = "abcabcabc";
            var data = new Dictionary<string, object>()
            {
                {"alias", "alalaalalala"},
                {"callback_url", "https://www.google.com"},
                {"callback_method", "POST"},
                {"is_voice_request", true}
            };

            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Endpoint/" + id + "/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/asyncResponse.json"
                );
            Setup<AsyncResponse>(200, response);
            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                        Api.Endpoint.UpdateAsync(id, alias: "alalaalalala", 
                            callbackUrl: "https://www.google.com",
                            callbackMethod: "POST"
                        ).Result
                    )
                );
            AssertRequest(request);
        }

        [Fact]
        public void TestEndpointDelete()
        {
            var id = "abcabcabc";
            var data = new Dictionary<string, object>()
            {
                {"is_voice_request", true}
            };
            var request =
                new PlivoRequest(
                    "DELETE",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Endpoint/" + id + "/",
                    "",
                    data);

            var response = "";
            Setup<UpdateResponse<Endpoint>>(
                204,
                response
            );
            Assert.Null(Api.Endpoint.Delete(id));
            AssertRequest(request);
        }
        
        [Fact]
        public void TestEndpointDeleteAsync()
        {
            var id = "abcabcabc";
            var data = new Dictionary<string, object>()
            {
                {"callback_url", "https://www.google.com"},
                {"callback_method", "POST"},
                {"is_voice_request", true}
            };
            var request =
                new PlivoRequest(
                    "DELETE",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Endpoint/" + id + "/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/asyncResponse.json"
                );
            Setup<AsyncResponse>(200, response);
            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Endpoint.DeleteAsync(id, 
                        callbackUrl: "https://www.google.com",
                        callbackMethod: "POST"
                    ).Result
                )
            );
            AssertRequest(request);
        }
    }
}