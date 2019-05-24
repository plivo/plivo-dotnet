﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Plivo.Client;


namespace Plivo.Resource.Call
{
    /// <summary>
    /// Call interface.
    /// </summary>
    public class CallInterface : ResourceInterface
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:plivo.Resource.Call.CallInterface"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        public CallInterface(HttpClient client) : base(client)
        {
            Uri = "Account/" + Client.GetAuthId() + "/Call/";
        }

        #region Create
        /// <summary>
        /// Create Call with the specified from, to, answerUrl, answerMethod, ringUrl, ringMethod, hangupUrl, hangupMethod,
        /// fallbackUrl, fallbackMethod, callerName, sendDigits, sendOnPreanswer, timeLimit, hangupOnRing,
        /// machineDetection, machineDetectionTime, machineDetectionUrl, machineDetectionMethod, sipHeaders,
        /// ringTimeout, parentCallUuid and errorIfrentNotFound.
        /// </summary>
        /// <returns>The create.</returns>
        /// <param name="from">From.</param>
        /// <param name="to">To.</param>
        /// <param name="answerUrl">Answer URL.</param>
        /// <param name="answerMethod">Answer method.</param>
        /// <param name="ringUrl">Ring URL.</param>
        /// <param name="ringMethod">Ring method.</param>
        /// <param name="hangupUrl">Hangup URL.</param>
        /// <param name="hangupMethod">Hangup method.</param>
        /// <param name="fallbackUrl">Fallback URL.</param>
        /// <param name="fallbackMethod">Fallback method.</param>
        /// <param name="callerName">Caller name.</param>
        /// <param name="sendDigits">Send digits.</param>
        /// <param name="sendOnPreanswer">Send on preanswer.</param>
        /// <param name="timeLimit">Time limit.</param>
        /// <param name="hangupOnRing">Hangup on ring.</param>
        /// <param name="machineDetection">Machine detection.</param>
        /// <param name="machineDetectionTime">Machine detection time.</param>
        /// <param name="machineDetectionUrl">Machine detection URL.</param>
        /// <param name="machineDetectionMethod">Machine detection method.</param>
        /// <param name="sipHeaders">Sip headers.</param>
        /// <param name="ringTimeout">Ring timeout.</param>
        /// <param name="parentCallUuid">Parent call UUID.</param>
        /// <param name="errorIfrentNotFound">Error ifrent not found.</param>
        public CallCreateResponse Create(
            string from, List<string> to, string answerUrl, string answerMethod,
            string ringUrl = null, string ringMethod = null,
            string hangupUrl = null, string hangupMethod = null,
            string fallbackUrl = null, string fallbackMethod = null,
            string callerName = null, string sendDigits = null,
            bool? sendOnPreanswer = null, uint? timeLimit = null,
            uint? hangupOnRing = null, string machineDetection = null,
            uint? machineDetectionTime = null, string machineDetectionUrl = null,
            string machineDetectionMethod = null, string sipHeaders = null,
            uint? ringTimeout = null, string parentCallUuid = null,
            bool? errorIfrentNotFound = null)
        {
            string _to = string.Join("<", to);
            var mandatoryParams = new List<string> { "from", "to", "answerUrl", "answerMethod" };
            var data = CreateData(
                mandatoryParams,
                new
                {
                    from,
                    _to,
                    answerUrl,
                    answerMethod,
                    ringUrl,
                    ringMethod,
                    hangupUrl,
                    hangupMethod,
                    fallbackUrl,
                    fallbackMethod,
                    callerName,
                    sendDigits,
                    sendOnPreanswer,
                    timeLimit,
                    hangupOnRing,
                    machineDetection,
                    machineDetectionTime,
                    machineDetectionUrl,
                    machineDetectionMethod,
                    sipHeaders,
                    ringTimeout,
                    parentCallUuid,
                    errorIfrentNotFound
                });

			return ExecuteWithExceptionUnwrap(() =>
			{
				var result = Task.Run(async () => await Client.Update<CallCreateResponse>(Uri, data).ConfigureAwait(false)).Result;
				return result.Object;
			});
		}
        /// <summary>
        /// Asynchronously create Call with the specified from, to, answerUrl, answerMethod, ringUrl, ringMethod, hangupUrl, hangupMethod,
        /// fallbackUrl, fallbackMethod, callerName, sendDigits, sendOnPreanswer, timeLimit, hangupOnRing,
        /// machineDetection, machineDetectionTime, machineDetectionUrl, machineDetectionMethod, sipHeaders,
        /// ringTimeout, parentCallUuid and errorIfrentNotFound.
        /// </summary>
        /// <returns>The create.</returns>
        /// <param name="from">From.</param>
        /// <param name="to">To.</param>
        /// <param name="answerUrl">Answer URL.</param>
        /// <param name="answerMethod">Answer method.</param>
        /// <param name="ringUrl">Ring URL.</param>
        /// <param name="ringMethod">Ring method.</param>
        /// <param name="hangupUrl">Hangup URL.</param>
        /// <param name="hangupMethod">Hangup method.</param>
        /// <param name="fallbackUrl">Fallback URL.</param>
        /// <param name="fallbackMethod">Fallback method.</param>
        /// <param name="callerName">Caller name.</param>
        /// <param name="sendDigits">Send digits.</param>
        /// <param name="sendOnPreanswer">Send on preanswer.</param>
        /// <param name="timeLimit">Time limit.</param>
        /// <param name="hangupOnRing">Hangup on ring.</param>
        /// <param name="machineDetection">Machine detection.</param>
        /// <param name="machineDetectionTime">Machine detection time.</param>
        /// <param name="machineDetectionUrl">Machine detection URL.</param>
        /// <param name="machineDetectionMethod">Machine detection method.</param>
        /// <param name="sipHeaders">Sip headers.</param>
        /// <param name="ringTimeout">Ring timeout.</param>
        /// <param name="parentCallUuid">Parent call UUID.</param>
        /// <param name="errorIfrentNotFound">Error ifrent not found.</param>
        public async Task<CallCreateResponse> CreateAsync(
            string from, List<string> to, string answerUrl, string answerMethod,
            string ringUrl = null, string ringMethod = null,
            string hangupUrl = null, string hangupMethod = null,
            string fallbackUrl = null, string fallbackMethod = null,
            string callerName = null, string sendDigits = null,
            bool? sendOnPreanswer = null, uint? timeLimit = null,
            uint? hangupOnRing = null, string machineDetection = null,
            uint? machineDetectionTime = null, string machineDetectionUrl = null,
            string machineDetectionMethod = null, string sipHeaders = null,
            uint? ringTimeout = null, string parentCallUuid = null,
            bool? errorIfrentNotFound = null)
        {
            string _to = string.Join("<", to);
            var mandatoryParams = new List<string> { "from", "to", "answerUrl", "answerMethod" };
            var data = CreateData(
                mandatoryParams,
                new
                {
                    from,
                    _to,
                    answerUrl,
                    answerMethod,
                    ringUrl,
                    ringMethod,
                    hangupUrl,
                    hangupMethod,
                    fallbackUrl,
                    fallbackMethod,
                    callerName,
                    sendDigits,
                    sendOnPreanswer,
                    timeLimit,
                    hangupOnRing,
                    machineDetection,
                    machineDetectionTime,
                    machineDetectionUrl,
                    machineDetectionMethod,
                    sipHeaders,
                    ringTimeout,
                    parentCallUuid,
                    errorIfrentNotFound
                });

            var result = await Client.Update<CallCreateResponse>(Uri, data);
            return result.Object;
        }
        #endregion

        #region List
        /// <summary>
        /// List Call with the specified subaccount, callDirection, fromNumber, toNumber, billDuration, billDuration_Gt,
        /// billDuration_Gte, billDuration_Lt, billDuration_Lte, endTime, endTime_Gt, endTime_Gte, endTime_Lt,
        /// endTime_Lte, parentCallUuid, hangupSource, hangupCauseCode, limit and offset.
        /// </summary>
        /// <returns>The list.</returns>
        /// <param name="subaccount">Subaccount.</param>
        /// <param name="callDirection">Call direction.</param>
        /// <param name="fromNumber">From number.</param>
        /// <param name="parentCallUuid">Parent call UUID.</param>
        /// <param name="hangupSource">Plivo Hangup Source.</param>
        /// <param name="hangupCauseCode">Plivo Hangup Cause Code.</param>
        /// <param name="toNumber">To number.</param>
        /// <param name="billDuration">Bill duration.</param>
        /// <param name="billDuration_Gt">Bill duration gt.</param>
        /// <param name="billDuration_Gte">Bill duration gte.</param>
        /// <param name="billDuration_Lt">Bill duration lt.</param>
        /// <param name="billDuration_Lte">Bill duration lte.</param>
        /// <param name="endTime">End time.</param>
        /// <param name="endTime_Gt">End time gt.</param>
        /// <param name="endTime_Gte">End time gte.</param>
        /// <param name="endTime_Lt">End time lt.</param>
        /// <param name="endTime_Lte">End time lte.</param>
        /// <param name="limit">Limit.</param>
        /// <param name="offset">Offset.</param>
        public ListResponse<Call> List(
            string subaccount = null, string callDirection = null,
            string fromNumber = null, string toNumber = null, string parentCallUuid = null,
            string hangupSource = null, uint? hangupCauseCode = null,
            DateTime? billDuration = null, DateTime? billDuration_Gt = null,
            DateTime? billDuration_Gte = null, DateTime? billDuration_Lt = null,
            DateTime? billDuration_Lte = null, DateTime? endTime = null,
            DateTime? endTime_Gt = null, DateTime? endTime_Gte = null,
            DateTime? endTime_Lt = null, DateTime? endTime_Lte = null,
            uint? limit = null, uint? offset = null)
        {
            var _billDuration = billDuration?.ToString("yyyy-MM-dd HH':'mm':'ss'.'ffffff''") ?? null;
            var _billDuration_Gt = billDuration_Gt?.ToString("yyyy-MM-dd HH':'mm':'ss'.'ffffff''") ?? null;
            var _billDuration_Gte = billDuration_Gte?.ToString("yyyy-MM-dd HH':'mm':'ss'.'ffffff''") ?? null;
            var _billDuration_Lt = billDuration_Lt?.ToString("yyyy-MM-dd HH':'mm':'ss'.'ffffff''") ?? null;
            var _billDuration_Lte = billDuration_Lte?.ToString("yyyy-MM-dd HH':'mm':'ss'.'ffffff''") ?? null;

            var _endTime = endTime?.ToString("yyyy-MM-dd HH':'mm':'ss'.'ffffff''") ?? null;
            var _endTime_Gt = endTime_Gt?.ToString("yyyy-MM-dd HH':'mm':'ss'.'ffffff''") ?? null;
            var _endTime_Gte = endTime_Gte?.ToString("yyyy-MM-dd HH':'mm':'ss'.'ffffff''") ?? null;
            var _endTime_Lt = endTime_Lt?.ToString("yyyy-MM-dd HH':'mm':'ss'.'ffffff''") ?? null;
            var _endTime_Lte = endTime_Lte?.ToString("yyyy-MM-dd HH':'mm':'ss'.'ffffff''") ?? null;

            var mandatoryParams = new List<string> { "" };
            var data = CreateData(
                mandatoryParams,
                new
                {
                    subaccount,
                    callDirection,
                    fromNumber,
                    toNumber,
                    parentCallUuid,
                    hangupSource,
                    hangupCauseCode,
                    _billDuration,
                    _billDuration_Gt,
                    _billDuration_Gte,
                    _billDuration_Lt,
                    _billDuration_Lte,
                    _endTime,
                    _endTime_Gt,
                    _endTime_Gte,
                    _endTime_Lt,
                    _endTime_Lte,
                    limit,
                    offset
                });

			return ExecuteWithExceptionUnwrap(() =>
			{
				var resources = Task.Run(async () => await ListResources<ListResponse<Call>>(data).ConfigureAwait(false)).Result;
				resources.Objects.ForEach(
					(obj) => obj.Interface = this
				);

				return resources;
			});
		}
        /// <summary>
        /// List Call with the specified subaccount, callDirection, fromNumber, toNumber, billDuration, billDuration_Gt,
        /// billDuration_Gte, billDuration_Lt, billDuration_Lte, endTime, endTime_Gt, endTime_Gte, endTime_Lt,
        /// endTime_Lte, parentCallUuid, hangupSource, hangupCauseCode, limit and offset.
        /// </summary>
        /// <returns>The list.</returns>
        /// <param name="subaccount">Subaccount.</param>
        /// <param name="callDirection">Call direction.</param>
        /// <param name="fromNumber">From number.</param>
        /// <param name="parentCallUuid">Parent call UUID.</param>
        /// <param name="hangupSource">Plivo Hangup Source.</param>
        /// <param name="hangupCauseCode">Plivo Hangup Cause Code.</param>
        /// <param name="toNumber">To number.</param>
        /// <param name="billDuration">Bill duration.</param>
        /// <param name="billDuration_Gt">Bill duration gt.</param>
        /// <param name="billDuration_Gte">Bill duration gte.</param>
        /// <param name="billDuration_Lt">Bill duration lt.</param>
        /// <param name="billDuration_Lte">Bill duration lte.</param>
        /// <param name="endTime">End time.</param>
        /// <param name="endTime_Gt">End time gt.</param>
        /// <param name="endTime_Gte">End time gte.</param>
        /// <param name="endTime_Lt">End time lt.</param>
        /// <param name="endTime_Lte">End time lte.</param>
        /// <param name="limit">Limit.</param>
        /// <param name="offset">Offset.</param>
        public async Task<ListResponse<Call>> ListAsync(
            string subaccount = null, string callDirection = null,
            string fromNumber = null, string toNumber = null, string parentCallUuid = null,
            string hangupSource = null, uint? hangupCauseCode = null,
            DateTime? billDuration = null, DateTime? billDuration_Gt = null,
            DateTime? billDuration_Gte = null, DateTime? billDuration_Lt = null,
            DateTime? billDuration_Lte = null, DateTime? endTime = null,
            DateTime? endTime_Gt = null, DateTime? endTime_Gte = null,
            DateTime? endTime_Lt = null, DateTime? endTime_Lte = null,
            uint? limit = null, uint? offset = null)
        {
            var _billDuration = billDuration?.ToString("yyyy-MM-dd HH':'mm':'ss'.'ffffff''") ?? null;
            var _billDuration_Gt = billDuration_Gt?.ToString("yyyy-MM-dd HH':'mm':'ss'.'ffffff''") ?? null;
            var _billDuration_Gte = billDuration_Gte?.ToString("yyyy-MM-dd HH':'mm':'ss'.'ffffff''") ?? null;
            var _billDuration_Lt = billDuration_Lt?.ToString("yyyy-MM-dd HH':'mm':'ss'.'ffffff''") ?? null;
            var _billDuration_Lte = billDuration_Lte?.ToString("yyyy-MM-dd HH':'mm':'ss'.'ffffff''") ?? null;

            var _endTime = endTime?.ToString("yyyy-MM-dd HH':'mm':'ss'.'ffffff''") ?? null;
            var _endTime_Gt = endTime_Gt?.ToString("yyyy-MM-dd HH':'mm':'ss'.'ffffff''") ?? null;
            var _endTime_Gte = endTime_Gte?.ToString("yyyy-MM-dd HH':'mm':'ss'.'ffffff''") ?? null;
            var _endTime_Lt = endTime_Lt?.ToString("yyyy-MM-dd HH':'mm':'ss'.'ffffff''") ?? null;
            var _endTime_Lte = endTime_Lte?.ToString("yyyy-MM-dd HH':'mm':'ss'.'ffffff''") ?? null;

            var mandatoryParams = new List<string> { "" };
            var data = CreateData(
                mandatoryParams,
                new
                {
                    subaccount,
                    callDirection,
                    fromNumber,
                    toNumber,
                    parentCallUuid,
                    hangupSource,
                    hangupCauseCode,
                    _billDuration,
                    _billDuration_Gt,
                    _billDuration_Gte,
                    _billDuration_Lt,
                    _billDuration_Lte,
                    _endTime,
                    _endTime_Gt,
                    _endTime_Gte,
                    _endTime_Lt,
                    _endTime_Lte,
                    limit,
                    offset
                });
            var resources = await ListResources<ListResponse<Call>>(data);
            resources.Objects.ForEach(
                (obj) => obj.Interface = this
            );

            return resources;
        }
        #endregion

        #region Get
        /// <summary>
        /// Get Call with the specified callUuid.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="callUuid">Call UUID.</param>
        public Call Get(string callUuid)
        {
			return ExecuteWithExceptionUnwrap(() =>
			{
				var call = Task.Run(async () => await GetResource<Call>(callUuid).ConfigureAwait(false)).Result;
				call.Interface = this;
				return call;
			});
		}
        /// <summary>
        /// Asynchronously get Call with the specified callUuid.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="callUuid">Call UUID.</param>
        public async Task<Call> GetAsync(string callUuid)
        {
            var call = await GetResource<Call>(callUuid);
            call.Interface = this;
            return call;
        }
        #endregion

        #region ListLive
        /// <summary>
        /// Lists the live.
        /// </summary>
        /// <returns>The live.</returns>
        /// <param name="callDirection">Call direction.</param>
        /// <param name="fromNumber">From number.</param>
        /// <param name="toNumber">To number.</param>
        public LiveCallListResponse ListLive(string callDirection = null,
            string fromNumber = null, string toNumber = null)
        {
            var status = "live";
            var mandatoryParams = new List<string> { "" };
            var data = CreateData(
                mandatoryParams,
                new
                {
                    status,
                    callDirection,
                    fromNumber,
                    toNumber
                });

			return ExecuteWithExceptionUnwrap(() =>
			{
				return Task.Run(async () => await ListResources<LiveCallListResponse>(data).ConfigureAwait(false)).Result;
			});
		}
        /// <summary>
        /// Lists the live.
        /// </summary>
        /// <returns>The live.</returns>
        /// <param name="callDirection">Call direction.</param>
        /// <param name="fromNumber">From number.</param>
        /// <param name="toNumber">To number.</param>
        public async Task<LiveCallListResponse> ListLiveAsync(string callDirection = null,
            string fromNumber = null, string toNumber = null)
        {
            var status = "live";
            var mandatoryParams = new List<string> { "" };
            var data = CreateData(
                mandatoryParams,
                new
                {
                    status,
                    callDirection,
                    fromNumber,
                    toNumber
                });

            return await ListResources<LiveCallListResponse>(data);
        }
        #endregion

        #region GetLive
        /// <summary>
        /// Gets the live.
        /// </summary>
        /// <returns>The live.</returns>
        /// <param name="liveCallUuid">Live call UUID.</param>
        public LiveCall GetLive(string liveCallUuid)
        {
			return ExecuteWithExceptionUnwrap(() =>
			{
				var liveCall = Task.Run(async () => await GetResource<LiveCall>(
					liveCallUuid, new Dictionary<string, object>() { { "status", "live" } }).ConfigureAwait(false)).Result;
				liveCall.Interface = this;
				return liveCall;
			});
		}
        /// <summary>
        ///Asynchronously gets the live.
        /// </summary>
        /// <returns>The live.</returns>
        /// <param name="liveCallUuid">Live call UUID.</param>
        public async Task<LiveCall> GetLiveAsync(string liveCallUuid)
        {
            var liveCall = await GetResource<LiveCall>(
                liveCallUuid, new Dictionary<string, object>() { { "status", "live" } });
            liveCall.Interface = this;
            return liveCall;
        }
        #endregion

        #region GetQueued
        /// <summary>
        /// Gets the Queued call.
        /// </summary>
        /// <returns>Queued call details.</returns>
        /// <param name="callUuid">Call UUID.</param>
        public QueuedCall GetQueued(string callUuid)
        {
			return ExecuteWithExceptionUnwrap(() =>
			{
				var queuedCall = Task.Run(async () => await GetResource<QueuedCall>(
					callUuid, new Dictionary<string, object>() { { "status", "queued" } }).ConfigureAwait(false)).Result;
				queuedCall.Interface = this;
				return queuedCall;
			});
		}
        /// <summary>
        /// Asynchronously gets the Queued call.
        /// </summary>
        /// <returns>Queued call details.</returns>
        /// <param name="callUuid">Call UUID.</param>
        public async Task<QueuedCall> GetQueuedAsync(string callUuid)
        {
            var queuedCall = await GetResource<QueuedCall>(
                callUuid, new Dictionary<string, object>() { { "status", "queued" } });
            queuedCall.Interface = this;
            return queuedCall;
        }
        #endregion

        #region ListQueued
        /// <summary>
        /// Lists the queued calls.
        /// </summary>
        /// <returns>queued calls list</returns>
        public QueuedCallListResponse ListQueued()
        {
			return ExecuteWithExceptionUnwrap(() =>
			{
				return Task.Run(async () => await ListResources<QueuedCallListResponse>(
						new Dictionary<string, object>() { { "status", "queued" } }).ConfigureAwait(false)).Result;
			});
		}
        /// <summary>
        /// Lists the queued calls.
        /// </summary>
        /// <returns>queued calls list</returns>
        public async Task<QueuedCallListResponse> ListQueuedAsync()
        {
            return
                await ListResources<QueuedCallListResponse>(
                    new Dictionary<string, object>() { { "status", "queued" } });
        }
        #endregion

        #region Delete
        /// <summary>
        /// Delete Call with the specified callUuid.
        /// </summary>
        /// <returns>The delete.</returns>
        /// <param name="callUuid">Call UUID.</param>
        public DeleteResponse<Call> Delete(string callUuid)
        {
			return ExecuteWithExceptionUnwrap(() =>
			{
				return Task.Run(async () => await DeleteResource<DeleteResponse<Call>>(callUuid).ConfigureAwait(false)).Result;
			});
		}
        /// <summary>
        /// Asynchronously delete Call with the specified callUuid.
        /// </summary>
        /// <returns>The delete.</returns>
        /// <param name="callUuid">Call UUID.</param>
        public async Task<DeleteResponse<Call>> DeleteAsync(string callUuid)
        {
            return await DeleteResource<DeleteResponse<Call>>(callUuid);
        }
        #endregion

        #region Transfer
        /// <summary>
        /// Transfer Call with the specified callUuid, legs, alegUrl, alegMethod, blegUrl and blegMethod.
        /// </summary>
        /// <returns>The transfer.</returns>
        /// <param name="callUuid">Call UUID.</param>
        /// <param name="legs">Legs.</param>
        /// <param name="alegUrl">Aleg URL.</param>
        /// <param name="alegMethod">Aleg method.</param>
        /// <param name="blegUrl">Bleg URL.</param>
        /// <param name="blegMethod">Bleg method.</param>
        public UpdateResponse<Call> Transfer(
            string callUuid, string legs = null, string alegUrl = null,
            string alegMethod = null, string blegUrl = null,
            string blegMethod = null)
        {
            var mandatoryParams = new List<string> { "" };
            var data = CreateData(
                mandatoryParams,
                new
                {
                    legs,
                    alegUrl,
                    alegMethod,
                    blegUrl,
                    blegMethod
                });

			return ExecuteWithExceptionUnwrap(() =>
			{
				var result = Task.Run(async () => await Client.Update<UpdateResponse<Call>>(Uri + callUuid + "/", data).ConfigureAwait(false)).Result;
				return result.Object;
			});
		}
        /// <summary>
        /// Asynchronously transfer Call with the specified callUuid, legs, alegUrl, alegMethod, blegUrl and blegMethod.
        /// </summary>
        /// <returns>The transfer.</returns>
        /// <param name="callUuid">Call UUID.</param>
        /// <param name="legs">Legs.</param>
        /// <param name="alegUrl">Aleg URL.</param>
        /// <param name="alegMethod">Aleg method.</param>
        /// <param name="blegUrl">Bleg URL.</param>
        /// <param name="blegMethod">Bleg method.</param>
        public async Task<UpdateResponse<Call>> TransferAsync(
            string callUuid, string legs = null, string alegUrl = null,
            string alegMethod = null, string blegUrl = null,
            string blegMethod = null)
        {
            var mandatoryParams = new List<string> { "" };
            var data = CreateData(
                mandatoryParams,
                new
                {
                    legs,
                    alegUrl,
                    alegMethod,
                    blegUrl,
                    blegMethod
                });
            var result = await Client.Update<UpdateResponse<Call>>(Uri + callUuid + "/", data);
            return result.Object;
        }
        #endregion

        #region StartPlaying
        /// <summary>
        /// Starts the playing.
        /// </summary>
        /// <returns>The playing.</returns>
        /// <param name="callUuid">Call UUID.</param>
        /// <param name="urls">Urls.</param>
        /// <param name="length">Length.</param>
        /// <param name="legs">Legs.</param>
        /// <param name="loop">Loop.</param>
        /// <param name="mix">Mix.</param>
        public UpdateResponse<Call> StartPlaying(
            string callUuid, List<string> urls, uint? length = null,
            string legs = null, bool? loop = null, bool? mix = null)
        {
            var _urls = string.Join(",", urls);
            var mandatoryParams = new List<string> { "" };
            var data = CreateData(
                mandatoryParams,
                new
                {
                    _urls,
                    length,
                    legs,
                    loop,
                    mix
                });

			return ExecuteWithExceptionUnwrap(() =>
			{
				var result = Task.Run(async () => await Client.Update<UpdateResponse<Call>>(Uri + callUuid + "/Play/", data).ConfigureAwait(false)).Result;
				return result.Object;
			});
		}
        /// <summary>
        /// Asynchronously starts the playing.
        /// </summary>
        /// <returns>The playing.</returns>
        /// <param name="callUuid">Call UUID.</param>
        /// <param name="urls">Urls.</param>
        /// <param name="length">Length.</param>
        /// <param name="legs">Legs.</param>
        /// <param name="loop">Loop.</param>
        /// <param name="mix">Mix.</param>
        public async Task<UpdateResponse<Call>> StartPlayingAsync(
            string callUuid, List<string> urls, uint? length = null,
            string legs = null, bool? loop = null, bool? mix = null)
        {
            var _urls = string.Join(",", urls);
            var mandatoryParams = new List<string> { "" };
            var data = CreateData(
                mandatoryParams,
                new
                {
                    _urls,
                    length,
                    legs,
                    loop,
                    mix
                });
            var result = await Client.Update<UpdateResponse<Call>>(Uri + callUuid + "/Play/", data);
            return result.Object;
        }
        #endregion

        #region StopPlaying
        /// <summary>
        /// Stops the playing.
        /// </summary>
        /// <returns>The playing.</returns>
        /// <param name="callUuid">Call UUID.</param>
        public DeleteResponse<Call> StopPlaying(string callUuid)
        {
			return ExecuteWithExceptionUnwrap(() =>
			{
				var result = Task.Run(async () => await Client.Delete<DeleteResponse<Call>>(Uri + callUuid + "/Play/").ConfigureAwait(false)).Result;
				return result.Object;
			});
		}
        /// <summary>
        /// Asynchronously stops the playing.
        /// </summary>
        /// <returns>The playing.</returns>
        /// <param name="callUuid">Call UUID.</param>
        public async Task<DeleteResponse<Call>> StopPlayingAsync(string callUuid)
        {
            var result = await Client.Delete<DeleteResponse<Call>>(Uri + callUuid + "/Play/");
            return result.Object;
        }
        #endregion

        #region StartRecording
        /// <summary>
        /// Starts the recording.
        /// </summary>
        /// <returns>The recording.</returns>
        /// <param name="callUuid">Call UUID.</param>
        /// <param name="timeLimit">Time limit.</param>
        /// <param name="fileFormat">File format.</param>
        /// <param name="transactionType">Transaction type.</param>
        /// <param name="transactionUrl">Transaction URL.</param>
        /// <param name="transactionMethod">Transaction method.</param>
        /// <param name="callbackUrl">Callback URL.</param>
        /// <param name="callbackMethod">Callback method.</param>
        public RecordCreateResponse<Call> StartRecording(
            string callUuid, uint? timeLimit = null, string fileFormat = null,
            string transactionType = null, string transactionUrl = null,
            string transactionMethod = null, string callbackUrl = null,
            string callbackMethod = null)
        {
            var mandatoryParams = new List<string> { "" };
            var data = CreateData(
                mandatoryParams,
                new
                {
                    timeLimit,
                    fileFormat,
                    transactionType,
                    transactionUrl,
                    transactionMethod,
                    callbackUrl,
                    callbackMethod
                });

			return ExecuteWithExceptionUnwrap(() =>
			{
				var result = Task.Run(async () => await Client.Update<RecordCreateResponse<Call>>(Uri + callUuid + "/Record/", data).ConfigureAwait(false)).Result;
				return result.Object;
			});
		}
        /// <summary>
        /// Asynchronously starts the recording.
        /// </summary>
        /// <returns>The recording.</returns>
        /// <param name="callUuid">Call UUID.</param>
        /// <param name="timeLimit">Time limit.</param>
        /// <param name="fileFormat">File format.</param>
        /// <param name="transactionType">Transaction type.</param>
        /// <param name="transactionUrl">Transaction URL.</param>
        /// <param name="transactionMethod">Transaction method.</param>
        /// <param name="callbackUrl">Callback URL.</param>
        /// <param name="callbackMethod">Callback method.</param>
        public async Task<RecordCreateResponse<Call>> StartRecordingAsync(
            string callUuid, uint? timeLimit = null, string fileFormat = null,
            string transactionType = null, string transactionUrl = null,
            string transactionMethod = null, string callbackUrl = null,
            string callbackMethod = null)
        {
            var mandatoryParams = new List<string> { "" };
            var data = CreateData(
                mandatoryParams,
                new
                {
                    timeLimit,
                    fileFormat,
                    transactionType,
                    transactionUrl,
                    transactionMethod,
                    callbackUrl,
                    callbackMethod
                });
            var result = await Client.Update<RecordCreateResponse<Call>>(Uri + callUuid + "/Record/", data);
            return result.Object;
        }
        #endregion

        #region StopRecording
        /// <summary>
        /// Stops the recording.
        /// </summary>
        /// <returns>The recording.</returns>
        /// <param name="callUuid">Call UUID.</param>
        /// <param name="URL">URL.</param>
        public DeleteResponse<Call> StopRecording(string callUuid, string URL = null)
        {
            var mandatoryParams = new List<string> { "" };
            var data = CreateData(
                mandatoryParams, new { URL });

			return ExecuteWithExceptionUnwrap(() =>
			{
				var result = Task.Run(async () => await Client.Delete<DeleteResponse<Call>>(Uri + callUuid + "/Record/", data).ConfigureAwait(false)).Result;
				return result.Object;
			});
		}
        /// <summary>
        /// Asynchronously stops the recording.
        /// </summary>
        /// <returns>The recording.</returns>
        /// <param name="callUuid">Call UUID.</param>
        /// <param name="URL">URL.</param>
        public async Task<DeleteResponse<Call>> StopRecordingAsync(string callUuid, string URL = null)
        {
            var mandatoryParams = new List<string> { "" };
            var data = CreateData(
                mandatoryParams, new { URL });
            var result = await Client.Delete<DeleteResponse<Call>>(Uri + callUuid + "/Record/", data);
            return result.Object;
        }
        #endregion

        #region StartSpeaking
        /// <summary>
        /// Starts the speaking.
        /// </summary>
        /// <returns>The speaking.</returns>
        /// <param name="callUuid">Call UUID.</param>
        /// <param name="text">Text.</param>
        /// <param name="voice">Voice.</param>
        /// <param name="language">Language.</param>
        /// <param name="legs">Legs.</param>
        /// <param name="loop">Loop.</param>
        /// <param name="mix">Mix.</param>
        public UpdateResponse<Call> StartSpeaking(
            string callUuid, string text, string voice = null,
            string language = null, string legs = null, bool? loop = null,
            bool? mix = null)
        {
            var mandatoryParams = new List<string> { "" };
            var data = CreateData(
                mandatoryParams,
                new
                {
                    text,
                    voice,
                    language,
                    legs,
                    loop,
                    mix
                });

			return ExecuteWithExceptionUnwrap(() =>
			{
				var result = Task.Run(async () => await Client.Update<UpdateResponse<Call>>(Uri + callUuid + "/Speak/", data).ConfigureAwait(false)).Result;
				return result.Object;
			});
		}
        /// <summary>
        /// Asynchronously starts the speaking.
        /// </summary>
        /// <returns>The speaking.</returns>
        /// <param name="callUuid">Call UUID.</param>
        /// <param name="text">Text.</param>
        /// <param name="voice">Voice.</param>
        /// <param name="language">Language.</param>
        /// <param name="legs">Legs.</param>
        /// <param name="loop">Loop.</param>
        /// <param name="mix">Mix.</param>
        public async Task<UpdateResponse<Call>> StartSpeakingAsync(
            string callUuid, string text, string voice = null,
            string language = null, string legs = null, bool? loop = null,
            bool? mix = null)
        {
            var mandatoryParams = new List<string> { "" };
            var data = CreateData(
                mandatoryParams,
                new
                {
                    text,
                    voice,
                    language,
                    legs,
                    loop,
                    mix
                });
            var result = await Client.Update<UpdateResponse<Call>>(Uri + callUuid + "/Speak/", data);
            return result.Object;
        }

        #endregion

        #region StopSpeaking
        /// <summary>
        /// Stops the speaking.
        /// </summary>
        /// <returns>The speaking.</returns>
        /// <param name="callUuid">Call UUID.</param>
        public DeleteResponse<Call> StopSpeaking(string callUuid)
        {
			return ExecuteWithExceptionUnwrap(() =>
			{
				var result = Task.Run(async () => await Client.Delete<DeleteResponse<Call>>(Uri + callUuid + "/Speak/").ConfigureAwait(false)).Result;
				return result.Object;
			});
		}
        /// <summary>
        /// Asynchronously stops the speaking.
        /// </summary>
        /// <returns>The speaking.</returns>
        /// <param name="callUuid">Call UUID.</param>
        public async Task<DeleteResponse<Call>> StopSpeakingAsync(string callUuid)
        {
            var result = await Client.Delete<DeleteResponse<Call>>(Uri + callUuid + "/Speak/");
            return result.Object;
        }
        #endregion

        #region SendDigits
        /// <summary>
        /// Sends the digits.
        /// </summary>
        /// <returns>The digits.</returns>
        /// <param name="callUuid">Call UUID.</param>
        /// <param name="digits">Digits.</param>
        /// <param name="leg">Leg.</param>
        public UpdateResponse<Call> SendDigits(
            string callUuid, string digits, string leg = null)
        {
            var mandatoryParams = new List<string> { "" };
            var data = CreateData(
                mandatoryParams,
                new
                {
                    digits,
                    leg
                });

			return ExecuteWithExceptionUnwrap(() =>
			{
				var result = Task.Run(async () => await Client.Update<UpdateResponse<Call>>(Uri + callUuid + "/DTMF/", data).ConfigureAwait(false)).Result;
				return result.Object;
			});
		}
        /// <summary>
        /// Asynchronously sends the digits.
        /// </summary>
        /// <returns>The digits.</returns>
        /// <param name="callUuid">Call UUID.</param>
        /// <param name="digits">Digits.</param>
        /// <param name="leg">Leg.</param>
        public async Task<UpdateResponse<Call>> SendDigitsAsync(
            string callUuid, string digits, string leg = null)
        {
            var mandatoryParams = new List<string> { "" };
            var data = CreateData(
                mandatoryParams,
                new
                {
                    digits,
                    leg
                });
            var result = await Client.Update<UpdateResponse<Call>>(Uri + callUuid + "/DTMF/", data);
            return result.Object;
        }
        #endregion

        #region CancelCall
        /// <summary>
        /// Cancels the call.
        /// </summary>
        /// <returns>The call.</returns>
        /// <param name="requestUuid">Request UUID.</param>
        public DeleteResponse<Call> CancelCall(string requestUuid)
        {
			return ExecuteWithExceptionUnwrap(() =>
			{
				var result = Task.Run(async () => await Client.Delete<DeleteResponse<Call>>("Account/" + Client.GetAuthId() + "/Request/" + requestUuid + "/", null).ConfigureAwait(false)).Result;
				return result.Object;
			});
		}
        /// <summary>
        /// Asynchronously сancels the call.
        /// </summary>
        /// <returns>The call.</returns>
        /// <param name="requestUuid">Request UUID.</param>
        public async Task<DeleteResponse<Call>> CancelCallAsync(string requestUuid)
        {
            var result = await Client.Delete<DeleteResponse<Call>>("Account/" + Client.GetAuthId() + "/Request/" + requestUuid + "/", null);
            return result.Object;
        }
        #endregion
    }
}