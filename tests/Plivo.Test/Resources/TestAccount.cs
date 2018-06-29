using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Xunit;
using Plivo.Authentication;
using Plivo.Http;
using Plivo.Resource;
using Plivo.Resource.Account;
using Plivo.Utilities;

namespace Plivo.NetCore.Test.Resources
{
    public class TestAccount : BaseTestCase
    {
        [Fact]
        public void TestAccountDetails()
        {
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/",
                    "");

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/accountGetResponse.json"
                );
            Setup<Account>(
                200,
                response
            );
            Assert.Empty(ComparisonUtilities.Compare(response, Api.Account.Get()));
            AssertRequest(request);
        }

        [Fact]
        public void TestAccountModifyResponse()
        {
            var data = new Dictionary<string, object>()
            {
                {"city", "delhi"},
                {"name", "name name name"},
            };
            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/accountModifyResponse.json"
                );
            Setup<UpdateResponse<Account>>(
                202,
                response
            );
            Assert.Empty(ComparisonUtilities.Compare(response, Api.Account.Update("name name name", "delhi")));

            CompareRequests(request, ((TestClient) Api.Client._client).Request);
        }
    }
}