using Xunit;
using Plivo.Http;
using Plivo.Resource.Pricing;
using System.Collections.Generic;
using Plivo.Utilities;

namespace Plivo.NetCore.Test.Resources
{
    public class TestPricing : BaseTestCase
    {
        [Fact]
        public void TestPricingGet()
        {
            var data = new Dictionary<string, object>()
            {
                {"country_iso", "US"},
            };
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Pricing/",
                    "", data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/pricingGetResponse.json"
                );
            Setup<Pricing>(
                200,
                response
            );
            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Pricing.Get("US")));

            AssertRequest(request);
        }
    }
}