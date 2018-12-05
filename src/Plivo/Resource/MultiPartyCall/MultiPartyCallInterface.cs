using System;
using System.Collections.Generic;
using Plivo.Client;
using Plivo.Exception;
using Plivo.Resource.Member;

namespace Plivo.Resource.MultiPartyCall
{
    public class MultiPartyCallInterface : ResourceInterface
    {
        /// <summary>
        /// PHLO Id
        /// </summary>
        private string _phloId;
        /// <summary>
        /// Node type
        /// </summary>
        private string _nodeType;
        /// <summary>
        /// Node Id
        /// </summary>
        private string _nodeId;

        private MemberInterface MemberI { get; set; }

        public MultiPartyCallInterface(HttpClient client, string phloId) : base(client)
        {
            _phloId = phloId;
            Uri = $"phlo/{_phloId}";
            _nodeType = "multi_party_call";
        }
        public MultiPartyCall Get(string phloId, string nodeId)
        {
            
            
            if (string.IsNullOrEmpty(nodeId))
            {
                throw new PlivoValidationException("nodeId is mandatory, can not be null or empty");
            }
            _nodeId = nodeId;
            var multiPartyCall = GetResource<MultiPartyCall>($"/{_nodeType}/{_nodeId}", new Dictionary<string, object>());
            multiPartyCall.Interface = this;
            multiPartyCall._member = new Lazy<MemberInterface>(() => new MemberInterface(Client, phloId, _nodeType, _nodeId));
            return multiPartyCall;
        }
        
        public BaseResponse Update(string action, string triggerSource, string to, string role)
        {
            if (string.IsNullOrEmpty(triggerSource))
            {
                throw new PlivoValidationException("triggerSource is mandatory, can not be null or empty");
            }
            var data = new Dictionary<string, object>
            {
                { "action", action },
                { "triggerSource", triggerSource },
                { "to", to },
                { "role", role }
            };
            var qs = Client.AsQueryString(data);
            return Client.Update<BaseResponse>(Uri + $"/{_nodeType}/{_nodeId}" + qs).Object;
        }
    }
}