namespace Plivo.Resource.RegulatoryCompliance.Application
{
    public class CreateResponse
    {
        public string Alias { get; set; }
        public string ApiId { get; set; }
        public string ComplianceApplicationId { get; set; }
        public string ComplianceRequirementId { get; set; }
        public string CountryIso2 { get; set; }
        public string CreatedAt { get; set; }
        public string Documents { get; set; }
        public string EndUserId { get; set; }
        public string EndUserType { get; set; }
        public string Message { get; set; }
        public string NumberType { get; set; }
        public string Status { get; set; }

        public override string ToString()
        {
            var result = "ApiId: " + ApiId + "\n" +
                         "Alias: " + Alias + "\n" +
                         "ComplianceApplicationId: " + ComplianceApplicationId + "\n" +
                         "ComplianceRequirementId: " + ComplianceRequirementId + "\n" +
                         "CountryIso2: " + CountryIso2 + "\n" +
                         "CreatedAt: " + CreatedAt + "\n" +
                         "Documents: " + Documents + "\n" +
                         "EndUserId: " + EndUserId + "\n" +
                         "EndUserType: " + EndUserType + "\n" +
                         "NumberType: " + NumberType + "\n" +
                         "Status: " + Status + "\n";
            return Status == "submitted" ? result : (result + "Message: " + Message + "\n");
        }
    }
}