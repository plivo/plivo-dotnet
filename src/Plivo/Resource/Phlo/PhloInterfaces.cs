using System;
using System.Collections.Generic;
using System.Text;
using Plivo.Client;

namespace Plivo.Resource.Phlo
{
    /// <summary>
    ///(PHLO) Plivo High Level Objects interface 
    /// </summary>
    public class PhloInterface : ResourceInterface
    {
        /// <summary>
        /// PHLO Id
        /// </summary>
        private readonly string _phloId;

        /// <summary>
        /// Authentication ID
        /// </summary>
        private readonly string _authId;

        /// <summary>
        /// Authentication Token
        /// </summary>
        private readonly string _authToken;

        /// <summary>
        /// Authentication Token
        /// </summary>
        private readonly string _accountId;


        /// <summary>
        /// PHLO 
        /// </summary>
        /// <param name="HTTP client"></param>
        /// <param name="PHLO Id"></param>
        internal PhloInterface(HttpClient client, string phloId, string authId, string authToken) : base(client)
        {
            Mandatory(Tuple.Create("phloId", phloId), Tuple.Create("authId", authId), Tuple.Create("authToken", authToken));

            _phloId = phloId;
            _authId = authId;
            _authToken = authToken;
            _accountId = GetAccountID();

            Uri = string.Format("account/{0}/phlo/{1}", _accountId, _phloId);
        }

        /// <summary>
        /// Multi Party Call Declaration
        /// </summary>
        /// <param name="Node Id"></param>
        /// <returns>Node like : Multi Party Call Interface</returns>
        public NodeInterface Node(string nodeId)
        {
            Mandatory(Tuple.Create("nodeId", nodeId));
            return new NodeInterface(Client, _phloId, nodeId);
        }
        
        /// <summary>
        /// To trigger or run a PHLO
        /// </summary>
        public UpdateResponse<PhloRunCallResponse> Run()
        {
            
            var data = new Dictionary<string, object>();
            return Client.Update<UpdateResponse<PhloRunCallResponse>>(Uri, data).Object;
        }

        /// <summary>
        ///  Get AccountID
        /// </summary>
        /// <returns></returns>
        public string GetAccountID()
        {
            var api = new PlivoApi(_authId, _authToken);
            var accountId = api.Account.Get().Id;
            return accountId;
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

    /// <summary>
    /// Node Interface - Multi Party Call
    /// </summary>
    public class NodeInterface : ResourceInterface
    {
        /// <summary>
        /// string PHLO Id
        /// </summary>
        private readonly string _phloId;

        /// <summary>
        /// string Node Id
        /// </summary>
        private readonly string _nodeId;

        /// <summary>
        /// Multi Party Call Interface 
        /// </summary>
        /// <param name="client"></param>
        /// <param name="PHLO Id"></param>
        /// <param name="Node Id"></param>
        internal NodeInterface(HttpClient client, string phloId, string nodeId) : base(client)
        {
            Mandatory(Tuple.Create("phloId", phloId),Tuple.Create("nodeId", nodeId));

            _phloId = phloId;
            _nodeId = nodeId;

            Uri = string.Format("phlo/{0}/multi_party_call/{1}", phloId, nodeId);
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
            return new MemberInterface(Client, _phloId, _nodeId, memberId);
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

    /// <summary>
    /// MemberInterface
    /// </summary>
    public class MemberInterface : ResourceInterface
    {
        /// <summary>
        /// string PHLO Id
        /// </summary>
        private readonly string _phloId;

        /// <summary>
        /// string Node Id
        /// </summary>
        private readonly string _nodeId;

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
        internal MemberInterface(HttpClient client, string phloId, string nodeId, string memberId) : base(client)
        {
            Mandatory(Tuple.Create("phloId", phloId), Tuple.Create("nodeId", nodeId), Tuple.Create("memberId", memberId));

            _phloId = phloId;
            _nodeId = nodeId;
            _memberId = memberId;

            Uri = string.Format("phlo/{0}/multi_party_call/{1}/members/{2}", phloId, nodeId, memberId);
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

    public interface IPhloInterface
    {
        void Run();
    }
}
