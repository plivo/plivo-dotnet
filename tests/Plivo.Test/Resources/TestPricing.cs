using System.Collections.Generic;
using NUnit.Framework;
using Plivo.Http;
using Plivo.Resource.Pricing;
using Plivo.Utilities;

namespace Plivo.Test.Resources
{
    [TestFixture]
    public class TestPricing : BaseTestCase
    {
        [Test]
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
                    SOURCE_DIR + @"Mocks/pricingGetResponse.json"
                );
            Setup<Pricing>(
                200,
                response
            );
            Assert.IsEmpty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Pricing.Get("US")));

            AssertRequest(request);
        }
    }
}