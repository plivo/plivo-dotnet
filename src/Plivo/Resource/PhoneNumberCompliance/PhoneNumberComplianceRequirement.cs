using System.Collections.Generic;

namespace Plivo.Resource.PhoneNumberCompliance
{
    public class PhoneNumberComplianceRequirement : Resource
    {
        public new string ApiId { get; set; }
        public string RequirementId { get; set; }
        public string CountryIso { get; set; }
        public string NumberType { get; set; }
        public string UserType { get; set; }
        public List<object> DocumentTypes { get; set; }

        public override string ToString()
        {
            return
                "ApiId: " + ApiId + "\n" +
                "RequirementId: " + RequirementId + "\n" +
                "CountryIso: " + CountryIso + "\n" +
                "NumberType: " + NumberType + "\n" +
                "UserType: " + UserType + "\n" +
                "DocumentTypes: " + (DocumentTypes != null ? string.Join(",\n", DocumentTypes) : "") + "\n";
        }
    }
}
