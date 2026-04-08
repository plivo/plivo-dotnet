using Newtonsoft.Json;

namespace Plivo.Resource.PhoneNumberCompliance
{
    public class ComplianceUpdateResponse
    {
        [JsonProperty("api_id")]
        public string ApiId { get; set; }

        [JsonProperty("compliance_id")]
        public string ComplianceId { get; set; }

        public string Message { get; set; }

        public uint StatusCode { get; set; }

        public override string ToString()
        {
            return "ApiId: " + ApiId + "\n" +
                   "ComplianceId: " + ComplianceId + "\n" +
                   "Message: " + Message + "\n";
        }
    }
}
