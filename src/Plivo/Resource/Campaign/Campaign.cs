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

        [JsonProperty("sub_usecase")]
        public string SubUsecase { get; set; }
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
        
        [JsonProperty("campaignId")]
        public new string CampaignId {get; set;}

        [JsonProperty("message")]
        public new string Messgae {get; set;}
        
        [JsonProperty("error")]
        public new string Error {get; set;}

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