using Newtonsoft.Json;

namespace Plivo.Resource.RegulatoryCompliance.Document
{
    public class GetResponse : Resource
    {
        [JsonProperty("api_id")] public new string ApiId { get; set; }
        [JsonProperty("alias")] public string Alias { get; set; }
        [JsonProperty("document_id")] public string DocumentId { get; set; }
        [JsonProperty("document_type_id")] public string DocumentTypeId { get; set; }
        [JsonProperty("end_user_id")] public string EndUserId { get; set; }
        [JsonProperty("file_name")] public string FileName { get; set; }
        [JsonProperty("meta_information")] MetaInformation _metaInformation = new MetaInformation();
        [JsonProperty("created_at")] public string CreatedAt { get; set; }

        public override string ToString()
        {
            return "ApiId: " + ApiId + "\n" +
                   "Alias: " + Alias + "\n" +
                   "DocumentId: " + DocumentId + "\n" +
                   "DocumentTypeId: " + DocumentTypeId + "\n" +
                   "EndUserId: " + EndUserId + "\n" +
                   "FileName: " + FileName + "\n" +
                   "MetaInformation: " + _metaInformation + "\n" +
                   "CreatedAt: " + CreatedAt + "\n";
        }
    }
}