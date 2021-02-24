using Newtonsoft.Json;

namespace Plivo.Resource.RegulatoryCompliance.Document
{
    public class Document : Resource
    {
        [JsonProperty("api_id")] public new string ApiId { get; set; }
        [JsonProperty("alias")] public string Alias { get; set; }

        [JsonProperty("compliance_document_id")]
        public string ComplianceDocumentId { get; set; }

        [JsonProperty("document_type_id")] public string DocumentTypeId { get; set; }
        [JsonProperty("end_user_id")] public string EndUserId { get; set; }
        [JsonProperty("file")] public string File { get; set; }
        [JsonProperty("meta_information")] MetaInformation _metaInformation = new MetaInformation();
        [JsonProperty("created_at")] public string CreatedAt { get; set; }

        public override string ToString()
        {
            var result = "Alias: " + Alias + "\n" +
                         "ComplianceDocumentId: " + ComplianceDocumentId + "\n" +
                         "DocumentTypeId: " + DocumentTypeId + "\n" +
                         "EndUserId: " + EndUserId + "\n" +
                         "File: " + File + "\n" +
                         "MetaInformation: " + _metaInformation + "\n" +
                         "CreatedAt: " + CreatedAt + "\n";
            return StatusCode != 0 ? "ApiId: " + ApiId + "\n" + result : result;
        }
    }
}