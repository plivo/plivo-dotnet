using Newtonsoft.Json;

namespace Plivo.Resource.RegulatoryCompliance.Document
{
    public class MetaInformation
    {
        [JsonProperty("bill_date")] public string BillDate { get; set; }
        [JsonProperty("bill_id")] public string BillId { get; set; }
        [JsonProperty("city")] public string City { get; set; }
        [JsonProperty("country")] public string Country { get; set; }
        [JsonProperty("first_name")] public string FirstName { get; set; }
        [JsonProperty("type_of_utility")] public string TypeOfUtility { get; set; }

        [JsonProperty("authorized_representative_name")]
        public string AuthorizedRepresentativeName;

        public override string ToString()
        {
            return
                "{\n" + "BillDate: " + BillDate + "\n" +
                "BillId: " + BillId + "\n" +
                "City: " + City + "\n" +
                "Country: " + Country + "\n" +
                "FirstName: " + FirstName + "\n" +
                "TypeOfUtility: " + TypeOfUtility + "\n" +
                "AuthorizedRepresentativeName: " + AuthorizedRepresentativeName + "}";
        }
    }
}