using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Plivo.Client;
using Plivo.Utilities;

namespace Plivo.Resource.TollfreeVerification
{
    public class TollfreeVerificationInterface : ResourceInterface
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:plivo.Resource.TollfreeVerification.TollfreeVerificationInterface"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        public TollfreeVerificationInterface(HttpClient client) : base(client)
        {
            Uri = "Account/" + Client.GetAuthId() + "/TollfreeVerification/";
        }

        #region create

        /// <summary>
        /// Create TollfreeVerification request with the specified parameters.
        /// </summary>
        /// <param name="profileUuid">The profile UUID.</param>
        /// <param name="number">The toll-free number.</param>
        /// <param name="usecase">The use case, e.g., "2FA, App Notifications".</param>
        /// <param name="usecaseSummary">The summary of the use case.</param>
        /// <param name="messageSample">Sample messages associated with the use case.</param>
        /// <param name="optinImageUrl">The URL of the opt-in image.</param>
        /// <param name="optinType">The type of opt-in.</param>
        /// <param name="volume">The message volume.</param>
        /// <param name="additionalInformation">Additional information.</param>
        /// <param name="extraData">Extra data.</param>
        /// <param name="callbackUrl">The callback URL.</param>
        /// <param name="callbackMethod">The callback method.</param>
        public TollfreeVerificationCreateResponse Create(
            string profileUuid, string number, string usecase,
            string usecaseSummary, string messageSample, string optinImageUrl, string optinType,
            string volume, string additionalInformation = null, string extraData = null, string callbackUrl = null,
            string callbackMethod = null)
        {
            var mandatoryParams = new List<string>
            {
                "profileUuid", "usecase", "usecaseSummary", "messageSample", "optInImageUrl", "optInType", "volume",
                "number"
            };
            var data = CreateData(
                mandatoryParams, new
                {
                    profileUuid,
                    number,
                    usecase,
                    usecaseSummary,
                    messageSample,
                    optinType,
                    optinImageUrl,
                    volume,
                    additionalInformation,
                    extraData,
                    callbackUrl,
                    callbackMethod
                });
            return ExecuteWithExceptionUnwrap(() =>
            {
                var result = Task.Run(async () =>
                    await Client.Update<TollfreeVerificationCreateResponse>(Uri, data).ConfigureAwait(false)).Result;
                JObject responseJson = JObject.Parse(result.Content);
                result.Object.StatusCode = result.StatusCode;
                result.Object.ApiId = responseJson["api_id"].ToString();
                result.Object.Message = responseJson["message"].ToString();
                result.Object.Uuid = responseJson["uuid"].ToString();
                return result.Object;
            });
        }

        /// <summary>
        ///  Asynchronously Create TollfreeVerification request with the specified parameters.
        /// fallbackMethod, messageUrl, messageMethod, defaultNumberApp, defaultEndpointApp, subaccount and logIncomingMessages.
        /// </summary>
        /// <returns>The create.</returns>
        /// <param name="profileUuid">The profile UUID.</param>
        /// <param name="number">The toll-free number.</param>
        /// <param name="usecase">The use case, e.g., "2FA, App Notifications".</param>
        /// <param name="usecaseSummary">The summary of the use case.</param>
        /// <param name="messageSample">Sample messages associated with the use case.</param>
        /// <param name="optinImageUrl">The URL of the opt-in image.</param>
        /// <param name="optinType">The type of opt-in.</param>
        /// <param name="volume">The message volume.</param>
        /// <param name="additionalInformation">Additional information.</param>
        /// <param name="extraData">Extra data.</param>
        /// <param name="callbackUrl">The callback URL.</param>
        /// <param name="callbackMethod">The callback method.</param>
        public async Task<TollfreeVerificationCreateResponse> CreateAsync(
            string profileUuid, string number, string usecase,
            string usecaseSummary, string messageSample, string optinImageUrl, string optinType,
            string volume, string additionalInformation = null, string extraData = null, string callbackUrl = null,
            string callbackMethod = null)
        {
            var mandatoryParams = new List<string>
            {
                "profileUuid", "usecase", "usecaseSummary", "messageSample", "optInImageUrl", "optInType", "volume",
                "number"
            };
            var data = CreateData(
                mandatoryParams,
                new
                {
                    profileUuid,
                    number,
                    usecase,
                    usecaseSummary,
                    messageSample,
                    optinType,
                    optinImageUrl,
                    volume,
                    additionalInformation,
                    extraData,
                    callbackUrl,
                    callbackMethod
                });


            var result = Task.Run(async () =>
                    await Client.Update<TollfreeVerificationCreateResponse>(Uri, data).ConfigureAwait(false))
                .Result;
            await Task.WhenAll();
            result.Object.StatusCode = result.StatusCode;
            JObject responseJson = JObject.Parse(result.Content);
            result.Object.ApiId = responseJson["api_id"].ToString();
            result.Object.Message = responseJson["message"].ToString();
            result.Object.Uuid = responseJson["uuid"].ToString();

            return result.Object;
        }

        #endregion

        #region Get

        /// <summary>
        /// Get Tollfree Verification Request with the specified uuid.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="uuid">App identifier.</param>
        public TollfreeVerification Get(string uuid)
        {
            return ExecuteWithExceptionUnwrap(() =>
            {
                var tfVerification =
                    Task.Run(async () => await GetResource<TollfreeVerification>(uuid).ConfigureAwait(false)).Result;
                tfVerification.Interface = this;
                return tfVerification;
            });
        }

        /// <summary>
        /// Asynchronously get Message with the specified messageUuid.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="uuid">TF Verification UUID.</param>
        public async Task<TollfreeVerification> GetAsync(string uuid)
        {
            var result = Task.Run(async () => await Client.Fetch<TollfreeVerification>(
                Uri + uuid + "/").ConfigureAwait(false)).Result;
            await Task.WhenAll();
            return result.Object;
        }

        #endregion

        #region List

        /// <summary>
        /// List TF Verification Request with the specified params, limit and offset.
        /// </summary>
        /// <returns>The list.</returns>
        /// <param name="limit">Limit.</param>
        /// <param name="offset">Offset.</param>
        /// <param name="number">Number.</param>
        /// <param name="status">Status.</param>
        /// <param name="profileUuid">Profile UUID.</param>
        /// <param name="created_gt">Created Time Greater Than.</param>
        /// <param name="created_gte">Created Time Greater Than Equal.</param>
        /// <param name="created_lt">Created Time Less Than.</param>
        /// <param name="created_lte">Created Time Less Than Equal.</param>
        /// <param name="usecase">Usecase.</param>
        public TollfreeVerificationListResponse<TollfreeVerification> List(
            uint? limit = null,
            uint? offset = null,
            string number = null,
            string status = null,
            string profileUuid = null,
            string usecase = null,
            string created_gt = null,
            string created_gte = null,
            string created_lt = null,
            string created_lte = null
        )
        {
            var mandatoryParams = new List<string> { "" };
            var data = CreateData(
                mandatoryParams, new
                {
                    limit,
                    offset,
                    number,
                    status,
                    profileUuid,
                    created_gt,
                    created_gte,
                    created_lt,
                    created_lte,
                    usecase
                });

            return ExecuteWithExceptionUnwrap(() =>
            {
                var resources = Task.Run(async () =>
                    await ListResources<TollfreeVerificationListResponse<TollfreeVerification>>(data)
                        .ConfigureAwait(false)).Result;
                resources.Objects.ForEach(
                    (obj) => obj.Interface = this
                );
                return resources;
            });
        }

        /// <summary>
        /// List TF Verification Request with the specified params, limit and offset.
        /// </summary>
        /// <returns>The list.</returns>
        /// <param name="limit">Limit.</param>
        /// <param name="offset">Offset.</param>
        /// <param name="number">Number.</param>
        /// <param name="status">Status.</param>
        /// <param name="profileUuid">Profile UUID.</param>
        /// <param name="created__gt">Created Time Greater Than.</param>
        /// <param name="created__gte">Created Time Greater Than Equal.</param>
        /// <param name="created__lt">Created Time Less Than.</param>
        /// <param name="created__lte">Created Time Less Than Equal.</param>
        /// <param name="usecase">Usecase.</param>
        public async Task<TollfreeVerificationListResponse<TollfreeVerification>> ListAsync(
            uint? limit = null,
            uint? offset = null,
            string number = null,
            string status = null,
            string profileUuid = null,
            string created__gt = null,
            string created__gte = null,
            string created__lt = null,
            string created__lte = null,
            string usecase = null
        )
        {
            var mandatoryParams = new List<string> { "" };
            var data = CreateData(
                mandatoryParams, new
                {
                    limit,
                    offset,
                    number,
                    status,
                    profileUuid,
                    created__gt,
                    created__gte,
                    created__lt,
                    created__lte,
                    usecase
                });
            // var resources = await ListResources<TollfreeVerificationListResponse<TollfreeVerification>>(data);
            var result = Task.Run(async () => await Client
                .Fetch<TollfreeVerificationListResponse<TollfreeVerification>>(
                    Uri, data).ConfigureAwait(false)).Result;
            await Task.WhenAll();
            return result.Object;
        }

        #endregion

        #region Update

        /// <summary>
        /// Update Tollfree Verification request with the specified profileUuid, usecase, usecaseSummary, messageSample, optinImageUrl,
        /// optinType, volume, additionalInformation, extraData, callbackUrl, callbackMethod.
        /// </summary>
        /// <returns>The update.</returns>
        /// <param name="uuid">The tollfree verification request UUID.</param>
        /// <param name="profileUuid">The profile UUID.</param>
        /// <param name="usecase">The use case, e.g., "2FA, App Notifications".</param>
        /// <param name="usecaseSummary">The summary of the use case.</param>
        /// <param name="messageSample">Sample messages associated with the use case.</param>
        /// <param name="optinImageUrl">The URL of the opt-in image.</param>
        /// <param name="optinType">The type of opt-in.</param>
        /// <param name="volume">The message volume.</param>
        /// <param name="additionalInformation">Additional information.</param>
        /// <param name="extraData">Extra data.</param>
        /// <param name="callbackUrl">The callback URL.</param>
        /// <param name="callbackMethod">The callback method.</param>
        public UpdateResponse<TollfreeVerification> Update(
            string uuid, string profileUuid = null, string usecase = null, string usecaseSummary = null,
            string messageSample = null,
            string optinImageUrl = null, string optinType = null, string volume = null,
            string additionalInformation = null,
            string extraData = null, string callbackUrl = null, string callbackMethod = null)
        {
            var mandatoryParams = new List<string> { "" };
            var data = CreateData(
                mandatoryParams,
                new
                {
                    uuid,
                    profileUuid,
                    usecase,
                    usecaseSummary,
                    messageSample,
                    optinType,
                    optinImageUrl,
                    volume,
                    additionalInformation,
                    extraData,
                    callbackUrl,
                    callbackMethod
                });

            return ExecuteWithExceptionUnwrap(() =>
            {
                var result = Task.Run(async () =>
                        await Client.Update<UpdateResponse<TollfreeVerification>>(Uri + uuid + "/", data)
                            .ConfigureAwait(false))
                    .Result;
                result.Object.StatusCode = result.StatusCode;
                return result.Object;
            });
        }

        /// <summary>
        /// Asynchronously update tollfree verificartion request with the specified profileUuid, usecase, usecaseSummary, messageSample, optinImageUrl,
        /// optinType, volume, additionalInformation, extraData, callbackUrl, callbackMethod.
        /// </summary>
        /// <returns>The update.</returns>
        /// <param name="uuid">The tollfree verification request UUID.</param>
        /// <param name="profileUuid">The profile UUID.</param>
        /// <param name="usecase">The use case, e.g., "2FA, App Notifications".</param>
        /// <param name="usecaseSummary">The summary of the use case.</param>
        /// <param name="messageSample">Sample messages associated with the use case.</param>
        /// <param name="optinImageUrl">The URL of the opt-in image.</param>
        /// <param name="optinType">The type of opt-in.</param>
        /// <param name="volume">The message volume.</param>
        /// <param name="additionalInformation">Additional information.</param>
        /// <param name="extraData">Extra data.</param>
        /// <param name="callbackUrl">The callback URL.</param>
        /// <param name="callbackMethod">The callback method.</param>
        public async Task<AsyncResponse> UpdateAsync(
            string uuid, string profileUuid = null, string usecase = null, string usecaseSummary = null,
            string messageSample = null,
            string optinImageUrl = null, string optinType = null, string volume = null,
            string additionalInformation = null,
            string extraData = null, string callbackUrl = null, string callbackMethod = null)
        {
            MpcUtils.ValidUrl("callbackUrl", callbackUrl, true);
            var mandatoryParams = new List<string> { "" };
            var data = CreateData(
                mandatoryParams,
                new
                {
                    uuid,
                    profileUuid,
                    usecase,
                    usecaseSummary,
                    messageSample,
                    optinType,
                    optinImageUrl,
                    volume,
                    additionalInformation,
                    extraData,
                    callbackUrl,
                    callbackMethod
                });
            var result = Task.Run(async () =>
                await Client.Update<AsyncResponse>(Uri + uuid + "/", data).ConfigureAwait(false)).Result;
            await Task.WhenAll();
            result.Object.StatusCode = result.StatusCode;
            JObject responseJson = JObject.Parse(result.Content);
            result.Object.ApiId = responseJson["api_id"].ToString();
            result.Object.Message = responseJson["message"].ToString();
            return result.Object;
        }

        #endregion

        #region Delete

        /// <summary>
        /// Delete Tollfree Verification Request with the specified uuid.
        /// </summary>
        /// <returns>The delete.</returns>
        /// <param name="uuid">App identifier.</param>
        public DeleteResponse<TollfreeVerification> Delete(string uuid)
        {
            return ExecuteWithExceptionUnwrap(() =>
            {
                return Task.Run(async () =>
                    await DeleteResource<DeleteResponse<TollfreeVerification>>(uuid).ConfigureAwait(false)).Result;
            });
        }

        /// <summary>
        /// Asynchronously delete Application with the specified appId.
        /// </summary>
        /// <returns>The delete.</returns>
        /// <param name="uuid">App identifier.</param>
        public async Task<AsyncResponse> DeleteAsync(string uuid)
        {
            var result = Task.Run(async () => await Client.Delete<AsyncResponse>(
                Uri + uuid + "/").ConfigureAwait(false)).Result;
            await Task.WhenAll();
            result.Object.StatusCode = result.StatusCode;
            return result.Object;
        }

        #endregion
    }
}