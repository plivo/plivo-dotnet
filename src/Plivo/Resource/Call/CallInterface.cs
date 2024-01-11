using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Plivo.Client;
using Plivo.Http;
using Plivo.Utilities;

namespace Plivo.Resource.Call {
    /// <summary>
    /// Call interface.
    /// </summary>
    public class CallInterface : ResourceInterface {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:plivo.Resource.Call.CallInterface"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        public CallInterface (HttpClient client) : base (client) {
            Uri = "Account/" + Client.GetAuthId () + "/Call/";
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
        public CallCreateResponse Create (
            string from = null, List<string> to = null, string answerUrl = null, string answerMethod = null,
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
            to = to ?? new List<string>();
            string _to = string.Join("<", to);
            string newTimeLimit = timeLimit.ToString();
            string newHangupOnRing = hangupOnRing.ToString();
            string newSendOnPreanswer = sendOnPreanswer.ToString();
            if (to.Count > 1)
            {
                for (int i = 0; i < to.Count - 1; i++)
                {
                    if (newTimeLimit != null) newTimeLimit += "<" + timeLimit.ToString();
                    if (newSendOnPreanswer != null) newSendOnPreanswer += "<" + sendOnPreanswer.ToString();
                    if (newHangupOnRing != null) newHangupOnRing += "<" + hangupOnRing.ToString();
                }
            }
            var mandatoryParams = new List<string> { "from", "_to", "answerUrl"};
            bool isVoiceRequest = true;
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
                    newSendOnPreanswer,
                    newTimeLimit,
                    newHangupOnRing,
                    machineDetection,
                    machineDetectionTime,
                    machineDetectionUrl,
                    machineDetectionMethod,
                    sipHeaders,
                    ringTimeout,
                    parentCallUuid,
                    errorIfrentNotFound,
                    isVoiceRequest
                });

            return ExecuteWithExceptionUnwrap(() => 
            {
                var result = Task.Run (async () => await Client.Update<CallCreateResponse> (Uri, data).ConfigureAwait (false)).Result;
                result.Object.StatusCode = result.StatusCode;
                JObject responseJson = JObject.Parse(result.Content);
                result.Object.ApiId = responseJson["api_id"].ToString();
                result.Object.RequestUuid = responseJson["request_uuid"].ToString();
                result.Object.Message = responseJson["message"].ToString();
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
        /// <param name="callbackUrl">Callback URL.</param>
        /// <param name="callbackMethod">Callback method.</param>
        public async Task<AsyncResponse> CreateAsync(
            string from = null, List<string> to = null, string answerUrl = null, string answerMethod = null,
            string ringUrl = null, string ringMethod = null,
            string hangupUrl = null, string hangupMethod = null,
            string fallbackUrl = null, string fallbackMethod = null,
            string callerName = null, string sendDigits = null,
            bool? sendOnPreanswer = null, uint? timeLimit = null,
            uint? hangupOnRing = null, string machineDetection = null,
            uint? machineDetectionTime = null, string machineDetectionUrl = null,
            string machineDetectionMethod = null, string sipHeaders = null,
            uint? ringTimeout = null, string parentCallUuid = null,
            bool? errorIfrentNotFound = null, string callbackUrl = null, string callbackMethod = "POST") 
            {
            to = to ?? new List<string>();
            string _to = string.Join("<", to);
            var mandatoryParams = new List<string> { "from", "_to", "answerUrl", "answerMethod" };
            bool isVoiceRequest = true;
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
                    errorIfrentNotFound,
                    callbackUrl,
                    callbackMethod,
                    isVoiceRequest
                });
            
            if (callbackMethod == null)
            {
                data.Remove(callbackMethod);
            }
            
            MpcUtils.ValidUrl("callbackUrl", callbackUrl, true);
            var result =  Task.Run (async () => await Client.Update<AsyncResponse> (Uri, data).ConfigureAwait (false)).Result;
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
            bool isVoiceRequest = true;
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
                    offset,
                    isVoiceRequest
                });

            return ExecuteWithExceptionUnwrap (() => 
            {
                var resources = Task.Run (async () => await ListResources<ListResponse<Call>>(data).ConfigureAwait(false)).Result;
                resources.Objects.ForEach (
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
        /// <param name="callbackUrl">Callback URL.</param>
        /// <param name="callbackMethod">Callback method.</param>
        public async Task<AsyncResponse> ListAsync(
            string subaccount = null, string callDirection = null,
            string fromNumber = null, string toNumber = null, string parentCallUuid = null,
            string hangupSource = null, uint? hangupCauseCode = null,
            DateTime? billDuration = null, DateTime? billDuration_Gt = null,
            DateTime? billDuration_Gte = null, DateTime? billDuration_Lt = null,
            DateTime? billDuration_Lte = null, DateTime? endTime = null,
            DateTime? endTime_Gt = null, DateTime? endTime_Gte = null,
            DateTime? endTime_Lt = null, DateTime? endTime_Lte = null,
            uint? limit = null, uint? offset = null, string callbackUrl = null, string callbackMethod = null) 
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
            bool isVoiceRequest = true;
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
                    offset,
                    callbackUrl,
                    callbackMethod,
                    isVoiceRequest
                });
            
            if (data.ContainsKey("callback_method") && callbackMethod == null) {
                data.Remove("callback_method");
            }
            MpcUtils.ValidUrl("callbackUrl", callbackUrl, true);
            var result = Task.Run (async () => await Client.Fetch<AsyncResponse> (Uri, data).ConfigureAwait (false)).Result;
            await Task.WhenAll();
            result.Object.StatusCode = result.StatusCode;
            JObject responseJson = JObject.Parse(result.Content);
            result.Object.ApiId = responseJson["api_id"].ToString();
            result.Object.Message = responseJson["message"].ToString();
            return result.Object;
            }
        #endregion

        #region Get
        /// <summary>
        /// Get Call with the specified callUuid.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="callUuid">Call UUID.</param>
        public Call Get (string callUuid = null) {
            MpcUtils.ValidParamString("CallUUid",callUuid,true);
            bool isVoiceRequest = true;
            var data = CreateData(new List<string> {""},new {isVoiceRequest});
            return ExecuteWithExceptionUnwrap (() => 
            {
                var call = Task.Run (async () => await GetResource<Call> (callUuid, data).ConfigureAwait (false)).Result;
                call.Interface = this;
                return call;
            });
        }
        /// <summary>
        /// Asynchronously get Call with the specified callUuid.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="callUuid">Call UUID.</param>
        /// <param name="callbackUrl">Callback URL.</param>
        /// <param name="callbackMethod">Callback method.</param>
        public async Task<AsyncResponse> GetAsync(string callUuid = null, string callbackUrl = null, string callbackMethod = null) 
        {
            MpcUtils.ValidParamString("CallUUid",callUuid,true);
            bool isVoiceRequest = true;
            var data = CreateData(new List<string> {""},new {callbackUrl, callbackMethod, isVoiceRequest});
            if (data.ContainsKey("callback_method") && callbackMethod == null) {
                data.Remove("callback_method");
            }
            MpcUtils.ValidUrl("callbackUrl", callbackUrl, true);
            var result = Task.Run (async () => await Client.Fetch<AsyncResponse> (Uri + callUuid + "/", data).ConfigureAwait (false)).Result;
            await Task.WhenAll();
            result.Object.StatusCode = result.StatusCode;
            JObject responseJson = JObject.Parse(result.Content);
            result.Object.ApiId = responseJson["api_id"].ToString();
            result.Object.Message = responseJson["message"].ToString();
            return result.Object;
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
        public LiveCallListResponse ListLive (string callDirection = null,
            string fromNumber = null, string toNumber = null) 
            {
            var status = "live";
            var mandatoryParams = new List<string> { "" };
            bool isVoiceRequest = true;
            var data = CreateData(
                mandatoryParams,
                new 
                {
                    status,
                    callDirection,
                    fromNumber,
                    toNumber,
                    isVoiceRequest
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
        /// <param name="callbackUrl">Callback URL.</param>
        /// <param name="callbackMethod">Callback method.</param>
        public async Task<AsyncResponse> ListLiveAsync (string callDirection = null,
            string fromNumber = null, string toNumber = null, string callbackUrl = null, string callbackMethod = null) {
            var status = "live";
            var mandatoryParams = new List<string> { "" };
            bool isVoiceRequest = true;
            var data = CreateData (
                mandatoryParams,
                new {
                    status,
                    callDirection,
                    fromNumber,
                    toNumber,
                    callbackUrl,
                    callbackMethod,
                    isVoiceRequest
                });

            if (data.ContainsKey("callback_method") && callbackMethod == null) {
                data.Remove("callback_method");
            }
            MpcUtils.ValidUrl("callbackUrl", callbackUrl, true);
            var result = Task.Run (async () => await Client.Fetch<AsyncResponse> (Uri, data).ConfigureAwait (false)).Result;
            await Task.WhenAll();
            result.Object.StatusCode = result.StatusCode;
            JObject responseJson = JObject.Parse(result.Content);
            result.Object.ApiId = responseJson["api_id"].ToString();
            result.Object.Message = responseJson["message"].ToString();
            return result.Object;
        }
        #endregion

        #region GetLive
        /// <summary>
        /// Gets the live.
        /// </summary>
        /// <returns>The live.</returns>
        /// <param name="liveCallUuid">Live call UUID.</param>
        public LiveCall GetLive (string liveCallUuid = null) {
            MpcUtils.ValidParamString("liveCallUuid",liveCallUuid,true);
            return ExecuteWithExceptionUnwrap (() => {
                var liveCall = Task.Run (async () => await GetResource<LiveCall> (
                    liveCallUuid, new Dictionary<string, object> () { { "status", "live" } , {"is_voice_request", true}}).ConfigureAwait (false)).Result;
                liveCall.Interface = this;
                return liveCall;
            });
        }
        /// <summary>
        ///Asynchronously gets the live.
        /// </summary>
        /// <returns>The live.</returns>
        /// <param name="liveCallUuid">Live call UUID.</param>
        /// <param name="callbackUrl">Callback URL.</param>
        /// <param name="callbackMethod">Callback method.</param>
        public async Task<AsyncResponse> GetLiveAsync (string liveCallUuid = null, string callbackUrl = null, string callbackMethod = null) {
            MpcUtils.ValidParamString("liveCallUuid",liveCallUuid,true);
            MpcUtils.ValidUrl("callbackUrl", callbackUrl, true);
            var data = new Dictionary<string, object>()
            {
                {"status", "live" } ,
                {"is_voice_request", true},
                {"callback_url", callbackUrl},
                {"callback_method", callbackMethod}
            };
            if (data.ContainsKey("callback_method") && callbackMethod == null) {
                data.Remove("callback_method");
            }
            var result = Task.Run (async () => await Client.Fetch<AsyncResponse> (Uri + liveCallUuid + "/", data).ConfigureAwait (false)).Result;
            await Task.WhenAll();
            result.Object.StatusCode = result.StatusCode;
            JObject responseJson = JObject.Parse(result.Content);
            result.Object.ApiId = responseJson["api_id"].ToString();
            result.Object.Message = responseJson["message"].ToString();
            return result.Object;
        }
        #endregion

        #region GetQueued
        /// <summary>
        /// Gets the Queued call.
        /// </summary>
        /// <returns>Queued call details.</returns>
        /// <param name="callUuid">Call UUID.</param>
        public QueuedCall GetQueued (string callUuid = null) {
            MpcUtils.ValidParamString("callUuid",callUuid,true);
            return ExecuteWithExceptionUnwrap (() => {
                var queuedCall = Task.Run (async () => await GetResource<QueuedCall> (
                    callUuid, new Dictionary<string, object> () { { "status", "queued" }, {"is_voice_request", true} }).ConfigureAwait (false)).Result;
                queuedCall.Interface = this;
                return queuedCall;
            });
        }
        /// <summary>
        /// Asynchronously gets the Queued call.
        /// </summary>
        /// <returns>Queued call details.</returns>
        /// <param name="callUuid">Call UUID.</param>
        /// <param name="callbackUrl">Callback URL.</param>
        /// <param name="callbackMethod">Callback method.</param>
        public async Task<AsyncResponse> GetQueuedAsync (string callUuid = null, string callbackUrl = null, string callbackMethod = null) {
            MpcUtils.ValidParamString("callUuid",callUuid,true);
            MpcUtils.ValidUrl("callbackUrl", callbackUrl, true);
            var data = new Dictionary<string, object>()
            {
                {"status", "queued" } ,
                {"is_voice_request", true},
                {"callback_url", callbackUrl},
                {"callback_method", callbackMethod}
            };
            if (data.ContainsKey("callback_method") && callbackMethod == null) {
                data.Remove("callback_method");
            }
            var result = Task.Run (async () => await Client.Fetch<AsyncResponse> ( Uri + callUuid + "/", data).ConfigureAwait (false)).Result;
            await Task.WhenAll();
            result.Object.StatusCode = result.StatusCode;
            JObject responseJson = JObject.Parse(result.Content);
            result.Object.ApiId = responseJson["api_id"].ToString();
            result.Object.Message = responseJson["message"].ToString();
            return result.Object;
        }
        #endregion

        #region ListQueued
        /// <summary>
        /// Lists the queued calls.
        /// </summary>
        /// <returns>queued calls list</returns>
        public QueuedCallListResponse ListQueued () {
            return ExecuteWithExceptionUnwrap (() => {
                return Task.Run (async () => await ListResources<QueuedCallListResponse> (
                    new Dictionary<string, object> () { { "status", "queued" }, {"is_voice_request", true}}).ConfigureAwait (false)).Result;
            });
        }
        /// <summary>
        /// Lists the queued calls.
        /// </summary>
        /// <returns>queued calls list</returns>
        /// <param name="callbackUrl">Callback URL.</param>
        /// <param name="callbackMethod">Callback method.</param>
        public async Task<AsyncResponse> ListQueuedAsync (string callbackUrl = null, string callbackMethod = null) {
            MpcUtils.ValidUrl("callbackUrl", callbackUrl, true);
            var data = new Dictionary<string, object>()
            {
                {"status", "queued" } ,
                {"is_voice_request", true},
                {"callback_url", callbackUrl},
                {"callback_method", callbackMethod}
            };
            if (data.ContainsKey("callback_method") && callbackMethod == null) {
                data.Remove("callback_method");
            }
            var result = Task.Run (async () => await Client.Fetch<AsyncResponse> ( Uri, data).ConfigureAwait (false)).Result;
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
        /// Delete Call with the specified callUuid.
        /// </summary>
        /// <returns>The delete.</returns>
        /// <param name="callUuid">Call UUID.</param>
        public DeleteResponse<Call> Delete (string callUuid = null) {
            MpcUtils.ValidParamString("callUuid",callUuid,true);
            bool isVoiceRequest = true;
            var data = CreateData(new List<string> {""},new {isVoiceRequest});
            return ExecuteWithExceptionUnwrap (() => {
                return Task.Run (async () => await DeleteResource<DeleteResponse<Call>> (callUuid, data).ConfigureAwait (false)).Result;
            });
        }
        /// <summary>
        /// Asynchronously delete Call with the specified callUuid.
        /// </summary>
        /// <returns>The delete.</returns>
        /// <param name="callUuid">Call UUID.</param>
        /// <param name="callbackUrl">Callback URL.</param>
        /// <param name="callbackMethod">Callback Method.</param>
        public async Task<AsyncResponse> DeleteAsync (string callUuid = null,
            string callbackUrl = null, string callbackMethod = null) {
            MpcUtils.ValidParamString("callUuid",callUuid,true);
            bool isVoiceRequest = true;
            var data = CreateData(new List<string> {""},
                new {isVoiceRequest, callbackUrl, callbackMethod});
            if (data.ContainsKey("callback_method") && callbackMethod == null) {
                data.Remove("callback_method");
            }
            MpcUtils.ValidUrl("callbackUrl", callbackUrl, true);
            var result = Task.Run (async () => await Client.Delete<AsyncResponse> (Uri + callUuid + "/", data).ConfigureAwait (false)).Result;
            await Task.WhenAll();
            result.Object.StatusCode = result.StatusCode;
            return result.Object;
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
        public UpdateResponse<Call> Transfer (
            string callUuid = null, string legs = null, string alegUrl = null,
            string alegMethod = null, string blegUrl = null,
            string blegMethod = null) {
            MpcUtils.ValidParamString("callUuid",callUuid,true);
            var mandatoryParams = new List<string> { "" };
            bool isVoiceRequest = true;
            var data = CreateData (
                mandatoryParams,
                new {
                    legs,
                    alegUrl,
                    alegMethod,
                    blegUrl,
                    blegMethod,
                    isVoiceRequest
                });
            return ExecuteWithExceptionUnwrap (() => {
                var result = Task.Run (async () => await Client.Update<UpdateResponse<Call>> (Uri + callUuid + "/", data).ConfigureAwait (false)).Result;
                result.Object.StatusCode = result.StatusCode;
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
        /// <param name="callbackUrl">Callback URL.</param>
        /// <param name="callbackMethod">Callback Method.</param>
        public async Task<AsyncResponse> TransferAsync (
            string callUuid = null, string legs = null, string alegUrl = null,
            string alegMethod = null, string blegUrl = null,
            string blegMethod = null, string callbackUrl = null, string callbackMethod = null) {
            MpcUtils.ValidParamString("callUuid",callUuid,true);
            var mandatoryParams = new List<string> { "" };
            bool isVoiceRequest = true;
            var data = CreateData (
                mandatoryParams,
                new {
                    legs,
                    alegUrl,
                    alegMethod,
                    blegUrl,
                    blegMethod,
                    callbackUrl,
                    callbackMethod,
                    isVoiceRequest
                });
            if (data.ContainsKey("callback_method") && callbackMethod == null) {
                data.Remove("callback_method");
            }
            MpcUtils.ValidUrl("callbackUrl", callbackUrl, true);
            var result = Task.Run (async () => await Client.Update<AsyncResponse> (Uri + callUuid + "/", data).ConfigureAwait (false)).Result;
            await Task.WhenAll();
            result.Object.StatusCode = result.StatusCode;
            JObject responseJson = JObject.Parse(result.Content);
            result.Object.ApiId = responseJson["api_id"].ToString();
            result.Object.Message = responseJson["message"].ToString();
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
        public UpdateResponse<Call> StartPlaying (
            string callUuid = null, List<string> urls = null, uint? length = null,
            string legs = null, bool? loop = null, bool? mix = null) {
            MpcUtils.ValidParamString("callUuid",callUuid,true);
            urls = urls ?? new List<string>();
            var _urls = string.Join (",", urls);
            var mandatoryParams = new List<string> { "_urls" };
            bool isVoiceRequest = true;
            var data = CreateData (
                mandatoryParams,
                new {
                    _urls,
                    length,
                    legs,
                    loop,
                    mix,
                    isVoiceRequest
                });

            return ExecuteWithExceptionUnwrap (() => {
                var result = Task.Run (async () => await Client.Update<UpdateResponse<Call>> (Uri + callUuid + "/Play/", data).ConfigureAwait (false)).Result;
                try {
                    result.Object.StatusCode = result.StatusCode;
                } catch (System.NullReferenceException) {

                }
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
        /// <param name="callbackUrl">CallbackUrl.</param>
        /// <param name="callbackMethod">CallbackMethod.</param>
        public async Task<AsyncResponse> StartPlayingAsync (
            string callUuid = null, List<string> urls = null, uint? length = null,
            string legs = null, bool? loop = null, bool? mix = null,
            string callbackUrl = null, string callbackMethod = null) {
            MpcUtils.ValidParamString("callUuid",callUuid,true);
            urls = urls ?? new List<string>();
            var _urls = string.Join (",", urls);
            var mandatoryParams = new List<string> { "_urls" };
            bool isVoiceRequest = true;
            var data = CreateData (
                mandatoryParams,
                new {
                    _urls,
                    length,
                    legs,
                    loop,
                    mix,
                    callbackUrl,
                    callbackMethod,
                    isVoiceRequest
                });
            if (data.ContainsKey("callback_method") && callbackMethod == null) {
                data.Remove("callback_method");
            }
            MpcUtils.ValidUrl("callbackUrl", callbackUrl, true);
            var result = Task.Run (async () => await Client.Update<AsyncResponse> (Uri + callUuid + "/Play/", data).ConfigureAwait (false)).Result;
            await Task.WhenAll();
            result.Object.StatusCode = result.StatusCode;
            JObject responseJson = JObject.Parse(result.Content);
            result.Object.ApiId = responseJson["api_id"].ToString();
            result.Object.Message = responseJson["message"].ToString();
            return result.Object;
        }
        #endregion

        #region StopPlaying
        /// <summary>
        /// Stops the playing.
        /// </summary>
        /// <returns>The playing.</returns>
        /// <param name="callUuid">Call UUID.</param>
        public DeleteResponse<Call> StopPlaying (string callUuid = null) {
            MpcUtils.ValidParamString("callUuid",callUuid,true);
            return ExecuteWithExceptionUnwrap (() => {
                var result = Task.Run (async () => await Client.Delete<DeleteResponse<Call>> (Uri + callUuid + "/Play/", new Dictionary<string, object> () { {"is_voice_request", true} }).ConfigureAwait (false)).Result;
                try {
                    result.Object.StatusCode = result.StatusCode;
                } catch (System.NullReferenceException) {

                }
                return result.Object;
            });
        }
        /// <summary>
        /// Asynchronously stops the playing.
        /// </summary>
        /// <returns>The playing.</returns>
        /// <param name="callUuid">Call UUID.</param>
        /// <param name="callbackUrl">Callback URL.</param>
        /// <param name="callbackMethod">Callback Method.</param>
        public async Task<AsyncResponse> StopPlayingAsync (string callUuid = null,
            string callbackUrl = null, string callbackMethod = null) {
            MpcUtils.ValidParamString("callUuid",callUuid,true);
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
            var result = Task.Run (async () => await Client.Delete<AsyncResponse> (Uri + callUuid + "/Play/", data).ConfigureAwait (false)).Result;
            await Task.WhenAll();
            result.Object.StatusCode = result.StatusCode;
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
        public RecordCreateResponse<Call> StartRecording (
            string callUuid = null, uint? timeLimit = null, string fileFormat = null,
            string transactionType = null, string transactionUrl = null,
            string transactionMethod = null, string callbackUrl = null,
            string callbackMethod = null) {
            MpcUtils.ValidParamString("callUuid",callUuid,true);
            var mandatoryParams = new List<string> { "" };
            bool isVoiceRequest = true;
            var data = CreateData (
                mandatoryParams,
                new {
                    timeLimit,
                    fileFormat,
                    transactionType,
                    transactionUrl,
                    transactionMethod,
                    callbackUrl,
                    callbackMethod,
                    isVoiceRequest
                });

            if (data.ContainsKey("callback_method") && callbackMethod == null) {
                data.Remove("callback_method");
            }
            return ExecuteWithExceptionUnwrap (() => {
                var result = Task.Run (async () => await Client.Update<RecordCreateResponse<Call>> (Uri + callUuid + "/Record/", data).ConfigureAwait (false)).Result;
                try {
                    result.Object.StatusCode = result.StatusCode;
                } catch (System.NullReferenceException) {

                }
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
        public async Task<AsyncResponse> StartRecordingAsync (
            string callUuid = null, uint? timeLimit = null, string fileFormat = null,
            string transactionType = null, string transactionUrl = null,
            string transactionMethod = null, string callbackUrl = null,
            string callbackMethod = null) {
            MpcUtils.ValidParamString("callUuid",callUuid,true);
            var mandatoryParams = new List<string> { "" };
            bool isVoiceRequest = true;
            var data = CreateData (
                mandatoryParams,
                new {
                    timeLimit,
                    fileFormat,
                    transactionType,
                    transactionUrl,
                    transactionMethod,
                    callbackUrl,
                    callbackMethod,
                    isVoiceRequest
                });
            if (data.ContainsKey("callback_method") && callbackMethod == null) {
                data.Remove("callback_method");
            }
            MpcUtils.ValidUrl("callbackUrl", callbackUrl, true);
            var result = Task.Run (async () => await Client.Update<AsyncResponse> (Uri + callUuid + "/Record/", data).ConfigureAwait (false)).Result;
            await Task.WhenAll();
            result.Object.StatusCode = result.StatusCode;
            JObject responseJson = JObject.Parse(result.Content);
            result.Object.ApiId = responseJson["api_id"].ToString();
            result.Object.Message = responseJson["message"].ToString();
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
        public DeleteResponse<Call> StopRecording (string callUuid = null, string URL = null) {
            MpcUtils.ValidParamString("callUuid",callUuid,true);
            var mandatoryParams = new List<string> { "" };
            bool isVoiceRequest = true;
            var data = CreateData (
                mandatoryParams, new { URL, isVoiceRequest });

            return ExecuteWithExceptionUnwrap (() => {
                var result = Task.Run (async () => await Client.Delete<DeleteResponse<Call>> (Uri + callUuid + "/Record/", data).ConfigureAwait (false)).Result;
                try {
                    result.Object.StatusCode = result.StatusCode;
                } catch (System.NullReferenceException) {

                }
                return result.Object;
            });
        }
        /// <summary>
        /// Asynchronously stops the recording.
        /// </summary>
        /// <returns>The recording.</returns>
        /// <param name="callUuid">Call UUID.</param>
        /// <param name="URL">URL.</param>
        /// <param name="callbackUrl">Callback URL.</param>
        /// <param name="callbackMethod">Callback method.</param>
        public async Task<AsyncResponse> StopRecordingAsync (string callUuid = null, string URL = null, 
            string callbackUrl = null, string callbackMethod = null) {
            MpcUtils.ValidParamString("callUuid",callUuid,true);
            var mandatoryParams = new List<string> { "" };
            bool isVoiceRequest = true;
            MpcUtils.ValidUrl("callbackUrl", callbackUrl, true);
            var data = CreateData (
                mandatoryParams, new { URL, callbackUrl, callbackMethod, isVoiceRequest });
            if (data.ContainsKey("callback_method") && callbackMethod == null) {
                data.Remove("callback_method");
            }
            var result = Task.Run (async () => await Client.Delete<AsyncResponse> (Uri + callUuid + "/Record/", data).ConfigureAwait (false)).Result;
            await Task.WhenAll();
            result.Object.StatusCode = result.StatusCode;
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
        /// <param name="type">Type.</param>
        public UpdateResponse<Call> StartSpeaking (
            string callUuid = null, string text = null, string voice = null,
            string language = null, string legs = null, bool? loop = null,
            bool? mix = null, string type = null) {
            MpcUtils.ValidParamString("callUuid",callUuid,true);
            var mandatoryParams = new List<string> { "text" };
            bool isVoiceRequest = true;
            var data = CreateData (
                mandatoryParams,
                new {
                    text,
                    voice,
                    language,
                    legs,
                    loop,
                    mix,
                    type,
                    isVoiceRequest
                });

            return ExecuteWithExceptionUnwrap (() => {
                var result = Task.Run (async () => await Client.Update<UpdateResponse<Call>> (Uri + callUuid + "/Speak/", data).ConfigureAwait (false)).Result;
                result.Object.StatusCode = result.StatusCode;
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
        /// <param name="type">Type.</param>
        /// <param name="callbackUrl">Callback URL.</param>
        /// <param name="callbackMethod">Callback method.</param>
        public async Task<AsyncResponse> StartSpeakingAsync (
            string callUuid = null, string text = null, string voice = null,
            string language = null, string legs = null, bool? loop = null,
            bool? mix = null, string type = null, string callbackUrl = null, string callbackMethod = null) {
            MpcUtils.ValidParamString("callUuid",callUuid,true);
            var mandatoryParams = new List<string> { "text" };
            bool isVoiceRequest = true;
            var data = CreateData (
                mandatoryParams,
                new {
                    text,
                    voice,
                    language,
                    legs,
                    loop,
                    mix,
                    type,
                    callbackUrl,
                    callbackMethod,
                    isVoiceRequest
                });
            if (data.ContainsKey("callback_method") && callbackMethod == null) {
                data.Remove("callback_method");
            }
            MpcUtils.ValidUrl("callbackUrl", callbackUrl, true);
            var result = Task.Run (async () => await Client.Update<AsyncResponse> (Uri + callUuid + "/Speak/", data).ConfigureAwait (false)).Result;
            await Task.WhenAll();
            result.Object.StatusCode = result.StatusCode;
            JObject responseJson = JObject.Parse(result.Content);
            result.Object.ApiId = responseJson["api_id"].ToString();
            result.Object.Message = responseJson["message"].ToString();
            return result.Object;
        }

        #endregion

        #region StopSpeaking
        /// <summary>
        /// Stops the speaking.
        /// </summary>
        /// <returns>The speaking.</returns>
        /// <param name="callUuid">Call UUID.</param>
        public DeleteResponse<Call> StopSpeaking (string callUuid = null) {
            MpcUtils.ValidParamString("callUuid",callUuid,true);
            return ExecuteWithExceptionUnwrap (() => {
                var result = Task.Run (async () => await Client.Delete<DeleteResponse<Call>> (Uri + callUuid + "/Speak/",new Dictionary<string, object> () { {"is_voice_request", true} }).ConfigureAwait (false)).Result;
                result.Object.StatusCode = result.StatusCode;
                return result.Object;
            });
        }
        /// <summary>
        /// Asynchronously stops the speaking.
        /// </summary>
        /// <returns>The speaking.</returns>
        /// <param name="callUuid">Call UUID.</param>
        /// <param name="callbackUrl">Callback URL.</param>
        /// <param name="callbackMethod">Callback method.</param>
        public async Task<AsyncResponse> StopSpeakingAsync (string callUuid = null, string callbackUrl = null, string callbackMethod = null) {
            MpcUtils.ValidParamString("callUuid",callUuid,true);
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
            var result = Task.Run (async () => await Client.Delete<AsyncResponse> (Uri + callUuid + "/Speak/", data).ConfigureAwait (false)).Result;
            await Task.WhenAll();
            result.Object.StatusCode = result.StatusCode;
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
        public UpdateResponse<Call> SendDigits (
            string callUuid = null, string digits = null, string leg = null) {
            MpcUtils.ValidParamString("callUuid",callUuid,true);
            var mandatoryParams = new List<string> { "digits" };
            bool isVoiceRequest = true;
            var data = CreateData (
                mandatoryParams,
                new {
                    digits,
                    leg,
                    isVoiceRequest
                });

            return ExecuteWithExceptionUnwrap (() => {
                var result = Task.Run (async () => await Client.Update<UpdateResponse<Call>> (Uri + callUuid + "/DTMF/", data).ConfigureAwait (false)).Result;
                result.Object.StatusCode = result.StatusCode;
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
        /// <param name="callbackUrl">Callback URL.</param>
        /// <param name="callbackMethod">Callback method.</param>
        public async Task<AsyncResponse> SendDigitsAsync (
            string callUuid = null, string digits = null, string leg = null,
            string callbackUrl = null, string callbackMethod = null) {
            MpcUtils.ValidParamString("callUuid",callUuid,true);
            var mandatoryParams = new List<string> { "digits" };
            bool isVoiceRequest = true;
            var data = CreateData (
                mandatoryParams,
                new {
                    digits,
                    leg,
                    callbackUrl,
                    callbackMethod,
                    isVoiceRequest
                });
            if (data.ContainsKey("callback_method") && callbackMethod == null) {
                data.Remove("callback_method");
            }
            MpcUtils.ValidUrl("callbackUrl", callbackUrl, true);
            var result = Task.Run (async () => await Client.Update<AsyncResponse> (Uri + callUuid + "/DTMF/", data).ConfigureAwait (false)).Result;
            await Task.WhenAll();
            result.Object.StatusCode = result.StatusCode;
            JObject responseJson = JObject.Parse(result.Content);
            result.Object.ApiId = responseJson["api_id"].ToString();
            result.Object.Message = responseJson["message"].ToString();
            return result.Object;
        }
        #endregion

        #region CancelCall
        /// <summary>
        /// Cancels the call.
        /// </summary>
        /// <returns>The call.</returns>
        /// <param name="requestUuid">Request UUID.</param>
        public DeleteResponse<Call> CancelCall (string requestUuid = null) {
            MpcUtils.ValidParamString("requestUuid",requestUuid,true);
            return ExecuteWithExceptionUnwrap (() => {
                var result = Task.Run (async () => await Client.Delete<DeleteResponse<Call>> ("Account/" + Client.GetAuthId () + "/Request/" + requestUuid + "/", new Dictionary<string, object> () { {"is_voice_request", true} }).ConfigureAwait (false)).Result;
                result.Object.StatusCode = result.StatusCode;
                return result.Object;
            });
        }
        /// <summary>
        /// Asynchronously сancels the call.
        /// </summary>
        /// <returns>The call.</returns>
        /// <param name="requestUuid">Request UUID.</param>
        /// <param name="callbackUrl">Callback URL.</param>
        /// <param name="callbackMethod">Callback method.</param>
        public async Task<AsyncResponse> CancelCallAsync (string requestUuid = null, string callbackUrl = null, string callbackMethod = null) {
            MpcUtils.ValidParamString("requestUuid",requestUuid,true);
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
            var result = Task.Run (async () => await Client.Delete<AsyncResponse> ("Account/" + Client.GetAuthId () + "/Request/" + requestUuid + "/", data).ConfigureAwait (false)).Result;
            await Task.WhenAll();
            result.Object.StatusCode = result.StatusCode;
            return result.Object;
        }
        #endregion
        
        #region StartStream
        /// <summary>
        /// Starts the recording.
        /// </summary>
        /// <returns>The stream.</returns>
        /// <param name="callUuid">Call UUID.</param>
        /// <param name="serviceUrl">Call UUID.</param>
        /// <param name="bidirectional">Time limit.</param>
        /// <param name="audioTrack">File format.</param>
        /// <param name="streamTimeout">Transaction type.</param>
        /// <param name="statusCallbackUrl">Transaction URL.</param>
        /// <param name="statusCallbackMethod">Transaction method.</param>
        /// <param name="contentType">Callback URL.</param>
        /// <param name="extraHeaders">Callback method.</param>
        public StreamCreateResponse StartStream (
            string callUuid = null, string serviceUrl = null, string bidirectional = null,
            string audioTrack = null, string streamTimeout = null,
            string statusCallbackUrl = null, string statusCallbackMethod = null,
            string contentType = null, string extraHeaders = null) {
            StreamUtils.ValidParamString("callUuid",callUuid,true);
            var mandatoryParams = new List<string> { "serviceUrl" };
            bool isVoiceRequest = true;
            var data = CreateData (
                mandatoryParams,
                new {
                    serviceUrl,
                    bidirectional,
                    audioTrack,
                    streamTimeout,
                    statusCallbackUrl,
                    statusCallbackMethod,
                    contentType,
                    extraHeaders,
                    isVoiceRequest
                });
            
            return ExecuteWithExceptionUnwrap(() => 
            {
                var result = Task.Run (async () => await Client.Update<StreamCreateResponse> (Uri + callUuid + "/Stream/", data).ConfigureAwait (false)).Result;
                result.Object.StatusCode = result.StatusCode;
                JObject responseJson = JObject.Parse(result.Content);
                result.Object.ApiId = responseJson["api_id"].ToString();
                result.Object.StreamId = responseJson["stream_id"].ToString();
                result.Object.Message = responseJson["message"].ToString();
                return result.Object;
            });
        }
        
        /// <summary>
        /// Asynchronously starts the recording.
        /// </summary>
        /// <returns>The stream.</returns>
        /// <param name="callUuid">Call UUID.</param>
        /// <param name="serviceUrl">Call UUID.</param>
        /// <param name="bidirectional">Time limit.</param>
        /// <param name="audioTrack">File format.</param>
        /// <param name="streamTimeout">Transaction type.</param>
        /// <param name="statusCallbackUrl">Transaction URL.</param>
        /// <param name="statusCallbackMethod">Transaction method.</param>
        /// <param name="contentType">Callback URL.</param>
        /// <param name="extraHeaders">Callback method.</param>
        public async Task<Stream.AsyncResponse> StartStreamAsync (
            string callUuid = null, string serviceUrl = null, string bidirectional = null,
            string audioTrack = null, string streamTimeout = null,
            string statusCallbackUrl = null, string statusCallbackMethod = null,
            string contentType = null, string extraHeaders = null) {
            StreamUtils.ValidParamString("callUuid",callUuid,true);
            var mandatoryParams = new List<string> { "serviceUrl" };
            bool isVoiceRequest = true;
            var data = CreateData (
                mandatoryParams,
                new {
                    serviceUrl,
                    bidirectional,
                    audioTrack,
                    streamTimeout,
                    statusCallbackUrl,
                    statusCallbackMethod,
                    contentType,
                    extraHeaders,
                    isVoiceRequest
                });

            var result = Task.Run (async () => await Client.Update<Stream.AsyncResponse> (Uri + callUuid + "/Stream/", data).ConfigureAwait (false)).Result;
            await Task.WhenAll();
            result.Object.StatusCode = result.StatusCode;
            JObject responseJson = JObject.Parse(result.Content);
            result.Object.ApiId = responseJson["api_id"].ToString();
            result.Object.Message = responseJson["message"].ToString();
            return result.Object;
        }
        #endregion
        
        #region GetStream
        public ListResponse<Stream.Stream> GetAllStreams(
            string callUuid = null) 
            {
                StreamUtils.ValidParamString("callUuid",callUuid,true);
                var mandatoryParams = new List<string> { "callUuid" };
                bool isVoiceRequest = true;
                var data = CreateData(
                    mandatoryParams,
                    new 
                    {
                        callUuid,
                        isVoiceRequest
                    });

            return ExecuteWithExceptionUnwrap (() => 
            {
                var resources = Task.Run (async () => await ListResources<ListResponse<Stream.Stream>>(callUuid + "/Stream" , data).ConfigureAwait(false)).Result;
                resources.Objects.ForEach (
                    (obj) => obj.Interface = this
                );

                return resources;
            });
        }
        
        public async Task<AsyncResponse> GetAllStreamsAsync(
            string callUuid = null) 
        {
            StreamUtils.ValidParamString("callUuid",callUuid,true);
            var mandatoryParams = new List<string> { "callUuid" };
            bool isVoiceRequest = true;
            var data = CreateData(
                mandatoryParams,
                new 
                {
                    callUuid,
                    isVoiceRequest
                });
            var result = Task.Run (async () => await Client.Fetch<AsyncResponse> (callUuid + "/Stream" , data).ConfigureAwait(false)).Result;
            await Task.WhenAll();
            result.Object.StatusCode = result.StatusCode;
            JObject responseJson = JObject.Parse(result.Content);
            result.Object.ApiId = responseJson["api_id"].ToString();
            result.Object.Message = responseJson["message"].ToString();
            return result.Object;
        }
        
        public Stream.Stream GetStream(string callUuid = null, string streamId = null)
        {
            StreamUtils.ValidParamString("callUuid", callUuid, true);
            StreamUtils.ValidParamString("streamId", streamId, true);
            
            return ExecuteWithExceptionUnwrap(() =>
            {
                var stream = Task.Run(async () =>
                    await GetSecondaryResource<Stream.Stream>(callUuid,
                        new Dictionary<string, object>() {{"is_voice_request", true}},
                        "Stream", streamId).ConfigureAwait(false)).Result;
                stream.Interface = this;
                return stream;
            });
        }
        
        public async Task<AsyncResponse> GetStreamAsync(string callUuid = null, string streamId = null)
        {
            StreamUtils.ValidParamString("callUuid", callUuid, true);
            StreamUtils.ValidParamString("streamId", streamId, true);
            
            var result = Task.Run (async () => await Client.Fetch<AsyncResponse> (
                Uri + callUuid + "/Stream/" + streamId + "/", 
                new Dictionary<string, object>() {{"is_voice_request", true}}).ConfigureAwait(false)).Result;
            await Task.WhenAll();
            result.Object.StatusCode = result.StatusCode;
            JObject responseJson = JObject.Parse(result.Content);
            result.Object.ApiId = responseJson["api_id"].ToString();
            result.Object.Message = responseJson["message"].ToString();
            return result.Object;
        }
        #endregion

        #region StopStream
        public DeleteResponse<Stream.Stream> StopStream (string callUuid = null, string streamId = null) {
            StreamUtils.ValidParamString("callUuid",callUuid,true);
            StreamUtils.ValidParamString("streamId",streamId,true);
            var mandatoryParams = new List<string> { "" };
            bool isVoiceRequest = true;
            var data = CreateData (
                mandatoryParams, new { isVoiceRequest });

            return ExecuteWithExceptionUnwrap (() => {
                var result = Task.Run (async () => 
                    await Client.Delete<DeleteResponse<Stream.Stream>> (Uri + callUuid + "/Stream/" + streamId, data).
                        ConfigureAwait (false)).Result;
                try {
                    result.Object.StatusCode = result.StatusCode;
                } catch (System.NullReferenceException) {

                }
                return result.Object;
            });
        }

        public async Task<AsyncResponse> StopStreamAsync (string callUuid = null, string streamId = null) {
            StreamUtils.ValidParamString("callUuid",callUuid,true);
            StreamUtils.ValidParamString("streamId",streamId,true);
            var mandatoryParams = new List<string> { "" };
            bool isVoiceRequest = true;
            var data = CreateData (
                mandatoryParams, new { isVoiceRequest });
            
            var result = Task.Run (async () => 
                await Client.Delete<AsyncResponse> (Uri + callUuid + "/Stream/" + streamId, data).ConfigureAwait (false)).Result;
            await Task.WhenAll();
            result.Object.StatusCode = result.StatusCode;
            return result.Object;
        }
        
        public DeleteResponse<Stream.Stream> StopAllStreams (string callUuid = null) {
            StreamUtils.ValidParamString("callUuid",callUuid,true);
            var mandatoryParams = new List<string> { "" };
            bool isVoiceRequest = true;
            var data = CreateData (
                mandatoryParams, new { isVoiceRequest });

            return ExecuteWithExceptionUnwrap (() => {
                var result = Task.Run (async () => 
                    await Client.Delete<DeleteResponse<Stream.Stream>> (Uri + callUuid + "/Stream/", data).
                        ConfigureAwait (false)).Result;
                try {
                    result.Object.StatusCode = result.StatusCode;
                } catch (System.NullReferenceException) {

                }
                return result.Object;
            });
        }

        public async Task<AsyncResponse> StopAllStreamsAsync (string callUuid = null) {
            StreamUtils.ValidParamString("callUuid",callUuid,true);
            var mandatoryParams = new List<string> { "" };
            bool isVoiceRequest = true;
            var data = CreateData (
                mandatoryParams, new { isVoiceRequest });
            
            var result = Task.Run (async () => 
                await Client.Delete<AsyncResponse> (Uri + callUuid + "/Stream/", data).ConfigureAwait (false)).Result;
            await Task.WhenAll();
            result.Object.StatusCode = result.StatusCode;
            return result.Object;
        }
        #endregion
    }
}