using Xunit;
using System.Collections.Generic;
using System.Threading.Tasks;
using Plivo.Http;
using Plivo.Resource;
using Plivo.Resource.TollfreeVerification;
using Plivo.Utilities;

namespace Plivo.NetCore.Test.Resources
{
    public class TestTollfreeVerification : BaseTestCase
    {
        [Fact]
        public void TestCreateTollfreeVerification()
        {
            var data = new Dictionary<string, object>()
            {
                { "usecase", "HIGHER_EDUCATION,2FA" },
                { "number", "18339920058" },
                { "profile_uuid", "fb239ee1-fb5c-4dd9-b55c-5cf10170e758" },
                { "optin_type", "VERBAL" },
                { "volume", "10" },
                { "usecase_summary", "test usecase summary" },
                { "message_sample", "test message sample" },
                { "optin_image_url", "https://www.test.com" },
                { "callback_url", "https://testcallback.com" },
                { "callback_method", "GET" },
                { "additional_information", "test additional information" },
                { "extra_data", "test extradata" },
            };
            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/TollfreeVerification/",
                    "",
                    data);

            var response = System.IO.File.ReadAllText(
                SOURCE_DIR + @"../Mocks/tollfreeVerificationCreateResponse.json"
            );

            Setup<TollfreeVerificationCreateResponse>(201, response);

            Assert.Empty(
                ComparisonUtilities.Compare(
                    response, Api.TollfreeVerification.Create(
                        "fb239ee1-fb5c-4dd9-b55c-5cf10170e758",
                        "18339920058",
                        "HIGHER_EDUCATION,2FA",
                        "test usecase summary",
                        "test message sample",
                        "https://www.test.com",
                        "VERBAL",
                        "10",
                        "test additional information",
                        "test extradata",
                        "https://testcallback.com",
                        "GET"
                    )
                ));
            AssertRequest(request);
        }

        [Fact]
        public void TestCreateTollfreeVerificationAsync()
        {
            var data = new Dictionary<string, object>()
            {
                { "usecase", "HIGHER_EDUCATION,2FA" },
                { "number", "18339920058" },
                { "profile_uuid", "fb239ee1-fb5c-4dd9-b55c-5cf10170e758" },
                { "optin_type", "VERBAL" },
                { "volume", "10" },
                { "usecase_summary", "test usecase summary" },
                { "message_sample", "test message sample" },
                { "optin_image_url", "https://www.test.com" },
                { "callback_url", "https://testcallback.com" },
                { "callback_method", "POST" },
                { "additional_information", "test additional information" },
                { "extra_data", "test extradata" },
            };
            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/TollfreeVerification/",
                    "",
                    data);

            var response = System.IO.File.ReadAllText(
                SOURCE_DIR + @"../Mocks/tollfreeVerificationCreateResponse.json"
            );

            Setup<TollfreeVerificationCreateResponse>(201, response);

            Assert.Empty(
                ComparisonUtilities.Compare(
                    response, Api.TollfreeVerification.CreateAsync(
                        "fb239ee1-fb5c-4dd9-b55c-5cf10170e758",
                        "18339920058",
                        "HIGHER_EDUCATION,2FA",
                        "test usecase summary",
                        "test message sample",
                        "https://www.test.com",
                        "VERBAL",
                        "10",
                        "test additional information",
                        "test extradata",
                        "https://testcallback.com",
                        "POST"
                    ).Result
                ));
            AssertRequest(request);
        }

        [Fact]
        public void TestTollfreeVerificationList()
        {
            var data = new Dictionary<string, object>()
            {
                { "limit", 20 },
                { "offset", 0 }
            };
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/TollfreeVerification/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/tollfreeVerificationListResponse.json"
                );
            Setup<ListResponse<TollfreeVerification>>(200, response);
            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.TollfreeVerification.List(20, 0)
                )
            );

            AssertRequest(request);
        }

        [Fact]
        public void TestTollfreeVerificationListAsync()
        {
            var data = new Dictionary<string, object>()
            {
                { "limit", 20 },
                { "offset", 0 }
            };
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/TollfreeVerification/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/tollfreeVerificationListResponse.json"
                );
            Setup<TollfreeVerificationListResponse<TollfreeVerification>>(200, response);
            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.TollfreeVerification.ListAsync(20, 0).Result
                )
            );

            AssertRequest(request);
        }

        [Fact]
        public void TestTollfreeVerificationGet()
        {
            var uuid = "28f736dc-680c-5ae4-6765-01732884e41e";

            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/TollfreeVerification/" + uuid + "/",
                    "");

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/tollfreeVerificationGetResponse.json"
                );
            Setup<TollfreeVerification>(
                200,
                response
            );
            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.TollfreeVerification.Get(uuid)));

            AssertRequest(request);
        }

        [Fact]
        public void TestTollfreeVerificationGetAsync()
        {
            var uuid = "28f736dc-680c-5ae4-6765-01732884e41e";

            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/TollfreeVerification/" + uuid + "/",
                    "");

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/tollfreeVerificationGetResponse.json"
                );
            Setup<TollfreeVerification>(200, response);
            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.TollfreeVerification.GetAsync(uuid).Result
                )
            );

            AssertRequest(request);
        }

        [Fact]
        public void TestTollfreeVerificationUpdate()
        {
            var uuid = "28f736dc-680c-5ae4-6765-01732884e41e";
            var data = new Dictionary<string, object>()
            {
                { "callback_url", "http://updated.callback.url" },
                { "callback_method", "POST" },
                { "usecase", "2FA" },
            };

            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/TollfreeVerification/" + uuid + "/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/tollfreeVerificationUpdateResponse.json"
                );
            Setup<UpdateResponse<TollfreeVerification>>(
                202,
                response
            );
            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.TollfreeVerification.Update(uuid, usecase: "2FA", callbackUrl: "http://updated.callback.url",
                        callbackMethod: "POST")));
            AssertRequest(request);
        }

        [Fact]
        public void TestTollfreeVerificationUpdateAsync()
        {
            var uuid = "28f736dc-680c-5ae4-6765-01732884e41e";
            var data = new Dictionary<string, object>()
            {
                { "callback_url", "http://updated.callback.url" },
                { "callback_method", "POST" },
                { "usecase", "2FA" },
            };

            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/TollfreeVerification/" + uuid + "/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/tollfreeVerificationUpdateResponse.json"
                );
            Setup<AsyncResponse>(200, response);
            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.TollfreeVerification.UpdateAsync(uuid, usecase: "2FA",
                        callbackUrl: "http://updated.callback.url", callbackMethod: "POST").Result
                )
            );
            AssertRequest(request);
        }
        
        [Fact]
        public void TestTollfreeVerificationDelete()
        {
            var uuid = "28f736dc-680c-5ae4-6765-01732884e41e";
            var request =
                new PlivoRequest(
                    "DELETE",
                    "Account/MAXXXXXXXXXXXXXXXXXX/TollfreeVerification/" + uuid + "/",
                    "");

            var response = "";
            Setup<DeleteResponse<TollfreeVerification>>(
                204,
                response
            );
            Assert.Null(Api.TollfreeVerification.Delete(uuid));
            AssertRequest(request);
        }
        
        [Fact]
        public void TestTollfreeVerificationDeleteAsync()
        {
            var uuid = "28f736dc-680c-5ae4-6765-01732884e41e";
           
            var request =
                new PlivoRequest(
                    "DELETE",
                    "Account/MAXXXXXXXXXXXXXXXXXX/TollfreeVerification/" + uuid + "/",
                    "");

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/asyncResponse.json"
                );
            Setup<AsyncResponse>(204, response);
            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.TollfreeVerification.DeleteAsync(uuid).Result
                )
            );
            
            AssertRequest(request);
        }
    }
}