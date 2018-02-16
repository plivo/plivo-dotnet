using System;
using System.Collections.Generic;

namespace Plivo.Resource.Identity
{
    /// <summary>
    /// Identity.
    /// </summary>
    public class Identity : Resource
    {
        /// <summary>
        /// Gets or sets Id
        /// </summary>
        /// <value>The identifier of the Resource object</value>
        public new string Id { get; set; }

        /// <summary>
        /// Gets or sets Country Iso
        /// </summary>
        /// <value>2-letter country ISO</value>
        public string CountryIso { get; set; }

        /// <summary>
        /// Account
        /// </summary>
        /// <value>Account</value>
        public string Account { get; set; }

        /// <summary>
        /// Gets or sets Alias
        /// </summary>
        /// <value>Alias of the Resource object</value>
        public string Alias { get; set; }

        /// <summary>
        /// Gets or sets Salutation
        /// </summary>
        /// <value>Salutation</value>
        public string Salutation { get; set; }

        /// <summary>
        /// Gets or sets First Name
        /// </summary>
        /// <value>First Name</value>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets Last Name
        /// </summary>
        /// <value>Last Name</value>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets Birth Place
        /// </summary>
        /// <value>Birth Place</value>
        public string BirthPlace { get; set; }

        /// <summary>
        /// Gets or sets Birth Date
        /// </summary>
        /// <value>Birth Date</value>
        public string BirthDate { get; set; }

        /// <summary>
        /// Gets or sets Nationality
        /// </summary>
        /// <value>Nationality</value>
        public string Nationality { get; set; }

        /// <summary>
        /// Gets or sets Id Nationality
        /// </summary>
        /// <value>Nationality mentioned in the identity proof</value>
        public string IdNationality { get; set; }

        /// <summary>
        /// Gets or sets Id Issue Date
        /// </summary>
        /// <value>Issue date in yyyy-mm-dd mentioned in the identity proof</value>
        public string IdIssueDate { get; set; }

        /// <summary>
        /// Gets or sets Business Name
        /// </summary>
        /// <value>Business name of the user for whom the identity is created</value>
        public string BusinessName { get; set; }

        /// <summary>
        /// Gets or sets Id Type
        /// </summary>
        /// <value>The type of ID</value>
        public string IdType { get; set; }

        /// <summary>
        /// Gets or sets Id Number
        /// </summary>
        /// <value>The unique number on the identifier</value>
        public string IdNumber { get; set; }

        /// <summary>
        /// Gets or sets Address Line 1
        /// </summary>
        /// <value>Address Line 1</value>
        public string AddressLine1 { get; set; }

        /// <summary>
        /// Gets or sets Address Line 2
        /// </summary>
        /// <value>Address Line 2</value>
        public string AddressLine2 { get; set; }

        /// <summary>
        /// Gets or sets City
        /// </summary>
        /// <value>City</value>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets Region
        /// </summary>
        /// <value>Region or State</value>
        public string Region { get; set; }

        /// <summary>
        /// Gets or sets Postal Code
        /// </summary>
        /// <value>Postal Code</value>
        public string PostalCode { get; set; }

        /// <summary>
        /// Gets or sets Fiscal Identification Code
        /// </summary>
        /// <value>Fiscal Identification Code</value>
        public string FiscalIdentificationCode { get; set; }

        /// <summary>
        /// Gets or sets Street Code
        /// </summary>
        /// <value>Street Code</value>
        public string StreetCode { get; set; }

        /// <summary>
        /// Gets or sets Municipal Code
        /// </summary>
        /// <value>Municipal Code</value>
        public string MunicipalCode { get; set; }

        /// <summary>
        /// Gets or sets Validation Status
        /// </summary>
        /// <value>Validation Status</value>
        public string ValidationStatus { get; set; }

        /// <summary>
        /// Gets or sets Verification Status
        /// </summary>
        /// <value>Verification Status</value>
        public string VerificationStatus { get; set; }

        /// <summary>
        /// Gets or sets Subaccount
        /// </summary>
        /// <value>Subaccount</value>
        public string Subaccount { get; set; }

        /// <summary>
        /// Gets or sets Url
        /// </summary>
        /// <value>Url</value>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets document details
        /// </summary>
        /// <value>Document Details</value>
        public IdentityDocumentDetail DocumentDetails { get; set; }


        /// <summary>
        /// Delete this instance.
        /// </summary>
        /// <returns>The delete.</returns>
        public DeleteResponse<Identity> Delete()
        {
            return ((IdentityInterface)Interface).Delete(Id);
        }

        /// <summary>
        /// Update identity with the specified params
        /// </summary>
        /// <returns>The update.</returns>
        /// <param name="countryIso">2-letter country ISO.</param>
        /// <param name="salutation">Salutation.</param>
        /// <param name="firstName">First Name.</param>
        /// <param name="lastName">Last Name.</param>
        /// <param name="birthPlace">Place of birth.</param>
        /// <param name="birthDate">Birth date.</param>
        /// <param name="nationality">Nationality.</param>
        /// <param name="idNationality">Nationality as per the ID proof.</param>
        /// <param name="idIssueDate">ID issuing date.</param>
        /// <param name="idType">ID Proof Type.</param>
        /// <param name="idNumber">ID Number.</param>
        /// <param name="addressLine1">Address Line 1.</param>
        /// <param name="addressLine2">Address Line 2.</param>
        /// <param name="city">City.</param>
        /// <param name="region">Region.</param>
        /// <param name="postalCode">Postal Code.</param>
        /// <param name="alias">Alias.</param>
        /// <param name="businessName">Name of the business.</param>
        /// <param name="fiscalIdentificationCode">Fiscal Identification Code</param>
        /// <param name="streetCode">Street code</param>
        /// <param name="municipalCode">Municipal code</param>
        /// <param name="subaccount">Subaccount to which this ID should be associated with</param>
        /// <param name="fileToUpload">File to be uploaded. Need the full path to the file</param>
        /// <param name="autoCorrectAddress">Auto Correct Address?.</param>
        /// <param name="callbackUrl">Callback URL</param>
        public UpdateResponse<Identity> Update(
            string countryIso = null,
            string salutation = null,
            string firstName = null,
            string lastName = null,
            string birthPlace = null,
            string birthDate = null,
            string nationality = null,
            string idNationality = null,
            string idIssueDate = null,
            string idType = null,
            string idNumber = null,
            string addressLine1 = null,
            string addressLine2 = null,
            string city = null,
            string region = null,
            string postalCode = null,
            string alias = null,
            string businessName = null,
            string fiscalIdentificationCode = null,
            string streetCode = null,
            string municipalCode = null,
            string subaccount = null,
            string fileToUpload = null,
            bool? autoCorrectAddress = null,
            string callbackUrl = null
        )
        {
            var updateResponse = ((IdentityInterface)Interface).Update(
                Id, countryIso,
                    salutation,
                    firstName,
                    lastName,
                    birthPlace,
                    birthDate,
                    nationality,
                    idNationality,
                    idIssueDate,
                    idType,
                    idNumber,
                    addressLine1,
                    addressLine2,
                    city,
                    region,
                    postalCode,
                    fiscalIdentificationCode,
                    streetCode,
                    municipalCode,
                    alias,
                    businessName,
                    subaccount,
                    fileToUpload,
                    autoCorrectAddress,
                    callbackUrl
            );

            Console.WriteLine(updateResponse);

            if (salutation != null) Salutation = salutation;
            if (firstName != null) FirstName = firstName;
            if (lastName != null) LastName = lastName;
            if (countryIso != null) CountryIso = countryIso;
            if (birthPlace != null) BirthPlace = birthPlace;
            if (birthDate != null) BirthDate = birthDate;
            if (nationality != null) Nationality = nationality;
            if (idNationality != null) IdNationality = idNationality;
            if (idIssueDate != null) IdIssueDate = idIssueDate;
            if (idType != null) IdType = idType;
            if (idNumber != null) IdNumber = idNumber;
            if (alias != null) Alias = alias;
            if (businessName != null) BusinessName = businessName;
            if (subaccount != null) Subaccount = subaccount;
            if (addressLine1 != null) AddressLine1 = addressLine1;
            if (addressLine2 != null) AddressLine2 = addressLine2;
            if (city != null) City = city;
            if (region != null) Region = region;
            if (postalCode != null) PostalCode = postalCode;

            return updateResponse;
        }
    }
}