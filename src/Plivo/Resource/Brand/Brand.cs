using Newtonsoft.Json;
using System.Threading.Tasks;
namespace Plivo.Resource.Brand
{
    /// <summary>
    /// Brand.
    /// </summary>
    public class BrandResponse 
    {
        [JsonProperty("brand_id")]
        public string BrandId { get; set; }

        [JsonProperty("company_name")]
        public string CompanyName { get; set; }

        [JsonProperty("ein")]
        public string Ein { get; set; }

        [JsonProperty("ein_issuing_country")]
        public string EinIssuingCountry { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("entity_type")]
        public string EntityType { get; set; }

        [JsonProperty("registration_status")]
        public string RegistrationStatus { get; set; }

        [JsonProperty("vertical")]
        public string Vertical { get; set; }

        [JsonProperty("website")]
        public string Website { get; set; }

        [JsonProperty("vetting_score")]
        public string VettingScore { get; set; }

        [JsonProperty("vetting_status")]
        public string VettingStatus { get; set; }
        
        [JsonProperty("address")]
        public string Address { get; set; }
        
    }
    
    public class Address {
        [JsonProperty("street")]
        public string Street { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
    }

    public class BrandCreate
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

    [JsonObject(MemberSerialization.OptIn)]
    public class BrandCreateResponse: Resource
    {
        [JsonProperty("api_id")]
        public new string ApiId {get; set;}

        [JsonProperty("brand_id")]
        public string BrandId {get; set;}

        [JsonProperty("message")]
        public string Message {get; set;}

         public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class ListBrands: Resource
    {
       [JsonProperty("brand_id")]
        public string BrandId { get; set; }

        [JsonProperty("company_name")]
        public string CompanyName { get; set; }

        [JsonProperty("ein")]
        public string Ein { get; set; }

        [JsonProperty("ein_issuing_country")]
        public string EinIssuingCountry { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("entity_type")]
        public string EntityType { get; set; }

        [JsonProperty("registration_status")]
        public string RegistrationStatus { get; set; }

        [JsonProperty("vertical")]
        public string Vertical { get; set; }

        [JsonProperty("website")]
        public string Website { get; set; }

        [JsonProperty("vetting_score")]
        public string VettingScore { get; set; }

        [JsonProperty("vetting_status")]
        public string VettingStatus { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class GetBrand: Resource
    {  
        [JsonProperty("api_id")]
        public new string ApiId {get; set;}

        [JsonProperty("brand")]
        public BrandResponse Brand {get; set;}

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}