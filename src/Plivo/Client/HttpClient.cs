using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Plivo.Authentication;
using Plivo.Http;

namespace Plivo.Client
{
    /// <summary>
    /// Http client.
    /// </summary>
    public class HttpClient
    {
        /// <summary>
        /// Gets or sets the client.
        /// </summary>
        /// <value>The client.</value>
        public IHttpClient _client { get; set; }

        /// <summary>
        /// The basic auth containing auth id and auth token
        /// </summary>
        private BasicAuth _basicAuth;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:plivo.Client.HttpClient"/> class.
        /// </summary>
        /// <param name="basicAuth">Basic auth.</param>
        /// <param name="proxyAddress">Proxy Address.</param>
        /// <param name="proxyPort">Proxy Port.</param>
        /// <param name="proxyUsername">Proxy Username.</param>
        /// <param name="proxyPassword">Proxy Password.</param>
        /// <param name="baseUri">Switch between environments</param>

        public HttpClient(BasicAuth basicAuth,
            string proxyAddress = null, string proxyPort = null,
            string proxyUsername = null, string proxyPassword = null, string baseUri = null)
        {
            _client = new SystemHttpClient(basicAuth,
                new Dictionary<string, string>
                {
                    {"Address", proxyAddress},
                    {"Password", proxyPassword},
                    {"Username", proxyUsername},
                    {"Port", proxyPort}
                }, baseUri);
            _basicAuth = basicAuth;
        }

        /// <summary>
        /// Fetch the specified uri with request parameters in data.
        /// </summary>
        /// <returns>The fetch.</returns>
        /// <param name="uri">URI.</param>
        /// <param name="data">Data.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public async Task<PlivoResponse<T>> Fetch<T>(string uri, Dictionary<string, object> data = null)
            where T : new()
        {
            return await _client.SendRequest<T>("GET", uri, data ?? new Dictionary<string, object>());
        }

        /// <summary>
        /// Update with the specified data.
        /// </summary>
        /// <returns>The update.</returns>
        /// <param name="uri">URI.</param>
        /// <param name="data">Data.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public async Task<PlivoResponse<T>> Update<T>(string uri, Dictionary<string, object> data = null,
            Dictionary<string, string> filesToUpload = null)
            where T : new()
        {
            return await _client.SendRequest<T>("POST", uri, data ?? new Dictionary<string, object>(), filesToUpload);
        }

        /// <summary>
        /// Delete the specified uri with request parameters in data.
        /// </summary>
        /// <returns>The delete.</returns>
        /// <param name="uri">URI.</param>
        /// <param name="data">Data.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public async Task<PlivoResponse<T> >Delete<T>(string uri, Dictionary<string, object> data = null)
            where T : new()
        {
            return await _client.SendRequest<T>("DELETE", uri, data ?? new Dictionary<string, object>());
        }

        /// <summary>
        /// Gets the auth identifier.
        /// </summary>
        /// <returns>The auth identifier.</returns>
        public string GetAuthId()
        {
            return _basicAuth.AuthId;
        }

        /// <summary>
        /// Sets the timeout of the httpclient.
        /// </summary>
        public void SetTimeout(int timeout)
        {
            ((SystemHttpClient) _client)._client.Timeout = TimeSpan.FromSeconds(timeout);
        }
        
        public string AsQueryString(IEnumerable<KeyValuePair<string, object>> parameters)
        {
            return _client.AsQueryString(parameters);
        }

    }
}