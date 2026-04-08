using System.Collections.Generic;
using Newtonsoft.Json;

namespace Plivo.Resource.PhoneNumberCompliance
{
    public class ComplianceLinkResponse
    {
        [JsonProperty("api_id")]
        public string ApiId { get; set; }

        [JsonProperty("total_count")]
        public int TotalCount { get; set; }

        [JsonProperty("updated_count")]
        public int UpdatedCount { get; set; }

        public List<object> Report { get; set; }

        public uint StatusCode { get; set; }

        public override string ToString()
        {
            return "ApiId: " + ApiId + "\n" +
                   "TotalCount: " + TotalCount + "\n" +
                   "UpdatedCount: " + UpdatedCount + "\n" +
                   "Report: " + (Report != null ? string.Join(",\n", Report) : "") + "\n";
        }
    }
}
