using System;
using System.Collections.Generic;
using System.Text;
using Plivo.Client;

namespace Plivo.Resource.Phlo
{
    /// <summary>
    /// 
    /// </summary>
    public class PhloInterface : ResourceInterface
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly string _phloUuid;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        /// <param name="phloUuid"></param>
        internal PhloInterface(HttpClient client, string phloUuid) : base(client)
        {
            Mandatory(Tuple.Create("phloUuid", phloUuid));
            _phloUuid = phloUuid;
            Uri = string.Format("phlo/{0}", phloUuid);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodeUuid"></param>
        /// <returns></returns>
        public MultiPartyCallInterface MultiPartyCall(string nodeUuid)
        {
            Mandatory(Tuple.Create("nodeUuid", nodeUuid));
            return new MultiPartyCallInterface(Client, _phloUuid, nodeUuid);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class MultiPartyCallInterface : ResourceInterface
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly string _phloUuid;

        /// <summary>
        /// 
        /// </summary>
        private readonly string _nodeUuid;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        /// <param name="phloUuid"></param>
        /// <param name="nodeUuid"></param>
        internal MultiPartyCallInterface(HttpClient client, string phloUuid, string nodeUuid) : base(client)
        {
            Mandatory(Tuple.Create("phloUuid", phloUuid),Tuple.Create("nodeUuid", nodeUuid));

            _phloUuid = phloUuid;
            _nodeUuid = nodeUuid;

            Uri = string.Format("phlo/{0}/multipartycall/{1}", phloUuid, nodeUuid);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="triggeSource"></param>
        /// <param name="to"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        public UpdateResponse<MultiPartyCallResponse> Call(string triggeSource, string to, string role)
        {
             return Update("Call", triggeSource, to, role);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="triggeSource"></param>
        /// <param name="to"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        public UpdateResponse<MultiPartyCallResponse> WarmTransfer(string triggeSource, string to, string role)
        {
            return Update("warmtransfer", triggeSource, to, role);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="triggeSource"></param>
        /// <param name="to"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        public UpdateResponse<MultiPartyCallResponse> ColdTransfer(string triggeSource, string to, string role)
        {
           return Update("coldtransfer", triggeSource, to, role);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <param name="triggeSource"></param>
        /// <param name="to"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        public UpdateResponse<MultiPartyCallResponse> Update(string action, string triggeSource, string to, string role)
        {
            var mandatoryParams = new List<string> { "action", "triggeSource", "to", "role" };
            var data = CreateData(mandatoryParams, new { action, triggeSource, to, role });
            return Client.Update<UpdateResponse<MultiPartyCallResponse>>(Uri, data).Object;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public MemberInterface Member(string memberId)
        {
            return new MemberInterface(Client, _phloUuid, _nodeUuid, memberId);
        }
    }
    
    /// <summary>
    /// 
    /// </summary>
    public class MemberInterface : ResourceInterface
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly string _phloUuid;

        /// <summary>
        /// 
        /// </summary>
        private readonly string _nodeUuid;

        /// <summary>
        /// 
        /// </summary>
        private readonly string _memberId;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        /// <param name="phloUuid"></param>
        /// <param name="nodeUuid"></param>
        /// <param name="memberId"></param>
        internal MemberInterface(HttpClient client, string phloUuid, string nodeUuid, string memberId) : base(client)
        {
            Mandatory(Tuple.Create("phloUuid", phloUuid), Tuple.Create("nodeUuid", nodeUuid), Tuple.Create("memberId", memberId));

            _phloUuid = phloUuid;
            _nodeUuid = nodeUuid;
            _memberId = memberId;

            Uri = string.Format("phlo/{0}/multipartycall/{1}/memeber/{2}", phloUuid, nodeUuid, memberId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public UpdateResponse<MultiPartyCallMemberResponse> AbortTransfer()
        {
            return Update("aborttransfer");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public UpdateResponse<MultiPartyCallMemberResponse> ResumeCall()
        {
            return Update("resumecall");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public UpdateResponse<MultiPartyCallMemberResponse> VoiceMailDrop()
        {
            return Update("voicemaildrop");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public UpdateResponse<MultiPartyCallMemberResponse> Hangup()
        {
            return Update("hangup");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public UpdateResponse<MultiPartyCallMemberResponse> Hold()
        {
            return Update("hold");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public UpdateResponse<MultiPartyCallMemberResponse> Unhold()
        {
            return Update("unhold");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public UpdateResponse<MultiPartyCallMemberResponse> Update(string action)
        {
            var mandatoryParams = new List<string> { "action" };
            var data = CreateData(mandatoryParams, new { action });
            return Client.Update<UpdateResponse<MultiPartyCallMemberResponse>>(Uri, data).Object;
        }
    }
}
