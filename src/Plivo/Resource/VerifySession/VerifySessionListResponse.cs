using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Plivo.Resource
{
    /// <summary>
    /// VerifySession List response.
    /// </summary>
    [JsonObject]
    public class VerifySessionListResponse<T> : BaseResponse, IEnumerable<T>
    {
        /// <summary>
        /// Gets or sets the meta.
        /// </summary>
        /// <value>The meta.</value>
        public VerifySessionMeta Meta { get; set; }
        /// <summary>
        /// Gets or sets the sessions.
        /// </summary>
        /// <value>The sessions.</value>
        public List<T> Sessions { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:plivo.Resource.ListResponse`1"/> class.
        /// </summary>
        public VerifySessionListResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:plivo.Resource.ListResponse`1"/> class.
        /// </summary>
        /// <param name="meta">Meta.</param>
        /// <param name="sessions">Sessions.</param>
        public VerifySessionListResponse(VerifySessionMeta meta, List<T> sessions)
        {
            Meta = meta ?? throw new ArgumentNullException(nameof(meta));
            Sessions = sessions ?? throw new ArgumentNullException(nameof(sessions));
        }

        /// <summary>
        /// System.s the collections. IE numerable. get enumerator.
        /// </summary>
        /// <returns>The collections. IE numerable. get enumerator.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Gets the enumerator.
        /// </summary>
        /// <returns>The enumerator.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>) Sessions).GetEnumerator();
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:plivo.Resource.ListResponse`1"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:plivo.Resource.ListResponse`1"/>.</returns>
        public override string ToString()
        {
            return "Api Id: " + ApiId + "\n" +
                   "[Meta]\n" + Meta +
                   "StatusCode: " + StatusCode +
                   "[Sessions]\n" + string.Join("\n", Sessions);



        }
    }
}