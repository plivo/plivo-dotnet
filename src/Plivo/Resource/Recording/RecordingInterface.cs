using System;
using System.Linq;
using System.Reflection;
using Plivo.Client;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Plivo.Utilities;

namespace Plivo.Resource.Recording
{
    /// <summary>
    /// Recording interface.
    /// </summary>
    public class RecordingInterface : ResourceInterface
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:plivo.Resource.Recording.RecordingInterface"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        public RecordingInterface(HttpClient client) : base(client)
        {
            Uri = "Account/" + Client.GetAuthId() + "/Recording/";
        }

        #region Get
        /// <summary>
        /// Get Recording with the specified recordingId.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="recordingId">Recording identifier.</param>
        public Recording Get(string recordingId)
        {
			return ExecuteWithExceptionUnwrap(() =>
			{
				var recording = Task.Run(async () => await GetResource<Recording>(recordingId, new Dictionary<string, object> () { {"is_voice_request", true} }).ConfigureAwait(false)).Result;
				recording.Interface = this;
				return recording;
			});
        }
        /// <summary>
        /// Asynchronously get Recording with the specified recordingId.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="recordingId">Recording identifier.</param>
        /// <param name="callbackUrl">Callback URL.</param>
        /// <param name="callbackMethod">Callback method.</param>
        public async Task<AsyncResponse> GetAsync(string recordingId, string callbackUrl = null, string callbackMethod = null)
        {
            MpcUtils.ValidUrl("callbackUrl", callbackUrl, true);
            var data = new Dictionary<string, object>()
            {
                {"is_voice_request", true},
                {"callback_url", callbackUrl},
                {"callback_method", callbackMethod}
            };
            if (data.ContainsKey("callback_method") && callbackMethod == null) {
                data.Remove("callback_method");
            }
            var result = Task.Run(async () => await Client.Fetch<AsyncResponse>(
                Uri + recordingId + "/", data).ConfigureAwait(false)).Result;
            await Task.WhenAll();
            result.Object.StatusCode = result.StatusCode;
            JObject responseJson = JObject.Parse(result.Content);
            result.Object.ApiId = responseJson["api_id"].ToString();
            result.Object.Message = responseJson["message"].ToString();
            return result.Object;
        }
        #endregion

        #region List
        /// <summary>
        /// List Recording with the specified subaccount, callUuid, addTime, addTime_Gt, addTime_Gte, addTime_Lt, addTime_Lte, limit
        /// and offset.
        /// </summary>
        /// <returns>The list.</returns>
        /// <param name="subaccount">Subaccount.</param>
        /// <param name="callUuid">Call UUID.</param>
        /// <param name="addTime">Add time.</param>
        /// <param name="addTime_Gt">Add time gt.</param>
        /// <param name="addTime_Gte">Add time gte.</param>
        /// <param name="addTime_Lt">Add time lt.</param>
        /// <param name="addTime_Lte">Add time lte.</param>
        /// <param name="limit">Limit.</param>
        /// <param name="offset">Offset.</param>
        /// <param name="fromNumber">From Number.</param>
        /// <param name="toNumber">To Number.</param>
        /// <param name="conferenceName">Conference Name.</param>
        /// <param name="mpcName">Mpc Name.</param>
        /// <param name="conferenceUuid">Conference Uuid.</param>
        /// <param name="mpcUuid">mpc Uuid.</param>
        public ListResponse<Recording> List(
            string fromNumber = null, string toNumber = null,
            string conferenceName = null, string mpcName = null,
            string conferenceUuid = null, string mpcUuid = null,
            string subaccount = null, string callUuid = null,
            DateTime? addTime = null, DateTime? addTime_Gt = null,
            DateTime? addTime_Gte = null, DateTime? addTime_Lt = null,
            DateTime? addTime_Lte = null, uint? limit = null,
            uint? offset = null)
        {
            var _addTime = addTime?.ToString("yyyy-MM-dd HH':'mm':'ss'.'ffffff''") ?? null;
            var _addTime_Gt = addTime_Gt?.ToString("yyyy-MM-dd HH':'mm':'ss'.'ffffff''") ?? null;
            var _addTime_Gte = addTime_Gte?.ToString("yyyy-MM-dd HH':'mm':'ss'.'ffffff''") ?? null;
            var _addTime_Lt = addTime_Lt?.ToString("yyyy-MM-dd HH':'mm':'ss'.'ffffff''") ?? null;
            var _addTime_Lte = addTime_Lte?.ToString("yyyy-MM-dd HH':'mm':'ss'.'ffffff''") ?? null;

            var mandatoryParams = new List<string> {""};
            bool isVoiceRequest = true;
            var data = CreateData(
                mandatoryParams,
                new
                {
                    fromNumber,
                    toNumber,
                    conferenceName,
                    mpcName,
                    conferenceUuid,
                    mpcUuid,
                    subaccount,
                    callUuid,
                    _addTime,
                    _addTime_Gt,
                    _addTime_Gte,
                    _addTime_Lt,
                    _addTime_Lte,
                    limit,
                    offset,
                    isVoiceRequest
                });

			return ExecuteWithExceptionUnwrap(() =>
			{
				var resources = Task.Run(async () => await ListResources<ListResponse<Recording>>(data).ConfigureAwait(false)).Result;
				resources.Objects.ForEach(
					(obj) => obj.Interface = this
				);

				return resources;
			});
        }
        /// <summary>
        /// List Recording with the specified subaccount, callUuid, addTime, addTime_Gt, addTime_Gte, addTime_Lt, addTime_Lte, limit
        /// and offset.
        /// </summary>
        /// <returns>The list.</returns>
        /// <param name="subaccount">Subaccount.</param>
        /// <param name="callUuid">Call UUID.</param>
        /// <param name="addTime">Add time.</param>
        /// <param name="addTime_Gt">Add time gt.</param>
        /// <param name="addTime_Gte">Add time gte.</param>
        /// <param name="addTime_Lt">Add time lt.</param>
        /// <param name="addTime_Lte">Add time lte.</param>
        /// <param name="limit">Limit.</param>
        /// <param name="offset">Offset.</param>
        /// <param name="callbackUrl">Callback URL.</param>
        /// <param name="callbackMethod">Callback method.</param>
        public async Task<AsyncResponse> ListAsync(
            string subaccount = null, string callUuid = null,
            DateTime? addTime = null, DateTime? addTime_Gt = null,
            DateTime? addTime_Gte = null, DateTime? addTime_Lt = null,
            DateTime? addTime_Lte = null, uint? limit = null,
            uint? offset = null, string callbackUrl = null, string callbackMethod = null)
        {
            var _addTime = addTime?.ToString("yyyy-MM-dd HH':'mm':'ss'.'ffffff''") ?? null;
            var _addTime_Gt = addTime_Gt?.ToString("yyyy-MM-dd HH':'mm':'ss'.'ffffff''") ?? null;
            var _addTime_Gte = addTime_Gte?.ToString("yyyy-MM-dd HH':'mm':'ss'.'ffffff''") ?? null;
            var _addTime_Lt = addTime_Lt?.ToString("yyyy-MM-dd HH':'mm':'ss'.'ffffff''") ?? null;
            var _addTime_Lte = addTime_Lte?.ToString("yyyy-MM-dd HH':'mm':'ss'.'ffffff''") ?? null;

            var mandatoryParams = new List<string> { "" };
            bool isVoiceRequest = true;
            var data = CreateData(
                mandatoryParams,
                new
                {
                    subaccount,
                    callUuid,
                    _addTime,
                    _addTime_Gt,
                    _addTime_Gte,
                    _addTime_Lt,
                    _addTime_Lte,
                    limit,
                    offset,
                    callbackUrl,
                    callbackMethod,
                    isVoiceRequest
                });
            if (data.ContainsKey("callback_method") && callbackMethod == null) {
                data.Remove("callback_method");
            }
            MpcUtils.ValidUrl("callbackUrl", callbackUrl, true);
            var result = Task.Run(async () => await Client.Fetch<AsyncResponse>(
                Uri, data).ConfigureAwait(false)).Result;
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
        /// Delete Recording with the specified recordingId.
        /// </summary>
        /// <returns>The delete.</returns>
        /// <param name="recordingId">Recording identifier.</param>
        public DeleteResponse<Recording> Delete(string recordingId)
        {
			return ExecuteWithExceptionUnwrap(() =>
			{
				return Task.Run(async () => await DeleteResource<DeleteResponse<Recording>>(recordingId, new Dictionary<string, object> () { {"is_voice_request", true} }).ConfigureAwait(false)).Result;
			});
        }

        /// <summary>
        /// Asynchronously delete Recording with the specified recordingId.
        /// </summary>
        /// <returns>The delete.</returns>
        /// <param name="recordingId">Recording identifier.</param>
        /// <param name="callbackUrl">Callback URL.</param>
        /// <param name="callbackMethod">Callback method.</param>
        public async Task<AsyncResponse> DeleteAsync(string recordingId, string callbackUrl = null, string callbackMethod = null)
        {
            MpcUtils.ValidUrl("callbackUrl", callbackUrl, true);
            var data = new Dictionary<string, object>()
            {
                {"is_voice_request", true},
                {"callback_url", callbackUrl},
                {"callback_method", callbackMethod}
            };
            if (data.ContainsKey("callback_method") && callbackMethod == null) {
                data.Remove("callback_method");
            }
            var result = Task.Run(async () => await Client.Delete<AsyncResponse>(
                Uri + recordingId + "/", data).ConfigureAwait(false)).Result;
            await Task.WhenAll();
            result.Object.StatusCode = result.StatusCode;
            return result.Object;
        }
        #endregion
    }
}