using Xunit;
using System.Collections.Generic;
using Plivo.Http;
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
            
            Setup<TollfreeVerificationCreateResponse>(201,response);
            
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
        
    }
}