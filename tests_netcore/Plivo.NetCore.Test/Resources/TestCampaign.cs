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
        public void TestCampaignCreate()
        {
            var data = new Dictionary<string, object>()
            {
                {"campaign_alias", "campaign_test_name"},
                {"brand_id", "BYEKDY1"},
                {"vertical", "REAL_ESTATE"},
                {"usecase", "MIXED"},
                {"description", "description should be minimum 40 character"},
                {"embedded_link", false},
                {"embedded_phone", false},
                {"age_gated", false},
                {"direct_lending", false},
                {"subscriber_optin", true},
                {"subscriber_optout", true},
                {"subscriber_help", true},
                {"affiliate_marketing", false},
                {"sample1", "sample message 1"},
                {"sample2", "sample message 2"},
                {"message_flow", "message_flow"},
                {"help_message", "help_message"},
                {"optout_message", "optout_message"},
                {"sub_usecases", new string[]{}},
                {"url", "https://test.exmple.com/v1"}, 
                {"method", "POST"},
                {"optin_keywords", "optin_keywords"},
                {"optin_message", "optin_message"},
                {"optout_keywords", "optout_keywords"},
                {"help_keywords", "help_keywords"}
            };

            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/10dlc/Campaign/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/campaignCreateResponse.json"
                );
            Setup<CreateCampaign>(
                200,
                response
            );
            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Campaign.Create(campaign_alias:"campaign_test_name",brand_id:"BYEKDY1",vertical:"REAL_ESTATE", usecase:"MIXED",description:"description should be minimum 40 character",  embedded_link:false,embedded_phone:false,  age_gated:false,
             direct_lending:false,  subscriber_optin:true,  subscriber_optout:true,  subscriber_help:true, 
             affiliate_marketing:false,  sample1:"sample message 1",  sample2:"sample message 2",  message_flow:"message_flow",  help_message:"help_message",  optout_message:"optout_message", sub_usecases: new string[]{},  url:"https://test.exmple.com/v1",  method:"POST",  optin_keywords:"optin_keywords", optin_message:"optin_message", optout_keywords:"optout_keywords", help_keywords:"help_keywords")));

            AssertRequest(request);
        }

        [Fact]
        public void TestCampaignGet()
        {
            var id = "CCMZZOS";
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