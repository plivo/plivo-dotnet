using System;

namespace Plivo.Resource.Node
{
    /// <summary>
    /// Node.
    /// </summary>
    public class Node : Resource
    {

        /// <summary>
        /// Node Id
        /// </summary>
        public string NodeId { get; set; }
        /// <summary>
        /// Phlo Id
        /// </summary>
        public string PhloId { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Node Type
        /// </summary>
        public string NodeType { get; set; }
        /// <summary>
        /// Created On
        /// </summary>
        public DateTime CreatedOn { get; set; }
        
    }
}