using System.Collections.Generic;
using Xunit;
using Plivo.Http;
using Plivo.Resource;
using Plivo.Resource.Campaign;
using Plivo.Utilities;

namespace Plivo.NetCore.Test.Resources
{
    public class TestCampaign : BaseTestCase
    {
        [Fact]
        public void TestCampaignList()
        {
            var data = new Dictionary<string, object>();
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/10dlc/Campaign/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/campaignListResponse.json"
                );
            Setup<ListResponse<ListCampaign>>(
                200,
                response
            );
            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Campaign.List()));

            AssertRequest(request);
        }

        [Fact]
        public void TestCampaignGet()
        {
            var id = "CMPT4EP";
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/10dlc/Campaign/" + id + "/",
                    "");

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/campaignGetResponse.json"
                );
            Setup<GetCampaign>(
                200,
                response
            );
            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Campaign.Get(id)));

            AssertRequest(request);
        }
    }
}