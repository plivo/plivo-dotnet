using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Plivo.Client;
using Plivo.Exception;
using Plivo.Http;
using Plivo.Utilities;

namespace Plivo.Resource.MultiPartyCall
{
    public class MultiPartyCallInterface : ResourceInterface
    {
        public MultiPartyCallInterface (HttpClient client) : base (client) {
            Uri = "Account/" + Client.GetAuthId () + "/MultiPartyCall/";
        }
        
        public string MakeMpcId(string mpcUuid, string friendlyName)
        {
            string mpcId = "";
            if (mpcUuid != null)
            {
                mpcId = "uuid_" + mpcUuid;
            }
            else if (friendlyName != null)
            {
                mpcId = "name_" + friendlyName;
            }
            else
            {
                throw new PlivoValidationException("Provide either mpc_uuid or friendly_name but not both");
            }
            return mpcId;
        }

        public ListResponse<MultiPartyCall> List(
            string subAccount = null,
            string friendlyName = null,
            string status = null,
            uint? terminationCauseCode = null,
            string endTime_Gt = null,
            string endTime_Gte = null,
            string endTime_Lt = null,
            string endTime_Lte = null,
            string creationTime_Gt = null,
            string creationTime_Gte = null,
            string creationTime_Lt = null,
            string creationTime_Lte = null,
            uint? limit = null,
            uint? offset = null)
        {
            var mandatoryParams = new List<string> { "" };
            bool isVoiceRequest = true;
            if (subAccount != null)
            {
                MpcUtils.ValidSubAccount(subAccount);
            }

            if (friendlyName != null)
            {
                MpcUtils.ValidParamString("friendlyName", friendlyName, false);
            }

            if (status != null)
            {
                MpcUtils.ValidParamString("status", status, false);
            }

            if (terminationCauseCode != null)
            {
                MpcUtils.ValidParamInt("terminationCauseCode", terminationCauseCode, false);
            }

            if (endTime_Gt != null)
            {
                MpcUtils.ValidDateFormat("endTime_Gt", endTime_Gt, false);
            }
            if (endTime_Gte != null)
            {
                MpcUtils.ValidDateFormat("endTime_Gte", endTime_Gte, false);
            }
            if (endTime_Lt != null)
            {
                MpcUtils.ValidDateFormat("endTime_Lt", endTime_Lt, false);
            }
            if (endTime_Lte != null)
            {
                MpcUtils.ValidDateFormat("endTime_Lte", endTime_Lte, false);
            }
            if (creationTime_Gt != null)
            {
                MpcUtils.ValidDateFormat("creationTime_Gt", creationTime_Gt, false);
            }
            if (creationTime_Gte != null)
            {
                MpcUtils.ValidDateFormat("creationTime_Gte", creationTime_Gte, false);
            }
            if (creationTime_Lt != null)
            {
                MpcUtils.ValidDateFormat("creationTime_Lt", creationTime_Lt, false);
            }
            if (creationTime_Lte != null)
            {
                MpcUtils.ValidDateFormat("creationTime_Lte", creationTime_Lte, false);
            }

            if (limit != null)
            {
                MpcUtils.ValidRange("limit", limit, false, 1, 20);
            }

            if (offset != null)
            {
                MpcUtils.ValidRange("offset", offset, false, 0);
            }
            var data = CreateData(
                mandatoryParams,
                new 
                {
                    subAccount,
                    friendlyName,
                    status,
                    terminationCauseCode,
                    endTime_Gt,
                    endTime_Gte,
                    endTime_Lt,
                    endTime_Lte,
                    creationTime_Gt,
                    creationTime_Gte,
                    creationTime_Lt,
                    creationTime_Lte,
                    limit,
                    offset,
                    isVoiceRequest
                });
            
            return ExecuteWithExceptionUnwrap (() => 
            {
                var resources = Task.Run (async () => await ListResources<ListResponse<MultiPartyCall>>(data).ConfigureAwait(false)).Result;
                resources.Objects.ForEach (
                    (obj) => obj.Interface = this
                );

                return resources;
            });
        }
        
        public async Task<AsyncResponse> ListAsync(
            string subAccount = null,
            string friendlyName = null,
            string status = null,
            uint? terminationCauseCode = null,
            string endTime_Gt = null,
            string endTime_Gte = null,
            string endTime_Lt = null,
            string endTime_Lte = null,
            string creationTime_Gt = null,
            string creationTime_Gte = null,
            string creationTime_Lt = null,
            string creationTime_Lte = null,
            uint? limit = null,
            uint? offset = null, 
            string callbackUrl = null, 
            string callbackMethod = null)
        {
            var mandatoryParams = new List<string> { "" };
            bool isVoiceRequest = true;
            if (subAccount != null)
            {
                MpcUtils.ValidSubAccount(subAccount);
            }

            if (friendlyName != null)
            {
                MpcUtils.ValidParamString("friendlyName", friendlyName, false);
            }

            if (status != null)
            {
                MpcUtils.ValidParamString("status", status, false);
            }

            if (terminationCauseCode != null)
            {
                MpcUtils.ValidParamInt("terminationCauseCode", terminationCauseCode, false);
            }

            if (endTime_Gt != null)
            {
                MpcUtils.ValidDateFormat("endTime_Gt", endTime_Gt, false);
            }
            if (endTime_Gte != null)
            {
                MpcUtils.ValidDateFormat("endTime_Gte", endTime_Gte, false);
            }
            if (endTime_Lt != null)
            {
                MpcUtils.ValidDateFormat("endTime_Lt", endTime_Lt, false);
            }
            if (endTime_Lte != null)
            {
                MpcUtils.ValidDateFormat("endTime_Lte", endTime_Lte, false);
            }
            if (creationTime_Gt != null)
            {
                MpcUtils.ValidDateFormat("creationTime_Gt", creationTime_Gt, false);
            }
            if (creationTime_Gte != null)
            {
                MpcUtils.ValidDateFormat("creationTime_Gte", creationTime_Gte, false);
            }
            if (creationTime_Lt != null)
            {
                MpcUtils.ValidDateFormat("creationTime_Lt", creationTime_Lt, false);
            }
            if (creationTime_Lte != null)
            {
                MpcUtils.ValidDateFormat("creationTime_Lte", creationTime_Lte, false);
            }

            if (limit != null)
            {
                MpcUtils.ValidRange("limit", limit, false, 1, 20);
            }

            if (offset != null)
            {
                MpcUtils.ValidRange("offset", offset, false, 0);
            }
            MpcUtils.ValidUrl("callbackUrl", callbackUrl, true);
            if (callbackMethod != null)
            {
                MpcUtils.ValidParamString("callbackMethod", callbackMethod.ToUpper(), false,
                    new List<string>() {"GET", "POST"});
            }
            var data = CreateData(
                mandatoryParams,
                new 
                {
                    subAccount,
                    friendlyName,
                    status,
                    terminationCauseCode,
                    endTime_Gt,
                    endTime_Gte,
                    endTime_Lt,
                    endTime_Lte,
                    creationTime_Gt,
                    creationTime_Gte,
                    creationTime_Lt,
                    creationTime_Lte,
                    limit,
                    offset,
                    callbackUrl,
                    callbackMethod,
                    isVoiceRequest
                });
            if (data.ContainsKey("callback_method") && callbackMethod == null) {
                data.Remove("callback_method");
            }
            var result = Task.Run (async () => await Client.Fetch<AsyncResponse> (Uri, data).ConfigureAwait(false)).Result;
            await Task.WhenAll();
            result.Object.StatusCode = result.StatusCode;
            JObject responseJson = JObject.Parse(result.Content);
            result.Object.ApiId = responseJson["api_id"].ToString();
            result.Object.Message = responseJson["message"].ToString();
            return result.Object;
        }
        
        public MultiPartyCall Get(string mpcUuid = null, string friendlyName = null)
        {
            if (mpcUuid != null)
            {
                MpcUtils.ValidParamString("mpcUuid", mpcUuid, false);
            }
            if (friendlyName != null)
            {
                MpcUtils.ValidParamString("friendlyName", friendlyName, false);
            }
            string mpcId = MakeMpcId(mpcUuid, friendlyName);
            return ExecuteWithExceptionUnwrap(() =>
            {
                var mpc = Task.Run(async () =>
                    await GetResource<MultiPartyCall>(mpcId,
                        new Dictionary<string, object>() {{"is_voice_request", true}}).ConfigureAwait(false)).Result;
                mpc.Interface = this;
                return mpc;
            });
        }
        
        public async Task<AsyncResponse> GetAsync(string mpcUuid = null, string friendlyName = null,
            string callbackUrl = null, string callbackMethod = null)
        {
            if (mpcUuid != null)
            {
                MpcUtils.ValidParamString("mpcUuid", mpcUuid, false);
            }
            if (friendlyName != null)
            {
                MpcUtils.ValidParamString("friendlyName", friendlyName, false);
            }
            MpcUtils.ValidUrl("callbackUrl", callbackUrl, true);
            if (callbackMethod != null)
            {
                MpcUtils.ValidParamString("callbackMethod", callbackMethod.ToUpper(), false,
                    new List<string>() {"GET", "POST"});
            }
            string mpcId = MakeMpcId(mpcUuid, friendlyName);
            var data = new Dictionary<string, object>()
            {
                {"is_voice_request", true},
                {"callback_url", callbackUrl},
                {"callback_method", callbackMethod}
            };
            if (data.ContainsKey("callback_method") && callbackMethod == null) {
                data.Remove("callback_method");
            }
            var result = Task.Run (async () => await Client.Fetch<AsyncResponse> (Uri + mpcId + "/", data).ConfigureAwait(false)).Result;
            await Task.WhenAll();
            result.Object.StatusCode = result.StatusCode;
            JObject responseJson = JObject.Parse(result.Content);
            result.Object.ApiId = responseJson["api_id"].ToString();
            result.Object.Message = responseJson["message"].ToString();
            return result.Object;
        }

        public MultiPartyCallAddParticipantResponse AddParticipant(
            string role = null,
            string friendlyName = null,
            string mpcUuid = null,
            string from = null,
            string to = null,
            string callUuid = null,
            string callerName = null,
            string callStatusCallbackUrl = null,
            string callStatusCallbackMethod = "POST",
            string sipHeaders = null,
            string confirmKey = null,
            string confirmKeySoundUrl = null,
            string confirmKeySoundMethod = "GET",
            string dialMusic = "Real",
            dynamic ringTimeout = null,
            dynamic delayDial = null,
            uint? maxDuration = 14400,
            uint? maxParticipants = 10,
            uint? recordMinMemberCount = 1,
            string waitMusicUrl = null,
            string waitMusicMethod = "GET",
            string agentHoldMusicUrl = null,
            string agentHoldMusicMethod = "GET",
            string customerHoldMusicUrl = null,
            string customerHoldMusicMethod = "GET",
            string recordingCallbackUrl = null,
            string recordingCallbackMethod = "GET",
            string statusCallbackUrl = null,
            string statusCallbackMethod = "GET",
            string onExitActionUrl = null,
            string onExitActionMethod = "POST",
            bool record = false,
            string recordFileFormat = "mp3",
            string statusCallbackEvents = "mpc-state-changes,participant-state-changes",
            bool stayAlone = false,
            bool coachMode = true,
            bool mute = false,
            bool hold = false,
            bool startMpcOnEnter = true,
            bool endMpcOnExit = false,
            bool relayDtmfInputs = false,
            string enterSound = "beep:1",
            string enterSoundMethod = "GET",
            string exitSound = "beep:2",
            string exitSoundMethod = "GET",
            string startRecordingAudio = null,
            string startRecordingAudioMethod = "GET",
            string stopRecordingAudio = null,
            string stopRecordingAudioMethod = "GET"
        ) 
        {
            if (mpcUuid != null)
            {
                MpcUtils.ValidParamString("mpcUuid", mpcUuid, false);
            }
            if (friendlyName != null)
            {
                MpcUtils.ValidParamString("friendlyName", friendlyName, false);
            }

            if (from != null && to != null && callUuid != null)
            {
                throw new PlivoValidationException("cannot specify call_uuid when (from, to) is provided");
            }

            if (from == null && to == null && callUuid == null)
            {
                throw new PlivoValidationException("specify either callUuid or (from, to)");
            }

            if ((from == null || to == null) && callUuid == null)
            {
                throw new PlivoValidationException("specify (from, to) when not adding an existing callUuid to multi party participant");
            }
            if (role != null)
            {
                MpcUtils.ValidParamString("role", role.ToLower(), true, new List<string>() {"agent", "supervisor", "customer"});
            }
            if (from != null)
            {
                MpcUtils.ValidParamString("from", from, false);
            }

            if (to != null)
            {
                MpcUtils.ValidParamString("to", to, false);
                MpcUtils.ValidMultipleDestinationNos("to", to, role, '<', 20);
            }

            if (callUuid != null)
            {
                MpcUtils.ValidParamString("callUuid", callUuid, false);
            }

            if(callerName!=null)
            {
                MpcUtils.ValidParamString("callerName", callerName, false);
                MpcUtils.ValidRange("callerName Length",(uint)callerName.Length, false , 0, 50);
            }
            else
            {
                callerName = from;
            }

            if (callStatusCallbackUrl != null)
            {
                MpcUtils.ValidUrl("callStatusCallbackUrl", callStatusCallbackUrl, false);
            }

            if (callStatusCallbackMethod != null)
            {
                MpcUtils.ValidParamString("callStatusCallbackMethod", callStatusCallbackMethod.ToUpper(), false,
                    new List<string>() {"GET", "POST"});
            }

            if (sipHeaders != null)
            {
                MpcUtils.ValidParamString("sipHeaders", sipHeaders, false);
            }

            if (confirmKey != null)
            {
                MpcUtils.ValidParamString("confirmKey", confirmKey, false, 
                    new List<string>() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "#", "*"});
            }

            if (confirmKeySoundUrl != null)
            {
                MpcUtils.ValidUrl("confirmKeySoundUrl", confirmKeySoundUrl, false);
            }

            if (confirmKeySoundMethod != null)
            {
                MpcUtils.ValidParamString("confirmKeySoundMethod", confirmKeySoundMethod.ToUpper(), false,
                    new List<string>() {"GET", "POST"});
            }

            if (dialMusic != null)
            {
                MpcUtils.IsOneAmongStringUrl("dialMusic", dialMusic, false, 
                    new List<string>() {"real", "none"});
            }

            if (ringTimeout != null)
            {
                if (ringTimeout.GetType() == typeof(System.String))
                {
                    MpcUtils.ValidMultipleDestinationIntegers("ringTimeout", ringTimeout);
                }
                else if (ringTimeout.GetType() != typeof(System.Int32))
                {
                    throw new PlivoValidationException("RingTimeout must be of type int or String");
                }
            }
            else
            {
                ringTimeout = 45;
            }

            if (delayDial != null)
            {
                if (delayDial.GetType() == typeof(System.String))
                {
                    MpcUtils.ValidMultipleDestinationIntegers("delayDial", delayDial);
                }
                else if(delayDial.GetType() != typeof(System.Int32))
                {
                    throw new PlivoValidationException("DelayDial must be of type int or String");
                }
            }
            else
            {
                delayDial = 0;
            }
            
            if (maxDuration != null)
            {
                MpcUtils.ValidRange("maxDuration", maxDuration, false, 300, 28800);
            }

            if (maxParticipants != null)
            {
                MpcUtils.ValidRange("maxParticipants", maxParticipants, false, 2, 10);
            }
            
            if (recordMinMemberCount != null)
            {
                MpcUtils.ValidRange("recordMinMemberCount", recordMinMemberCount, false, 1, 2);
            }

            if (waitMusicUrl != null)
            {
                MpcUtils.ValidUrl("waitMusicUrl", waitMusicUrl, false);
            }

            if (waitMusicMethod != null)
            {
                MpcUtils.ValidParamString("waitMusicMethod", waitMusicMethod.ToUpper(), false,
                    new List<string>() {"GET", "POST"});
            }
            
            if (agentHoldMusicUrl != null)
            {
                MpcUtils.ValidUrl("agentHoldMusicUrl", agentHoldMusicUrl, false);
            }

            if (agentHoldMusicMethod != null)
            {
                MpcUtils.ValidParamString("agentHoldMusicMethod", agentHoldMusicMethod.ToUpper(), false,
                    new List<string>() {"GET", "POST"});
            }
            
            if (customerHoldMusicUrl != null)
            {
                MpcUtils.ValidUrl("customerHoldMusicUrl", customerHoldMusicUrl, false);
            }

            if (customerHoldMusicMethod != null)
            {
                MpcUtils.ValidParamString("customerHoldMusicMethod", customerHoldMusicMethod.ToUpper(), false,
                    new List<string>() {"GET", "POST"});
            }
            
            if (recordingCallbackUrl != null)
            {
                MpcUtils.ValidUrl("recordingCallbackUrl", recordingCallbackUrl, false);
            }

            if (recordingCallbackMethod != null)
            {
                MpcUtils.ValidParamString("recordingCallbackMethod", recordingCallbackMethod.ToUpper(), false,
                    new List<string>() {"GET", "POST"});
            }
            
            if (statusCallbackUrl != null)
            {
                MpcUtils.ValidUrl("statusCallbackUrl", statusCallbackUrl, false);
            }

            if (statusCallbackMethod != null)
            {
                MpcUtils.ValidParamString("statusCallbackMethod", statusCallbackMethod.ToUpper(), false,
                    new List<string>() {"GET", "POST"});
            }
            
            if (onExitActionUrl != null)
            {
                MpcUtils.ValidUrl("onExitActionUrl", onExitActionUrl, false);
            }

            if (onExitActionMethod != null)
            {
                MpcUtils.ValidParamString("onExitActionMethod", onExitActionMethod.ToUpper(), false,
                    new List<string>() {"GET", "POST"});
            }

            if (recordFileFormat != null)
            {
                MpcUtils.ValidParamString("recordFileFormat", recordFileFormat.ToLower(), false,
                    new List<string>() {"mp3", "wav"});
            }

            if (statusCallbackEvents != null)
            {
                MpcUtils.MultiValidParam("statusCallbackEvents", statusCallbackEvents.ToLower(),
                    false, true, new List<string>()
                    {
                        "mpc-state-changes", 
                        "participant-state-changes",
                        "participant-speak-events",
                        "participant-digit-input-events",
                        "add-participant-api-events"
                    }, ',');
            }

            if (enterSound != null)
            {
                MpcUtils.IsOneAmongStringUrl("enterSound", enterSound, false,
                    new List<string>() {"beep:1", "beep:2", "none"});
            }

            if (enterSoundMethod != null)
            {
                MpcUtils.ValidParamString("enterSoundMethod", enterSoundMethod.ToUpper(), false,
                    new List<string>() {"GET", "POST"});
            }
            
            if (exitSound != null)
            {
                MpcUtils.IsOneAmongStringUrl("exitSound", exitSound, false,
                    new List<string>() {"beep:1", "beep:2", "none"});
            }

            if (exitSoundMethod != null)
            {
                MpcUtils.ValidParamString("exitSoundMethod", exitSoundMethod.ToUpper(), false,
                    new List<string>() {"GET", "POST"});
            }
            
            if (startRecordingAudio != null)
            {
                MpcUtils.ValidUrl("startRecordingAudio", startRecordingAudio, false);
            }
            
            if (startRecordingAudioMethod != null)
            {
                MpcUtils.ValidParamString("startRecordingAudioMethod", startRecordingAudioMethod.ToUpper(), false,
                    new List<string>() {"GET", "POST"});
            }
            
            if (stopRecordingAudio != null)
            {
                MpcUtils.ValidUrl("stopRecordingAudio", stopRecordingAudio, false);
            }
            
            if (stopRecordingAudioMethod != null)
            {
                MpcUtils.ValidParamString("stopRecordingAudioMethod", stopRecordingAudioMethod.ToUpper(), false,
                    new List<string>() {"GET", "POST"});
            }
            string mpcId = MakeMpcId(mpcUuid, friendlyName);
            var mandatoryParams = new List<string> {"role"};
            bool isVoiceRequest = true;
            var data = CreateData(
                mandatoryParams,
                new 
                {
                    role,
                    from,
                    to,
                    callUuid,
                    callerName,
                    callStatusCallbackUrl,
                    callStatusCallbackMethod,
                    sipHeaders,
                    confirmKey,
                    confirmKeySoundUrl,
                    confirmKeySoundMethod,
                    dialMusic,
                    ringTimeout,
                    delayDial,
                    maxDuration,
                    maxParticipants,
                    recordMinMemberCount,
                    waitMusicUrl,
                    waitMusicMethod,
                    agentHoldMusicUrl,
                    agentHoldMusicMethod,
                    customerHoldMusicUrl,
                    customerHoldMusicMethod,
                    recordingCallbackUrl,
                    recordingCallbackMethod,
                    statusCallbackUrl,
                    statusCallbackMethod,
                    onExitActionUrl,
                    onExitActionMethod,
                    record,
                    recordFileFormat,
                    statusCallbackEvents,
                    stayAlone,
                    coachMode,
                    mute,
                    hold,
                    startMpcOnEnter,
                    endMpcOnExit,
                    relayDtmfInputs,
                    enterSound,
                    enterSoundMethod,
                    exitSound,
                    exitSoundMethod,
                    startRecordingAudio,
                    startRecordingAudioMethod,
                    stopRecordingAudio,
                    stopRecordingAudioMethod,
                    isVoiceRequest
                });
            
            return ExecuteWithExceptionUnwrap(() => 
            {
                var result = Task.Run (async () => await Client.Update<MultiPartyCallAddParticipantResponse> (Uri + mpcId + "/Participant/", data).ConfigureAwait (false)).Result;
                try
                {
                    result.Object.StatusCode = result.StatusCode;
                    JObject responseJson = JObject.Parse(result.Content);
                    result.Object.ApiId = responseJson["api_id"].ToString();
                    result.Object.RequestUuid = responseJson["request_uuid"].ToString();
                    result.Object.Message = responseJson["message"].ToString();
                }
                catch (System.NullReferenceException)
                {
                }
                return result.Object;
            });
        }

        public async Task<AsyncResponse> AddParticipantAsync(
            string role = null,
            string friendlyName = null,
            string mpcUuid = null,
            string from = null,
            string to = null,
            string callUuid = null,
            string callerName = null,
            string callStatusCallbackUrl = null,
            string callStatusCallbackMethod = "POST",
            string sipHeaders = null,
            string confirmKey = null,
            string confirmKeySoundUrl = null,
            string confirmKeySoundMethod = "GET",
            string dialMusic = "Real",
            dynamic ringTimeout = null,
            dynamic delayDial = null,
            uint? maxDuration = 14400,
            uint? maxParticipants = 10,
            string waitMusicUrl = null,
            string waitMusicMethod = "GET",
            string agentHoldMusicUrl = null,
            string agentHoldMusicMethod = "GET",
            string customerHoldMusicUrl = null,
            string customerHoldMusicMethod = "GET",
            string recordingCallbackUrl = null,
            string recordingCallbackMethod = "GET",
            string statusCallbackUrl = null,
            string statusCallbackMethod = "GET",
            string onExitActionUrl = null,
            string onExitActionMethod = "POST",
            bool record = false,
            string recordFileFormat = "mp3",
            string statusCallbackEvents = "mpc-state-changes,participant-state-changes",
            bool stayAlone = false,
            bool coachMode = true,
            bool mute = false,
            bool hold = false,
            bool startMpcOnEnter = true,
            bool endMpcOnExit = false,
            bool relayDtmfInputs = false,
            string enterSound = "beep:1",
            string enterSoundMethod = "GET",
            string exitSound = "beep:2",
            string exitSoundMethod = "GET",
            string startRecordingAudio = null,
            string startRecordingAudioMethod = "GET",
            string stopRecordingAudio = null,
            string stopRecordingAudioMethod = "GET", 
            string callbackUrl = null, 
            string callbackMethod = null
        ) 
        {
            if (mpcUuid != null)
            {
                MpcUtils.ValidParamString("mpcUuid", mpcUuid, false);
            }
            if (friendlyName != null)
            {
                MpcUtils.ValidParamString("friendlyName", friendlyName, false);
            }

            if (from != null && to != null && callUuid != null)
            {
                throw new PlivoValidationException("cannot specify call_uuid when (from, to) is provided");
            }

            if (from == null && to == null && callUuid == null)
            {
                throw new PlivoValidationException("specify either callUuid or (from, to)");
            }

            if ((from == null || to == null) && callUuid == null)
            {
                throw new PlivoValidationException("specify (from, to) when not adding an existing callUuid to multi party participant");
            }
            if (role != null)
            {
                MpcUtils.ValidParamString("role", role.ToLower(), true, new List<string>() {"agent", "supervisor", "customer"});
            }
            if (from != null)
            {
                MpcUtils.ValidParamString("from", from, false);
            }

            if (to != null)
            {
                MpcUtils.ValidParamString("to", to, false);
                MpcUtils.ValidMultipleDestinationNos("to", to, role, '<', 20);
            }

            if (callUuid != null)
            {
                MpcUtils.ValidParamString("callUuid", callUuid, false);
            }

            if(callerName!=null)
            {
                MpcUtils.ValidParamString("callerName", callerName, false);
                MpcUtils.ValidRange("callerName Length",(uint)callerName.Length, false , 0, 50);
            }
            else
            {
                callerName = from;
            }

            if (callStatusCallbackUrl != null)
            {
                MpcUtils.ValidUrl("callStatusCallbackUrl", callStatusCallbackUrl, false);
            }

            if (callStatusCallbackMethod != null)
            {
                MpcUtils.ValidParamString("callStatusCallbackMethod", callStatusCallbackMethod.ToUpper(), false,
                    new List<string>() {"GET", "POST"});
            }

            if (sipHeaders != null)
            {
                MpcUtils.ValidParamString("sipHeaders", sipHeaders, false);
            }

            if (confirmKey != null)
            {
                MpcUtils.ValidParamString("confirmKey", confirmKey, false, 
                    new List<string>() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "#", "*"});
            }

            if (confirmKeySoundUrl != null)
            {
                MpcUtils.ValidUrl("confirmKeySoundUrl", confirmKeySoundUrl, false);
            }

            if (confirmKeySoundMethod != null)
            {
                MpcUtils.ValidParamString("confirmKeySoundMethod", confirmKeySoundMethod.ToUpper(), false,
                    new List<string>() {"GET", "POST"});
            }

            if (dialMusic != null)
            {
                MpcUtils.IsOneAmongStringUrl("dialMusic", dialMusic, false, 
                    new List<string>() {"real", "none"});
            }

            if (ringTimeout != null)
            {
                if (ringTimeout.GetType() == typeof(System.String))
                {
                    MpcUtils.ValidMultipleDestinationIntegers("ringTimeout", ringTimeout);
                }
                else if (ringTimeout.GetType() != typeof(System.Int32))
                {
                    throw new PlivoValidationException("RingTimeout must be of type int or String");
                }
            }
            else
            {
                ringTimeout = 45;
            }

            if (delayDial != null)
            {
                if (delayDial.GetType() == typeof(System.String))
                {
                    MpcUtils.ValidMultipleDestinationIntegers("delayDial", delayDial);
                }
                else if(delayDial.GetType() != typeof(System.Int32))
                {
                    throw new PlivoValidationException("DelayDial must be of type int or String");
                }
            }
            else
            {
                delayDial = 0;
            }
            
            if (maxDuration != null)
            {
                MpcUtils.ValidRange("maxDuration", maxDuration, false, 300, 28800);
            }

            if (maxParticipants != null)
            {
                MpcUtils.ValidRange("maxParticipants", maxParticipants, false, 2, 10);
            }

            if (waitMusicUrl != null)
            {
                MpcUtils.ValidUrl("waitMusicUrl", waitMusicUrl, false);
            }

            if (waitMusicMethod != null)
            {
                MpcUtils.ValidParamString("waitMusicMethod", waitMusicMethod.ToUpper(), false,
                    new List<string>() {"GET", "POST"});
            }
            
            if (agentHoldMusicUrl != null)
            {
                MpcUtils.ValidUrl("agentHoldMusicUrl", agentHoldMusicUrl, false);
            }

            if (agentHoldMusicMethod != null)
            {
                MpcUtils.ValidParamString("agentHoldMusicMethod", agentHoldMusicMethod.ToUpper(), false,
                    new List<string>() {"GET", "POST"});
            }
            
            if (customerHoldMusicUrl != null)
            {
                MpcUtils.ValidUrl("customerHoldMusicUrl", customerHoldMusicUrl, false);
            }

            if (customerHoldMusicMethod != null)
            {
                MpcUtils.ValidParamString("customerHoldMusicMethod", customerHoldMusicMethod.ToUpper(), false,
                    new List<string>() {"GET", "POST"});
            }
            
            if (recordingCallbackUrl != null)
            {
                MpcUtils.ValidUrl("recordingCallbackUrl", recordingCallbackUrl, false);
            }

            if (recordingCallbackMethod != null)
            {
                MpcUtils.ValidParamString("recordingCallbackMethod", recordingCallbackMethod.ToUpper(), false,
                    new List<string>() {"GET", "POST"});
            }
            
            if (statusCallbackUrl != null)
            {
                MpcUtils.ValidUrl("statusCallbackUrl", statusCallbackUrl, false);
            }

            if (statusCallbackMethod != null)
            {
                MpcUtils.ValidParamString("statusCallbackMethod", statusCallbackMethod.ToUpper(), false,
                    new List<string>() {"GET", "POST"});
            }
            
            if (onExitActionUrl != null)
            {
                MpcUtils.ValidUrl("onExitActionUrl", onExitActionUrl, false);
            }

            if (onExitActionMethod != null)
            {
                MpcUtils.ValidParamString("onExitActionMethod", onExitActionMethod.ToUpper(), false,
                    new List<string>() {"GET", "POST"});
            }

            if (recordFileFormat != null)
            {
                MpcUtils.ValidParamString("recordFileFormat", recordFileFormat.ToLower(), false,
                    new List<string>() {"mp3", "wav"});
            }

            if (statusCallbackEvents != null)
            {
                MpcUtils.MultiValidParam("statusCallbackEvents", statusCallbackEvents.ToLower(),
                    false, true, new List<string>()
                    {
                        "mpc-state-changes", 
                        "participant-state-changes",
                        "participant-speak-events",
                        "participant-digit-input-events",
                        "add-participant-api-events"
                    }, ',');
            }

            if (enterSound != null)
            {
                MpcUtils.IsOneAmongStringUrl("enterSound", enterSound, false,
                    new List<string>() {"beep:1", "beep:2", "none"});
            }

            if (enterSoundMethod != null)
            {
                MpcUtils.ValidParamString("enterSoundMethod", enterSoundMethod.ToUpper(), false,
                    new List<string>() {"GET", "POST"});
            }
            
            if (exitSound != null)
            {
                MpcUtils.IsOneAmongStringUrl("exitSound", exitSound, false,
                    new List<string>() {"beep:1", "beep:2", "none"});
            }

            if (exitSoundMethod != null)
            {
                MpcUtils.ValidParamString("exitSoundMethod", exitSoundMethod.ToUpper(), false,
                    new List<string>() {"GET", "POST"});
            }
            
            if (startRecordingAudio != null)
            {
                MpcUtils.ValidUrl("startRecordingAudio", startRecordingAudio, false);
            }
            
            if (startRecordingAudioMethod != null)
            {
                MpcUtils.ValidParamString("startRecordingAudioMethod", startRecordingAudioMethod.ToUpper(), false,
                    new List<string>() {"GET", "POST"});
            }
            
            if (stopRecordingAudio != null)
            {
                MpcUtils.ValidUrl("stopRecordingAudio", stopRecordingAudio, false);
            }
            
            if (stopRecordingAudioMethod != null)
            {
                MpcUtils.ValidParamString("stopRecordingAudioMethod", stopRecordingAudioMethod.ToUpper(), false,
                    new List<string>() {"GET", "POST"});
            }
            MpcUtils.ValidUrl("callbackUrl", callbackUrl, true);
            if (callbackMethod != null)
            {
                MpcUtils.ValidParamString("callbackMethod", callbackMethod.ToUpper(), false,
                    new List<string>() {"GET", "POST"});
            }
            string mpcId = MakeMpcId(mpcUuid, friendlyName);
            var mandatoryParams = new List<string> {"role"};
            bool isVoiceRequest = true;
            var data = CreateData(
                mandatoryParams,
                new 
                {
                    role,
                    from,
                    to,
                    callUuid,
                    callerName,
                    callStatusCallbackUrl,
                    callStatusCallbackMethod,
                    sipHeaders,
                    confirmKey,
                    confirmKeySoundUrl,
                    confirmKeySoundMethod,
                    dialMusic,
                    ringTimeout,
                    delayDial,
                    maxDuration,
                    maxParticipants,
                    waitMusicUrl,
                    waitMusicMethod,
                    agentHoldMusicUrl,
                    agentHoldMusicMethod,
                    customerHoldMusicUrl,
                    customerHoldMusicMethod,
                    recordingCallbackUrl,
                    recordingCallbackMethod,
                    statusCallbackUrl,
                    statusCallbackMethod,
                    onExitActionUrl,
                    onExitActionMethod,
                    record,
                    recordFileFormat,
                    statusCallbackEvents,
                    stayAlone,
                    coachMode,
                    mute,
                    hold,
                    startMpcOnEnter,
                    endMpcOnExit,
                    relayDtmfInputs,
                    enterSound,
                    enterSoundMethod,
                    exitSound,
                    exitSoundMethod,
                    startRecordingAudio,
                    startRecordingAudioMethod,
                    stopRecordingAudio,
                    stopRecordingAudioMethod,
                    callbackUrl,
                    callbackMethod,
                    isVoiceRequest
                });
            if (data.ContainsKey("callback_method") && callbackMethod == null) {
                data.Remove("callback_method");
            }
            var result = Task.Run (async () => await Client.Update<AsyncResponse> (Uri + mpcId + "/Participant/", data).ConfigureAwait (false)).Result;
            await Task.WhenAll();
            result.Object.StatusCode = result.StatusCode;
            JObject responseJson = JObject.Parse(result.Content);
            result.Object.ApiId = responseJson["api_id"].ToString();
            result.Object.Message = responseJson["message"].ToString();
            return result.Object;
        }
        
        public UpdateResponse<MultiPartyCall> Start(string mpcUuid = null, string friendlyName = null)
        {
            if (mpcUuid != null)
            {
                MpcUtils.ValidParamString("mpcUuid", mpcUuid, false);
            }
            if (friendlyName != null)
            {
                MpcUtils.ValidParamString("friendlyName", friendlyName, false);
            }

            var status = "active";
            string mpcId = MakeMpcId(mpcUuid, friendlyName);
            var mandatoryParams = new List<string> { "" };
            bool isVoiceRequest = true;
            var data = CreateData (
                mandatoryParams,
                new {
                    status,
                    isVoiceRequest
                });
            return ExecuteWithExceptionUnwrap (() => {
                var result = Task.Run (async () => await Client.Update<UpdateResponse<MultiPartyCall>> (Uri + mpcId + "/", data).ConfigureAwait (false)).Result;
                try
                {
                    result.Object.StatusCode = result.StatusCode;
                }
                catch (System.NullReferenceException) {

                }
                return result.Object;
            });
        }
        
        public async Task<AsyncResponse> StartAsync(string mpcUuid = null, string friendlyName = null,
            string callbackUrl = null, string callbackMethod = null)
        {
            if (mpcUuid != null)
            {
                MpcUtils.ValidParamString("mpcUuid", mpcUuid, false);
            }
            if (friendlyName != null)
            {
                MpcUtils.ValidParamString("friendlyName", friendlyName, false);
            }
            MpcUtils.ValidUrl("callbackUrl", callbackUrl, true);
            if (callbackMethod != null)
            {
                MpcUtils.ValidParamString("callbackMethod", callbackMethod.ToUpper(), false,
                    new List<string>() {"GET", "POST"});
            }
            var status = "active";
            string mpcId = MakeMpcId(mpcUuid, friendlyName);
            var mandatoryParams = new List<string> { "" };
            bool isVoiceRequest = true;
            var data = CreateData (
                mandatoryParams,
                new {
                    status,
                    callbackUrl,
                    callbackMethod,
                    isVoiceRequest
                });
            if (data.ContainsKey("callback_method") && callbackMethod == null) {
                data.Remove("callback_method");
            }
            var result = Task.Run (async () => await Client.Update<AsyncResponse> (Uri + mpcId + "/", data).ConfigureAwait (false)).Result;
            await Task.WhenAll();
            result.Object.StatusCode = result.StatusCode;
            JObject responseJson = JObject.Parse(result.Content);
            result.Object.ApiId = responseJson["api_id"].ToString();
            result.Object.Message = responseJson["message"].ToString();
            return result.Object;
        }
        
        public DeleteResponse<MultiPartyCall> Stop(string mpcUuid = null, string friendlyName = null)
        {
            if (mpcUuid != null)
            {
                MpcUtils.ValidParamString("mpcUuid", mpcUuid, false);
            }
            if (friendlyName != null)
            {
                MpcUtils.ValidParamString("friendlyName", friendlyName, false);
            }
            string mpcId = MakeMpcId(mpcUuid, friendlyName);
            return ExecuteWithExceptionUnwrap(() =>
            {
                return Task.Run(async () => await DeleteResource<DeleteResponse<MultiPartyCall>>(mpcId,new Dictionary<string, object> () { {"is_voice_request", true} }).ConfigureAwait(false)).Result;
            });
        }
        
        public async Task<AsyncResponse> StopAsync(string mpcUuid = null, string friendlyName = null,
            string callbackUrl = null, string callbackMethod = null)
        {
            if (mpcUuid != null)
            {
                MpcUtils.ValidParamString("mpcUuid", mpcUuid, false);
            }
            if (friendlyName != null)
            {
                MpcUtils.ValidParamString("friendlyName", friendlyName, false);
            }
            MpcUtils.ValidUrl("callbackUrl", callbackUrl, true);
            if (callbackMethod != null)
            {
                MpcUtils.ValidParamString("callbackMethod", callbackMethod.ToUpper(), false,
                    new List<string>() {"GET", "POST"});
            }
            string mpcId = MakeMpcId(mpcUuid, friendlyName);
            var data = new Dictionary<string, object>()
            {
                {"callback_url", callbackUrl},
                {"callback_method", callbackMethod},
                {"is_voice_request", true}
            };
            if (data.ContainsKey("callback_method") && callbackMethod == null) {
                data.Remove("callback_method");
            }
            var result = Task.Run(async () => await Client.Delete<AsyncResponse> (Uri + mpcId + "/", data).ConfigureAwait(false)).Result;
            await Task.WhenAll();
            result.Object.StatusCode = result.StatusCode;
            return result.Object;
        }
        
        public RecordCreateResponse<MultiPartyCall> StartRecording (
            string mpcUuid = null, string friendlyName = null,
            string fileFormat = "mp3", 
            string recordingCallbackUrl = null, string recordingCallbackMethod = "POST"
            ) 
        {
            if (mpcUuid != null)
            {
                MpcUtils.ValidParamString("mpcUuid", mpcUuid, false);
            }
            if (friendlyName != null)
            {
                MpcUtils.ValidParamString("friendlyName", friendlyName, false);
            }

            if (fileFormat != null)
            {
                MpcUtils.ValidParamString("fileFormat", fileFormat.ToLower(), false,
                    new List<string>() {"mp3", "wav"});
            }

            if (recordingCallbackUrl != null)
            {
                MpcUtils.ValidUrl("recordingCallbackUrl", recordingCallbackUrl, false);
            }

            if (recordingCallbackMethod != null)
            {
                MpcUtils.ValidParamString("recordingCallbackMethod", recordingCallbackMethod.ToUpper(), false,
                    new List<string>() {"GET", "POST"});
            }
            string mpcId = MakeMpcId(mpcUuid, friendlyName);
            var mandatoryParams = new List<string> { "" };
            bool isVoiceRequest = true;
            var data = CreateData (
                mandatoryParams,
                new {
                    fileFormat,
                    recordingCallbackUrl,
                    recordingCallbackMethod,
                    isVoiceRequest
                });

            return ExecuteWithExceptionUnwrap (() => {
                var result = Task.Run (async () => await Client.Update<RecordCreateResponse<MultiPartyCall>> (Uri + mpcId + "/Record/", data).ConfigureAwait (false)).Result;
                try {
                    result.Object.StatusCode = result.StatusCode;
                    JObject responseJson = JObject.Parse(result.Content);
                    result.Object.ApiId = responseJson["api_id"].ToString();
                    result.Object.RecordingId = responseJson["recording_id"].ToString();
                    result.Object.RecordingUrl = responseJson["recording_url"].ToString();
                    result.Object.Message = responseJson["message"].ToString();
                } catch (System.NullReferenceException) {

                }
                return result.Object;
            });
        }
        
        public async Task<AsyncResponse> StartRecordingAsync (
            string mpcUuid = null, string friendlyName = null,
            string fileFormat = "mp3", 
            string recordingCallbackUrl = null, string recordingCallbackMethod = "POST",
            string callbackUrl = null, string callbackMethod = null
            ) 
        {
            if (mpcUuid != null)
            {
                MpcUtils.ValidParamString("mpcUuid", mpcUuid, false);
            }
            if (friendlyName != null)
            {
                MpcUtils.ValidParamString("friendlyName", friendlyName, false);
            }

            if (fileFormat != null)
            {
                MpcUtils.ValidParamString("fileFormat", fileFormat.ToLower(), false,
                    new List<string>() {"mp3", "wav"});
            }

            if (recordingCallbackUrl != null)
            {
                MpcUtils.ValidUrl("recordingCallbackUrl", recordingCallbackUrl, false);
            }

            if (recordingCallbackMethod != null)
            {
                MpcUtils.ValidParamString("recordingCallbackMethod", recordingCallbackMethod.ToUpper(), false,
                    new List<string>() {"GET", "POST"});
            }
            MpcUtils.ValidUrl("callbackUrl", callbackUrl, true);
            if (callbackMethod != null)
            {
                MpcUtils.ValidParamString("callbackMethod", callbackMethod.ToUpper(), false,
                    new List<string>() {"GET", "POST"});
            }
            string mpcId = MakeMpcId(mpcUuid, friendlyName);
            var mandatoryParams = new List<string> { "" };
            bool isVoiceRequest = true;
            var data = CreateData (
                mandatoryParams,
                new {
                    fileFormat,
                    recordingCallbackUrl,
                    recordingCallbackMethod,
                    callbackUrl,
                    callbackMethod,
                    isVoiceRequest
                });
            if (data.ContainsKey("callback_method") && callbackMethod == null) {
                data.Remove("callback_method");
            }
            var result = Task.Run (async () => await Client.Update<AsyncResponse> (Uri + mpcId + "/Record/", data).ConfigureAwait (false)).Result;
            await Task.WhenAll();
            result.Object.StatusCode = result.StatusCode;
            JObject responseJson = JObject.Parse(result.Content);
            result.Object.ApiId = responseJson["api_id"].ToString();
            result.Object.Message = responseJson["message"].ToString();
            return result.Object;
    }
        
        public DeleteResponse<MultiPartyCall> StopRecording (string mpcUuid = null, string friendlyName = null) {
            if (mpcUuid != null)
            {
                MpcUtils.ValidParamString("mpcUuid", mpcUuid, false);
            }
            if (friendlyName != null)
            {
                MpcUtils.ValidParamString("friendlyName", friendlyName, false);
            }
            string mpcId = MakeMpcId(mpcUuid, friendlyName);
            var mandatoryParams = new List<string> { "" };
            bool isVoiceRequest = true;
            var data = CreateData (
                mandatoryParams, new { isVoiceRequest });

            return ExecuteWithExceptionUnwrap (() => {
                var result = Task.Run (async () => await Client.Delete<DeleteResponse<MultiPartyCall>> (Uri + mpcId + "/Record/", data).ConfigureAwait (false)).Result;
                try {
                    result.Object.StatusCode = result.StatusCode;
                } catch (System.NullReferenceException) {

                }
                return result.Object;
            });
        }
        
        public async Task<AsyncResponse> StopRecordingAsync (string mpcUuid = null, string friendlyName = null,
            string callbackUrl = null, string callbackMethod = null) {
            if (mpcUuid != null)
            {
                MpcUtils.ValidParamString("mpcUuid", mpcUuid, false);
            }
            if (friendlyName != null)
            {
                MpcUtils.ValidParamString("friendlyName", friendlyName, false);
            }
            MpcUtils.ValidUrl("callbackUrl", callbackUrl, true);
            if (callbackMethod != null)
            {
                MpcUtils.ValidParamString("callbackMethod", callbackMethod.ToUpper(), false,
                    new List<string>() {"GET", "POST"});
            }
            string mpcId = MakeMpcId(mpcUuid, friendlyName);
            var mandatoryParams = new List<string> { "" };
            bool isVoiceRequest = true;
            var data = CreateData (
                mandatoryParams, new
                {
                    callbackUrl,
                    callbackMethod,
                    isVoiceRequest
                });

            if (data.ContainsKey("callback_method") && callbackMethod == null) {
                data.Remove("callback_method");
            }
            var result = Task.Run (async () => await Client.Delete<AsyncResponse> (Uri + mpcId + "/Record/", data).ConfigureAwait (false)).Result;
            await Task.WhenAll();
            result.Object.StatusCode = result.StatusCode;
            return result.Object;
        }
        
        public UpdateResponse<MultiPartyCall> PauseRecording (
            string mpcUuid = null, string friendlyName = null) 
        {
            if (mpcUuid != null)
            {
                MpcUtils.ValidParamString("mpcUuid", mpcUuid, false);
            }
            if (friendlyName != null)
            {
                MpcUtils.ValidParamString("friendlyName", friendlyName, false);
            }
            string mpcId = MakeMpcId(mpcUuid, friendlyName);
            var mandatoryParams = new List<string> { "" };
            bool isVoiceRequest = true;
            var data = CreateData (
                mandatoryParams,
                new {
                    isVoiceRequest
                });

            return ExecuteWithExceptionUnwrap (() => {
                var result = Task.Run (async () => await Client.Update<UpdateResponse<MultiPartyCall>> (Uri + mpcId + "/Record/Pause/", data).ConfigureAwait (false)).Result;
                try {
                    result.Object.StatusCode = result.StatusCode;
                } catch (System.NullReferenceException) {

                }
                return result.Object;
            });
        }
        
        public async Task<AsyncResponse> PauseRecordingAsync (
            string mpcUuid = null, string friendlyName = null, 
            string callbackUrl = null, string callbackMethod = null) 
        {
            if (mpcUuid != null)
            {
                MpcUtils.ValidParamString("mpcUuid", mpcUuid, false);
            }
            if (friendlyName != null)
            {
                MpcUtils.ValidParamString("friendlyName", friendlyName, false);
            }
            MpcUtils.ValidUrl("callbackUrl", callbackUrl, true);
            if (callbackMethod != null)
            {
                MpcUtils.ValidParamString("callbackMethod", callbackMethod.ToUpper(), false,
                    new List<string>() {"GET", "POST"});
            }
            string mpcId = MakeMpcId(mpcUuid, friendlyName);
            var mandatoryParams = new List<string> { "" };
            bool isVoiceRequest = true;
            var data = CreateData (
                mandatoryParams,
                new {
                    callbackUrl,
                    callbackMethod,
                    isVoiceRequest
                });

            if (data.ContainsKey("callback_method") && callbackMethod == null) {
                data.Remove("callback_method");
            }
            var result = Task.Run (async () => await Client.Update<AsyncResponse> (Uri + mpcId + "/Record/Pause/", data).ConfigureAwait (false)).Result;
            await Task.WhenAll();
            result.Object.StatusCode = result.StatusCode;
            JObject responseJson = JObject.Parse(result.Content);
            result.Object.ApiId = responseJson["api_id"].ToString();
            result.Object.Message = responseJson["message"].ToString();
            return result.Object;
        }
        
        public UpdateResponse<MultiPartyCall> ResumeRecording (
            string mpcUuid = null, string friendlyName = null) 
        {
            if (mpcUuid != null)
            {
                MpcUtils.ValidParamString("mpcUuid", mpcUuid, false);
            }
            if (friendlyName != null)
            {
                MpcUtils.ValidParamString("friendlyName", friendlyName, false);
            }
            string mpcId = MakeMpcId(mpcUuid, friendlyName);
            var mandatoryParams = new List<string> { "" };
            bool isVoiceRequest = true;
            var data = CreateData (
                mandatoryParams,
                new {
                    isVoiceRequest
                });

            return ExecuteWithExceptionUnwrap (() => {
                var result = Task.Run (async () => await Client.Update<UpdateResponse<MultiPartyCall>> (Uri + mpcId + "/Record/Resume/", data).ConfigureAwait (false)).Result;
                try {
                    result.Object.StatusCode = result.StatusCode;
                } catch (System.NullReferenceException) {

                }
                return result.Object;
            });
        }
        
        public async Task<AsyncResponse> ResumeRecordingAsync (
            string mpcUuid = null, string friendlyName = null, 
            string callbackUrl = null, string callbackMethod = null) 
        {
            if (mpcUuid != null)
            {
                MpcUtils.ValidParamString("mpcUuid", mpcUuid, false);
            }
            if (friendlyName != null)
            {
                MpcUtils.ValidParamString("friendlyName", friendlyName, false);
            }
            MpcUtils.ValidUrl("callbackUrl", callbackUrl, true);
            if (callbackMethod != null)
            {
                MpcUtils.ValidParamString("callbackMethod", callbackMethod.ToUpper(), false,
                    new List<string>() {"GET", "POST"});
            }
            string mpcId = MakeMpcId(mpcUuid, friendlyName);
            var mandatoryParams = new List<string> { "" };
            bool isVoiceRequest = true;
            var data = CreateData (
                mandatoryParams,
                new {
                    callbackUrl,
                    callbackMethod,
                    isVoiceRequest
                });

            if (data.ContainsKey("callback_method") && callbackMethod == null) {
                data.Remove("callback_method");
            }
            var result = Task.Run (async () => await Client.Update<AsyncResponse> (Uri + mpcId + "/Record/Resume/", data).ConfigureAwait (false)).Result;
            await Task.WhenAll();
            result.Object.StatusCode = result.StatusCode;
            JObject responseJson = JObject.Parse(result.Content);
            result.Object.ApiId = responseJson["api_id"].ToString();
            result.Object.Message = responseJson["message"].ToString();
            return result.Object;
        }

        public RecordCreateResponse<MultiPartyCallParticipant> StartParticipantRecording (
            string participantId = null,
            string mpcUuid = null, string friendlyName = null,
            string fileFormat = "mp3", 
            string recordingCallbackUrl = null, string recordingCallbackMethod = "POST"
            ) 
        {
            if (mpcUuid != null)
            {
                MpcUtils.ValidParamString("mpcUuid", mpcUuid, false);
            }
            if (friendlyName != null)
            {
                MpcUtils.ValidParamString("friendlyName", friendlyName, false);
            }

            if (fileFormat != null)
            {
                MpcUtils.ValidParamString("fileFormat", fileFormat.ToLower(), false,
                    new List<string>() {"mp3", "wav"});
            }

            if (recordingCallbackUrl != null)
            {
                MpcUtils.ValidUrl("recordingCallbackUrl", recordingCallbackUrl, false);
            }

            if (recordingCallbackMethod != null)
            {
                MpcUtils.ValidParamString("recordingCallbackMethod", recordingCallbackMethod.ToUpper(), false,
                    new List<string>() {"GET", "POST"});
            }
            MpcUtils.ValidParamString("participantId", participantId, true);
            string mpcId = MakeMpcId(mpcUuid, friendlyName);
            var mandatoryParams = new List<string> { "" };
            bool isVoiceRequest = true;
            var data = CreateData (
                mandatoryParams,
                new {
                    fileFormat,
                    recordingCallbackUrl,
                    recordingCallbackMethod,
                    isVoiceRequest
                });

            return ExecuteWithExceptionUnwrap (() => {
                return Task.Run(async () =>
                    await UpdateSecondaryResource<RecordCreateResponse<MultiPartyCallParticipant>>(mpcId,
                        data,
                        "Participant", participantId + "/Record").ConfigureAwait(false)).Result;
            });
        }
        
        public async Task<AsyncResponse> StartParticipantRecordingAsync (
            string participantId = null,
            string mpcUuid = null, string friendlyName = null,
            string fileFormat = "mp3", 
            string recordingCallbackUrl = null, string recordingCallbackMethod = "POST",
            string callbackUrl = null, string callbackMethod = null) 
        {
            if (mpcUuid != null)
            {
                MpcUtils.ValidParamString("mpcUuid", mpcUuid, false);
            }
            if (friendlyName != null)
            {
                MpcUtils.ValidParamString("friendlyName", friendlyName, false);
            }

            if (fileFormat != null)
            {
                MpcUtils.ValidParamString("fileFormat", fileFormat.ToLower(), false,
                    new List<string>() {"mp3", "wav"});
            }

            if (recordingCallbackUrl != null)
            {
                MpcUtils.ValidUrl("recordingCallbackUrl", recordingCallbackUrl, false);
            }

            if (recordingCallbackMethod != null)
            {
                MpcUtils.ValidParamString("recordingCallbackMethod", recordingCallbackMethod.ToUpper(), false,
                    new List<string>() {"GET", "POST"});
            }
            MpcUtils.ValidParamString("participantId", participantId, true);
            MpcUtils.ValidUrl("callbackUrl", callbackUrl, true);
            if (callbackMethod != null)
            {
                MpcUtils.ValidParamString("callbackMethod", callbackMethod.ToUpper(), false,
                    new List<string>() {"GET", "POST"});
            }
            string mpcId = MakeMpcId(mpcUuid, friendlyName);
            var mandatoryParams = new List<string> { "" };
            bool isVoiceRequest = true;
            var data = CreateData (
                mandatoryParams,
                new {
                    fileFormat,
                    recordingCallbackUrl,
                    recordingCallbackMethod,
                    callbackUrl,
                    callbackMethod,
                    isVoiceRequest
                });
            if (data.ContainsKey("callback_method") && callbackMethod == null) {
                data.Remove("callback_method");
            }
            var result = Task.Run (async () => await Client.Update<AsyncResponse> (Uri + mpcId + "/Participant/"
                    + participantId + "/Record/", data).ConfigureAwait (false)).Result;
                await Task.WhenAll();
                result.Object.StatusCode = result.StatusCode;
                JObject responseJson = JObject.Parse(result.Content);
                result.Object.ApiId = responseJson["api_id"].ToString();
                result.Object.Message = responseJson["message"].ToString();
                return result.Object;
        }
        
        public DeleteResponse<MultiPartyCallParticipant> StopParticipantRecording (string participantId = null, string mpcUuid = null, string friendlyName = null) {
            if (mpcUuid != null)
            {
                MpcUtils.ValidParamString("mpcUuid", mpcUuid, false);
            }
            if (friendlyName != null)
            {
                MpcUtils.ValidParamString("friendlyName", friendlyName, false);
            }
            MpcUtils.ValidParamString("participantId", participantId, true);
            string mpcId = MakeMpcId(mpcUuid, friendlyName);
            var mandatoryParams = new List<string> { "" };
            bool isVoiceRequest = true;
            var data = CreateData (
                mandatoryParams, new { isVoiceRequest });

            return ExecuteWithExceptionUnwrap (() => {
                return Task.Run(async () => await DeleteSecondaryResource<DeleteResponse<MultiPartyCallParticipant>>(mpcId,
                    data, 
                    "Participant", participantId+"/Record").ConfigureAwait(false)).Result;
            });
        }
        
        public async Task<AsyncResponse> StopParticipantRecordingAsync (string participantId = null, 
            string mpcUuid = null, string friendlyName = null,
            string callbackUrl = null, string callbackMethod = null) {
            if (mpcUuid != null)
            {
                MpcUtils.ValidParamString("mpcUuid", mpcUuid, false);
            }
            if (friendlyName != null)
            {
                MpcUtils.ValidParamString("friendlyName", friendlyName, false);
            }
            MpcUtils.ValidParamString("participantId", participantId, true);
            MpcUtils.ValidUrl("callbackUrl", callbackUrl, true);
            if (callbackMethod != null)
            {
                MpcUtils.ValidParamString("callbackMethod", callbackMethod.ToUpper(), false,
                    new List<string>() {"GET", "POST"});
            }
            string mpcId = MakeMpcId(mpcUuid, friendlyName);
            var mandatoryParams = new List<string> { "" };
            bool isVoiceRequest = true;
            var data = CreateData (
                mandatoryParams, new
                {
                    callbackUrl,
                    callbackMethod,
                    isVoiceRequest
                });
            if (data.ContainsKey("callback_method") && callbackMethod == null) {
                data.Remove("callback_method");
            }
            var result = Task.Run (async () => await Client.Delete<AsyncResponse> (Uri + mpcId + "/Participant/"
                    + participantId + "/Record/", data).ConfigureAwait (false)).Result;
            await Task.WhenAll();
            result.Object.StatusCode = result.StatusCode;
            return result.Object;
        }
        
        public UpdateResponse<MultiPartyCallParticipant> PauseParticipantRecording (
            string participantId = null, string mpcUuid = null, string friendlyName = null) 
        {
            if (mpcUuid != null)
            {
                MpcUtils.ValidParamString("mpcUuid", mpcUuid, false);
            }
            if (friendlyName != null)
            {
                MpcUtils.ValidParamString("friendlyName", friendlyName, false);
            }
            MpcUtils.ValidParamString("participantId", participantId, true);
            string mpcId = MakeMpcId(mpcUuid, friendlyName);
            var mandatoryParams = new List<string> { "" };
            bool isVoiceRequest = true;
            var data = CreateData (
                mandatoryParams,
                new {
                    isVoiceRequest
                });

            return ExecuteWithExceptionUnwrap (() => {
                return Task.Run(async () =>
                    await UpdateSecondaryResource<UpdateResponse<MultiPartyCallParticipant>>(mpcId,
                        data,
                        "Participant", participantId + "/Record/Pause").ConfigureAwait(false)).Result;
            });
        }

        public async Task<AsyncResponse> PauseParticipantRecordingAsync (
            string participantId = null, string mpcUuid = null, string friendlyName = null,
            string callbackUrl = null, string callbackMethod = null) 
        {
            if (mpcUuid != null)
            {
                MpcUtils.ValidParamString("mpcUuid", mpcUuid, false);
            }
            if (friendlyName != null)
            {
                MpcUtils.ValidParamString("friendlyName", friendlyName, false);
            }
            MpcUtils.ValidParamString("participantId", participantId, true);
            MpcUtils.ValidUrl("callbackUrl", callbackUrl, true);
            if (callbackMethod != null)
            {
                MpcUtils.ValidParamString("callbackMethod", callbackMethod.ToUpper(), false,
                    new List<string>() {"GET", "POST"});
            }
            string mpcId = MakeMpcId(mpcUuid, friendlyName);
            var mandatoryParams = new List<string> { "" };
            bool isVoiceRequest = true;
            var data = CreateData (
                mandatoryParams,
                new {
                    callbackUrl,
                    callbackMethod,
                    isVoiceRequest
                });

            if (data.ContainsKey("callback_method") && callbackMethod == null) {
                data.Remove("callback_method");
            }
            var result = Task.Run (async () => await Client.Update<AsyncResponse> (Uri + mpcId + "/Participant/"
                + participantId + "/Record/Pause/", data).ConfigureAwait (false)).Result;
            await Task.WhenAll();
            result.Object.StatusCode = result.StatusCode;
            JObject responseJson = JObject.Parse(result.Content);
            result.Object.ApiId = responseJson["api_id"].ToString();
            result.Object.Message = responseJson["message"].ToString();
            return result.Object;
        }

        public UpdateResponse<MultiPartyCallParticipant> ResumeParticipantRecording (
            string participantId = null, string mpcUuid = null, string friendlyName = null) 
        {
            if (mpcUuid != null)
            {
                MpcUtils.ValidParamString("mpcUuid", mpcUuid, false);
            }
            if (friendlyName != null)
            {
                MpcUtils.ValidParamString("friendlyName", friendlyName, false);
            }
            MpcUtils.ValidParamString("participantId", participantId, true);
            string mpcId = MakeMpcId(mpcUuid, friendlyName);
            var mandatoryParams = new List<string> { "" };
            bool isVoiceRequest = true;
            var data = CreateData (
                mandatoryParams,
                new {
                    isVoiceRequest
                });

            return ExecuteWithExceptionUnwrap (() => {
                 return Task.Run(async () =>
                    await UpdateSecondaryResource<UpdateResponse<MultiPartyCallParticipant>>(mpcId,
                        data,
                        "Participant", participantId + "/Record/Resume").ConfigureAwait(false)).Result;
            });
        }
        
        public async Task<AsyncResponse> ResumeParticipantRecordingAsync (
            string participantId = null, string mpcUuid = null, string friendlyName = null,
            string callbackUrl = null, string callbackMethod = null) 
        {
            if (mpcUuid != null)
            {
                MpcUtils.ValidParamString("mpcUuid", mpcUuid, false);
            }
            if (friendlyName != null)
            {
                MpcUtils.ValidParamString("friendlyName", friendlyName, false);
            }
            MpcUtils.ValidParamString("participantId", participantId, true);
            MpcUtils.ValidUrl("callbackUrl", callbackUrl, true);
            if (callbackMethod != null)
            {
                MpcUtils.ValidParamString("callbackMethod", callbackMethod.ToUpper(), false,
                    new List<string>() {"GET", "POST"});
            }
            string mpcId = MakeMpcId(mpcUuid, friendlyName);
            var mandatoryParams = new List<string> { "" };
            bool isVoiceRequest = true;
            var data = CreateData (
                mandatoryParams,
                new {
                    callbackUrl,
                    callbackMethod,
                    isVoiceRequest
                });

            if (data.ContainsKey("callback_method") && callbackMethod == null) {
                data.Remove("callback_method");
            }
            var result = Task.Run (async () => await Client.Update<AsyncResponse> (Uri + mpcId + "/Participant/"
                + participantId + "/Record/Resume/", data).ConfigureAwait (false)).Result;
            await Task.WhenAll();
            result.Object.StatusCode = result.StatusCode;
            JObject responseJson = JObject.Parse(result.Content);
            result.Object.ApiId = responseJson["api_id"].ToString();
            result.Object.Message = responseJson["message"].ToString();
            return result.Object;
        }

        public ListResponse<MultiPartyCallParticipant> ListParticipants(
            string mpcUuid = null, string friendlyName = null,
            string callUuid = null)
        {
            if (mpcUuid != null)
            {
                MpcUtils.ValidParamString("mpcUuid", mpcUuid, false);
            }
            if (friendlyName != null)
            {
                MpcUtils.ValidParamString("friendlyName", friendlyName, false);
            }

            if (callUuid != null)
            {
                MpcUtils.ValidParamString("callUuid", callUuid, false);
            }
            string mpcId = MakeMpcId(mpcUuid, friendlyName);
            var mandatoryParams = new List<string> { "" };
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
                var resources = Task.Run (async () => await ListResources<ListResponse<MultiPartyCallParticipant>>(mpcId + "/Participant" , data).ConfigureAwait(false)).Result;
                resources.Objects.ForEach (
                    (obj) => obj.Interface = this
                );

                return resources;
            });
        }
        
        public async Task<AsyncResponse> ListParticipantsAsync(
            string mpcUuid = null, string friendlyName = null,
            string callUuid = null, string callbackUrl = null, string callbackMethod = null)
        {
            if (mpcUuid != null)
            {
                MpcUtils.ValidParamString("mpcUuid", mpcUuid, false);
            }
            if (friendlyName != null)
            {
                MpcUtils.ValidParamString("friendlyName", friendlyName, false);
            }

            if (callUuid != null)
            {
                MpcUtils.ValidParamString("callUuid", callUuid, false);
            }
            MpcUtils.ValidUrl("callbackUrl", callbackUrl, true);
            if (callbackMethod != null)
            {
                MpcUtils.ValidParamString("callbackMethod", callbackMethod.ToUpper(), false,
                    new List<string>() {"GET", "POST"});
            }
            string mpcId = MakeMpcId(mpcUuid, friendlyName);
            var mandatoryParams = new List<string> { "" };
            bool isVoiceRequest = true;
            var data = CreateData(
                mandatoryParams,
                new 
                {
                    callUuid,
                    callbackUrl,
                    callbackMethod,
                    isVoiceRequest
                });
            if (data.ContainsKey("callback_method") && callbackMethod == null) {
                data.Remove("callback_method");
            }
            var result = Task.Run (async () => await Client.Fetch<AsyncResponse> (Uri + mpcId + "/Participant/", data).ConfigureAwait(false)).Result;
            await Task.WhenAll();
            result.Object.StatusCode = result.StatusCode;
            JObject responseJson = JObject.Parse(result.Content);
            result.Object.ApiId = responseJson["api_id"].ToString();
            result.Object.Message = responseJson["message"].ToString();
            return result.Object;
        }

        public MultiPartyCallParticipantUpdateResponse<MultiPartyCallParticipant> UpdateParticipant(string participantId = null, string mpcUuid = null, 
            string friendlyName = null,
            bool? coachMode = null, bool? mute = null, bool? hold = null)
        {
            if (mpcUuid != null)
            {
                MpcUtils.ValidParamString("mpcUuid", mpcUuid, false);
            }
            if (friendlyName != null)
            {
                MpcUtils.ValidParamString("friendlyName", friendlyName, false);
            }

            MpcUtils.ValidParamString("participantId", participantId, true);
            string mpcId = MakeMpcId(mpcUuid, friendlyName);
            var mandatoryParams = new List<string> { "" };
            bool isVoiceRequest = true;
            var data = CreateData (
                mandatoryParams,
                new {
                    coachMode,
                    mute,
                    hold,
                    isVoiceRequest
                });
            return ExecuteWithExceptionUnwrap(() =>
            {
                var result = Task.Run(async () =>
                    await UpdateSecondaryResource<MultiPartyCallParticipantUpdateResponse<MultiPartyCallParticipant>>(mpcId,
                        data,
                        "Participant", participantId).ConfigureAwait(false)).Result;
                return result;
            });
        }
        
        public async Task<AsyncResponse> UpdateParticipantAsync(
            string participantId = null, string mpcUuid = null, 
            string friendlyName = null,
            bool? coachMode = null, bool? mute = null, bool? hold = null,
            string callbackUrl = null, string callbackMethod = null)
        {
            if (mpcUuid != null)
            {
                MpcUtils.ValidParamString("mpcUuid", mpcUuid, false);
            }
            if (friendlyName != null)
            {
                MpcUtils.ValidParamString("friendlyName", friendlyName, false);
            }

            MpcUtils.ValidParamString("participantId", participantId, true);
            MpcUtils.ValidUrl("callbackUrl", callbackUrl, true);
            if (callbackMethod != null)
            {
                MpcUtils.ValidParamString("callbackMethod", callbackMethod.ToUpper(), false,
                    new List<string>() {"GET", "POST"});
            }
            string mpcId = MakeMpcId(mpcUuid, friendlyName);
            var mandatoryParams = new List<string> { "" };
            bool isVoiceRequest = true;
            var data = CreateData (
                mandatoryParams,
                new {
                    coachMode,
                    mute,
                    hold,
                    callbackUrl,
                    callbackMethod,
                    isVoiceRequest
                });
            if (data.ContainsKey("callback_method") && callbackMethod == null) {
                data.Remove("callback_method");
            }
            var result = Task.Run (async () => await Client.Update<AsyncResponse> (
                Uri + mpcId + "/Participant/" + participantId + "/", data).ConfigureAwait(false)).Result;
            await Task.WhenAll();
            result.Object.StatusCode = result.StatusCode;
            JObject responseJson = JObject.Parse(result.Content);
            result.Object.ApiId = responseJson["api_id"].ToString();
            result.Object.Message = responseJson["message"].ToString();
            return result.Object;
        }

        public MultiPartyCallParticipant GetParticipant(string participantId = null, string mpcUuid = null, string friendlyName = null)
        {
            if (mpcUuid != null)
            {
                MpcUtils.ValidParamString("mpcUuid", mpcUuid, false);
            }
            if (friendlyName != null)
            {
                MpcUtils.ValidParamString("friendlyName", friendlyName, false);
            }

            MpcUtils.ValidParamString("participantId", participantId, true); 
            string mpcId = MakeMpcId(mpcUuid, friendlyName);
            return ExecuteWithExceptionUnwrap(() =>
            {
                var mpcParticipant = Task.Run(async () =>
                    await GetSecondaryResource<MultiPartyCallParticipant>(mpcId,
                        new Dictionary<string, object>() {{"is_voice_request", true}},
                        "Participant", participantId).ConfigureAwait(false)).Result;
                mpcParticipant.Interface = this;
                return mpcParticipant;
            });
        }
        
        public async Task<AsyncResponse> GetParticipantAsync(
            string participantId = null, string mpcUuid = null, string friendlyName = null,
            string callbackUrl = null, string callbackMethod = null)
        {
            if (mpcUuid != null)
            {
                MpcUtils.ValidParamString("mpcUuid", mpcUuid, false);
            }
            if (friendlyName != null)
            {
                MpcUtils.ValidParamString("friendlyName", friendlyName, false);
            }

            MpcUtils.ValidParamString("participantId", participantId, true); 
            MpcUtils.ValidUrl("callbackUrl", callbackUrl, true);
            if (callbackMethod != null)
            {
                MpcUtils.ValidParamString("callbackMethod", callbackMethod.ToUpper(), false,
                    new List<string>() {"GET", "POST"});
            }
            string mpcId = MakeMpcId(mpcUuid, friendlyName);
            var data = new Dictionary<string, object>()
            {
                {"is_voice_request", true},
                {"callback_url", callbackUrl},
                {"callback_method", callbackMethod}
            };
            if (data.ContainsKey("callback_method") && callbackMethod == null) {
                data.Remove("callback_method");
            }
            var result = Task.Run (async () => await Client.Fetch<AsyncResponse> (
                Uri + mpcId + "/Participant/" + participantId + "/", data).ConfigureAwait(false)).Result;
            await Task.WhenAll();
            result.Object.StatusCode = result.StatusCode;
            JObject responseJson = JObject.Parse(result.Content);
            result.Object.ApiId = responseJson["api_id"].ToString();
            result.Object.Message = responseJson["message"].ToString();
            return result.Object;
        }
        
        public DeleteResponse<MultiPartyCallParticipant> KickParticipant(string participantId = null, string mpcUuid = null, string friendlyName = null)
        {
            if (mpcUuid != null)
            {
                MpcUtils.ValidParamString("mpcUuid", mpcUuid, false);
            }
            if (friendlyName != null)
            {
                MpcUtils.ValidParamString("friendlyName", friendlyName, false);
            }

            MpcUtils.ValidParamString("participantId", participantId, true);
            string mpcId = MakeMpcId(mpcUuid, friendlyName);
            return ExecuteWithExceptionUnwrap(() =>
            {
                return Task.Run(async () => await DeleteSecondaryResource<DeleteResponse<MultiPartyCallParticipant>>(mpcId,
                    new Dictionary<string, object> () { {"is_voice_request", true} }, 
                    "Participant", participantId).ConfigureAwait(false)).Result;
            });
        }
        
        public async Task<AsyncResponse> KickParticipantAsync(
            string participantId = null, string mpcUuid = null, string friendlyName = null,
            string callbackUrl = null, string callbackMethod = null)
        {
            if (mpcUuid != null)
            {
                MpcUtils.ValidParamString("mpcUuid", mpcUuid, false);
            }
            if (friendlyName != null)
            {
                MpcUtils.ValidParamString("friendlyName", friendlyName, false);
            }

            MpcUtils.ValidParamString("participantId", participantId, true);
            MpcUtils.ValidUrl("callbackUrl", callbackUrl, true);
            if (callbackMethod != null)
            {
                MpcUtils.ValidParamString("callbackMethod", callbackMethod.ToUpper(), false,
                    new List<string>() {"GET", "POST"});
            }
            string mpcId = MakeMpcId(mpcUuid, friendlyName);
            var data = new Dictionary<string, object>()
            {
                {"callback_url", callbackUrl},
                {"callback_method", callbackMethod},
                {"is_voice_request", true}
            };
            if (data.ContainsKey("callback_method") && callbackMethod == null) {
                data.Remove("callback_method");
            }
            var result = Task.Run (async () => await Client.Delete<AsyncResponse> (
                Uri + mpcId + "/Participant/" + participantId + "/", data).ConfigureAwait(false)).Result;
            await Task.WhenAll();
            result.Object.StatusCode = result.StatusCode;
            return result.Object;
        }

        public MultiPartyCallParticipantPlayResponse<MultiPartyCallParticipant> StartPlayAudio(string participantId = null, string mpcUuid = null, 
            string friendlyName = null, string url = null)
        {
            if (mpcUuid != null)
            {
                MpcUtils.ValidParamString("mpcUuid", mpcUuid, false);
            }
            if (friendlyName != null)
            {
                MpcUtils.ValidParamString("friendlyName", friendlyName, false);
            }
            MpcUtils.ValidUrl("url", url, true);
            MpcUtils.ValidParamString("participantId", participantId, true);
            string mpcId = MakeMpcId(mpcUuid, friendlyName);
            var mandatoryParams = new List<string> {"url"};
            bool isVoiceRequest = true;
            var data = CreateData(
                mandatoryParams,
                new 
                {
                    url,
                    isVoiceRequest
                });

            return ExecuteWithExceptionUnwrap(() =>
            {
                var result = Task.Run (async () => 
                    await Client.Update<MultiPartyCallParticipantPlayResponse<MultiPartyCallParticipant>> (Uri + mpcId + "/Member/" + participantId + "/Play/", data).ConfigureAwait (false)).Result;
                try {
                    result.Object.StatusCode = result.StatusCode;
                    JObject responseJson = JObject.Parse(result.Content);
                    Console.WriteLine(responseJson);
                    result.Object.ApiId = responseJson["api_id"].ToString();
                    result.Object.MpcMemberId = responseJson["mpcMemberId"].ToObject<List<string>>();
                    result.Object.MpcName = responseJson["mpcName"].ToString();
                    result.Object.Message = responseJson["message"].ToString();
                } catch (System.NullReferenceException) {
                }
                return result.Object;
            });
        }
        
        public async Task<AsyncResponse> StartPlayAudioAsync(
            string participantId = null, string mpcUuid = null, 
            string friendlyName = null, string url = null,
            string callbackUrl = null, string callbackMethod = null
            )
        {
            if (mpcUuid != null)
            {
                MpcUtils.ValidParamString("mpcUuid", mpcUuid, false);
            }
            if (friendlyName != null)
            {
                MpcUtils.ValidParamString("friendlyName", friendlyName, false);
            }
            MpcUtils.ValidUrl("url", url, true);
            if (callbackMethod != null)
            {
                MpcUtils.ValidParamString("callbackMethod", callbackMethod.ToUpper(), false,
                    new List<string>() {"GET", "POST"});
            }
            MpcUtils.ValidParamString("participantId", participantId, true);
            MpcUtils.ValidUrl("callbackUrl", callbackUrl, true);
            if (callbackMethod != null)
            {
                MpcUtils.ValidParamString("callbackMethod", callbackMethod.ToUpper(), false,
                    new List<string>() {"GET", "POST"});
            }
            string mpcId = MakeMpcId(mpcUuid, friendlyName);
            var mandatoryParams = new List<string> {"url"};
            bool isVoiceRequest = true;
            var data = CreateData(
                mandatoryParams,
                new 
                {
                    url,
                    callbackUrl,
                    callbackMethod,
                    isVoiceRequest
                });
            
            if (data.ContainsKey("callback_method") && callbackMethod == null) {
                data.Remove("callback_method");
            }
            var result = Task.Run (async () => 
                    await Client.Update<AsyncResponse> (Uri + mpcId + "/Member/" + participantId + "/Play/", data).ConfigureAwait (false)).Result;
                await Task.WhenAll();
                result.Object.StatusCode = result.StatusCode;
                JObject responseJson = JObject.Parse(result.Content);
                result.Object.ApiId = responseJson["api_id"].ToString();
                result.Object.Message = responseJson["message"].ToString();
                return result.Object;
        }
        
        public DeleteResponse<MultiPartyCallParticipant> StopPlayAudio(string participantId = null, string mpcUuid = null, 
            string friendlyName = null)
        {
            if (mpcUuid != null)
            {
                MpcUtils.ValidParamString("mpcUuid", mpcUuid, false);
            }
            if (friendlyName != null)
            {
                MpcUtils.ValidParamString("friendlyName", friendlyName, false);
            }
            MpcUtils.ValidParamString("participantId", participantId, true);
            string mpcId = MakeMpcId(mpcUuid, friendlyName);
            var mandatoryParams = new List<string> { "" };
            bool isVoiceRequest = true;
            var data = CreateData (
                mandatoryParams, new { isVoiceRequest });

            return ExecuteWithExceptionUnwrap (() => {
                var result = Task.Run (async () => 
                    await Client.Delete<DeleteResponse<MultiPartyCallParticipant>> (Uri + mpcId + "/Member/" + participantId + "/Play/", data).ConfigureAwait (false)).Result;
                try {
                    result.Object.StatusCode = result.StatusCode;
                } catch (System.NullReferenceException) {
                }
                return result.Object;
            });
        }
        
        public async Task<AsyncResponse> StopPlayAudioAsync(
            string participantId = null, string mpcUuid = null, 
            string friendlyName = null, string callbackUrl = null, string callbackMethod = null)
        {
            if (mpcUuid != null)
            {
                MpcUtils.ValidParamString("mpcUuid", mpcUuid, false);
            }
            if (friendlyName != null)
            {
                MpcUtils.ValidParamString("friendlyName", friendlyName, false);
            }
            MpcUtils.ValidParamString("participantId", participantId, true);
            MpcUtils.ValidUrl("callbackUrl", callbackUrl, true);
            if (callbackMethod != null)
            {
                MpcUtils.ValidParamString("callbackMethod", callbackMethod.ToUpper(), false,
                    new List<string>() {"GET", "POST"});
            }
            string mpcId = MakeMpcId(mpcUuid, friendlyName);
            var mandatoryParams = new List<string> { "" };
            bool isVoiceRequest = true;
            var data = CreateData (
                mandatoryParams, new
                {
                    callbackUrl,
                    callbackMethod,
                    isVoiceRequest
                });

            if (data.ContainsKey("callback_method") && callbackMethod == null) {
                data.Remove("callback_method");
            }
            var result = Task.Run (async () => 
                    await Client.Delete<AsyncResponse> (Uri + mpcId + "/Member/" + participantId + "/Play/", data).ConfigureAwait (false)).Result;
                await Task.WhenAll();
                result.Object.StatusCode = result.StatusCode;
                return result.Object;
        }
    }
}