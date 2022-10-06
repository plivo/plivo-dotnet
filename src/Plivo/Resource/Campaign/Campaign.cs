using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Plivo.Resource.Campaign
{
    /// <summary>
    /// Campaign.
    /// </summary>

     public class MnoMetaData {
        [JsonProperty("at&t")]
        public TPMDetail At_t { get; set; }
        [JsonProperty("t-mobile")]
        public TPMDetail Tmobile { get; set; }
        [JsonProperty("us cellular")]
        public TPMDetail UsCellular { get; set; }
        [JsonProperty("verizon wireless")]
        public TPMDetail VerizonWireless { get; set; }
    }

    public class CampaignAttributes {
        [JsonProperty("subscriber_optin")]
        public string SubscriberOptin { get; set; }
        [JsonProperty("subscriber_optout")]
        public string SubscriberOptout { get; set; }
        [JsonProperty("embedded_link")]
        public string EmbeddedLink { get; set; }
        [JsonProperty("embedded_phone")]
        public string EmbeddedPhone { get; set; }
        [JsonProperty("age_gated")]
        public string AgeGated { get; set; }
        [JsonProperty("direct_lending")]
        public string DirectLending { get; set; }
        [JsonProperty("subscriber_help")]
        public string SubscriberHelp { get; set; }
        [JsonProperty("affiliate_marketing")]
        public string AffiliateMarketing { get; set; }
    }

    public class TPMDetail {
        [JsonProperty("tpm")]
        public string tpm { get; set; }
        [JsonProperty("brand_tier")]
        public string brand_tier { get; set; }
    }

    public class CampaignResponse 
    {
        [JsonProperty("brand_id")]
        public string BrandId { get; set; }

        [JsonProperty("campaign_id")]
        public string CampaignId { get; set; }

        [JsonProperty("mno_metadata")]
        public MnoMetaData MnoMetadata { get; set; }

        [JsonProperty("reseller_id")]
        public string ResellerId { get; set; }

        [JsonProperty("usecase")]
        public string Usecase { get; set; }  

        [JsonProperty("sub_usecase")]
        public string SubUsecase { get; set; }

        [JsonProperty("sample1")]
        public string Sample1 { get; set; }

        [JsonProperty("sample2")]
        public string Sample2 { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("campaign_attributes")]
        public CampaignAttributes CampaignAttributes { get; set; }
        

        [JsonProperty("message_flow")]
        public string MessageFlow { get; set; }
        
        [JsonProperty("help_message")]
        public string HelpMessage { get; set; }
        
        [JsonProperty("optin_keywords")]
        public string OptinKeywords { get; set; }
        
        [JsonProperty("optin_message")]
        public string OptinMessage { get; set; }
        
        [JsonProperty("optout_keywords")]
        public string OptoutKeywords { get; set; }
        
        [JsonProperty("optout_message")]
        public string OptoutMessage { get; set; }
        
        [JsonProperty("help_keywords")]
        public string HelpKeywords { get; set; }


    }

   [JsonObject(MemberSerialization.OptIn)]
    public class GetCampaign: Resource
    {   
        [JsonProperty("api_id")]
        public new string ApiId {get; set;}

        [JsonProperty("campaign")]
        public CampaignResponse Campaign {get; set;}

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class CreateCampaign: Resource
    {   
        [JsonProperty("api_id")]
        public new string ApiId {get; set;}
        
        [JsonProperty("campaign_id")]
        public new string CampaignId {get; set;}

        [JsonProperty("message")]
        public new string Messgae {get; set;}
        

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class ListCampaigns: Resource
    { 

        [JsonProperty("brand_id")]
        public string BrandId { get; set; }

        [JsonProperty("campaign_id")]
        public string CampaignId { get; set; }

        [JsonProperty("mno_metadata")]
        public MnoMetaData MnoMetadata { get; set; }

        [JsonProperty("reseller_id")]
        public string ResellerId { get; set; }

        [JsonProperty("usecase")]
        public string Usecase { get; set; } 

        [JsonProperty("sub_usecase")]
        public string SubUsecase { get; set; } 

        [JsonProperty("sample1")]
        public string Sample1 { get; set; }

        [JsonProperty("sample2")]
        public string Sample2 { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("campaign_attributes")]
        public CampaignAttributes CampaignAttributes { get; set; }

        [JsonProperty("message_flow")]
        public string MessageFlow { get; set; }
        
        [JsonProperty("help_message")]
        public string HelpMessage { get; set; }
        
        [JsonProperty("optin_keywords")]
        public string OptinKeywords { get; set; }
        
        [JsonProperty("optin_message")]
        public string OptinMessage { get; set; }
        
        [JsonProperty("optout_keywords")]
        public string OptoutKeywords { get; set; }
        
        [JsonProperty("optout_message")]
        public string OptoutMessage { get; set; }
        
        [JsonProperty("help_keywords")]
        public string HelpKeywords { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }

    public class NumberObject
    {
        [JsonProperty("number")]
        public string number { get; set; }
        [JsonProperty("status")]
        public string status { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class Number:Resource
    {
        [JsonProperty("apiId")]
        public string ApidID { get; set; }  

        [JsonProperty("campaign_alias")]
        public string campaign_alias { get; set; }  
        
        [JsonProperty("usecase")]
        public string Usecase { get; set; }  

        [JsonProperty("campaign_id")]
        public string CampaignId { get; set; }

        [JsonProperty("phone_numbers")]
        public List<NumberObject> PhoneNumbers { get; set; }  
        [JsonProperty("phone_numbers_summary")]
        public Dictionary<string, int> PhoneNumbersSummary { get; set; }  
        [JsonProperty("number_pool_limit")]
        public int NumberPoolLimit { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class LinkNumber:Resource
    {
        [JsonProperty("apiId")]
        public string ApidID { get; set; } 
                
        [JsonProperty("message")]
        public string Message { get; set; } 

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
    public class DeleteNumber{

    }

}