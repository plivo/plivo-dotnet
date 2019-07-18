using System.Collections.Generic;
using System.Threading.Tasks;
using Plivo.Exception;
using Plivo.Client;

namespace Plivo.Resource.Node
{
    public class NodeInterface: ResourceInterface
    {
        /// <summary>
        /// PHLO Id
        /// </summary>
        private string _phloId;
        /// <summary>
        /// Node Type
        /// </summary>
        private string _nodeType;
        /// <summary>
        /// Node Id
        /// </summary>
        private string _nodeId;
        
        public NodeInterface(HttpClient client, string phloId) : base(client)
        {
            _phloId = phloId;
            Uri = $"phlo/{_phloId}";
        }
        
        public Node Get(string nodeType, string nodeId)
        {
            _nodeType = nodeType;
            _nodeId = nodeId;
            
            if (string.IsNullOrEmpty(_nodeId))
            {
                throw new PlivoValidationException("nodeId is mandatory, can not be null or empty");
            }
            var node = Task.Run(async () => await GetResource<Node>($"/{_nodeType}/{_nodeId}", new Dictionary<string, object>()).ConfigureAwait(false)).Result;
            node.Interface = this;
            return node;
        }

    }
}