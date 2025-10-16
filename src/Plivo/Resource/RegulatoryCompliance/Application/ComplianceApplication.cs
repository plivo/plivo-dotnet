using System.Collections.Generic;

namespace Plivo.Resource.RegulatoryCompliance.Application
{
    public class ComplianceApplication : Resource
    {
        public new string ApiId { get; set; }
        public string Alias { get; set; }
        public string ComplianceApplicationId { get; set; }
        public string ComplianceRequirementId { get; set; }
        public string CountryIso2 { get; set; }
        public string CreatedAt { get; set; }
        public List<object> Documents { get; set; }
        public string EndUserId { get; set; }
        public string EndUserType { get; set; }
        public string NumberType { get; set; }
        public string Status { get; set; }
        public string RejectionReason { get; set; }

        public override string ToString()
        {
            var result = "Alias: " + Alias + "\n" +
                         "ComplianceApplicationId: " + ComplianceApplicationId + "\n" +
                         "ComplianceRequirementId: " + ComplianceRequirementId + "\n" +
                         "CountryIso2: " + CountryIso2 + "\n" +
                         "CreatedAt: " + CreatedAt + "\n" +
                         "Documents: " + string.Join(",\n", Documents) + "\n" +
                         "EndUserId: " + EndUserId + "\n" +
                         "EndUserType: " + EndUserType + "\n" +
                         "NumberType: " + NumberType + "\n" +
                         "Status: " + Status + "\n" +
                         "RejectionReason: " + RejectionReason + "\n";
            return StatusCode != 0 ? "ApiId: " + ApiId + "\n" + result : result;
        }
    }
}