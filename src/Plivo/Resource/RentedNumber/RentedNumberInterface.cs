using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Plivo.Client;


namespace Plivo.Resource.RentedNumber
{
    /// <summary>
    /// Rented number interface.
    /// </summary>
    public class RentedNumberInterface : ResourceInterface
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:plivo.Resource.RentedNumber.RentedNumberInterface"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        public RentedNumberInterface(HttpClient client) : base(client)
        {
            Uri = "Account/" + Client.GetAuthId() + "/Number/";
        }

        #region Get
        /// <summary>
        /// Get RentedNumber with the specified number.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="number">Number.</param>
        public RentedNumber Get(string number)
        {
			return ExecuteWithExceptionUnwrap(() =>
			{
				var rentedNumber = Task.Run(async () => await GetResource<RentedNumber>(number).ConfigureAwait(false)).Result;
				rentedNumber.Interface = this;
				return rentedNumber;
			});
        }

        /// <summary>
        /// Asynchronously get RentedNumber with the specified number.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="number">Number.</param>
        public async Task<RentedNumber> GetAsync(string number)
        {
            var rentedNumber = await GetResource<RentedNumber>(number);
            rentedNumber.Interface = this;
            return rentedNumber;
        }
        #endregion

        #region List
        /// <summary>
        /// List RentedNumber with the specified type, numberStartswith, subaccount, alias, services, limit and offset.
        /// </summary>
        /// <returns>The list.</returns>
        /// <param name="type">Type.</param>
        /// <param name="numberStartswith">Number startswith.</param>
        /// <param name="subaccount">Subaccount.</param>
        /// <param name="alias">Alias.</param>
        /// <param name="services">Services.</param>
        /// <param name="limit">Limit.</param>
        /// <param name="offset">Offset.</param>
        /// <param name="tendlcCampaignId">TenDlc Campaign ID.</param>
        /// <param name="tendlcRegistrationStatus">TenDLC Registration Status.</param>
        /// <param name="tollFreeSMSVerification">Toll-free SMS Verification status .</param>
        /// <param name="renewalDate">Renewal Date</param>
        /// <param name="renewalDate_Lt">Renewal Date Less Than</param>
        /// <param name="renewalDate_Lte">Renewal Date Less Than or Equal</param>
        /// <param name="renewalDate_Gt">Renewal Date Greater Than</param>
        /// <param name="renewalDate_Gte">Renewal Date Greater Than or Equal</param>
        /// <param name="cnamLookup">Cnam Lookup configuration</param>
        public ListResponse<RentedNumber> List(
            string type = null, string numberStartswith = null,
            string subaccount = null, string alias = null,
            string services = null,
            string tendlcCampaignId = null, string tendlcRegistrationStatus = null,
            PropertyInfo tollFreeSmsVerification = null,
            string renewalDate = null,
            string renewalDate_Lt = null, string renewalDate_Lte = null,
            string renewalDate_Gt = null, string renewalDate_Gte = null,
            string cnamLookup = null,
            uint? limit = null, uint? offset = null)
        {
            var mandatoryParams = new List<string> {""};
            var data = CreateData(
                mandatoryParams,
                new
                {
                    type,
                    numberStartswith,
                    subaccount,
                    alias,
                    services,
                    tendlcCampaignId,
                    tendlcRegistrationStatus,
                    tollFreeSmsVerification,
                    renewalDate,
                    renewalDate_Lt,
                    renewalDate_Lte,
                    renewalDate_Gte,
                    renewalDate_Gt,
                    cnamLookup,
                    limit,
                    offset
                });

			return ExecuteWithExceptionUnwrap(() =>
			{
				var resources = Task.Run(async () => await ListResources<ListResponse<RentedNumber>>(data).ConfigureAwait(false)).Result;
				resources.Objects.ForEach(
					(obj) => obj.Interface = this
				);

				return resources;
			});
        }
        /// <summary>
        /// List RentedNumber with the specified type, numberStartswith, subaccount, alias, services, limit and offset.
        /// </summary>
        /// <returns>The list.</returns>
        /// <param name="type">Type.</param>
        /// <param name="numberStartswith">Number startswith.</param>
        /// <param name="subaccount">Subaccount.</param>
        /// <param name="alias">Alias.</param>
        /// <param name="services">Services.</param>
        /// <param name="limit">Limit.</param>
        /// <param name="offset">Offset.</param>
        public async Task<ListResponse<RentedNumber>> ListAsync(
            string type = null, string numberStartswith = null,
            string subaccount = null, string alias = null,
            string services = null, uint? limit = null, uint? offset = null)
        {
            var mandatoryParams = new List<string> { "" };
            var data = CreateData(
                mandatoryParams,
                new
                {
                    type,
                    numberStartswith,
                    subaccount,
                    alias,
                    services,
                    limit,
                    offset
                });
            var resources = await ListResources<ListResponse<RentedNumber>>(data);
            resources.Objects.ForEach(
                (obj) => obj.Interface = this
            );

            return resources;
        }
        #endregion

        #region AddNumber
        /// <summary>
        /// Adds the number.
        /// </summary>
        /// <returns>The number.</returns>
        /// <param name="numbers">Numbers.</param>
        /// <param name="carrier">Carrier.</param>
        /// <param name="region">Region.</param>
        /// <param name="numberType">Number type.</param>
        /// <param name="appId">App identifier.</param>
        /// <param name="subaccount">Subaccount.</param>
        public UpdateResponse<RentedNumber> AddNumber(
            List<string> numbers, string carrier, string region,
            string numberType = null, string appId = null,
            string subaccount = null)
        {
            string _numbers = string.Join(",", numbers);
            var mandatoryParams = new List<string> {""};
            var data = CreateData(
                mandatoryParams,
                new
                {
                    _numbers,
                    carrier,
                    region,
                    numberType,
                    appId,
                    subaccount
                });

			return ExecuteWithExceptionUnwrap(() =>
			{
				var result = Task.Run(async () => await Client.Update<UpdateResponse<RentedNumber>>(Uri, data).ConfigureAwait(false)).Result;
                result.Object.StatusCode = result.StatusCode;
				return result.Object;
			});
        }
        /// <summary>
        /// Asynchronously adds the number.
        /// </summary>
        /// <returns>The number.</returns>
        /// <param name="numbers">Numbers.</param>
        /// <param name="carrier">Carrier.</param>
        /// <param name="region">Region.</param>
        /// <param name="numberType">Number type.</param>
        /// <param name="appId">App identifier.</param>
        /// <param name="subaccount">Subaccount.</param>
        public async Task<UpdateResponse<RentedNumber>> AddNumberAsync(
            List<string> numbers, string carrier, string region,
            string numberType = null, string appId = null,
            string subaccount = null)
        {
            string _numbers = string.Join(",", numbers);
            var mandatoryParams = new List<string> { "" };
            var data = CreateData(
                mandatoryParams,
                new
                {
                    _numbers,
                    carrier,
                    region,
                    numberType,
                    appId,
                    subaccount
                });
            var result = await Client.Update<UpdateResponse<RentedNumber>>(Uri, data);
            result.Object.StatusCode = result.StatusCode;
            return result.Object;
        }
        #endregion

        #region Update
        /// <summary>
        /// Update RentedNumber with the specified number, appId, subaccount and alias.
        /// </summary>
        /// <returns>The update.</returns>
        /// <param name="number">Number.</param>
        /// <param name="appId">App identifier.</param>
        /// <param name="subaccount">Subaccount.</param>
        /// <param name="alias">Alias.</param>
        /// <param name="verificationInfo">Verification Information.</param>
        /// <param name="cnamLookup">Cnam Lookup.</param>
        public UpdateResponse<RentedNumber> Update(
            string number, string appId = null, string subaccount = null,
            string alias = null, Dictionary<string, string> verificationInfo = null, string cnamLookup = null)
        {
            var mandatoryParams = new List<string> {""};
            var data = CreateData(
                mandatoryParams,
                new
                {
                    appId,
                    subaccount,
                    alias,
                    verificationInfo,
                    cnamLookup
                });
            if (appId == "null") data["app_id"] = null;

			return ExecuteWithExceptionUnwrap(() =>
			{
				var result = Task.Run(async () => await Client.Update<UpdateResponse<RentedNumber>>(
					Uri + number + "/",
					data
				).ConfigureAwait(false)).Result;
                result.Object.StatusCode = result.StatusCode;
				return result.Object;
			});
        }
        /// <summary>
        /// Asynchronously update RentedNumber with the specified number, appId, subaccount and alias.
        /// </summary>
        /// <returns>The update.</returns>
        /// <param name="number">Number.</param>
        /// <param name="appId">App identifier.</param>
        /// <param name="subaccount">Subaccount.</param>
        /// <param name="alias">Alias.</param>
        /// <param name="verificationInfo">Verification Information.</param>
        /// <param name="cnamLookup">Cnam Lookup.</param>
        public async Task<UpdateResponse<RentedNumber>> UpdateAsync(
            string number, string appId = null, string subaccount = null,
            string alias = null, Dictionary<string, string> verificationInfo = null, string cnamLookup = null)
        {
            var mandatoryParams = new List<string> { "" };
            var data = CreateData(
                mandatoryParams,
                new
                {
                    appId,
                    subaccount,
                    alias,
                    verificationInfo,
                    cnamLookup
                });
            if (appId == "null") data["app_id"] = null;
            var result = await Client.Update<UpdateResponse<RentedNumber>>(
        Uri + number + "/",
        data
    );
            result.Object.StatusCode = result.StatusCode;
            return result.Object;
        }
        #endregion

        #region Delete
        /// <summary>
        /// Unrent RentedNumber with the specified number.
        /// </summary>
        /// <returns>The delete.</returns>
        /// <param name="number">Number.</param>
        public DeleteResponse<RentedNumber> Delete(string number)
        {
			return ExecuteWithExceptionUnwrap(() =>
			{
				return Task.Run(async () => await DeleteResource<DeleteResponse<RentedNumber>>(number).ConfigureAwait(false)).Result;
			});
        }
        /// <summary>
        /// Asynchronously unrent RentedNumber with the specified number.
        /// </summary>
        /// <returns>The delete.</returns>
        /// <param name="number">Number.</param>
        public async Task<DeleteResponse<RentedNumber>> DeleteAsync(string number)
        {
            return await DeleteResource<DeleteResponse<RentedNumber>>(number);
        }
        #endregion
    }
}