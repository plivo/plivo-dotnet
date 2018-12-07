using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Plivo.Resource.Address
{
    /// <summary>
    /// Address.
    /// </summary>
    public class Address : Resource
    {
        /// <summary>
        /// Gets or sets Id
        /// </summary>
        /// <value>The identifier of the Address resource</value>
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
        /// <value>Alias of the Address</value>
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
        /// Gets or sets Address Proof Type
        /// </summary>
        /// <value>Address Proof Type</value>
        public string AddressProofType { get; set; }

        /// <summary>
        /// Gets or sets Address Proof Number
        /// </summary>
        /// <value>Address Proof Number</value>
        public string AddressProofNumber { get; set; }

        /// <summary>
        /// Gets or sets Linked Phone Numbers
        /// </summary>
        /// <value>Linked Phone Numbers</value>
        public List<string> LinkedPhoneNumbers { get; set; }

        /// <summary>
        /// Gets or sets document details
        /// </summary>
        /// <value>Document Details</value>
        public AddressDocumentDetail DocumentDetails { get; set; }

        public Address()
        {
        }
        #region Delete
        /// <summary>
        /// Delete this instance.
        /// </summary>
        /// <returns>The delete.</returns>
        public  DeleteResponse<Address> Delete()
        {
            return ((AddressInterface)Interface).Delete(Id);
        }
        /// <summary>
        /// Asynchronously delete this instance.
        /// </summary>
        /// <returns>The delete.</returns>
        public async Task<DeleteResponse<Address>> DeleteAsync()
        {
            return await ((AddressInterface) Interface).DeleteAsync(Id);
        }
        #endregion
        #region Update
        /// <summary>
        /// Update address with the specified params
        /// </summary>
        /// <returns>The update.</returns>
        /// <param name="salutation">Salutation.</param>
        /// <param name="firstName">First Name.</param>
        /// <param name="lastName">Last Name.</param>
        /// <param name="countryIso">2-letter country ISO.</param>
        /// <param name="addressLine1">Address Line 1.</param>
        /// <param name="addressLine2">Address Line 2.</param>
        /// <param name="city">City.</param>
        /// <param name="region">Region.</param>
        /// <param name="postalCode">Postal Code.</param>
        /// <param name="alias">Alias.</param>
        /// <param name="fileToUpload">File to be uploaded. Need the full path to the file</param>
        /// <param name="autoCorrectAddress">Auto Correct Address?.</param>
        /// <param name="callbackUrl">Callback URL</param>
        public UpdateResponse<Address> Update(
            string salutation = null,
            string firstName = null,
            string lastName = null,
            string countryIso = null,
            string addressLine1 = null,
            string addressLine2 = null,
            string city = null,
            string region = null,
            string postalCode = null,
            string alias = null,
            string fileToUpload = null,
            bool? autoCorrectAddress = null,
            string callbackUrl = null)
        {
            var updateResponse = ((AddressInterface) Interface).Update(
                Id, salutation, firstName, lastName, countryIso, addressLine1,
                addressLine2, city, region, postalCode, alias, fileToUpload,
                autoCorrectAddress, callbackUrl
            );

            if (salutation != null) Salutation = salutation;
            if (firstName != null) FirstName = firstName;
            if (lastName != null) LastName = lastName;
            if (countryIso != null) CountryIso = countryIso;
            if (addressLine1 != null) AddressLine1 = addressLine1;
            if (addressLine2 != null) AddressLine2 = addressLine2;
            if (city != null) City = city;
            if (region != null) Region = region;
            if (postalCode != null) PostalCode = postalCode;
            if (alias != null) Alias = alias;

            return updateResponse;
        }

        /// <summary>
        /// Asynchronously update address with the specified params
        /// </summary>
        /// <returns>The update.</returns>
        /// <param name="salutation">Salutation.</param>
        /// <param name="firstName">First Name.</param>
        /// <param name="lastName">Last Name.</param>
        /// <param name="countryIso">2-letter country ISO.</param>
        /// <param name="addressLine1">Address Line 1.</param>
        /// <param name="addressLine2">Address Line 2.</param>
        /// <param name="city">City.</param>
        /// <param name="region">Region.</param>
        /// <param name="postalCode">Postal Code.</param>
        /// <param name="alias">Alias.</param>
        /// <param name="fileToUpload">File to be uploaded. Need the full path to the file</param>
        /// <param name="autoCorrectAddress">Auto Correct Address?.</param>
        /// <param name="callbackUrl">Callback URL</param>
        public async Task<UpdateResponse<Address>> UpdateAsync(
            string salutation = null,
            string firstName = null,
            string lastName = null,
            string countryIso = null,
            string addressLine1 = null,
            string addressLine2 = null,
            string city = null,
            string region = null,
            string postalCode = null,
            string alias = null,
            string fileToUpload = null,
            bool? autoCorrectAddress = null,
            string callbackUrl = null)
        {
            var updateResponse = await ((AddressInterface)Interface).UpdateAsync(
                Id, salutation, firstName, lastName, countryIso, addressLine1,
                addressLine2, city, region, postalCode, alias, fileToUpload,
                autoCorrectAddress, callbackUrl
            );

            if (salutation != null) Salutation = salutation;
            if (firstName != null) FirstName = firstName;
            if (lastName != null) LastName = lastName;
            if (countryIso != null) CountryIso = countryIso;
            if (addressLine1 != null) AddressLine1 = addressLine1;
            if (addressLine2 != null) AddressLine2 = addressLine2;
            if (city != null) City = city;
            if (region != null) Region = region;
            if (postalCode != null) PostalCode = postalCode;
            if (alias != null) Alias = alias;

            return updateResponse;
        }
        #endregion
    }
}