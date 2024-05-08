using Newtonsoft.Json;

namespace Plivo.Resource.MaskingSession
{
    public class MaskingSessionListResponse : Resource
    {
        [JsonProperty("amount")]
        public object Amount { get; set; }

        [JsonProperty("call_time_limit")]
        public object CallTimeLimit { get; set; }

        [JsonProperty("callback_method")]
        public object CallbackMethod { get; set; }

        [JsonProperty("callback_url")]
        public object CallbackUrl { get; set; }

        [JsonProperty("created_time")]
        public object CreatedTime { get; set; }

        [JsonProperty("duration")]
        public object Duration { get; set; }

        [JsonProperty("expiry_time")]
        public object Expiry_time { get; set; }

        [JsonProperty("first_party")]
        public object FirstParty { get; set; }

        [JsonProperty("first_party_pin")]
        public object FirstPartyPin { get; set; }

        [JsonProperty("first_party_play_url")]
        public object FirstPartyPlayUrl { get; set; }

        [JsonProperty("generate_pin")]
        public object GeneratePin { get; set; }

        [JsonProperty("generate_pin_length")]
        public object GeneratePinLength { get; set; }

        [JsonProperty("incorrect_pin_play")]
        public object IncorrectPinPlay { get; set; }

        [JsonProperty("initiate_call_to_first_party")]
        public object InitiateCallToFirstParty { get; set; }

        [JsonProperty("interaction")]
        public object Interaction { get; set; }

        [JsonProperty("is_pin_authentication_required")]
        public object IsPinAuthenticationRequired { get; set; }

        [JsonProperty("last_interaction_time")]
        public object LastInteractionTime { get; set; }

        [JsonProperty("modified_time")]
        public object ModifiedTime { get; set; }

        [JsonProperty("pin_prompt_play")]
        public object PinPromptPlay { get; set; }

        [JsonProperty("pin_retry")]
        public object PinRetry { get; set; }

        [JsonProperty("pin_retry_wait")]
        public object PinRetryWait { get; set; }

        [JsonProperty("record")]
        public object Record { get; set; }

        [JsonProperty("record_file_format")]
        public object RecordFileFormat { get; set; }

        [JsonProperty("recording_callback_method")]
        public object RecordingCallbackMethod { get; set; }

        [JsonProperty("recording_callback_url")]
        public object RecordingCallbackUrl { get; set; }

        [JsonProperty("resource_uri")]
        public object ResourceUri { get; set; }

        [JsonProperty("ring_timeout")]
        public object RingTimeout { get; set; }

        [JsonProperty("second_party")]
        public object SecondParty { get; set; }

        [JsonProperty("second_party_pin")]
        public object SecondPartyPin { get; set; }

        [JsonProperty("second_party_play_url")]
        public object SecondPartyPlayUrl { get; set; }

        [JsonProperty("session_uuid")]
        public object SessionUuid { get; set; }

        [JsonProperty("status")]
        public object Status { get; set; }

        [JsonProperty("total_call_amount")]
        public object TotalCallAmount { get; set; }

        [JsonProperty("total_call_billed_duration")]
        public object TotalCallBilledDuration { get; set; }

        [JsonProperty("total_call_count")]
        public object TotalCallCount { get; set; }

        [JsonProperty("total_session_amount")]
        public object TotalSessionAmount { get; set; }

        [JsonProperty("unknown_caller_play")]
        public object UnknownCallerPlay { get; set; }

        [JsonProperty("virtual_number")]
        public object VirtualNumber { get; set; }

        public override string ToString()
        {
            return "Amount: " + Amount + "\n" +
                   "CallTimeLimit: " + CallTimeLimit + "\n" +
                   "CallbackMethod: " + CallbackMethod + "\n" +
                   "CallbackUrl: " + CallbackUrl + "\n" +
                   "CreatedTime: " + CreatedTime + "\n" +
                   "Duration: " + Duration + "\n" +
                   "ExpiryTime: " + Expiry_time + "\n" +
                   "FirstParty: " + FirstParty + "\n" +
                   "FirstPartyPin: " + FirstPartyPin + "\n" +
                   "FirstPartyPlayUrl: " + FirstPartyPlayUrl + "\n" +
                   "GeneratePin: " + GeneratePin + "\n" +
                   "GeneratePinLength: " + GeneratePinLength + "\n" +
                   "IncorrectPinPlay: " + IncorrectPinPlay + "\n" +
                   "InitiateCallToFirstParty: " + InitiateCallToFirstParty + "\n" +
                   "Interaction: " + Interaction + "\n" +
                   "IsPinAuthenticationRequired: " + IsPinAuthenticationRequired + "\n" +
                   "LastInteractionTime: " + LastInteractionTime + "\n" +
                   "ModifiedTime: " + ModifiedTime + "\n" +
                   "PinPromptPlay: " + PinPromptPlay + "\n" +
                   "PinRetry: " + PinRetry + "\n" +
                   "PinRetryWait: " + PinRetryWait + "\n" +
                   "Record: " + Record + "\n" +
                   "RecordFileFormat: " + RecordFileFormat + "\n" +
                   "RecordingCallbackMethod: " + RecordingCallbackMethod + "\n" +
                   "RecordingCallbackUrl: " + RecordingCallbackUrl + "\n" +
                   "ResourceUri: " + ResourceUri + "\n" +
                   "RingTimeout: " + RingTimeout + "\n" +
                   "SecondParty: " + SecondParty + "\n" +
                   "SecondPartyPin: " + SecondPartyPin + "\n" +
                   "SecondPartyPlayUrl: " + SecondPartyPlayUrl + "\n" +
                   "SessionUuid: " + SessionUuid + "\n" +
                   "Status: " + Status + "\n" +
                   "TotalCallAmount: " + TotalCallAmount + "\n" +
                   "TotalCallBilledDuration: " + TotalCallBilledDuration + "\n" +
                   "TotalCallCount: " + TotalCallCount + "\n" +
                   "TotalSessionAmount: " + TotalSessionAmount + "\n" +
                   "UnknownCallerPlay: " + UnknownCallerPlay + "\n" +
                   "VirtualNumber: " + VirtualNumber + "\n";
        }

    }
}