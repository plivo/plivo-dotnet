using System;
using System.IO;
using Plivo.Exception;

namespace Plivo.Authentication
{
    /// <summary>
    /// Basic auth.
    /// </summary>
    public class BasicAuth
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:plivo.Authentication.BasicAuth"/> class.
        /// </summary>
        public BasicAuth()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:plivo.Authentication.BasicAuth"/> class.
        /// </summary>
        /// <param name="authId">Auth identifier.</param>
        /// <param name="authToken">Auth token.</param>
        public BasicAuth(string authId, string authToken)
        {
            AuthId = authId;
            AuthToken = authToken;

            if (AuthId == null || AuthToken == null)
            {
                throw new PlivoAuthenticationException("Authentication credentials not supplied");
            }
        }

        /// <summary>
        /// Gets or sets the authentication identifier.
        /// </summary>
        /// <value>The authentication identifier.</value>
        public string AuthId { get; set; }

        /// <summary>
        /// Gets or sets the authentication token.
        /// </summary>
        /// <value>The authentication token.</value>
        public string AuthToken { get; set; }
    }
}