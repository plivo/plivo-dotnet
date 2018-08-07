using Plivo.Authentication;
using Plivo.Client;
using Plivo.Exception;
using Plivo.Resource.Account;
using Plivo.Resource.Application;
using Plivo.Resource.Phlo;
using Plivo.Resource.Subaccount;
using System;
using System.Collections.Generic;
using System.Text;

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
        private Lazy<PhloInterface> _phlo;


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
            string proxyPassword = null
        )
        {
            var baseStagingUri = "https://phlo-runner-service-staging.ovilp.io/v1/"; // test URL, just removing this will start sending request on production URL.
            BasicAuth = new BasicAuth(authId, authToken);            
            Client = new HttpClient(BasicAuth, proxyAddress, proxyPort, proxyUsername, proxyPassword, baseStagingUri);
        }

        public PhloInterface Phlo(string phloUiid)
        {
            if (string.IsNullOrEmpty(phloUiid))
            {
                throw new PlivoValidationException("phloUiid is mandatory, can not be null or empty");
            }
            _phlo = new Lazy<PhloInterface>(() => new PhloInterface(Client, phloUiid));
            return _phlo.Value;
        }
    }
}
