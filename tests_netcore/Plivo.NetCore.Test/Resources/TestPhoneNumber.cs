using System.Collections.Generic;
using Xunit;
using Plivo.Http;
using Plivo.Resource;
using Plivo.Resource.PhoneNumber;
using Plivo.Utilities;

namespace Plivo.NetCore.Test.Resources
{
    
    public class TestPhoneNumber : BaseTestCase
    {
        [Fact]
        public void TestPhoneNumberList()
        {
            var data = new Dictionary<string, object>()
            {
                {"country_iso", "IN"},
                {"limit", 12}
            };
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/PhoneNumber/",
                    "",
                    data);
            
            var response = 
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/phoneNumberListResponse.json"
                );
            Setup<ListResponse<PhoneNumber>>(
                200,
                response
            );
            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.PhoneNumber.List("IN", limit:12)));
            
            AssertRequest(request);
        }
        
        [Fact]
        public void TestPhoneNumberBuy()
        {
            var id = "abcabcabc";
            var data = new Dictionary<string, object>()
            {
                {"app_id", "123"}
            };
            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/PhoneNumber/" + id + "/",
                    "",
                    data);
            
            var response = 
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/phoneNumberCreateResponse.json"
                );
            Setup<PhoneNumberBuyResponse>(
                201,
                response
            );
            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.PhoneNumber.Buy(id, "123")));
            
            AssertRequest(request);
        }
    }
}
