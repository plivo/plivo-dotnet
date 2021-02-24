using System.Collections.Generic;

namespace Plivo.Resource.RegulatoryCompliance.Requirement
{
    public class Requirement : Resource
    {
        public new string ApiId { get; set; }
        public string ComplianceRequirementId { get; set; }
        public string CountryIso2 { get; set; }
        public string NumberType { get; set; }
        public string EndUserType { get; set; }
        public List<object> acceptableDocumentTypes { get; set; }

        public override string ToString()
        {
            return
                "ApiId: " + ApiId + "\n" +
                "ComplianceRequirementId: " + ComplianceRequirementId + "\n" +
                "CountryIso2: " + CountryIso2 + "\n" +
                "NumberType: " + NumberType + "\n" +
                "EndUserType: " + EndUserType + "\n" +
                "AcceptableDocumentTypes: " + string.Join(",\n", acceptableDocumentTypes) + "\n";
        }
    }
}