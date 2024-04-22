
using System;
using System.Threading.Tasks;

namespace Plivo.Resource.MaskingSession
{
    public class MaskingSession : Resource
    {
        public new string Id => SessionUuid;
        public string FirstParty { get; set; }
        public string SecondParty { get; set; }
        public string VirtualNumber { get; set; }
        public string Status { get; set; }
        public bool InitiateCallToFirstParty { get; set; }
        public string SessionUuid { get; set; }
        public string CallbackUrl { get; set; }
        public string CallbackMethod { get; set; }
        public string CreatedTime { get; set; }
        public string ModifiedTime { get; set; }
        public string ExpiryTime { get; set; }
        public int Duration { get; set; }
        public int Amount { get; set; }
        public int CallTimeLimit { get; set; }
        public int RingTimeout { get; set; }
        public string FirstPartyPlayUrl { get; set; }
        public string SecondPartyPlayUrl { get; set; }
        public bool Record { get; set; }
        public string RecordFileFormat { get; set; }
        public string RecordingCallbackUrl { get; set; }
        public string RecordingCallbackMethod { get; set; }
        public Object Interaction { get; set; }
        public float TotalCallAmount { get; set; }
        public int TotalCallCount { get; set; }
        public int TotalCallBilledDuration { get; set; }
        public float TotalSessionAmount { get; set; }
        public string LastInteractionTime { get; set; }
        public bool IsPinAuthenticationRequired { get; set; }
        public bool GeneratePin { get; set; }
        public Int64 GeneratePinLength { get; set; }
        public string FirstPartyPin { get; set; }
        public string SecondPartyPin { get; set; }
        public string PinPromptPlay { get; set; }
        public Int64 PinRetry { get; set; }
        public Int64 PinRetryWait { get; set; }
        public string IncorrectPinPlay { get; set; }
        public string UnknownCallerPlay { get; set; }

        public override string ToString()
        {
            return  "api_id: " + ApiId + "\n"+
                    "first_party: " + FirstParty + "\n"+
                    "second_party: " + SecondParty + "\n"+
                    "virtual_number: " + VirtualNumber + "\n"+
                    "status: " + Status + "\n"+
                    "initiate_call_to_first_party: " + InitiateCallToFirstParty + "\n"+
                    "session_uuid: " + SessionUuid + "\n"+
                    "callback_url: " + CallbackUrl + "\n"+
                    "callback_method: " + CallbackMethod + "\n"+
                    "created_time: " + CreatedTime + "\n"+
                    "modified_time: " + ModifiedTime + "\n"+
                    "expiry_time: " + ExpiryTime + "\n"+
                    "duration: " + Duration + "\n"+
                    "amount: " + Amount + "\n"+
                    "call_time_limit: " + CallTimeLimit + "\n"+
                    "ring_timeout: " + RingTimeout + "\n"+
                    "first_party_play_url: " + FirstPartyPlayUrl + "\n"+
                    "second_party_play_url: " + SecondPartyPlayUrl + "\n"+
                    "record: " + Record + "\n"+
                    "record_file_format: " + RecordFileFormat + "\n"+
                    "recording_callback_url: " + RecordingCallbackUrl + "\n"+
                    "recording_callback_method: " + RecordingCallbackMethod + "\n"+
                    "interaction: " + Interaction + "\n"+
                    "total_call_amount: " + TotalCallAmount + "\n"+
                    "total_call_count: " + TotalCallCount + "\n"+
                    "total_call_billed_duration: " + TotalCallBilledDuration + "\n"+
                    "total_session_amount: " + TotalSessionAmount + "\n"+
                    "last_interaction_time: " + LastInteractionTime + "\n"+
                    "is_pin_authentication_required: " + IsPinAuthenticationRequired + "\n"+
                    "generate_pin: " + GeneratePin + "\n"+
                    "generate_pin_length: " + GeneratePinLength + "\n"+
                    "first_party_pin: " + FirstPartyPin + "\n"+
                    "second_party_pin: " + SecondPartyPin + "\n"+
                    "pin_prompt_play: " + PinPromptPlay + "\n"+
                    "pin_retry: " + PinRetry + "\n"+
                    "pin_retry_wait: " + PinRetryWait + "\n"+
                    "incorrect_pin_play: " + IncorrectPinPlay + "\n"+
                    "unknown_caller_play: " + UnknownCallerPlay + "\n";
        }

        #region Delete
        public DeleteResponse<MaskingSession> Delete()
        {
            return ((MaskingSessionInterface) Interface).Delete(Id);
        }
        public async Task<AsyncResponse> DeleteAsync(string Id)
        {
            return await ((MaskingSessionInterface)Interface).DeleteAsync(Id);
        }
        #endregion


        #region Update
        public UpdateResponse<MaskingSession> Update(string sessionUuid, uint? session_expiry = null, uint? call_time_limit = null, 
        bool? record = null, string record_file_format = null, string recording_callback_url = null, string callback_url = null, 
        string callback_method = null, uint? ring_timeout = null, string first_party_play_url = null, string second_party_play_url = null, 
        string recording_callback_method = null, string subaccount = null, bool? geomatch = null
        )
        {
            var updateResponse =
                ((MaskingSessionInterface) Interface)
                .Update(Id, session_expiry, call_time_limit, record, record_file_format, recording_callback_url, callback_url, 
                callback_method, ring_timeout, first_party_play_url, second_party_play_url, recording_callback_method, 
                subaccount, geomatch);
            return updateResponse;
        }

        public async Task<AsyncResponse> UpdateAsync(string sessionUuid, uint? session_expiry = null, uint? call_time_limit = null, 
        bool? record = null, string record_file_format = null, string recording_callback_url = null, string callback_url = null, 
        string callback_method = null, uint? ring_timeout = null, string first_party_play_url = null, string second_party_play_url = null, 
        string recording_callback_method = null, string subaccount = null, bool? geomatch = null
        )
        {
            var updateResponse = await
                ((MaskingSessionInterface)Interface)
                .UpdateAsync(Id, session_expiry, call_time_limit, record, record_file_format, recording_callback_url, callback_url, 
                callback_method, ring_timeout, first_party_play_url, second_party_play_url, recording_callback_method, 
                subaccount, geomatch);

            return updateResponse;
        }
        #endregion

    }
}