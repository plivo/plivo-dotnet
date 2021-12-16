using Newtonsoft.Json;
using System.Threading.Tasks;
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
        [JsonProperty("us_cellular")]
        public TPMDetail UsCellular { get; set; }
        [JsonProperty("verizon_wireless")]
        public TPMDetail VerizonWireless { get; set; }
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
        public new string api_id {get; set;}

        [JsonProperty("campaigns")]
        public CampaignResponse Campaigns {get; set;}

        // [JsonProperty("brand_id")]
        // public string BrandId { get; set; }

        // [JsonProperty("campaign_id")]
        // public string CampaignId { get; set; }

        // [JsonProperty("mno_metadata")]
        // public MnoMetaData MnoMetadata { get; set; }

        // [JsonProperty("reseller_id")]
        // public string ResellerId { get; set; }

        // [JsonProperty("usecase")]
        // public string Usecase { get; set; }  
    }

}