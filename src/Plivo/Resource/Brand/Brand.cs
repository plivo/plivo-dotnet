using Newtonsoft.Json;

namespace Plivo.Resource.Brand
{
    /// <summary>
    /// Brand.
    /// </summary>
    public class BrandResponse : Resource
    {
        [JsonProperty("brand_id")]
        public string brand_id { get; set; }

        [JsonProperty("company_name")]
        public string company_name { get; set; }

        [JsonProperty("ein")]
        public string ein { get; set; }

        [JsonProperty("ein_issuing_country")]
        public string ein_issuing_country { get; set; }

        [JsonProperty("email")]
        public string email { get; set; }

        [JsonProperty("entity_type")]
        public string entity_type { get; set; }

        [JsonProperty("registration_status")]
        public string registration_status { get; set; }

        [JsonProperty("companverticaly_name")]
        public string vertical { get; set; }

        [JsonProperty("website")]
        public string website { get; set; }
        
    }
    public class Brand: Resource
    {  
        [JsonProperty("api_id")]
        public string ApiId {get; set;}

        [JsonProperty("brand")]
        public BrandResponse brand {get; set;}

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
    public class Brands: Resource
    {
        [JsonProperty("api_id")]
        public string ApiId {get; set;}
        [JsonProperty("brands")]
        public BrandResponse brands {get; set;}
         public override string ToString()
        {
	    // this intentionally returns json instead of manually printing
	    // each nested objected individually.
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
    public class BrandCreate: Resource
    {   
        [JsonProperty("alt_business_id_type")]
        public string AltBusinessIdType { get; set; }
        [JsonProperty("brand_id")]
        public string BrandId { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("ein_issuing_country")]
        public string EinIssuingCountry { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("entity_type")]
        public string EntityType { get; set; }
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        [JsonProperty("phone")]
        public string Phone { get; set; }
        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }
        [JsonProperty("registration_status")]
        public string RegistrationStatus { get; set; }
        [JsonProperty("State")]
        public string state { get; set; }
        [JsonProperty("stock_exchange")]
        public string StockExchange { get; set; }
        [JsonProperty("stock_symbol")]
        public string StockSymbol { get; set; }
        [JsonProperty("street")]
        public string Street { get; set; }
        [JsonProperty("vertical")]
        public string Vertical { get; set; }
        [JsonProperty("website")]
        public string Website { get; set; }
    }
    public class BrandCreateResponse: Resource
    {
        [JsonProperty("api_id")]
        public string ApiId {get; set;}
        [JsonProperty("brand")]
        public BrandCreate Brand {get; set;}

         public override string ToString()
        {
	    // this intentionally returns json instead of manually printing
	    // each nested objected individually.
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}