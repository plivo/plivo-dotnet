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
    public class BrandListUsecaseResponse<T> : BaseResponse, IEnumerable<T>
    {
        /// <summary>
        /// Gets or sets the objects.
        /// </summary>
        /// <value>The objects.</value>
        public List<T> BrandUsecases { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:plivo.Resource.ListResponse`1"/> class.
        /// </summary>
        public BrandListUsecaseResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:plivo.Resource.ListResponse`1"/> class.
        /// </summary>
        public BrandListUsecaseResponse( List<T> usecases)
        {
            BrandUsecases = usecases ?? throw new ArgumentNullException(nameof(usecases));
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
            return ((IEnumerable<T>) BrandUsecases).GetEnumerator();
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:plivo.Resource.ListResponse`1"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:plivo.Resource.ListResponse`1"/>.</returns>
        public override string ToString()
        {
            return "Api Id: " + ApiId + "\n" +
                   "StatusCode: " + StatusCode +
                   "[BrandUsecases]\n" + string.Join("\n", BrandUsecases);



        }
    }
}