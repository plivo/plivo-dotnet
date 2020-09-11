using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Plivo.Client;
using Plivo.Exception;
using Plivo.Http;


namespace Plivo.Resource.MultiPartyCall
{
    /// <summary>
    /// MPC interface.
    /// </summary>
    public class MultiPartyCallInterface : ResourceInterface
    {
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
                throw new PlivoValidationException("Provide either mpc_uuid or friendly_name");
            }

            return mpcId;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:plivo.Resource.Application.MultiPartyCallInterface"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        public MultiPartyCallInterface(HttpClient client) : base(client)
        {
            Uri = "Account/" + Client.GetAuthId() + "/MultiPartyCall/";
        }

        public MultiPartyCall Get(string mpcUuid = null, string friendlyName = null)
        {
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

        public ListResponse<MultiPartyCall> List(
            string subAccount = null,
            string friendlyName = null,
            string status = null,
            string terminationCauseCode = null,
            string endTimeGt = null,
            string endTimeGte = null,
            string endTimeLt = null,
            string endTimeLte = null,
            string endTime = null,
            string creationTimeGt = null,
            string creationTimeGte = null,
            string creationTimeLt = null,
            string creationTimeLte = null,
            string creationTime = null,
            uint? limit = null,
            uint? offset = null)
        {
            string mpcId = MakeMpcId("", friendlyName);
            var givenParams = new List<string> { };
            bool isVoiceRequest = true;
            var data = CreateData(
                givenParams,
                new
                {
                    mpcId, subAccount, status, terminationCauseCode, endTime, endTimeGt, endTimeGte, endTimeLt,
                    endTimeLte,
                    creationTime, creationTimeGt, creationTimeGte, creationTimeLt, creationTimeLte, limit, offset,
                    isVoiceRequest
                });
            return ExecuteWithExceptionUnwrap(() =>
            {
                var resources = Task.Run(async () =>
                    await ListResources<ListResponse<MultiPartyCall>>(data).ConfigureAwait(false)).Result;
                resources.Objects.ForEach(
                    (obj) => obj.Interface = this
                );

                return resources;
            });
        }

        public MultiPartyCallAddParticipantResponse AddParticipant(
            string role = null,
            string friendlyName = null,
            string mpcUuid = null,
            string from = null,
            string to = null,
            string callUuid = null,
            string callStatusCallbackUrl = null,
            string callStatusCallbackMethod = "POST",
            string sipHeaders = null,
            string confirmKey = null,
            string confirmKeySoundUrl = null,
            string confirmKeySoundMethod = "GET",
            string dialMusic = null,
            int ringTimeout = 45,
            int maxDuration = 14400,
            int maxParticipants = 10,
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
            string exitSoundMethod = "GET")
        {
            if ((from != null || to != null) && callUuid != null) {
                throw new PlivoValidationException("cannot specify call_uuid when (from, to) is provided");
            }
            if (from == null && to == null && callUuid == null) {
                throw new PlivoValidationException("specify either call_uuid or (from, to)");
            }
            if (callUuid == null && (from == null || to == null)) {
                throw new PlivoValidationException("specify (from, to) when not adding an existing call_uuid to multi party participant");
            }
            string mpcId = MakeMpcId(mpcUuid, friendlyName);
            var givenParams = new List<string> { };
            bool isVoiceRequest = true;
            var data = CreateData(
                givenParams,
                new
                {
                    role,
                    friendlyName,
                    mpcUuid,
                    from,
                    to,
                    callUuid,
                    callStatusCallbackUrl,
                    callStatusCallbackMethod,
                    sipHeaders,
                    confirmKey,
                    confirmKeySoundUrl,
                    confirmKeySoundMethod,
                    dialMusic,
                    ringTimeout,
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
                    isVoiceRequest
                });
            return ExecuteWithExceptionUnwrap(() =>
            {
                var result = Task.Run(async () => await Client.Update<MultiPartyCallAddParticipantResponse>(Uri + mpcId + "/Participant", data).ConfigureAwait(false)).Result;
                result.Object.StatusCode = result.StatusCode;
                return result.Object;
            });
        }
    }
}