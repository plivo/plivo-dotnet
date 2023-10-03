using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Plivo.Resource
{
    /// <summary>
    /// Brand List response.
    /// </summary>
    [JsonObject]
    public class CampaignListResponse<T> : BaseResponse, IEnumerable<T>
    {

        /// <summary>
        /// Gets or sets the meta.
        /// </summary>
        /// <value>The meta.</value>
        public CampaignMeta Meta { get; set; }
        /// <summary>
        /// Gets or sets the objects.
        /// </summary>
        /// <value>The objects.</value>
        public List<T> Campaigns { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:plivo.Resource.ListResponse`1"/> class.
        /// </summary>
        public CampaignListResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:plivo.Resource.ListResponse`1"/> class.
        /// </summary>
        /// <param name="meta">Meta.</param>
        /// <param name="Campaigns">Campaigns.</param>
        public CampaignListResponse(CampaignMeta meta, List<T> campaigns)
        {
            Meta = meta ?? throw new ArgumentNullException(nameof(meta));
            Campaigns = campaigns ?? throw new ArgumentNullException(nameof(campaigns));
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
            return ((IEnumerable<T>) Campaigns).GetEnumerator();
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
                   "[Campaigns]\n" + string.Join("\n", Campaigns);



        }
    }
}