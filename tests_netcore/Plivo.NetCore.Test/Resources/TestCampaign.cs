using System.Collections.Generic;
using Xunit;
using Plivo.Http;
using Plivo.Resource;
using Plivo.Resource.Campaign;
using Plivo.Utilities;
using System;

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
            Setup<ListResponse<ListCampaigns>>(
                200,
                response
            );
            var resp = Api.Campaign.List();
           
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
            var resp = Api.Campaign.Get(id);
            // Assert.Empty(
            //     ComparisonUtilities.Compare(
            //         response,
            //         Api.Campaign.Get(id)));

            AssertRequest(request);
        }

        [Fact]
        public void TestCampaignListNumber()
        {
            var campaignID = "CRIGC80";
            var data = new Dictionary<string, object>();
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/10dlc/Campaign/"+campaignID+"/Number/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/campaignListNumberResponse.json"
                );
            Setup<Number>(
                200,
                response
            );
            var resp = Api.Campaign.ListNumber(campaignID);
           
            AssertRequest(request);
        }

        [Fact]
        public void TestCampaignGetNumber()
        {
            var campaignID = "CRIGC80";
            var number = "14845007032";
            var data = new Dictionary<string, object>();
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/10dlc/Campaign/"+campaignID+"/Number/"+number+"/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/campaignGetNumberResponse.json"
                );
            Setup<Number>(
                200,
                response
            );
            var resp = Api.Campaign.GetNumber(campaignID, number);
           
            AssertRequest(request);
        }
    }
}