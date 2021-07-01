using System;
using Plivo.Client;

namespace Plivo.Resource
{
    /// <summary>
    /// Resource.
    /// </summary>
    public class Resource
    {
        /// <summary>
        /// Gets or sets the resource identifier.
        /// </summary>
        /// <value>The resource identifier.</value>
        public string Id;

        /// <summary>
        /// Gets or sets the API identifier.
        /// </summary>
        /// <value>The API identifier.</value>
        public string ApiId { get; set; }

        /// <summary>
        /// Gets or sets the interface.
        /// </summary>
        /// <value>The interface.</value>
        /// 
        public uint StatusCode { get; set; }

        public ResourceInterface Interface { get; set; }

        
    }

    public class SecondaryResource : Resource
    {
        public string SecondaryId;
        public string SecondaryName;
        
        public ResourceInterface Interface { get; set; }
    }
}