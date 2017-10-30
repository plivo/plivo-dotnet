using System.Collections.Generic;

namespace Plivo.Resource.Conference
{
    /// <summary>
    /// Conference list response.
    /// </summary>
    public class ConferenceListResponse
    {
        /// <summary>
        /// Gets or sets the API identifier.
        /// </summary>
        /// <value>The API identifier.</value>
        public string ApiId { get; set; }
        /// <summary>
        /// Gets or sets the conferences.
        /// </summary>
        /// <value>The conferences.</value>
        public List<string> Conferences { get; set; }
    }
}
