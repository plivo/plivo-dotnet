using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Plivo.Resource.Profile
{
    /// <summary>
    /// Profile.
    /// </summary>

     public class AuthorizedContactResponse {
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("seniority")]
        public string Seniority { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        [JsonProperty("phone")]
        public string Phone { get; set; }
    }

    public class AuthorizedContact {
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        [JsonProperty("seniority")]
        public string Seniority { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("phone")]
        public string Phone { get; set; }
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

    
    [JsonObject(MemberSerialization.OptIn)]
    public class ProfileResponse: Resource{

        [JsonProperty("api_id")]
        public string ApiId {get; set;}

        [JsonProperty("profile_uuid")]
        public string ProfileUUID {get; set;}

        [JsonProperty("message")]
        public string Message {get; set;}

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }

    public class ProfileDeleteResponse
    {
    
    }

    public class Profile 
    {
        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("alt_business_id_type")]
        public string AltBusinessIdType { get; set; }

        [JsonProperty("authorized_contact")]
        public AuthorizedContact authorized_contact { get; set; }

        [JsonProperty("company_name")]
        public string CompanyName { get; set; }

        [JsonProperty("customer_type")]
        public string CustomerType { get; set; }

        [JsonProperty("ein_issuing_country")]
        public string EinIssuingCountry { get; set; }  

        [JsonProperty("entity_type")]
        public string EntityType { get; set; }  

        [JsonProperty("primary_profile")]
        public string PrimaryProfile { get; set; }  

        [JsonProperty("profile_type")]
        public string ProfileType { get; set; }  

        [JsonProperty("profile_alias")]
        public string ProfileAlias { get; set; } 

        [JsonProperty("profile_uuid")]
        public string ProfileUuid { get; set; }  

        [JsonProperty("stock_symbol")]
        public string StockSymbol { get; set; }  

        [JsonProperty("vertical")]
        public string Vertical { get; set; }  

        [JsonProperty("website")]
        public string Website { get; set; }

        [JsonProperty("plivo_subaccount")]
        public string PlivoSubaccount { get; set; }

    }

    [JsonObject(MemberSerialization.OptIn)]
    public class GetProfile:Resource
    {
        [JsonProperty("api_id")]
        public new string ApiId {get; set;}

        [JsonProperty("profile")]
        public Profile Profile {get; set;}

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class ListProfiles: Resource
    { 
        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("alt_business_id_type")]
        public string AltBusinessIdType { get; set; }

        [JsonProperty("company_name")]
        public string CompanyName { get; set; }

        [JsonProperty("CustomerType")]
        public string CustomerType { get; set; }  

        [JsonProperty("entity_type")]
        public string EntityType { get; set; }  

        [JsonProperty("primary_profile")]
        public string PrimaryProfile { get; set; }  

        [JsonProperty("profile_alias")]
        public string ProfileAlias { get; set; }  

        [JsonProperty("profile_type")]
        public string ProfileType { get; set; } 

        [JsonProperty("vertical")]
        public string Vertical { get; set; }  

        [JsonProperty("stock_symbol")]
        public string StockSymbol { get; set; }  

        [JsonProperty("profile_uuid")]
        public string ProfileUuid { get; set; }

        [JsonProperty("plivo_subaccount")]
        public string PlivoSubaccount { get; set; }

        [JsonProperty("authorized_contact")]
        public AuthorizedContact authorized_contact { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}