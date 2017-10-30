using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using NUnit.Framework;
using Plivo.Authentication;
using Plivo.Http;
using Plivo.Resource;
using Plivo.Resource.Account;

namespace Plivo.Test.Resources
{
    [TestFixture]
    public class TestAccount : BaseTestCase
    {
        [Test]
        public void TestAccountDetails()
        {
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX//",
                    "");
            
            var response = 
                System.IO.File.ReadAllText(
                SOURCE_DIR + @"Mocks/accountGetResponse.json"
            );
            Setup<Account>(
                200,
                response
            );
            Assert.IsEmpty(Util.Compare(response, Api.Account.Get()));
            AssertRequest(request);
        }
        
        [Test]
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
                    SOURCE_DIR + @"Mocks/accountModifyResponse.json"
                );
            Setup<UpdateResponse<Account>>(
                202,
                response
            );
            Assert.IsEmpty(Util.Compare(response, Api.Account.Update("name name name", "delhi")));
            
            CompareRequests(request, ((TestClient)Api.Client._client).Request);
            
        }
    }
}
