using Xunit;
using Plivo.Http;
using Plivo.Resource.Pricing;

namespace Plivo.NetCore.Test.Resources
{
    
    public class TestPricing : BaseTestCase
    {
        [Fact]
        public void TestPricingGet()
        {
            var id = "abcabcabc";
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Pricing/" + id + "/",
                    "");
            
            var response = 
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/pricingGetResponse.json"
                );
            Setup<Pricing>(
                200,
                response
            );
            Assert.Empty(
                Util.Compare(
                    response,
                    Api.Pricing.Get(id)));
            
            AssertRequest(request);
        }
    }
}
