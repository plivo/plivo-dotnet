using Newtonsoft.Json;

namespace Plivo.Resource.RegulatoryCompliance.Document
{
    public class CreateResponse
    {
        [JsonProperty("api_id")] public string ApiId { get; set; }
        [JsonProperty("alias")] public string Alias { get; set; }
        [JsonProperty("created_at")] public string CreatedAt { get; set; }
        [JsonProperty("document_id")] public string DocumentId { get; set; }
        [JsonProperty("document_type_id")] public string DocumentTypeId { get; set; }
        [JsonProperty("end_user_id")] public string EndUserId { get; set; }
        [JsonProperty("file_name")] public string FileName { get; set; }
        [JsonProperty("message")] public string Message { get; set; }
        [JsonProperty("meta_information")] public MetaInformation MetaInformation { get; set; }

        public override string ToString()
        {
            var file = !string.IsNullOrWhiteSpace(FileName) ? "File: " + FileName + "\n" : "";
            return "ApiId: " + ApiId + "\n" +
                   "Alias: " + Alias + "\n" +
                   "CreatedAt: " + CreatedAt + "\n" +
                   "ComplianceDocumentId: " + DocumentId + "\n" +
                   "DocumentTypeId: " + DocumentTypeId + "\n" +
                   "EndUserId: " + EndUserId + "\n" + file +
                   "Message: " + Message + "\n" +
                   "MetaInformation: " + MetaInformation + "\n";
        }
    }
}