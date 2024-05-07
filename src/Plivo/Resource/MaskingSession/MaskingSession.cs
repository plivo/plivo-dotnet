
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
            return  "ApiId: " + ApiId + "\n"+
                    "FirstParty: " + FirstParty + "\n"+
                    "SecondParty: " + SecondParty + "\n"+
                    "VirtualNumber: " + VirtualNumber + "\n"+
                    "Status: " + Status + "\n"+
                    "InitiateCallToFirstParty: " + InitiateCallToFirstParty + "\n"+
                    "SessionUuid: " + SessionUuid + "\n"+
                    "CallbackUrl: " + CallbackUrl + "\n"+
                    "CallbackMethod: " + CallbackMethod + "\n"+
                    "CreatedTime: " + CreatedTime + "\n"+
                    "ModifiedTime: " + ModifiedTime + "\n"+
                    "ExpiryTime: " + ExpiryTime + "\n"+
                    "Duration: " + Duration + "\n"+
                    "Amount: " + Amount + "\n"+
                    "CallTimeLimit: " + CallTimeLimit + "\n"+
                    "RingTimeout: " + RingTimeout + "\n"+
                    "FirstPartyPlayUrl: " + FirstPartyPlayUrl + "\n"+
                    "SecondPartyPlayUrl: " + SecondPartyPlayUrl + "\n"+
                    "Record: " + Record + "\n"+
                    "RecordFileFormat: " + RecordFileFormat + "\n"+
                    "RecordingCallbackUrl: " + RecordingCallbackUrl + "\n"+
                    "RecordingCallbackMethod: " + RecordingCallbackMethod + "\n"+
                    "Interaction: " + Interaction + "\n"+
                    "TotalCallAmount: " + TotalCallAmount + "\n"+
                    "TotalCallCount: " + TotalCallCount + "\n"+
                    "TotalCallBilledDuration: " + TotalCallBilledDuration + "\n"+
                    "TotalSessionAmount: " + TotalSessionAmount + "\n"+
                    "LastInteractionTime: " + LastInteractionTime + "\n"+
                    "IsPinAuthenticationRequired: " + IsPinAuthenticationRequired + "\n"+
                    "GeneratePin: " + GeneratePin + "\n"+
                    "GeneratePinLength: " + GeneratePinLength + "\n"+
                    "FirstPartyPin: " + FirstPartyPin + "\n"+
                    "SecondPartyPin: " + SecondPartyPin + "\n"+
                    "PinPromptPlay: " + PinPromptPlay + "\n"+
                    "PinRetry: " + PinRetry + "\n"+
                    "PinRetryWait: " + PinRetryWait + "\n"+
                    "IncorrectPinPlay: " + IncorrectPinPlay + "\n"+
                    "UnknownCallerPlay: " + UnknownCallerPlay + "\n";
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