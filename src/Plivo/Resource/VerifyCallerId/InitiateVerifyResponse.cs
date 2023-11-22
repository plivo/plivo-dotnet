using Newtonsoft.Json;

namespace Plivo.Resource.VerifyCallerId
{   
    [JsonObject(MemberSerialization.OptIn)]
    public class InitiateVerifyResponse  : Resource
    {
        [JsonProperty("api_id")]
        public new string ApiId { get; set; }

        [JsonProperty("verification_uuid")]
        public new string VerificationUuid { get; set; }

        [JsonProperty("message")]
        public new string Message { get; set; }

        [JsonProperty("error", NullValueHandling = NullValueHandling.Ignore)] // Ignore null values for "error"
        public string Error { get; set; }

        public override string ToString()
        {
            var settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore // Ignore null values globally
            };

            return JsonConvert.SerializeObject(this, settings);
        }
    }
}