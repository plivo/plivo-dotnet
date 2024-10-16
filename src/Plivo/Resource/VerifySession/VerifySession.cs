using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace Plivo.Resource.VerifySession
{

    public class AttemptCharge {
        [JsonProperty("attempt_uuid")]
        public string AttemptUUID { get; set; }
        [JsonProperty("channel")]
        public string Channel { get; set; }
        [JsonProperty("charge")]
        public string Charge { get; set; }
    }

    public class Charges {
        [JsonProperty("total_charge")]
        public string TotalCharge { get; set; }
        [JsonProperty("validation_charge")]
        public string ValidationCharge { get; set; }
        [JsonProperty("attempt_charges")]
        public AttemptCharge[] AttemptCharges { get; set; }
    }

    public class AttemptDetail {
        [JsonProperty("channel")]
        public string Channel { get; set; }
        [JsonProperty("attempt_uuid")]
        public string AttemptUUID { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("time")]
        public string Time { get; set; }
        [JsonProperty("brand_name")]
        public string BrandName {get; set;}
        [JsonProperty("app_hash")]
        public string AppHash {get; set;}
        [JsonProperty("code_length")]
        public int CodeLength {get; set;}
        [JsonProperty("dtmf")]
        public int? Dtmf {get; set;}
        [JsonProperty("fraud_check")]
        public string FraudCheck {get; set;}
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class VerifySession : Resource
    { 


        [JsonProperty("session_uuid")]
        public string SessionUUID { get; set; }

        [JsonProperty("app_uuid")]
        public string AppUUID { get; set; }

        [JsonProperty("alias")]
        public string Alias { get; set; }

        [JsonProperty("recipient")]
        public string Recipient { get; set; } 

        [JsonProperty("channel")]
        public string Channel { get; set; } 

        [JsonProperty("locale")]
        public string Locale { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("count")]
        public string Count { get; set; }
        [JsonProperty("requestor_ip")]
        public string RequestorIP { get; set; }
        [JsonProperty("destination_country_iso2")]
        public string DestinationCountryISO2 { get; set; }

        [JsonProperty("destination_network")]
        public string DestinationNetwork { get; set; }
        
        [JsonProperty("attempt_details")]
        public AttemptDetail[] AttemptDetails { get; set; }
        
        [JsonProperty("charges")]
        public Charges Charges { get; set; }
        
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }
        
        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }
        

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }

}
