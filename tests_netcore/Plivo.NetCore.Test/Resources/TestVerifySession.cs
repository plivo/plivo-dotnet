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

            Assert.Empty(ComparisonUtilities.Compare(response, Api.VerifySession.Get(session_uuid: "4124e518-a8c9-4feb-8cff-d86636ba9234")));
            AssertRequest(request);
        }

        [Fact]
        public void TestVerifySessionGetUsdAccountHasNoInrFields()
        {
            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/verifySessionGetUsdResponse.json"
                );
            Setup<VerifySession>(200, response);

            var session = Api.VerifySession.Get(session_uuid: "4124e518-a8c9-4feb-8cff-d86636ba9234");

            Assert.Equal("0.00500", session.Charges.TotalCharge);
            Assert.Null(session.Charges.TotalChargeInr);
            Assert.Equal("0.00500", session.Charges.AttemptCharges[0].Charge);
            Assert.Null(session.Charges.AttemptCharges[0].ChargeInr);
            Assert.Equal(0.005, session.AttemptDetails[0].Amount);
            Assert.Null(session.AttemptDetails[0].AmountInr);
        }

        [Fact]
        public void TestVerifySessionGetInrAccount()
        {
            var session_id = "4124e518-a8c9-4feb-8cff-d86636ba9234";
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Verify/Session/" + session_id + "/",
                    "");
            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/verifySessionGetInrResponse.json"
                );
            Setup<VerifySession>(200, response);

            var session = Api.VerifySession.Get(session_uuid: session_id);

            Assert.Equal("0.00500", session.Charges.TotalCharge);
            Assert.Equal("0.41500", session.Charges.TotalChargeInr);
            Assert.Equal(2, session.Charges.AttemptCharges.Length);
            Assert.Equal("0.41500", session.Charges.AttemptCharges[0].ChargeInr);
            Assert.Equal("0.00000", session.Charges.AttemptCharges[1].ChargeInr);
            Assert.Equal(2, session.AttemptDetails.Length);
            Assert.Equal(0.005, session.AttemptDetails[0].Amount);
            Assert.Equal(0.415, session.AttemptDetails[0].AmountInr);
            // A genuine zero stays distinguishable from "absent".
            Assert.Equal(0.0, session.AttemptDetails[1].Amount);
            Assert.Equal(0.0, session.AttemptDetails[1].AmountInr);
            AssertRequest(request);
        }

        [Fact]
        public void TestVerifySessionListInrAccount()
        {
            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/verifySessionListInrResponse.json"
                );
            Setup<VerifySessionListResponse<VerifySession>>(200, response);

            var sessions = Api.VerifySession.List(limit: 10);

            Assert.Equal(2, sessions.Sessions.Count);
            Assert.Equal("0.41500", sessions.Sessions[0].Charges.TotalChargeInr);
            Assert.Equal("0.41500", sessions.Sessions[0].Charges.AttemptCharges[0].ChargeInr);
            Assert.Equal(0.005, sessions.Sessions[0].AttemptDetails[0].Amount);
            Assert.Equal(0.415, sessions.Sessions[0].AttemptDetails[0].AmountInr);
            // Validation charge has no INR value, so the session total is omitted
            // while the per-attempt INR charge is still present.
            Assert.Null(sessions.Sessions[1].Charges.TotalChargeInr);
            Assert.Equal("0.83000", sessions.Sessions[1].Charges.AttemptCharges[0].ChargeInr);
            Assert.Equal(0.01, sessions.Sessions[1].AttemptDetails[0].Amount);
            Assert.Equal(0.83, sessions.Sessions[1].AttemptDetails[0].AmountInr);
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