using System.Collections.Generic;
using Xunit;
using Plivo.Http;
using Plivo.Resource;
using Plivo.Resource.VerifySession;
using Plivo.Utilities;
using System;
using Xunit.Sdk;

namespace Plivo.NetCore.Test.Resources
{
    public class TestVerifySession : BaseTestCase
    {
        [Fact]
        public void TestVerifySessionCreate()
        {
            var data = new Dictionary<string, object>()
            {
                {"recipient", "+919999999999"}
            };

            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Verify/Session/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/verifySessionSendResponse.json"
                );
            Setup<VerifySessionCreateResponse>(
                202,
                response
            );
            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.VerifySession.Create(recipient:"+919999999999")));

            AssertRequest(request);

        }

        [Fact]
        public void TestVerifySessionGet()
        {
            var session_id = "4124e518-a8c9-4feb-8cff-d86636ba9234";
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Verify/Session/" + session_id + "/",
                    "");
            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"Mocks/verifySessionGetResponse.json"
                );
            Setup<VerifySession>(
                200,
                response
            );

            Assert.IsEmpty(ComparisonUtilities.Compare(response, Api.VerifySession.Get(session_uuid: "4124e518-a8c9-4feb-8cff-d86636ba9234")));
            AssertRequest(request);
        }

        [Fact]
        public void TestVerifySessionList()
        {
            var data = new Dictionary<string, object>()
            {
                {"limit", 10}
            };
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Verify/Session/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/verifySessionListResponse.json"
                );
            Setup<VerifySessionListResponse<VerifySession>>(
                200,
                response
            );
            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.VerifySession.List(limit: 10)));

            AssertRequest(request);
        }

        [Fact]
        public void TestVerifySessionValidate()
        {
            var session_id = "5b40a428-bfc7-4daf-9d06-726c558bf3b8";
            var data = new Dictionary<string, object>()
            {
                {"otp", "819078"}
            };

            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Verify/Session/" + session_id + "/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/verifySessionValidateResponse.json"
                );
            Setup<VerifySessionCreateResponse>(
                200,
                response
            );
            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.VerifySession.Validate(session_uuid: "5b40a428-bfc7-4daf-9d06-726c558bf3b8",
                    otp:"819078")));

            AssertRequest(request);

        }
    }
}