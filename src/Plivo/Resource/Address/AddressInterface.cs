using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Plivo.Client;

namespace Plivo.Resource.Address
{
    /// <summary>
    /// Address interface.
    /// </summary>
    public class AddressInterface : ResourceInterface
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:plivo.Resource.Address.AddressInterface"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        public AddressInterface(HttpClient client) : base(client)
        {
            Uri = "Account/" + Client.GetAuthId() + "/Verification/Address/";
        }

        #region old

        /// <summary>
        /// Asynchronously create address with the specified params
        /// </summary>
        /// <returns>The create.</returns>
        /// <param name="countryIso">2-letter country ISO.</param>
        /// <param name="salutation">Salutation.</param>
        /// <param name="firstName">First Name.</param>
        /// <param name="lastName">Last Name.</param>
        /// <param name="addressLine1">Address Line 1.</param>
        /// <param name="addressLine2">Address Line 2.</param>
        /// <param name="city">City.</param>
        /// <param name="region">Region.</param>
        /// <param name="postalCode">Postal Code.</param>
        /// <param name="addressProofType">Address Proof Type.</param>
        /// <param name="alias">Alias.</param>
        /// <param name="fileToUpload">File to be uploaded. Need the full path to the file</param>
        /// <param name="autoCorrectAddress">Auto Correct Address?.</param>
        /// <param name="fiscalIdentificationCode">Fiscal Identification Code</param>
        /// <param name="streetCode">Street code</param>
        /// <param name="municipalCode">Municipal code</param>
        /// <param name="callbackUrl">Callback URL</param>
        public async Task<AddressCreateResponse> CreateAsyncOld(
            string countryIso,
            string salutation,
            string firstName,
            string lastName,
            string addressLine1,
            string addressLine2,
            string city,
            string region,
            string postalCode,
            string addressProofType,
            string alias = null,
            string fileToUpload = null,
            bool? autoCorrectAddress = null,
            string fiscalIdentificationCode = null,
            string streetCode = null,
            string municipalCode = null,
            string callbackUrl = null
        )
        {
            var mandatoryParams = new List<string>
            {
                "countryIso",
                "salutation",
                "firstName",
                "lastName",
                "addressLine1",
                "addressLine2",
                "city",
                "region",
                "postalCode",
                "addressProofType"
            };

            if (countryIso == "ES")
            {
                mandatoryParams.Add("fiscalIdentificationCode");
            }
            else if (countryIso == "DK")
            {
                mandatoryParams.Add("streetCode");
                mandatoryParams.Add("municipalCode");
            }

            var data = CreateData(
                mandatoryParams,
                new
                {
                    countryIso,
                    salutation,
                    firstName,
                    lastName,
                    addressLine1,
                    addressLine2,
                    city,
                    region,
                    postalCode,
                    addressProofType,
                    alias,
                    autoCorrectAddress,
                    fiscalIdentificationCode,
                    streetCode,
                    municipalCode,
                    callbackUrl
                });

            var filesToUpload = new Dictionary<string, string>();

            if (fileToUpload != null)
            {
                filesToUpload.Add("file", fileToUpload);
            }

            var result = await Client.Update<AddressCreateResponse>(Uri, data, filesToUpload);

            return result.Object;
        }

        /// <summary>
        /// Create address with the specified params
        /// </summary>
        /// <returns>The create.</returns>
        /// <param name="countryIso">2-letter country ISO.</param>
        /// <param name="salutation">Salutation.</param>
        /// <param name="firstName">First Name.</param>
        /// <param name="lastName">Last Name.</param>
        /// <param name="addressLine1">Address Line 1.</param>
        /// <param name="addressLine2">Address Line 2.</param>
        /// <param name="city">City.</param>
        /// <param name="region">Region.</param>
        /// <param name="postalCode">Postal Code.</param>
        /// <param name="addressProofType">Address Proof Type.</param>
        /// <param name="alias">Alias.</param>
        /// <param name="fileToUpload">File to be uploaded. Need the full path to the file</param>
        /// <param name="autoCorrectAddress">Auto Correct Address?.</param>
        /// <param name="fiscalIdentificationCode">Fiscal Identification Code</param>
        /// <param name="streetCode">Street code</param>
        /// <param name="municipalCode">Municipal code</param>
        /// <param name="callbackUrl">Callback URL</param>
        public AddressCreateResponse CreateOld(
            string countryIso,
            string salutation,
            string firstName,
            string lastName,
            string addressLine1,
            string addressLine2,
            string city,
            string region,
            string postalCode,
            string addressProofType,
            string alias = null,
            string fileToUpload = null,
            bool? autoCorrectAddress = null,
            string fiscalIdentificationCode = null,
            string streetCode = null,
            string municipalCode = null,
            string callbackUrl = null
        )
        {
            var mandatoryParams = new List<string>
            {
                "countryIso",
                "salutation",
                "firstName",
                "lastName",
                "addressLine1",
                "addressLine2",
                "city",
                "region",
                "postalCode",
                "addressProofType"
            };

            if (countryIso == "ES")
            {
                mandatoryParams.Add("fiscalIdentificationCode");
            }
            else if (countryIso == "DK")
            {
                mandatoryParams.Add("streetCode");
                mandatoryParams.Add("municipalCode");
            }

            var data = CreateData(
                mandatoryParams,
                new
                {
                    countryIso,
                    salutation,
                    firstName,
                    lastName,
                    addressLine1,
                    addressLine2,
                    city,
                    region,
                    postalCode,
                    addressProofType,
                    alias,
                    autoCorrectAddress,
                    fiscalIdentificationCode,
                    streetCode,
                    municipalCode,
                    callbackUrl
                });

            var filesToUpload = new Dictionary<string, string>();

            if (fileToUpload != null)
            {
                filesToUpload.Add("file", fileToUpload);
            }

            var result = Task.Run(async () => await Client.Update<AddressCreateResponse>(Uri, data, filesToUpload).ConfigureAwait(false)).Result;

            return result.Object;
        }

        /// <summary>
        /// Update address with the specified params
        /// </summary>
        /// <returns>The update.</returns>
        /// <param name="addressId">ID of the address to be updated.</param>
        /// <param name="countryIso">2-letter country ISO.</param>
        /// <param name="salutation">Salutation.</param>
        /// <param name="firstName">First Name.</param>
        /// <param name="lastName">Last Name.</param>
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
            string addressId,
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
            string callbackUrl = null
        )
        {
            var mandatoryParams = new List<string> { };

            var data = CreateData(
                mandatoryParams,
                new
                {
                    salutation,
                    firstName,
                    lastName,
                    countryIso,
                    addressLine1,
                    addressLine2,
                    city,
                    region,
                    postalCode,
                    alias,
                    autoCorrectAddress,
                    callbackUrl
                });

            var filesToUpload = new Dictionary<string, string>();

            if (fileToUpload != null)
            {
                filesToUpload.Add("file", fileToUpload);
            }

            var result = Task.Run(async () => await Client.Update<UpdateResponse<Address>>(Uri + addressId + "/", data, filesToUpload).ConfigureAwait(false)).Result;
            return result.Object;
        }

        /// <summary>
        /// Asynchronously update address with the specified params
        /// </summary>
        /// <returns>The update.</returns>
        /// <param name="addressId">ID of the address to be updated.</param>
        /// <param name="countryIso">2-letter country ISO.</param>
        /// <param name="salutation">Salutation.</param>
        /// <param name="firstName">First Name.</param>
        /// <param name="lastName">Last Name.</param>
        /// <param name="addressLine1">Address Line 1.</param>
        /// <param name="addressLine2">Address Line 2.</param>
        /// <param name="city">City.</param>
        /// <param name="region">Region.</param>
        /// <param name="postalCode">Postal Code.</param>
        /// <param name="alias">Alias.</param>
        /// <param name="fileToUpload">File to be uploaded. Need the full path to the file</param>
        /// <param name="autoCorrectAddress">Auto Correct Address?.</param>
        /// <param name="callbackUrl">Callback URL</param>
        public async Task<UpdateResponse<Address>> UpdateAsyncOld(
            string addressId,
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
            string callbackUrl = null
        )
        {
            var mandatoryParams = new List<string> { };

            var data = CreateData(
                mandatoryParams,
                new
                {
                    salutation,
                    firstName,
                    lastName,
                    countryIso,
                    addressLine1,
                    addressLine2,
                    city,
                    region,
                    postalCode,
                    alias,
                    autoCorrectAddress,
                    callbackUrl
                });

            var filesToUpload = new Dictionary<string, string>();

            if (fileToUpload != null)
            {
                filesToUpload.Add("file", fileToUpload);
            }

            var result = await Client.Update<UpdateResponse<Address>>(Uri + addressId + "/", data, filesToUpload);
            return result.Object;
        }

        /// <summary>
        /// Get address with the specified id.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="id">Identifier.</param>
        public Address GetOld(string id)
        {
            var address = Task.Run(async () => await GetResource<Address>(id).ConfigureAwait(false)).Result;
            address.Interface = this;
            return address;
        }
        /// <summary>
        /// Asynchronously get address with the specified id.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="id">Identifier.</param>
        public async Task<Address> GetAsyncOld(string id)
        {
            var address = await GetResource<Address>(id);
            address.Interface = this;
            return address;
        }
        
        /// <summary>
        /// List Addresses with the specified params.
        /// </summary>
        /// <returns>The list.</returns>
        /// <param name="countryIso">Country ISO (2-letter).</param>
        /// <param name="customerName">Customer's Name.</param>
        /// <param name="alias">Alias.</param>
        /// <param name="verificationStatus">Verification status.</param>
        /// <param name="validationStatus">Validation status.</param>
        /// <param name="limit">Limit.</param>
        /// <param name="offset">Offset.</param>
        public ListResponse<Address> ListOld(
            string countryIso = null,
            string customerName = null,
            string alias = null,
            string verificationStatus = null,
            string validationStatus = null,
            uint? limit = null,
            uint? offset = null)
        {
            var mandatoryParams = new List<string> { };
            var data = CreateData(mandatoryParams, new
            {
                countryIso,
                customerName,
                alias,
                verificationStatus,
                validationStatus,
                limit,
                offset
            });
            var resources = Task.Run(async () => await ListResources<ListResponse<Address>>(data).ConfigureAwait(false)).Result;
            resources.Objects.ForEach(
                (obj) => obj.Interface = this
            );

            return resources;
        }
        /// <summary>
        /// List Addresses with the specified params.
        /// </summary>
        /// <returns>The list.</returns>
        /// <param name="countryIso">Country ISO (2-letter).</param>
        /// <param name="customerName">Customer's Name.</param>
        /// <param name="alias">Alias.</param>
        /// <param name="verificationStatus">Verification status.</param>
        /// <param name="validationStatus">Validation status.</param>
        /// <param name="limit">Limit.</param>
        /// <param name="offset">Offset.</param>
        public async Task<ListResponse<Address>> ListAsyncOld(
            string countryIso = null,
            string customerName = null,
            string alias = null,
            string verificationStatus = null,
            string validationStatus = null,
            uint? limit = null,
            uint? offset = null)
        {
            var mandatoryParams = new List<string> { };
            var data = CreateData(mandatoryParams, new
            {
                countryIso,
                customerName,
                alias,
                verificationStatus,
                validationStatus,
                limit,
                offset
            });
            var resources = await ListResources<ListResponse<Address>>(data);
            resources.Objects.ForEach(
                (obj) => obj.Interface = this
            );

            return resources;
        }

        /// <summary>
        /// Asynchronously delete Address with the specified id.
        /// </summary>
        /// <returns>The delete.</returns>
        /// <param name="id">Identifier.</param>
        public async Task<DeleteResponse<Address>> DeleteAsyncOld(string id)
        {
            return await DeleteResource<DeleteResponse<Address>>(id);
        }
        /// <summary>
        ///  Delete Address with the specified id.
        /// </summary>
        /// <returns>The delete.</returns>
        /// <param name="id">Identifier.</param>
        public DeleteResponse<Address> DeleteOld(string id)
        {
            return Task.Run(async () => await DeleteResource<DeleteResponse<Address>>(id).ConfigureAwait(false)).Result;
        }

        #endregion

        #region Create
        /// <summary>
        /// Asynchronously create address with the specified params
        /// </summary>
        /// <returns>The create.</returns>
        /// <param name="phoneNumberCountry">2-letter country ISO.</param>
        /// <param name="numberType">Number Type.</param>
        /// <param name="countryIso">2-letter country ISO.</param>
        /// <param name="salutation">Salutation.</param>
        /// <param name="firstName">First Name.</param>
        /// <param name="lastName">Last Name.</param>
        /// <param name="addressLine1">Address Line 1.</param>
        /// <param name="addressLine2">Address Line 2.</param>
        /// <param name="city">City.</param>
        /// <param name="region">Region.</param>
        /// <param name="postalCode">Postal Code.</param>
        /// <param name="idNumber">ID Number.</param>
        /// <param name="addressProofType">Address Proof Type.</param>
        /// <param name="alias">Alias.</param>
        /// <param name="fileToUpload">File to be uploaded. Need the full path to the file</param>
        /// <param name="autoCorrectAddress">Auto Correct Address?.</param>
        /// <param name="fiscalIdentificationCode">Fiscal Identification Code</param>
        /// <param name="streetCode">Street code</param>
        /// <param name="municipalCode">Municipal code</param>
        /// <param name="callbackUrl">Callback URL</param>
        public async Task<AddressCreateResponse> CreateAsync(
            string phoneNumberCountry,
            string numberType,
            string countryIso,
            string salutation,
            string firstName,
            string lastName,
            string addressLine1,
            string addressLine2,
            string city,
            string region,
            string postalCode,
            string idNumber,
            string addressProofType,
            string alias = null,
            string fileToUpload = null,
            bool? autoCorrectAddress = null,
            string fiscalIdentificationCode = null,
            string streetCode = null,
            string municipalCode = null,
            string callbackUrl = null
        )
        {
            var mandatoryParams = new List<string>
            {
                "phoneNumberCountry",
                "numberType",
                "countryIso",
                "salutation",
                "firstName",
                "lastName",
                "addressLine1",
                "addressLine2",
                "city",
                "region",
                "postalCode",
                "addressProofType"
            };

            if (countryIso == "ES")
            {
                mandatoryParams.Add("fiscalIdentificationCode");
            }
            else if (countryIso == "DK")
            {
                mandatoryParams.Add("streetCode");
                mandatoryParams.Add("municipalCode");
            }

            var data = CreateData(
                mandatoryParams,
                new
                {
                    phoneNumberCountry,
                    numberType,
                    salutation,
                    firstName,
                    lastName,
                    addressLine1,
                    addressLine2,
                    city,
                    region,
                    postalCode,
                    countryIso,
                    callbackUrl,
                    alias,
                    addressProofType,
                    idNumber,
                    autoCorrectAddress,
                    fiscalIdentificationCode,
                    streetCode,
                    municipalCode
                });

            var filesToUpload = new Dictionary<string, string>();

            if (fileToUpload != null)
            {
                filesToUpload.Add("file", fileToUpload);
            }

            var result = await Client.Update<AddressCreateResponse>(Uri, data, filesToUpload);

            return result.Object;
        }

        /// <summary>
        /// Create address with the specified params
        /// </summary>
        /// <returns>The create.</returns>
        /// <param name="phoneNumberCountry">2-letter country ISO.</param>
        /// <param name="numberType">Number Type.</param>
        /// <param name="salutation">Salutation.</param>
        /// <param name="firstName">First Name.</param>
        /// <param name="lastName">Last Name.</param>
        /// <param name="addressLine1">Address Line 1.</param>
        /// <param name="addressLine2">Address Line 2.</param>
        /// <param name="city">City.</param>
        /// <param name="region">Region.</param>
        /// <param name="postalCode">Postal Code.</param>
        /// <param name="countryIso">2-letter country ISO.</param>
        /// <param name="callbackUrl">Callback URL.</param>
        /// <param name="alias">Alias.</param>
        /// <param name="fileToUpload">File to be uploaded. Need the full path to the file.</param>
        /// <param name="addressProofType">Address Proof Type.</param>
        /// <param name="idNumber">ID Number.</param>
        /// <param name="autoCorrectAddress">Auto Correct Address?.</param>
        /// <param name="fiscalIdentificationCode">Fiscal Identification Code.</param>
        /// <param name="streetCode">Street code.</param>
        /// <param name="municipalCode">Municipal code.</param>
        public AddressCreateResponse Create(
            string phoneNumberCountry,
            string numberType,
            string countryIso,
            string salutation,
            string firstName,
            string lastName,
            string addressLine1,
            string addressLine2,
            string city,
            string region,
            string postalCode,
            string addressProofType,
            string idNumber = null,
            string alias = null,
            string fileToUpload = null,
            bool? autoCorrectAddress = null,
            string fiscalIdentificationCode = null,
            string streetCode = null,
            string municipalCode = null,
            string callbackUrl = null
        )
        {
            var mandatoryParams = new List<string>
            {
                "phoneNumberCountry",
                "numberType",
                "salutation",
                "firstName",
                "lastName",
                "addressLine1",
                "addressLine2",
                "city",
                "region",
                "postalCode",
                "countryIso"
            };

            if (countryIso == "ES")
            {
                mandatoryParams.Add("fiscalIdentificationCode");
            }
            else if (countryIso == "DK")
            {
                mandatoryParams.Add("streetCode");
                mandatoryParams.Add("municipalCode");
            }

            var data = CreateData(
                mandatoryParams,
                new
                {
                    phoneNumberCountry,
                    numberType,
                    salutation,
                    firstName,
                    lastName,
                    addressLine1,
                    addressLine2,
                    city,
                    region,
                    postalCode,
                    countryIso,
                    callbackUrl,
                    alias,
                    addressProofType,
                    idNumber,
                    autoCorrectAddress,
                    fiscalIdentificationCode,
                    streetCode,
                    municipalCode
                });

            var filesToUpload = new Dictionary<string, string>();

            if (fileToUpload != null)
            {
                filesToUpload.Add("file", fileToUpload);
            }

            var result = Task.Run(async () => await Client.Update<AddressCreateResponse>(Uri, data, filesToUpload).ConfigureAwait(false)).Result;

            return result.Object;
        }

        #endregion

        #region Update
        /// <summary>
        /// Update address with the specified params
        /// </summary>
        /// <returns>The update.</returns>
        /// <param name="addressId">ID of the address to be updated.</param>
        /// <param name="phoneNumberCountry">2-letter country ISO.</param>
        /// <param name="numberType">Number Type.</param>
        /// <param name="countryIso">2-letter country ISO.</param>
        /// <param name="salutation">Salutation.</param>
        /// <param name="firstName">First Name.</param>
        /// <param name="lastName">Last Name.</param>
        /// <param name="addressLine1">Address Line 1.</param>
        /// <param name="addressLine2">Address Line 2.</param>
        /// <param name="city">City.</param>
        /// <param name="region">Region.</param>
        /// <param name="postalCode">Postal Code.</param>
        /// <param name="alias">Alias.</param>
        /// <param name="idNumber">ID Number.</param>
        /// <param name="fileToUpload">File to be uploaded. Need the full path to the file</param>
        /// <param name="autoCorrectAddress">Auto Correct Address?.</param>
        /// <param name="callbackUrl">Callback URL</param>
        public UpdateResponse<Address> Update(
            string addressId,
            string phoneNumberCountry = null,
            string numberType = null,
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
            string idNumber = null,
            string fileToUpload = null,
            bool? autoCorrectAddress = null,
            string callbackUrl = null
        )
        {
            var mandatoryParams = new List<string> { };

            var data = CreateData(
                mandatoryParams,
                new
                {
                    phoneNumberCountry,
                    numberType,
                    salutation,
                    firstName,
                    lastName,
                    countryIso,
                    addressLine1,
                    addressLine2,
                    city,
                    region,
                    postalCode,
                    alias,
                    idNumber,
                    autoCorrectAddress,
                    callbackUrl
                });

            var filesToUpload = new Dictionary<string, string>();

            if (fileToUpload != null)
            {
                filesToUpload.Add("file", fileToUpload);
            }

            var result = Task.Run(async () => await Client.Update<UpdateResponse<Address>>(Uri + addressId + "/", data, filesToUpload).ConfigureAwait(false)).Result;
            return result.Object;
        }


        /// <summary>
        /// Asynchronously update address with the specified params
        /// </summary>
        /// <returns>The update.</returns>
        /// <param name="addressId">ID of the address to be updated.</param>
        /// <param name="phoneNumberCountry">2-letter country ISO.</param>
        /// <param name="numberType">Number Type.</param>
        /// <param name="countryIso">2-letter country ISO.</param>
        /// <param name="salutation">Salutation.</param>
        /// <param name="firstName">First Name.</param>
        /// <param name="lastName">Last Name.</param>
        /// <param name="addressLine1">Address Line 1.</param>
        /// <param name="addressLine2">Address Line 2.</param>
        /// <param name="city">City.</param>
        /// <param name="region">Region.</param>
        /// <param name="postalCode">Postal Code.</param>
        /// <param name="alias">Alias.</param>
        /// <param name="idNumber">ID Number.</param>
        /// <param name="fileToUpload">File to be uploaded. Need the full path to the file</param>
        /// <param name="autoCorrectAddress">Auto Correct Address?.</param>
        /// <param name="callbackUrl">Callback URL</param>
        public async Task<UpdateResponse<Address>> UpdateAsync(
            string addressId,
            string phoneNumberCountry = null,
            string numberType = null,
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
            string idNumber = null,
            string fileToUpload = null,
            bool? autoCorrectAddress = null,
            string callbackUrl = null
        )
        {
            var mandatoryParams = new List<string> { };

            var data = CreateData(
                mandatoryParams,
                new
                {
                    phoneNumberCountry,
                    numberType,
                    salutation,
                    firstName,
                    lastName,
                    countryIso,
                    addressLine1,
                    addressLine2,
                    city,
                    region,
                    postalCode,
                    alias,
                    idNumber,
                    autoCorrectAddress,
                    callbackUrl
                });

            var filesToUpload = new Dictionary<string, string>();

            if (fileToUpload != null)
            {
                filesToUpload.Add("file", fileToUpload);
            }

            var result = await Client.Update<UpdateResponse<Address>>(Uri + addressId + "/", data, filesToUpload);
            return result.Object;
        }
        #endregion

        #region Get
        /// <summary>
        /// Get address with the specified id.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="id">Identifier.</param>
        public AddressGetResponse Get(string id)
        {
            var address = Task.Run(async () => await GetResource<AddressGetResponse>(id).ConfigureAwait(false)).Result;
            address.Interface = this;


            return address;
        }
        /// <summary>
        /// Asynchronously get address with the specified id.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="id">Identifier.</param>
        public async Task<AddressGetResponse> GetAsync(string id)
        {
            var address = await GetResource<AddressGetResponse>(id);
            address.Interface = this;

            return address;
        }
        #endregion

        #region List
        /// <summary>
        /// List Addresses with the specified params.
        /// </summary>
        /// <returns>The list.</returns>
        /// <param name="countryIso">Country ISO (2-letter).</param>
        /// <param name="customerName">Customer's Name.</param>
        /// <param name="alias">Alias.</param>
        /// <param name="verificationStatus">Verification status.</param>
        /// <param name="validationStatus">Validation status.</param>
        /// <param name="limit">Limit.</param>
        /// <param name="offset">Offset.</param>
        public ListResponse<Address> List(
            string countryIso = null,
            string customerName = null,
            string alias = null,
            string verificationStatus = null,
            string validationStatus = null,
            uint? limit = null,
            uint? offset = null)
        {
            var mandatoryParams = new List<string> { };
            var data = CreateData(mandatoryParams, new
            {
                countryIso,
                customerName,
                alias,
                verificationStatus,
                validationStatus,
                limit,
                offset
            });
            var resources = Task.Run(async () => await ListResources<ListResponse<Address>>(data).ConfigureAwait(false)).Result;
            resources.Objects.ForEach(
                (obj) => obj.Interface = this
            );

            return resources;
        }
        /// <summary>
        /// List Addresses with the specified params.
        /// </summary>
        /// <returns>The list.</returns>
        /// <param name="countryIso">Country ISO (2-letter).</param>
        /// <param name="customerName">Customer's Name.</param>
        /// <param name="alias">Alias.</param>
        /// <param name="verificationStatus">Verification status.</param>
        /// <param name="validationStatus">Validation status.</param>
        /// <param name="limit">Limit.</param>
        /// <param name="offset">Offset.</param>
        public async Task<ListResponse<Address>> ListAsync(
            string countryIso = null,
            string customerName = null,
            string alias = null,
            string verificationStatus = null,
            string validationStatus = null,
            uint? limit = null,
            uint? offset = null)
        {
            var mandatoryParams = new List<string> { };
            var data = CreateData(mandatoryParams, new
            {
                countryIso,
                customerName,
                alias,
                verificationStatus,
                validationStatus,
                limit,
                offset
            });
            var resources = await ListResources<ListResponse<Address>>(data);
            resources.Objects.ForEach(
                (obj) => obj.Interface = this
            );

            return resources;
        }
        #endregion

        #region Delete
        /// <summary>
        /// Asynchronously delete Address with the specified id.
        /// </summary>
        /// <returns>The delete.</returns>
        /// <param name="id">Identifier.</param>
        public async Task<AddressDeleteResponse> DeleteAsync(string id)
        {
            return await DeleteResource(id);
        }
        /// <summary>
        ///  Delete Address with the specified id.
        /// </summary>
        /// <returns>The delete.</returns>
        /// <param name="id">Identifier.</param>
        public AddressDeleteResponse Delete(string id)
        {
            return Task.Run(async () => await DeleteResource(id).ConfigureAwait(false)).Result;
        }

        /// <summary>
        /// Deletes the address.
        /// </summary>
        /// <returns>The delete response.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="data">Data.</param>
        public async Task<AddressDeleteResponse> DeleteResource(string id, Dictionary<string, object> data = null)
        {
            var result = await Client.Delete<AddressDeleteResponse>(Uri + id + "/", data);

            result.Object = new AddressDeleteResponse
            {
                StatusCode = result.StatusCode
            };

            return result.Object;
        }

        #endregion
    }
}