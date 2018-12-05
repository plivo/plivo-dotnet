using System;
using System.Collections.Generic;
using Plivo.Exception;
using Plivo.Resource.MultiPartyCall;
using Plivo.Resource.Node;

namespace Plivo.Resource.Phlo
{
    public class Phlo :Resource
    {
        /// <summary>
        /// Api ID
        /// </summary>
        public string ApiId { get; set; }
        
        /// <summary>
        /// PHLO Run ID
        /// </summary>
        public string PhloId { get; set; }   

        /// <summary>
        /// PHLO Name
        /// </summary>
        public string Name { get; set; }   

        /// <summary>
        /// PHLO CreatedOn
        /// </summary>
        public DateTime CreatedOn { get; set; }
        
        
        public Lazy<NodeInterface> _node;
        public Lazy<MultiPartyCallInterface> _multiPartyCall;
        public NodeInterface NodeI => _node.Value;
        public MultiPartyCallInterface MultiPartyCallI => _multiPartyCall.Value;

        public MultiPartyCall.MultiPartyCall MultiPartyCall(string nodeId)
        {
            return MultiPartyCallI.Get(PhloId, nodeId);
        }
        
        public Node.Node Node(string nodeType, string nodeId)
        {
            if (string.IsNullOrEmpty(nodeId))
            {
                throw new PlivoValidationException("nodeId is mandatory, can not be null or empty");
            }
            var data = new Dictionary<string, object>();
            return NodeI.Get(nodeType, nodeId);
        }

        
        public PhloRunCallResponse Run(Dictionary<string, object> data = null)
        {
            return ((PhloInterface)Interface)
                .Run(data);
            
        }
        
    }
}
