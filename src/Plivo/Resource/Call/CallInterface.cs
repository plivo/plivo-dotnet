using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            var mandatoryParams = new List<string> {"from", "to", "answerUrl", "answerMethod"};
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
            return Client.Update<CallCreateResponse>(Uri, data).Object;
        }

        /// <summary>
        /// List Call with the specified subaccount, callDirection, fromNumber, toNumber, billDuration, billDuration_Gt,
        /// billDuration_Gte, billDuration_Lt, billDuration_Lte, endTime, endTime_Gt, endTime_Gte, endTime_Lt,
        /// endTime_Lte, limit and offset.
        /// </summary>
        /// <returns>The list.</returns>
        /// <param name="subaccount">Subaccount.</param>
        /// <param name="callDirection">Call direction.</param>
        /// <param name="fromNumber">From number.</param>
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
            string fromNumber = null, string toNumber = null,
            DateTime? billDuration = null, DateTime? billDuration_Gt = null,
            DateTime? billDuration_Gte = null, DateTime? billDuration_Lt = null,
            DateTime? billDuration_Lte = null, DateTime? endTime = null,
            DateTime? endTime_Gt = null, DateTime? endTime_Gte = null,
            DateTime? endTime_Lt = null, DateTime? endTime_Lte = null,
            uint? limit = null, uint? offset = null)
        {
            var _billDuration = billDuration?.ToString("yyyy-MM-dd HH':'mm'[:'ss'[.'ffffff']]'") ?? null;
            var _billDuration_Gt = billDuration_Gt?.ToString("yyyy-MM-dd HH':'mm'[:'ss'[.'ffffff']]'") ?? null;
            var _billDuration_Gte = billDuration_Gte?.ToString("yyyy-MM-dd HH':'mm'[:'ss'[.'ffffff']]'") ?? null;
            var _billDuration_Lt = billDuration_Lt?.ToString("yyyy-MM-dd HH':'mm'[:'ss'[.'ffffff']]'") ?? null;
            var _billDuration_Lte = billDuration_Lte?.ToString("yyyy-MM-dd HH':'mm'[:'ss'[.'ffffff']]'") ?? null;

            var _endTime = endTime?.ToString("yyyy-MM-dd HH':'mm'[:'ss'[.'ffffff']]'") ?? null;
            var _endTime_Gt = endTime_Gt?.ToString("yyyy-MM-dd HH':'mm'[:'ss'[.'ffffff']]'") ?? null;
            var _endTime_Gte = endTime_Gte?.ToString("yyyy-MM-dd HH':'mm'[:'ss'[.'ffffff']]'") ?? null;
            var _endTime_Lt = endTime_Lt?.ToString("yyyy-MM-dd HH':'mm'[:'ss'[.'ffffff']]'") ?? null;
            var _endTime_Lte = endTime_Lte?.ToString("yyyy-MM-dd HH':'mm'[:'ss'[.'ffffff']]'") ?? null;

            var mandatoryParams = new List<string> {""};
            var data = CreateData(
                mandatoryParams,
                new
                {
                    subaccount,
                    callDirection,
                    fromNumber,
                    toNumber,
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
            var resources = ListResources<ListResponse<Call>>(data);
            resources.Objects.ForEach(
                (obj) => obj.Interface = this
            );

            return resources;
        }

        /// <summary>
        /// Get Call with the specified callUuid.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="callUuid">Call UUID.</param>
        public Call Get(string callUuid)
        {
            var call = GetResource<Call>(callUuid);
            call.Interface = this;
            return call;
        }

        /// <summary>
        /// Lists the live.
        /// </summary>
        /// <returns>The live.</returns>
        public LiveCallListResponse ListLive()
        {
            return
                ListResources<LiveCallListResponse>(
                    new Dictionary<string, object>() {{"status", "live"}});
        }

        /// <summary>
        /// Gets the live.
        /// </summary>
        /// <returns>The live.</returns>
        /// <param name="liveCallUuid">Live call UUID.</param>
        public LiveCall GetLive(string liveCallUuid)
        {
            var liveCall = GetResource<LiveCall>(
                liveCallUuid, new Dictionary<string, object>() {{"status", "live"}});
            liveCall.Interface = this;
            return liveCall;
        }

        /// <summary>
        /// Delete Call with the specified callUuid.
        /// </summary>
        /// <returns>The delete.</returns>
        /// <param name="callUuid">Call UUID.</param>
        public DeleteResponse<Call> Delete(string callUuid)
        {
            return DeleteResource<DeleteResponse<Call>>(callUuid);
        }

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
            var mandatoryParams = new List<string> {""};
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
            return
                Client.Update<UpdateResponse<Call>>(
                    Uri + callUuid + "/", data).Object;
        }

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
            var mandatoryParams = new List<string> {""};
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
            return Client.Update<UpdateResponse<Call>>(Uri + callUuid + "/Play/", data).Object;
        }

        /// <summary>
        /// Stops the playing.
        /// </summary>
        /// <returns>The playing.</returns>
        /// <param name="callUuid">Call UUID.</param>
        public DeleteResponse<Call> StopPlaying(string callUuid)
        {
            return Client.Delete<DeleteResponse<Call>>(Uri + callUuid + "/Play/").Object;
        }

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
            var mandatoryParams = new List<string> {""};
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
            return Client.Update<RecordCreateResponse<Call>>(Uri + callUuid + "/Record/", data).Object;
        }

        /// <summary>
        /// Stops the recording.
        /// </summary>
        /// <returns>The recording.</returns>
        /// <param name="callUuid">Call UUID.</param>
        /// <param name="URL">URL.</param>
        public DeleteResponse<Call> StopRecording(string callUuid, string URL = null)
        {
            var mandatoryParams = new List<string> {""};
            var data = CreateData(
                mandatoryParams, new {URL});
            return Client.Delete<DeleteResponse<Call>>(Uri + callUuid + "/Record/", data).Object;
        }

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
            var mandatoryParams = new List<string> {""};
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
            return Client.Update<UpdateResponse<Call>>(Uri + callUuid + "/Speak/", data).Object;
        }

        /// <summary>
        /// Stops the speaking.
        /// </summary>
        /// <returns>The speaking.</returns>
        /// <param name="callUuid">Call UUID.</param>
        public DeleteResponse<Call> StopSpeaking(string callUuid)
        {
            return Client.Delete<DeleteResponse<Call>>(Uri + callUuid + "/Speak/").Object;
        }

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
            var mandatoryParams = new List<string> {""};
            var data = CreateData(
                mandatoryParams,
                new
                {
                    digits,
                    leg
                });
            return Client.Update<UpdateResponse<Call>>(Uri + callUuid + "/DTMF/", data).Object;
        }

        /// <summary>
        /// Cancels the call.
        /// </summary>
        /// <returns>The call.</returns>
        /// <param name="requestUuid">Request UUID.</param>
        public DeleteResponse<Call> CancelCall(string requestUuid)
        {
            return
                Client.Delete<DeleteResponse<Call>>(
                    "Account/" + Client.GetAuthId() + "/Request/" + requestUuid + "/",
                    null).Object;
        }
    }
}