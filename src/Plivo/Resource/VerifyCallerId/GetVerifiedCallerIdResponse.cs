using Newtonsoft.Json;

namespace Plivo.Resource.VerifyCallerId
{
    [JsonObject(MemberSerialization.OptIn)]
    public class GetVerifiedCallerIdResponse : Resource
    {
        [JsonProperty("api_id")]
        public string ApiID { get; set; }
        
        [JsonProperty("alias")]
        public string Alias { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; } 
        
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; } 
        
        [JsonProperty("modified_at")]
        public string ModifiedAt { get; set; } 
        
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; } 
        
        [JsonProperty("subaccount")]
        public string Subaccount { get; set; } 
        
        [JsonProperty("verification_uuid")]
        public string VerificationUuid { get; set; } 
        
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}