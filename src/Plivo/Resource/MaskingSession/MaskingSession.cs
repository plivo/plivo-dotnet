
using System;
using System.Threading.Tasks;

namespace Plivo.Resource.MaskingSession
{
    public class MaskingSession : Resource
    {
        public new string Id => SessionUuid;
        public string SessionUuid { get; set; }
        public object Response { get; set; }

        public override string ToString()
        {
            return  "ApiId: " + ApiId + "\n"+
                    "Response: " + Response + "\n";
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
        public MaskingSessionUpdateResponse<MaskingSession> Update(string sessionUuid, string first_party = null, string second_party = null, uint? session_expiry = null, uint? call_time_limit = null, 
        bool? record = null, string record_file_format = null, string recording_callback_url = null, string callback_url = null, 
        string callback_method = null, uint? ring_timeout = null, string first_party_play_url = null, string second_party_play_url = null, 
        string recording_callback_method = null, string subaccount = null, bool? geomatch = null
        )
        {
            var updateResponse =
                ((MaskingSessionInterface) Interface)
                .Update(Id, first_party, second_party, session_expiry, call_time_limit, record, record_file_format, recording_callback_url, callback_url, 
                callback_method, ring_timeout, first_party_play_url, second_party_play_url, recording_callback_method, 
                subaccount, geomatch);
            return updateResponse;
        }

        public async Task<AsyncResponse> UpdateAsync(string sessionUuid, string first_party = null, string second_party = null,  uint? session_expiry = null, uint? call_time_limit = null, 
        bool? record = null, string record_file_format = null, string recording_callback_url = null, string callback_url = null, 
        string callback_method = null, uint? ring_timeout = null, string first_party_play_url = null, string second_party_play_url = null, 
        string recording_callback_method = null, string subaccount = null, bool? geomatch = null
        )
        {
            var updateResponse = await
                ((MaskingSessionInterface)Interface)
                .UpdateAsync(Id, first_party, second_party, session_expiry, call_time_limit, record, record_file_format, recording_callback_url, callback_url, 
                callback_method, ring_timeout, first_party_play_url, second_party_play_url, recording_callback_method, 
                subaccount, geomatch);

            return updateResponse;
        }
        #endregion

    }
}