using Newtonsoft.Json;

namespace Plivo.Resource.Lookup
{
    public class Country
    {
        [JsonProperty("code_iso2")]
        public string CodeIso2 { get; set; }

        [JsonProperty("code_iso3")]
        public string CodeIso3 { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Format
    {
        [JsonProperty("e164")]
        public string E164 { get; set; }

        [JsonProperty("international")]
        public string International { get; set; }

        [JsonProperty("national")]
        public string National { get; set; }

        [JsonProperty("rfc3966")]
        public string Rfc3966 { get; set; }
    }

    public class Carrier
    {
        [JsonProperty("mobile_country_code")]
        public string MobileCountryCode { get; set; }

        [JsonProperty("mobile_network_code")]
        public string MobileNetworkCode { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("ported")]
        public bool Ported { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class Number : Resource
    {
        [JsonProperty("api_id")]
        public new string ApiId { get; set; }

        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty("country")]
        public Country Country { get; set; }

        [JsonProperty("format")]
        public Format Format { get; set; }

        [JsonProperty("carrier")]
        public Carrier Carrier { get; set; }

        [JsonProperty("resource_uri")]
        public string ResourceURI { get; set; }

        public override string ToString()
        {
	    // this intentionally returns json instead of manually printing
	    // each nested objected individually.
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
