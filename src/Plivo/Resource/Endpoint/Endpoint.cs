using System.Threading.Tasks;

namespace Plivo.Resource.Endpoint
{
    /// <summary>
    /// Endpoint.
    /// </summary>
    public class Endpoint : Resource
    {
        public new string Id => EndpointId;

        /// <summary>
        /// Gets or sets the alias.
        /// </summary>
        /// <value>The alias.</value>
        public string Alias { get; set; }

        /// <summary>
        /// Gets or sets the application.
        /// </summary>
        /// <value>The application.</value>
        public string Application { get; set; }

        /// <summary>
        /// Gets or sets the endpoint identifier.
        /// </summary>
        /// <value>The endpoint identifier.</value>
        public string EndpointId { get; set; }

        /// <summary>
        /// Gets or sets the resource URI.
        /// </summary>
        /// <value>The resource URI.</value>
        public string ResourceUri { get; set; }

        /// <summary>
        /// Gets or sets the sip contact.
        /// </summary>
        /// <value>The sip contact.</value>
        public string SipContact { get; set; }

        /// <summary>
        /// Gets or sets the sip expires.
        /// </summary>
        /// <value>The sip expires.</value>
        public string SipExpires { get; set; }

        /// <summary>
        /// Gets or sets the sip registered.
        /// </summary>
        /// <value>The sip registered.</value>
        public string SipRegistered { get; set; }

        /// <summary>
        /// Gets or sets the sip URI.
        /// </summary>
        /// <value>The sip URI.</value>
        public string SipUri { get; set; }

        /// <summary>
        /// Gets or sets the sip user agent.
        /// </summary>
        /// <value>The sip user agent.</value>
        public string SipUserAgent { get; set; }

        /// <summary>
        /// Gets or sets the sub account.
        /// </summary>
        /// <value>The sub account.</value>
        public object SubAccount { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>The username.</value>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        public string Password { get; set; }

        public override string ToString()
        {
            return  "StatusCode: " + StatusCode + "\n"+
                    "api_id: " + ApiId + "\n"+
                    "Alias: " + Alias + "\n" +
                   "Application: " + Application + "\n" +
                   "EndpointId: " + EndpointId + "\n" +
                   "Password: " + Password + "\n" +
                   "ResourceUri: " + ResourceUri + "\n" +
                   "SipRegistered: " + SipRegistered + "\n" +
                   "SipUri: " + SipUri + "\n" +
                   "SubAccount: " + SubAccount + "\n" +
                   "Username: " + Username + "\n";
        }
        
        #region Delete
        /// <summary>
        /// Delete Endpoint with the specified endpointId.
        /// </summary>
        /// <returns>The delete.</returns>
        public DeleteResponse<Endpoint> Delete()
        {
            return ((EndpointInterface) Interface).Delete(Id);
        }
        /// <summary>
        /// Asynchronously delete Endpoint with the specified endpointId.
        /// </summary>
        /// <returns>The delete.</returns>
        /// <param name="callbackUrl">Callback URL.</param>
        /// <param name="callbackMethod">Callback method.</param>
        public async Task<AsyncResponse> DeleteAsync(string callbackUrl = null, string callbackMethod = null)
        {
            return await ((EndpointInterface)Interface).DeleteAsync(Id, callbackUrl, callbackMethod);
        }
        #endregion

        #region Update
        /// <summary>
        /// Update Endpoint with the specified endpointId, password, alias and appId.
        /// </summary>
        /// <returns>The update.</returns>
        /// <param name="password">Password.</param>
        /// <param name="alias">Alias.</param>
        /// <param name="appId">App identifier.</param>
        public UpdateResponse<Endpoint> Update(
            string password = null, string alias = null,
            string appId = null)
        {
            var updateResponse =
                ((EndpointInterface) Interface)
                .Update(Id, password, alias, appId);

            if (password != null) Password = password;
            if (alias != null) Alias = alias;
            if (appId != null)
                Application =
                    "/v1/Account/" +
                    ((EndpointInterface) Interface).Client.GetAuthId() +
                    "/Application/" +
                    appId +
                    "/";

            return updateResponse;
        }
        /// <summary>
        /// Asynchronously update Endpoint with the specified endpointId, password, alias and appId.
        /// </summary>
        /// <returns>The update.</returns>
        /// <param name="password">Password.</param>
        /// <param name="alias">Alias.</param>
        /// <param name="appId">App identifier.</param>
        /// <param name="callbackUrl">Callback URL.</param>
        /// <param name="callbackMethod">Callback method.</param>
        public async Task<AsyncResponse> UpdateAsync(
            string password = null, string alias = null,
            string appId = null, string callbackUrl = null, string callbackMethod = null)
        {
            var updateResponse = await
                ((EndpointInterface)Interface)
                .UpdateAsync(Id, password, alias, appId, callbackUrl, callbackMethod);

            if (password != null) Password = password;
            if (alias != null) Alias = alias;
            if (appId != null)
                Application =
                    "/v1/Account/" +
                    ((EndpointInterface)Interface).Client.GetAuthId() +
                    "/Application/" +
                    appId +
                    "/";

            return updateResponse;
        }
        #endregion
    }
}