using System;
using System.Collections.Generic;
using Plivo.Client;

namespace Plivo.Resource.Phlo
{
    /// <summary>
    /// MemberInterface
    /// </summary>
    public class MemberInterface : ResourceInterface
    {
        /// <summary>
        /// string PHLO Id
        /// </summary>
        private readonly string _phloUuid;

        /// <summary>
        /// string Node Id
        /// </summary>
        private readonly string _nodeUuid;

        /// <summary>
        /// string Member Id
        /// </summary>
        private readonly string _memberId;

        /// <summary>
        /// Member Interface constuctor
        /// </summary>
        /// <param name="client"></param>
        /// <param name="PHLO Id"></param>
        /// <param name="Node Id"></param>
        /// <param name="memberId"></param>
        internal MemberInterface(HttpClient client, string phloUuid, string nodeUuid, string memberId) : base(client)
        {
            Mandatory(Tuple.Create("phloUuid", phloUuid), Tuple.Create("nodeUuid", nodeUuid), Tuple.Create("memberId", memberId));

            _phloUuid = phloUuid;
            _nodeUuid = nodeUuid;
            _memberId = memberId;

            Uri = string.Format("phlo/{0}/multi_party_call/{1}/members/{2}", phloUuid, nodeUuid, memberId);
        }

        /// <summary>
        /// Multi Party Call AbortTransfer
        /// </summary>
        /// <returns>AbortTransfer</returns>
        public UpdateResponse<MultiPartyCallMemberResponse> AbortTransfer()
        {
            return Update("abort_transfer");
        }

        /// <summary>
        /// Multi Party Call ResumeCall
        /// </summary>
        /// <returns>ResumeCall</returns>
        public UpdateResponse<MultiPartyCallMemberResponse> ResumeCall()
        {
            return Update("resume_call");
        }

        /// <summary>
        /// Multi Party Call VoiceMailDrop
        /// </summary>
        /// <returns>VoiceMailDrop</returns>
        public UpdateResponse<MultiPartyCallMemberResponse> VoiceMailDrop()
        {
            return Update("voicemail_drop");
        }

        /// <summary>
        /// Multi Party Call Hangup
        /// </summary>
        /// <returns>Hangup</returns>
        public UpdateResponse<MultiPartyCallMemberResponse> Hangup()
        {
            return Update("hangup");
        }

        /// <summary>
        /// Multi Party Call Hold
        /// </summary>
        /// <returns>Hold</returns>
        public UpdateResponse<MultiPartyCallMemberResponse> Hold()
        {
            return Update("hold");
        }

        /// <summary>
        /// Multi Party Call Unhold
        /// </summary>
        /// <returns>Unhold</returns>
        public UpdateResponse<MultiPartyCallMemberResponse> Unhold()
        {
            return Update("unhold");
        }

        /// <summary>
        /// ///  Multi Party Call Update can trigger any particular "action" supported 
        ///  by API implementation (for all current/future action type    
        /// </summary>
        /// <param name="action"></param>
        /// <returns>Update</returns>
        public UpdateResponse<MultiPartyCallMemberResponse> Update(string action)
        {
            var mandatoryParams = new List<string> { "action" };
            var data = CreateData(mandatoryParams, new { action });
            return Client.Update<UpdateResponse<MultiPartyCallMemberResponse>>(Uri, data).Object;
        }

        /// <summary>
        /// Delete functionality is not supported by PHLO api yet.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public new T DeleteResource<T>(string id, Dictionary<string, object> data = null) where T : new()
        {
            throw new NotImplementedException("Delete functionality is not supported by PHLO api yet.");
        }
        /// <summary>
        /// Get list functionality is not supported by PHLO api yet.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public new T ListResources<T>(Dictionary<string, object> data = null) where T : new()
        {
            throw new NotImplementedException("Get list functionality is not supported by PHLO api yet.");
        }

        /// <summary>
        /// Get functionality is not supported by PHLO api yet.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public new T GetResource<T>(string id, Dictionary<string, object> data = null) where T : new()
        {
            throw new NotImplementedException("Get functionality is not supported by PHLO api yet");
        }
    }
}
