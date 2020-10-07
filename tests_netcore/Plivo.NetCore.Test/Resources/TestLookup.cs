using System.Collections.Generic;
using NUnit.Framework;
using Plivo.Http;
using Plivo.Resource;
using Plivo.Resource.Lookup;
using Plivo.Utilities;

namespace Plivo.NetCore.Test.Resources
{
    [TestFixture]
    public class TestLookup : BaseTestCase
    {
        [Test]
        public void TestLookupGet()
        {
            var number = "14154305555";
            var request =
                new PlivoRequest(
                    "GET",
                    "Lookup/Number/" + number + "?type=carrier",
                    "");

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/lookupGetResponse.json"
                );
            Setup<Number>(
                200,
                response
            );
            Assert.IsEmpty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Lookup.Get(number)));

            AssertRequest(request);
        }
    }
}
