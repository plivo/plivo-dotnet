using System.Collections.Generic;
using NUnit.Framework;
using Plivo.Http;
using Plivo.Resource;
using Plivo.Resource.VerifyCallerId;
using Plivo.Utilities;
using System;
using Plivo.Test;

namespace Plivo.Test.Resources
{
    [TestFixture]
    public class TestVerifyCallerId : BaseTestCase
    {
        [Test]
        public void TestVerifyCallerIdInitiate()
        {
            var data = new Dictionary<string, object>()
            {
                {"phone_number", "+919999999999"}
            };

            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/VerifiedCallerId/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/initiateVerifyResponse.json"
                );
            Setup<InitiateVerifyResponse>(
                202,
                response
            );
            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.VerifyCallerId.Initiate(phoneNumber:"+919999999999")));

            AssertRequest(request);

        }
        
        [Test]
        public void TestVerifyCallerIdVerify()
        {
            var data = new Dictionary<string, object>()
            {
                {"otp", "123456"}
            };
            var verification_uuid = "4124e518-a8c9-4feb-8cff-d86636ba9234";
            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/VerifiedCallerId/Verification/" + verification_uuid ,
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/verifyCallerIdResponse.json"
                );
            Setup<VerifyCallerId>(
                202,
                response
            );
            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.VerifyCallerId.Verify(otp:"123456",verification_uuid)));

            AssertRequest(request);
        }
        
        [Test]
        public void TestVerifyCallerIdGet()
        {
            var phoneNumber = "+919999999999";
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/VerifiedCallerId/" + phoneNumber,
                    "");
            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"Mocks/getVerifiedCallerIdResponse.json"
                );
            Setup<GetVerifiedCallerIdResponse>(
                200,
                response
            );

            Assert.Empty(ComparisonUtilities.Compare(response, Api.VerifyCallerId.Verify(phoneNumber: "+919999999999")));
            AssertRequest(request);
        }
        
        [Test]
        public void TestVerifyCallerIdList()
        {
            var data = new Dictionary<string, object>()
            {
                {"limit", 10}
            };
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/VerifiedCallerId/",
                    "");
            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"Mocks/listVerifiedCallerIdResponse.json"
                );
            Setup<ListResponse<ListVerifiedCallerIdResponse>>(
                200,
                response
            );
            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.VerifyCallerId.List(limit: 10)));

            AssertRequest(request);
        }
        
        
    }
    
}
