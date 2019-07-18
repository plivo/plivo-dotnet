using Plivo.Authentication;
using Plivo.Client;
using Plivo.Resource.Phlo;
using System;

namespace Plivo
{
    public class PhloApi
    {
        /// <summary>
        /// Gets or sets the client.
        /// </summary>
        /// <value>The client.</value>
        public HttpClient Client { get; set; }

        /// <summary>
        /// The basic auth.
        /// </summary>
        protected BasicAuth BasicAuth;


        // resource interfaces
        private readonly Lazy<PhloInterface> _phlo;
        /// <summary>
        /// Gets the account.
        /// </summary>
        /// <value>The account.</value>
        public PhloInterface Phlo => _phlo.Value;

        //private Lazy<NodeInterface> _node;
        //public PhloInterface Node => _node.Value;

        /// <summary>
        /// Authentication ID
        /// </summary>
        private string _authId;

        /// <summary>
        /// Authentication Token
        /// </summary>
        private string _authToken;


        /// <summary>
        /// Initializes a new instance of the <see cref="T:plivo.PhloApi"/> class.
        /// </summary>
        /// <param name="authId">Auth identifier.</param>
        /// <param name="authToken">Auth token.</param>
        /// <param name="proxyAddress">Proxy Address.</param>
        /// <param name="proxyPort">Proxy Port.</param>
        /// <param name="proxyUsername">Proxy Username.</param>
        /// <param name="proxyPassword">Proxy Password.</param>
        public PhloApi(
            string authId,
            string authToken,
            string proxyAddress = null,
            string proxyPort = null,
            string proxyUsername = null,
            string proxyPassword = null,
            string baseUri = null
        )
        {
            BasicAuth = new BasicAuth(authId, authToken);
            Client = new HttpClient(BasicAuth, proxyAddress, proxyPort, proxyUsername, proxyPassword, baseUri="https://phlorunner.plivo.com/v1");
            _authId = authId;
            _authToken = authToken;
            _phlo = new Lazy<PhloInterface>(() => new PhloInterface(Client, _authId, _authToken));
            
        }
    }
}