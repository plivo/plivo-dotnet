using System;
using System.Collections.Generic;
using Plivo.Client;

namespace Plivo.Resource.Phlo
{
    /// <summary>
    /// Multi Party Call Interface
    /// </summary>
    public class MultiPartyCallInterface : ResourceInterface
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
        /// Multi Party Call Interface 
        /// </summary>
        /// <param name="client"></param>
        /// <param name="PHLO Id"></param>
        /// <param name="Node Id"></param>
        internal MultiPartyCallInterface(HttpClient client, string phloUuid, string nodeUuid) : base(client)
        {
            Mandatory(Tuple.Create("phloUuid", phloUuid),Tuple.Create("nodeUuid", nodeUuid));

            _phloUuid = phloUuid;
            _nodeUuid = nodeUuid;

            Uri = string.Format("phlo/{0}/multi_party_call/{1}", phloUuid, nodeUuid);
        }

        /// <summary>
        /// Create Multi Party Call
        /// </summary>
        /// <param name="Source"></param>
        /// <param name="Number being called"></param>
        /// <param name="role ="agent""></param>
        /// <returns>call </returns>
        public UpdateResponse<MultiPartyCallResponse> Call(string triggerSource, string to, string role)
        {
             return Update("call", triggerSource, to, role);
        }

        /// <summary>
        /// Multi Party Call Warm Transfer
        /// </summary>
        /// <param name="Source"></param>
        /// <param name="Number being called"></param>
        /// <param name="role ="agent""></param>
        /// <returns>Warm Transfer</returns>
        public UpdateResponse<MultiPartyCallResponse> WarmTransfer(string triggeSource, string to, string role)
        {
            return Update("warm_transfer", triggeSource, to, role);
        }

        /// <summary>
        /// Multi Party Call Cold Transfer
        /// </summary>
        /// <param name="Source"></param>
        /// <param name="Number being called"></param>
        /// <param name="role ="agent""></param>
        /// <returns>Cold Transfer</returns>
        public UpdateResponse<MultiPartyCallResponse> ColdTransfer(string triggeSource, string to, string role)
        {
           return Update("cold_transfer", triggeSource, to, role);
        }

        /// <summary>
        ///  Multi Party Call Update can trigger any particular "action" supported 
        ///  by API implementation (for all current/future action type    
        /// </summary>
        /// <param name=string="action"></param>
        /// <param name="Source"></param>
        /// <param name="Number being called"></param>
        /// <param name="role"></param>
        /// <returns>Update</returns>
        public UpdateResponse<MultiPartyCallResponse> Update(string action, string triggerSource, string to, string role)
        {
            var mandatoryParams = new List<string> { "action", "trigger_source", "to", "role" };
            var data = CreateData(mandatoryParams, new { action, triggerSource, to, role });
            return Client.Update<UpdateResponse<MultiPartyCallResponse>>(Uri, data).Object;
        }

        /// <summary>
        /// Member Interface
        /// </summary>
        /// <param name="memberId">Member Id</param>
        /// <returns>Member</returns>
        public MemberInterface Member(string memberId)
        {
            return new MemberInterface(Client, _phloUuid, _nodeUuid, memberId);
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
        public MultiPartyCall Get()
        {
            var multiPartyCall = base.GetResource<MultiPartyCall>(string.Empty, null);
            multiPartyCall.Interface = this;
            return multiPartyCall;
        }
    }
}
