using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Plivo.Client;
using Plivo.Exception;
using Plivo.Resource.Member;

namespace Plivo.Resource.Phlo.MultiPartyCall
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
            var multiPartyCall = Task.Run(async () => await GetResource<MultiPartyCall>($"/{_nodeType}/{_nodeId}", new Dictionary<string, object>()).ConfigureAwait(false)).Result;
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
                { "trigger_source", triggerSource },
                { "to", to },
                { "role", role }
            };
            var qs = Client.AsQueryString(data);
            var result = Task.Run(async () => await Client.Update<BaseResponse>(Uri + $"/{_nodeType}/{_nodeId}/" + qs, data).ConfigureAwait(false)).Result;
            return result.Object;
        }
    }
}