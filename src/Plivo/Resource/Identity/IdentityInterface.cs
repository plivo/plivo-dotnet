using System.Collections.Generic;
using System.Threading.Tasks;
using Plivo.Client;

namespace Plivo.Resource.Identity
{
    /// <summary>
    /// Identity interface.
    /// </summary>
    public class IdentityInterface : ResourceInterface
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:plivo.Resource.Identity.IdentityInterface"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        public IdentityInterface(HttpClient client) : base(client)
        {
            Uri = "Account/" + Client.GetAuthId() + "/Verification/Identity/";
        }

        #region old

        /// <summary>
        /// Get identity with the specified id.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="id">Identifier.</param>
        public Identity GetOld(string id)
        {
            var identity = Task.Run(async () => await GetResource<Identity>(id).ConfigureAwait(false)).Result;
            identity.Interface = this;
            return identity;
        }
        /// <summary>
        /// Asynchronously get identity with the specified id.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="id">Identifier.</param>
        public async Task<Identity> GetAsyncOld(string id)
        {
            var identity = await GetResource<Identity>(id);
            identity.Interface = this;
            return identity;
        }

        /// <summary>
        /// List Identities with the specified params.
        /// </summary>
        /// <returns>The list.</returns>
        /// <param name="countryIso">Country ISO (2-letter).</param>
        /// <param name="customerName">Customer's Name.</param>
        /// <param name="alias">Alias.</param>
        /// <param name="verificationStatus">Verification status.</param>
        /// <param name="limit">Limit.</param>
        /// <param name="offset">Offset.</param>
        public ListResponse<Identity> ListOld(
            string countryIso = null,
            string customerName = null,
            string alias = null,
            string verificationStatus = null,
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
                limit,
                offset
            });

            var resources = Task.Run(async () => await ListResources<ListResponse<Identity>>(data).ConfigureAwait(false)).Result;
            resources.Objects.ForEach(
                (obj) => obj.Interface = this
            );

            return resources;
        }
        /// <summary>
        /// List Identities with the specified params.
        /// </summary>
        /// <returns>The list.</returns>
        /// <param name="countryIso">Country ISO (2-letter).</param>
        /// <param name="customerName">Customer's Name.</param>
        /// <param name="alias">Alias.</param>
        /// <param name="verificationStatus">Verification status.</param>
        /// <param name="limit">Limit.</param>
        /// <param name="offset">Offset.</param>
        public async Task<ListResponse<Identity>> ListAsyncOld(
            string countryIso = null,
            string customerName = null,
            string alias = null,
            string verificationStatus = null,
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
                limit,
                offset
            });

            var resources = await ListResources<ListResponse<Identity>>(data);
            resources.Objects.ForEach(
                (obj) => obj.Interface = this
            );

            return resources;
        }

        /// <summary>
        /// Delete Identity with the specified id.
        /// </summary>
        /// <returns>The delete.</returns>
        /// <param name="id">Identifier.</param>
        public DeleteResponse<Identity> DeleteOld(string id)
        {
            return Task.Run(async () => await DeleteResource<DeleteResponse<Identity>>(id).ConfigureAwait(false)).Result;
        }
        /// <summary>
        /// Asynchronously delete Identity with the specified id.
        /// </summary>
        /// <returns>The delete.</returns>
        /// <param name="id">Identifier.</param>
        public async Task<DeleteResponse<Identity>> DeleteAsyncOld(string id)
        {
            return await DeleteResource<DeleteResponse<Identity>>(id);
        }

        /// <summary>
        /// Create identity with the specified params
        /// </summary>
        /// <returns>The create.</returns>
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
        public IdentityCreateResponse CreateOld(
            string countryIso,
            string salutation,
            string firstName,
            string lastName,
            string birthPlace,
            string birthDate,
            string nationality,
            string idNationality,
            string idIssueDate,
            string idType,
            string idNumber,
            string addressLine1,
            string addressLine2,
            string city,
            string region,
            string postalCode,
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
            var mandatoryParams = new List<string>
            {
                "countryIso",
                "salutation",
                "firstName",
                "lastName",
                "birthPlace",
                "birthDate",
                "nationality",
                "idNationality",
                "idIssueDate",
                "idType",
                "idNumber",
                "addressLine1",
                "addressLine2",
                "city",
                "region",
                "postalCode",
                "addressProofType"
            };

            var data = CreateData(
                mandatoryParams,
                new
                {
                    countryIso,
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
                    autoCorrectAddress,
                    callbackUrl
                });

            var filesToUpload = new Dictionary<string, string>();

            if (fileToUpload != null)
            {
                filesToUpload.Add("file", fileToUpload);
            }

            var result = Task.Run(async () => await Client.Update<IdentityCreateResponse>(Uri, data, filesToUpload).ConfigureAwait(false)).Result;
            return result.Object;
        }
        /// <summary>
        /// Asynchronously create identity with the specified params
        /// </summary>
        /// <returns>The create.</returns>
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
        public async Task<IdentityCreateResponse> CreateAsyncOld(
            string countryIso,
            string salutation,
            string firstName,
            string lastName,
            string birthPlace,
            string birthDate,
            string nationality,
            string idNationality,
            string idIssueDate,
            string idType,
            string idNumber,
            string addressLine1,
            string addressLine2,
            string city,
            string region,
            string postalCode,
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
            var mandatoryParams = new List<string>
            {
                "countryIso",
                "salutation",
                "firstName",
                "lastName",
                "birthPlace",
                "birthDate",
                "nationality",
                "idNationality",
                "idIssueDate",
                "idType",
                "idNumber",
                "addressLine1",
                "addressLine2",
                "city",
                "region",
                "postalCode",
                "addressProofType"
            };

            var data = CreateData(
                mandatoryParams,
                new
                {
                    countryIso,
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
                    autoCorrectAddress,
                    callbackUrl
                });

            var filesToUpload = new Dictionary<string, string>();

            if (fileToUpload != null)
            {
                filesToUpload.Add("file", fileToUpload);
            }
            var result = await Client.Update<IdentityCreateResponse>(Uri, data, filesToUpload);
            return result.Object;
        }

        /// <summary>
        /// Update identity with the specified params
        /// </summary>
        /// <returns>The update.</returns>
        /// <param name="identityId">ID of the identity to be updated.</param>
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
        public UpdateResponse<Identity> UpdateOld(
            string identityId,
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
            var mandatoryParams = new List<string> { };

            var data = CreateData(
                mandatoryParams,
                new
                {
                    countryIso,
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
                    autoCorrectAddress,
                    callbackUrl
                });

            var filesToUpload = new Dictionary<string, string>();

            if (fileToUpload != null)
            {
                filesToUpload.Add("file", fileToUpload);
            }
            var result = Task.Run(async () => await Client.Update<UpdateResponse<Identity>>(Uri + identityId + "/", data, filesToUpload).ConfigureAwait(false)).Result;
            return result.Object;
        }
        /// <summary>
        /// Asynchronously update identity with the specified params
        /// </summary>
        /// <returns>The update.</returns>
        /// <param name="identityId">ID of the identity to be updated.</param>
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
        public async Task<UpdateResponse<Identity>> UpdateAsyncOld(
            string identityId,
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
            var mandatoryParams = new List<string> { };

            var data = CreateData(
                mandatoryParams,
                new
                {
                    countryIso,
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
                    autoCorrectAddress,
                    callbackUrl
                });

            var filesToUpload = new Dictionary<string, string>();

            if (fileToUpload != null)
            {
                filesToUpload.Add("file", fileToUpload);
            }

            var result = await Client.Update<UpdateResponse<Identity>>(Uri + identityId + "/", data, filesToUpload);
            return result.Object;
        }

        #endregion

        #region Get
        /// <summary>
        /// Get identity with the specified id.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="id">Identifier.</param>
        public IdentityGetResponse Get(string id)
        {
			return ExecuteWithExceptionUnwrap(() =>
			{
				var identity = Task.Run(async () => await GetResource<IdentityGetResponse>(id).ConfigureAwait(false)).Result;
				identity.Interface = this;

				return identity;
			});
        }
        /// <summary>
        /// Asynchronously get identity with the specified id.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="id">Identifier.</param>
        public async Task<IdentityGetResponse> GetAsync(string id)
        {
            var identity = await GetResource<IdentityGetResponse>(id);
            identity.Interface = this;

            return identity;
        }
        #endregion

        #region List
        /// <summary>
        /// List Identities with the specified params.
        /// </summary>
        /// <returns>The list.</returns>
        /// <param name="countryIso">Country ISO (2-letter).</param>
        /// <param name="customerName">Customer's Name.</param>
        /// <param name="alias">Alias.</param>
        /// <param name="verificationStatus">Verification status.</param>
        /// <param name="limit">Limit.</param>
        /// <param name="offset">Offset.</param>
        public ListResponse<Identity> List(
            string countryIso = null,
            string customerName = null,
            string alias = null,
            string verificationStatus = null,
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
                limit,
                offset
            });

			return ExecuteWithExceptionUnwrap(() =>
			{
				var resources = Task.Run(async () => await ListResources<ListResponse<Identity>>(data).ConfigureAwait(false)).Result;
				resources.Objects.ForEach(
					(obj) => obj.Interface = this
				);

				return resources;
			});
        }
        /// <summary>
        /// List Identities with the specified params.
        /// </summary>
        /// <returns>The list.</returns>
        /// <param name="countryIso">Country ISO (2-letter).</param>
        /// <param name="customerName">Customer's Name.</param>
        /// <param name="alias">Alias.</param>
        /// <param name="verificationStatus">Verification status.</param>
        /// <param name="limit">Limit.</param>
        /// <param name="offset">Offset.</param>
        public async Task<ListResponse<Identity>> ListAsync(
            string countryIso = null,
            string customerName = null,
            string alias = null,
            string verificationStatus = null,
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
                limit,
                offset
            });

            var resources = await ListResources<ListResponse<Identity>>(data);
            resources.Objects.ForEach(
                (obj) => obj.Interface = this
            );

            return resources;
        }
        #endregion

        #region Delete
        /// <summary>
        /// Delete Identity with the specified id.
        /// </summary>
        /// <returns>The delete.</returns>
        /// <param name="id">Identifier.</param>
        public IdentityDeleteResponse Delete(string id)
        {
			return ExecuteWithExceptionUnwrap(() =>
			{
				return Task.Run(async () => await DeleteResource(id).ConfigureAwait(false)).Result;
			});
        }
        /// <summary>
        /// Asynchronously delete Identity with the specified id.
        /// </summary>
        /// <returns>The delete.</returns>
        /// <param name="id">Identifier.</param>
        public async Task<IdentityDeleteResponse> DeleteAsync(string id)
        {
            return await DeleteResource(id);
        }

        /// <summary>
        /// Deletes the address.
        /// </summary>
        /// <returns>The delete response.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="data">Data.</param>
        public async Task<IdentityDeleteResponse> DeleteResource(string id, Dictionary<string, object> data = null)
        {
            var result = await Client.Delete<IdentityDeleteResponse>(Uri + id + "/", data);
            result.Object.StatusCode = result.StatusCode;
            return result.Object;
        }
        #endregion

        #region Create
        /// <summary>
        /// Create identity with the specified params
        /// </summary>
        /// <returns>The create.</returns>
        /// <param name="phoneNumberCountry">2-letter country ISO.</param>
        /// <param name="numberType">Number Type.</param>
        /// <param name="countryIso">2-letter country ISO.</param>
        /// <param name="salutation">Salutation.</param>
        /// <param name="firstName">First Name.</param>
        /// <param name="lastName">Last Name.</param>
        /// <param name="birthPlace">Place of birth.</param>
        /// <param name="birthDate">Birth date.</param>
        /// <param name="nationality">Nationality.</param>
        /// <param name="idNationality">Nationality as per the ID proof.</param>
        /// <param name="idIssueDate">ID issuing date.</param>
        /// <param name="addressProofType">Address Proof Type.</param>
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
        public IdentityCreateResponse Create(
            string phoneNumberCountry,
            string numberType,
            string countryIso,
            string salutation,
            string firstName,
            string lastName,
            string birthPlace,
            string birthDate,
            string nationality,
            string idNationality,
            string idIssueDate,
            string addressProofType,
            string idNumber,
            string addressLine1,
            string addressLine2,
            string city,
            string region,
            string postalCode,
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
            var mandatoryParams = new List<string>
            {
                "phoneNumberCountry",
                "numberType",
                "countryIso",
                "salutation",
                "firstName",
                "lastName",
                "birthPlace",
                "birthDate",
                "nationality",
                "idNationality",
                "idIssueDate",
                "idNumber",
                "addressLine1",
                "addressLine2",
                "city",
                "region",
                "postalCode",
                "addressProofType"
            };

            var data = CreateData(
                mandatoryParams,
                new
                {
                    phoneNumberCountry,
                    numberType,
                    countryIso,
                    salutation,
                    firstName,
                    lastName,
                    birthPlace,
                    birthDate,
                    nationality,
                    idNationality,
                    idIssueDate,
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
                    autoCorrectAddress,
                    callbackUrl,
                    addressProofType
                });

            var filesToUpload = new Dictionary<string, string>();

            if (fileToUpload != null)
            {
                filesToUpload.Add("file", fileToUpload);
            }

			return ExecuteWithExceptionUnwrap(() =>
			{
				var result = Task.Run(async () => await Client.Update<IdentityCreateResponse>(Uri, data, filesToUpload).ConfigureAwait(false)).Result;
				return result.Object;
			});
        }
        /// <summary>
        /// Asynchronously create identity with the specified params
        /// </summary>
        /// <returns>The create.</returns>
        /// <param name="phoneNumberCountry">2-letter country ISO.</param>
        /// <param name="numberType">Number Type.</param>
        /// <param name="countryIso">2-letter country ISO.</param>
        /// <param name="salutation">Salutation.</param>
        /// <param name="firstName">First Name.</param>
        /// <param name="lastName">Last Name.</param>
        /// <param name="birthPlace">Place of birth.</param>
        /// <param name="birthDate">Birth date.</param>
        /// <param name="nationality">Nationality.</param>
        /// <param name="idNationality">Nationality as per the ID proof.</param>
        /// <param name="idIssueDate">ID issuing date.</param>
        /// <param name="addressProofType">Address Proof Type.</param>
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
        public async Task<IdentityCreateResponse> CreateAsync(
            string phoneNumberCountry,
            string numberType,
            string countryIso,
            string salutation,
            string firstName,
            string lastName,
            string birthPlace,
            string birthDate,
            string nationality,
            string idNationality,
            string idIssueDate,
            string addressProofType,
            string idNumber,
            string addressLine1,
            string addressLine2,
            string city,
            string region,
            string postalCode,
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
            var mandatoryParams = new List<string>
            {
                "phoneNumberCountry",
                "numberType",
                "countryIso",
                "salutation",
                "firstName",
                "lastName",
                "birthPlace",
                "birthDate",
                "nationality",
                "idNationality",
                "idIssueDate",
                "idNumber",
                "addressLine1",
                "addressLine2",
                "city",
                "region",
                "postalCode",
                "addressProofType"
            };

            var data = CreateData(
                mandatoryParams,
                new
                {
                    phoneNumberCountry,
                    numberType,
                    countryIso,
                    salutation,
                    firstName,
                    lastName,
                    birthPlace,
                    birthDate,
                    nationality,
                    idNationality,
                    idIssueDate,
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
                    autoCorrectAddress,
                    callbackUrl,
                    addressProofType
                });

            var filesToUpload = new Dictionary<string, string>();

            if (fileToUpload != null)
            {
                filesToUpload.Add("file", fileToUpload);
            }
            var result = await Client.Update<IdentityCreateResponse>(Uri, data, filesToUpload);
            return result.Object;
        }
        #endregion

        #region Update
        /// <summary>
        /// Update identity with the specified params
        /// </summary>
        /// <returns>The update.</returns>
        /// <param name="identityId">ID of the identity to be updated.</param>
        /// <param name="phoneNumberCountry">2-letter country ISO.</param>
        /// <param name="numberType">Number Type.</param>
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
            string identityId,
            string phoneNumberCountry = null,
            string numberType = null,
            string countryIso = null,
            string salutation = null,
            string firstName = null,
            string lastName = null,
            string birthPlace = null,
            string birthDate = null,
            string nationality = null,
            string idNationality = null,
            string idIssueDate = null,
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
            var mandatoryParams = new List<string> { };

            var data = CreateData(
                mandatoryParams,
                new
                {
                    phoneNumberCountry,
                    numberType,
                    countryIso,
                    salutation,
                    firstName,
                    lastName,
                    birthPlace,
                    birthDate,
                    nationality,
                    idNationality,
                    idIssueDate,
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
                    autoCorrectAddress,
                    callbackUrl
                });

            var filesToUpload = new Dictionary<string, string>();

            if (fileToUpload != null)
            {
                filesToUpload.Add("file", fileToUpload);
            }

			return ExecuteWithExceptionUnwrap(() =>
			{
				var result = Task.Run(async () => await Client.Update<UpdateResponse<Identity>>(Uri + identityId + "/", data, filesToUpload).ConfigureAwait(false)).Result;
				return result.Object;
			});
        }
        /// <summary>
        /// Asynchronously update identity with the specified params
        /// </summary>
        /// <returns>The update.</returns>
        /// <param name="identityId">ID of the identity to be updated.</param>
        /// <param name="phoneNumberCountry">2-letter country ISO.</param>
        /// <param name="numberType">Number Type.</param>
        /// <param name="countryIso">2-letter country ISO.</param>
        /// <param name="salutation">Salutation.</param>
        /// <param name="firstName">First Name.</param>
        /// <param name="lastName">Last Name.</param>
        /// <param name="birthPlace">Place of birth.</param>
        /// <param name="birthDate">Birth date.</param>
        /// <param name="nationality">Nationality.</param>
        /// <param name="idNationality">Nationality as per the ID proof.</param>
        /// <param name="idIssueDate">ID issuing date.</param>
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
        public async  Task<UpdateResponse<Identity>> UpdateAsync(
            string identityId,
            string phoneNumberCountry = null,
            string numberType = null,
            string countryIso = null,
            string salutation = null,
            string firstName = null,
            string lastName = null,
            string birthPlace = null,
            string birthDate = null,
            string nationality = null,
            string idNationality = null,
            string idIssueDate = null,
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
            var mandatoryParams = new List<string> { };

            var data = CreateData(
                mandatoryParams,
                new
                {
                    phoneNumberCountry,
                    numberType,
                    countryIso,
                    salutation,
                    firstName,
                    lastName,
                    birthPlace,
                    birthDate,
                    nationality,
                    idNationality,
                    idIssueDate,
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
                    autoCorrectAddress,
                    callbackUrl
                });

            var filesToUpload = new Dictionary<string, string>();

            if (fileToUpload != null)
            {
                filesToUpload.Add("file", fileToUpload);
            }

            var result = await Client.Update<UpdateResponse<Identity>>(Uri + identityId + "/", data, filesToUpload);
            return result.Object;
        }
        #endregion
    }
}