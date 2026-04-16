using System.Collections.Generic;
using Newtonsoft.Json;

namespace Plivo.Resource.PhoneNumberCompliance
{
    public class ComplianceListResponse
    {
        [JsonProperty("api_id")]
        public string ApiId { get; set; }

        public Meta Meta { get; set; }

        public List<Compliance> Compliances { get; set; }

        public uint StatusCode { get; set; }

        public override string ToString()
        {
            return "ApiId: " + ApiId + "\n" +
                   "[Meta]\n" + Meta +
                   "[Compliances]\n" + (Compliances != null ? string.Join("\n", Compliances) : "") + "\n";
        }
    }
}
