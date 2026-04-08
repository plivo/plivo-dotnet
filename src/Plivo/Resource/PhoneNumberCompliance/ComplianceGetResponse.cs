using Newtonsoft.Json;

namespace Plivo.Resource.PhoneNumberCompliance
{
    public class ComplianceGetResponse
    {
        [JsonProperty("api_id")]
        public string ApiId { get; set; }

        public Compliance Compliance { get; set; }

        public uint StatusCode { get; set; }

        public override string ToString()
        {
            return "ApiId: " + ApiId + "\n" +
                   "Compliance: " + Compliance + "\n";
        }
    }
}
