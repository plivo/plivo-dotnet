using System.Collections.Generic;
using NUnit.Framework;
using Plivo.Http;
using Plivo.Resource;
using Plivo.Resource.Account;
using Plivo.Resource.Subaccount;

namespace Plivo.Test.Resources
{
    [TestFixture]
    public class TestSubaccount : BaseTestCase
    {
        [Test]
        public void TestSubaccountCreate()
        {
            var data = new Dictionary<string, object>()
            {
                {"name", "naam"},
                {"enabled", true}
            };
            
            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Subaccount/",
                    "",
                    data);
            
            var response = 
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"Mocks/subaccountCreateResponse.json"
                );
            Setup<SubaccountCreateResponse>(
                201,
                response
            );
            Assert.IsEmpty(
                Util.Compare(
                    response,
                    Api.Subaccount.Create("naam", true)));
            AssertRequest(request);
        }
        
        [Test]
        public void TestAccountGet()
        {
            var id = "abcabcabc";
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Subaccount/" + id + "/",
                    "");
            
            var response = 
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"Mocks/subaccountGetResponse.json"
                );
            Setup<Account>(
                200,
                response
            );
            Assert.IsEmpty(Util.Compare(response, Api.Subaccount.Get(id)));
            AssertRequest(request);
        }
        
        [Test]
        public void TestAccountList()
        {
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Subaccount/",
                    "");
            
            var response = 
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"Mocks/subaccountListResponse.json"
                );
            Setup<Account>(
                200,
                response
            );
            Assert.IsEmpty(Util.Compare(response, Api.Subaccount.List()));
            AssertRequest(request);
        }
        
        [Test]
        public void TestAccountModifyResponse()
        {
            var id = "abcabcabc";
            var data = new Dictionary<string, object>()
            {
                {"enabled", true},
                {"name", "naam"}
            };
            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Subaccount/" + id + "/",
                    "",
                    data);
            
            var response = 
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"Mocks/subaccountModifyResponse.json"
                );
            Setup<UpdateResponse<Account>>(
                202,
                response
            );
            Assert.IsEmpty(Util.Compare(response, Api.Subaccount.Update(id, "naam", true)));
            
            CompareRequests(request, ((TestClient)Api.Client._client).Request);
            
        }
        
        [Test]
        public void TestSubaccountDelete()
        {
            var id = "abcabcabc";
            var request =
                new PlivoRequest(
                    "DELETE",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Subaccount/" + id + "/",
                    "");
            
            var response = "";
            Setup<UpdateResponse<Subaccount>>(
                204,
                response
            );
            Assert.IsNull(Api.Subaccount.Delete(id));
            AssertRequest(request);
        }
    }
}
