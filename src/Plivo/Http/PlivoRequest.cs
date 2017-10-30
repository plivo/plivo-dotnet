using System;
using System.Collections.Generic;

namespace Plivo.Http
{
    /// <summary>
    /// Plivo request.
    /// </summary>
    public class PlivoRequest
    {
        /// <summary>
        /// The URI.
        /// </summary>
        public string Uri;
        /// <summary>
        /// The method.
        /// </summary>
        public string Method;
        /// <summary>
        /// The headers.
        /// </summary>
        public string Headers;
        /// <summary>
        /// The data.
        /// </summary>
        public Dictionary<string, object> Data;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:plivo.Http.PlivoRequest"/> class.
        /// </summary>
        /// <param name="method">Method.</param>
        /// <param name="uri">URI.</param>
        /// <param name="headers">Headers.</param>
        /// <param name="data">Data.</param>
        public PlivoRequest(string method, string uri, string headers, Dictionary<string, object> data = null)
        {
            Method = method ?? throw new ArgumentNullException(nameof(method));
            Uri = uri ?? throw new ArgumentNullException(nameof(uri));
            Headers = headers ?? throw new ArgumentNullException(nameof(headers));
            Data = data ?? new Dictionary<string, object>();
        }
    }
}
