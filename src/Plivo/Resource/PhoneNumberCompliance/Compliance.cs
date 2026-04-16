using System.Collections.Generic;

namespace Plivo.Resource.PhoneNumberCompliance
{
    public class Compliance : Resource
    {
        public new string ApiId { get; set; }
        public string ComplianceId { get; set; }
        public string Status { get; set; }
        public string Alias { get; set; }
        public string CountryIso { get; set; }
        public string NumberType { get; set; }
        public string UserType { get; set; }
        public string CallbackUrl { get; set; }
        public string CallbackMethod { get; set; }
        public string RejectionReason { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        public object EndUser { get; set; }
        public List<object> Documents { get; set; }
        public List<object> LinkedNumbers { get; set; }

        public override string ToString()
        {
            return
                "ApiId: " + ApiId + "\n" +
                "ComplianceId: " + ComplianceId + "\n" +
                "Status: " + Status + "\n" +
                "Alias: " + Alias + "\n" +
                "CountryIso: " + CountryIso + "\n" +
                "NumberType: " + NumberType + "\n" +
                "UserType: " + UserType + "\n" +
                "CallbackUrl: " + CallbackUrl + "\n" +
                "CallbackMethod: " + CallbackMethod + "\n" +
                "RejectionReason: " + RejectionReason + "\n" +
                "CreatedAt: " + CreatedAt + "\n" +
                "UpdatedAt: " + UpdatedAt + "\n";
        }
    }
}
