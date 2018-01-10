using System.Collections.Generic;
using Xunit;
using Plivo.Http;
using Plivo.Resource;
using Plivo.Resource.RentedNumber;
using Plivo.Utilities;

namespace Plivo.NetCore.Test.Resources
{
    
    public class TestNumber : BaseTestCase
    {
        [Fact]
        public void TestRentedNumberList()
        {
            var data = new Dictionary<string, object>()
            {
                {"limit", 10}
            };
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Number/",
                    "",
                    data);
            
            var response = 
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/numberListResponse.json"
                );
            Setup<ListResponse<RentedNumber>>(
                200,
                response
            );
            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Number.List(limit:10)));
            
            AssertRequest(request);
        }
        
        [Fact]
        public void TestRentedNumberGet()
        {
            var id = "abcabcabc";
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Number/" + id + "/",
                    "");
            
            var response = 
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/numberGetResponse.json"
                );
            Setup<RentedNumber>(
                200,
                response
            );
            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Number.Get(id)));
            
            AssertRequest(request);
        }
        
        [Fact]
        public void TestRentedNumberAdd()
        {   
            var data = new Dictionary<string, object>()
            {
                {"numbers", "+919999999999,+919898989898"},
                {"carrier", "carry me"},
                {"region", "somewhere here"}
            };
            
            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Number/",
                    "",
                    data);
            
            var response = 
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/numberCreateResponse.json"
                );
            Setup<UpdateResponse<RentedNumber>>(
                200,
                response
            );
            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Number.AddNumber(new List<string>(){"+919999999999","+919898989898"}, "carry me", "somewhere here")));
            
            AssertRequest(request);
        }
        
        [Fact]
        public void TestNumberUpdate()
        {
            var id = "abcabcabc";
            var data = new Dictionary<string, object>()
            {
                {"alias", "alalaalalala"}
            };
            
            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Number/" + id + "/",
                    "",
                    data);
            
            var response = 
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/endpointUpdateResponse.json"
                );
            Setup<UpdateResponse<RentedNumber>>(
                202,
                response
            );
            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Number.Update(id, alias: "alalaalalala")));
            AssertRequest(request);
        }
        
        [Fact]
        public void TestNumberDelete()
        {
            var id = "abcabcabc";
            var request =
                new PlivoRequest(
                    "DELETE",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Number/" + id + "/",
                    "");
            
            var response = "";
            Setup<UpdateResponse<RentedNumber>>(
                204,
                response
            );
            Api.Number.Delete(id);
            AssertRequest(request);
        }
    }
}
