using System;
using Newtonsoft.Json;

namespace Plivo.Resource.RegulatoryCompliance.Document
{
    public class MetaInformation
    {
        [JsonProperty("nationality")] public string Nationality { get; set; }
        [JsonProperty("support_email")] public string SupportEmail { get; set; }
        [JsonProperty("support_phone_number")] public string SupportPhoneNumber { get; set; }

        [JsonProperty("unique_identification_number")]
        public string UniqueIdentificationNumber { get; set; }

        [JsonProperty("use_case_description")] public string UseCaseDescription { get; set; }
        [JsonProperty("postal_code")] public string PostalCode { get; set; }
        [JsonProperty("date_of_birth")] public string DateOfBirth { get; set; }
        [JsonProperty("type_of_id")] public string TypeOfId { get; set; }
        [JsonProperty("address_line_1")] public string AddressLine1 { get; set; }
        [JsonProperty("address_line_2")] public string AddressLine2 { get; set; }
        [JsonProperty("date_of_issue")] public string DateOfIssue { get; set; }
        [JsonProperty("business_name")] public string BusinessName { get; set; }
        [JsonProperty("place_of_birth")] public string PlaceOfBirth { get; set; }
        [JsonProperty("date_of_expiration")] public string DateOfExpiration { get; set; }
        [JsonProperty("bill_date")] public string BillDate { get; set; }
        [JsonProperty("bill_id")] public string BillId { get; set; }
        [JsonProperty("city")] public string City { get; set; }
        [JsonProperty("country")] public string Country { get; set; }
        [JsonProperty("first_name")] public string FirstName { get; set; }
        [JsonProperty("last_name")] public string LastName { get; set; }
        [JsonProperty("type_of_utility")] public string TypeOfUtility { get; set; }

        [JsonProperty("authorized_representative_name")]
        public string AuthorizedRepresentativeName { get; set; }

        public override string ToString()
        {
            var nationality = !string.IsNullOrWhiteSpace(Nationality) ? "Nationality: " + Nationality + "\n" : "";
            var supportEmail = !string.IsNullOrWhiteSpace(SupportEmail) ? "SupportEmail: " + SupportEmail + "\n" : "";
            var supportPhoneNumber = !string.IsNullOrWhiteSpace(SupportPhoneNumber)
                ? "SupportPhoneNumber: " + SupportPhoneNumber + "\n"
                : "";
            var uniqueIdentificationNumber = !string.IsNullOrWhiteSpace(UniqueIdentificationNumber)
                ? "UniqueIdentificationNumber: " + UniqueIdentificationNumber + "\n"
                : "";
            var useCaseDescription = !string.IsNullOrWhiteSpace(UseCaseDescription)
                ? "UseCaseDescription: " + UseCaseDescription + "\n"
                : "";
            var postalCode = !string.IsNullOrWhiteSpace(PostalCode) ? "PostalCode: " + PostalCode + "\n" : "";
            var dateOfBirth = !string.IsNullOrWhiteSpace(DateOfBirth) ? "DateOfBirth: " + DateOfBirth + "\n" : "";
            var typeOfId = !string.IsNullOrWhiteSpace(TypeOfId) ? "TypeOfId: " + TypeOfId + "\n" : "";
            var addressLine1 = !string.IsNullOrWhiteSpace(AddressLine1) ? "AddressLine1: " + AddressLine1 + "\n" : "";
            var addressLine2 = !string.IsNullOrWhiteSpace(AddressLine2) ? "AddressLine2: " + AddressLine2 + "\n" : "";
            var dateOfIssue = !string.IsNullOrWhiteSpace(DateOfIssue) ? "DateOfIssue: " + DateOfIssue + "\n" : "";
            var businessName = !string.IsNullOrWhiteSpace(BusinessName) ? "BusinessName: " + BusinessName + "\n" : "";
            var placeOfBirth = !string.IsNullOrWhiteSpace(PlaceOfBirth) ? "PlaceOfBirth: " + PlaceOfBirth + "\n" : "";
            var dateOfExpiration = !string.IsNullOrWhiteSpace(DateOfExpiration)
                ? "DateOfExpiration: " + DateOfExpiration + "\n"
                : "";
            var billDate = !string.IsNullOrWhiteSpace(BillDate) ? "BillDate: " + BillDate + "\n" : "";
            var billId = !string.IsNullOrWhiteSpace(BillId) ? "BillId: " + BillId + "\n" : "";
            var city = !string.IsNullOrWhiteSpace(City) ? "City: " + City + "\n" : "";
            var country = !string.IsNullOrWhiteSpace(Country) ? "Country: " + Country + "\n" : "";
            var firstName = !string.IsNullOrWhiteSpace(FirstName) ? "FirstName: " + FirstName + "\n" : "";
            var lastName = !string.IsNullOrWhiteSpace(LastName) ? "LastName: " + LastName + "\n" : "";
            var typeOfUtility = !string.IsNullOrWhiteSpace(TypeOfUtility)
                ? "TypeOfUtility: " + TypeOfUtility + "\n"
                : "";
            var authorizedRepresentativeName = !string.IsNullOrWhiteSpace(AuthorizedRepresentativeName)
                ? "AuthorizedRepresentativeName: " + AuthorizedRepresentativeName + "\n"
                : "";
            return "{\n" + nationality + supportEmail + supportPhoneNumber + uniqueIdentificationNumber +
                   useCaseDescription +
                   postalCode + dateOfBirth + typeOfId + addressLine1 + addressLine2 + dateOfIssue + businessName +
                   placeOfBirth +
                   dateOfExpiration + billDate + billId + city + country + firstName + lastName + typeOfUtility +
                   authorizedRepresentativeName + "}";
        }
    }
}