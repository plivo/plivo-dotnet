using Newtonsoft.Json;

namespace Plivo.Resource.Campaign
{
    /// <summary>
    /// Campaign.
    /// </summary>

     public class MnoMetaData {
        public TPMDetail at_t { get; set; }
        public TPMDetail t_mobile { get; set; }
        public TPMDetail us_cellular { get; set; }
        public TPMDetail verizon_wireless { get; set; }
    }

    public class TPMDetail {
        public string tpm { get; set; }
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
    }

   [JsonObject(MemberSerialization.OptIn)]
    public class GetCampaign: Resource
    {   
        [JsonProperty("api_id")]
        public new string api_id {get; set;}

        [JsonProperty("campaign")]
        public CampaignResponse Campaign {get; set;}
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class ListCampaigns: Resource
    {  
        [JsonProperty("api_id")]
        public new string ApiId {get; set;}

        [JsonProperty("campaigns")]
        public CampaignResponse Campaigns {get; set;}
    }

}