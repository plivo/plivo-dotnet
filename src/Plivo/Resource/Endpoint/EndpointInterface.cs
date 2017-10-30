using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Plivo.Client;


namespace Plivo.Resource.Endpoint
{
    /// <summary>
    /// Endpoint interface.
    /// </summary>
    public class EndpointInterface :ResourceInterface
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:plivo.Resource.Endpoint.EndpointInterface"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        public EndpointInterface(HttpClient client) : base(client)
        {
            Uri = "Account/" + Client.GetAuthId() + "/Endpoint/";
        }

        /// <summary>
        /// Create Endpoint with the specified username, password, alias and appId.
        /// </summary>
        /// <returns>The create.</returns>
        /// <param name="username">Username.</param>
        /// <param name="password">Password.</param>
        /// <param name="alias">Alias.</param>
        /// <param name="appId">App identifier.</param>
        public EndpointCreateResponse Create(
            string username, string password, string alias, string appId = null)
        {
            var mandatory_params = new List<string> { "" };var data = CreateData(
                mandatory_params,
                new 
                {
                    username, password, alias, appId
                });
            return Client.Update<EndpointCreateResponse>(Uri, data).Object;
        }

        /// <summary>
        /// Get Endpoint with the specified endpointId.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="endpointId">App identifier.</param>
        public Endpoint Get(string endpointId)
        {
            var endpoint = GetResource<Endpoint>(endpointId);
            endpoint.Interface = this;
            return endpoint;
        }

        /// <summary>
        /// List Endpoint with the specified subaccount, limit and offset.
        /// </summary>
        /// <returns>The list.</returns>
        /// <param name="subaccount">Subaccount.</param>
        /// <param name="limit">Limit.</param>
        /// <param name="offset">Offset.</param>
        public ListResponse<Endpoint> List(
            string subaccount = null, uint? limit = null, uint? offset = null)
        {
            var mandatory_params = new List<string> { "" };var data = CreateData(
                mandatory_params,new {subaccount, limit, offset});
            var resources = ListResources<ListResponse<Endpoint>>(data);
            resources.Objects.Select(obj => obj.Interface = this);
            return resources;
        }

        /// <summary>
        /// Delete Endpoint with the specified endpointId.
        /// </summary>
        /// <returns>The delete.</returns>
        /// <param name="endpointId">Endpoint identifier.</param>
        public DeleteResponse<Endpoint> Delete(string endpointId)
        {
            return DeleteResource<DeleteResponse<Endpoint>>(endpointId);
        }

        /// <summary>
        /// Update Endpoint with the specified endpointId, password, alias and appId.
        /// </summary>
        /// <returns>The update.</returns>
        /// <param name="endpointId">Endpoint identifier.</param>
        /// <param name="password">Password.</param>
        /// <param name="alias">Alias.</param>
        /// <param name="appId">App identifier.</param>
        public UpdateResponse<Endpoint> Update(
            string endpointId, string password = null, string alias = null,
            string appId = null)
        {
            var mandatory_params = new List<string> { "" };var data = CreateData(
                mandatory_params,
                new
                {
                    password, alias, appId
                });
            return Client.Update<UpdateResponse<Endpoint>>(Uri + endpointId + "/", data).Object;
        }
    }
}
