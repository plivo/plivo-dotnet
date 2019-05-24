using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Plivo.Client;


namespace Plivo.Resource.Endpoint
{
    /// <summary>
    /// Endpoint interface.
    /// </summary>
    public class EndpointInterface : ResourceInterface
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:plivo.Resource.Endpoint.EndpointInterface"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        public EndpointInterface(HttpClient client) : base(client)
        {
            Uri = "Account/" + Client.GetAuthId() + "/Endpoint/";
        }

        #region Create
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
            var mandatoryParams = new List<string> {""};
            var data = CreateData(
                mandatoryParams,
                new
                {
                    username,
                    password,
                    alias,
                    appId
                });

			return ExecuteWithExceptionUnwrap(() =>
			{
				var result = Task.Run(async () => await Client.Update<EndpointCreateResponse>(Uri, data).ConfigureAwait(false)).Result;
				return result.Object;
			});

        }
        /// <summary>
        /// Asynchronous create Endpoint with the specified username, password, alias and appId.
        /// </summary>
        /// <returns>The create.</returns>
        /// <param name="username">Username.</param>
        /// <param name="password">Password.</param>
        /// <param name="alias">Alias.</param>
        /// <param name="appId">App identifier.</param>
        public async Task<EndpointCreateResponse> CreateAsync(
            string username, string password, string alias, string appId = null)
        {
            var mandatoryParams = new List<string> { "" };
            var data = CreateData(
                mandatoryParams,
                new
                {
                    username,
                    password,
                    alias,
                    appId
                });
            var result = await Client.Update<EndpointCreateResponse>(Uri, data);
            return result.Object;
        }
        #endregion

        #region Get
        /// <summary>
        /// Get Endpoint with the specified endpointId.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="endpointId">App identifier.</param>
        public Endpoint Get(string endpointId)
        {
			return ExecuteWithExceptionUnwrap(() =>
			{
				var endpoint = Task.Run(async () => await GetResource<Endpoint>(endpointId).ConfigureAwait(false)).Result;
				endpoint.Interface = this;
				return endpoint;
			});
        }

        /// <summary>
        /// Asynchronous get Endpoint with the specified endpointId.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="endpointId">App identifier.</param>
        public async Task<Endpoint> GetAsync(string endpointId)
        {
            var endpoint = await GetResource<Endpoint>(endpointId);
            endpoint.Interface = this;
            return endpoint;
        }
        #endregion

        #region List
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
            var mandatoryParams = new List<string> {""};
            var data = CreateData(
                mandatoryParams, new {subaccount, limit, offset});

			return ExecuteWithExceptionUnwrap(() =>
			{
				var resources = Task.Run(async () => await ListResources<ListResponse<Endpoint>>(data).ConfigureAwait(false)).Result;

				resources.Objects.ForEach(
					(obj) => obj.Interface = this
				);

				return resources;
			});
        }
        /// <summary>
        /// List Endpoint with the specified subaccount, limit and offset.
        /// </summary>
        /// <returns>The list.</returns>
        /// <param name="subaccount">Subaccount.</param>
        /// <param name="limit">Limit.</param>
        /// <param name="offset">Offset.</param>
        public async Task<ListResponse<Endpoint>> ListAsync(
            string subaccount = null, uint? limit = null, uint? offset = null)
        {
            var mandatoryParams = new List<string> { "" };
            var data = CreateData(
                mandatoryParams, new { subaccount, limit, offset });
            var resources = await ListResources<ListResponse<Endpoint>>(data);

            resources.Objects.ForEach(
                (obj) => obj.Interface = this
            );

            return resources;
        }
        #endregion

        #region Delete
        /// <summary>
        /// Delete Endpoint with the specified endpointId.
        /// </summary>
        /// <returns>The delete.</returns>
        /// <param name="endpointId">Endpoint identifier.</param>
        public DeleteResponse<Endpoint> Delete(string endpointId)
        {
			return ExecuteWithExceptionUnwrap(() =>
			{
				return Task.Run(async () => await DeleteResource<DeleteResponse<Endpoint>>(endpointId).ConfigureAwait(false)).Result;
			});
        }
        /// <summary>
        /// Asynchronously delete Endpoint with the specified endpointId.
        /// </summary>
        /// <returns>The delete.</returns>
        /// <param name="endpointId">Endpoint identifier.</param>
        public async Task<DeleteResponse<Endpoint>> DeleteAsync(string endpointId)
        {
            return await DeleteResource<DeleteResponse<Endpoint>>(endpointId);
        }
        #endregion

        #region Update
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
            var mandatoryParams = new List<string> {""};
            var data = CreateData(
                mandatoryParams,
                new
                {
                    password,
                    alias,
                    appId
                });

			return ExecuteWithExceptionUnwrap(() =>
			{
				var result = Task.Run(async () => await Client.Update<UpdateResponse<Endpoint>>(Uri + endpointId + "/", data).ConfigureAwait(false)).Result;
				return result.Object;
			});
        }
        /// <summary>
        /// Asynchronously update Endpoint with the specified endpointId, password, alias and appId.
        /// </summary>
        /// <returns>The update.</returns>
        /// <param name="endpointId">Endpoint identifier.</param>
        /// <param name="password">Password.</param>
        /// <param name="alias">Alias.</param>
        /// <param name="appId">App identifier.</param>
        public async Task<UpdateResponse<Endpoint>> UpdateAsync(
            string endpointId, string password = null, string alias = null,
            string appId = null)
        {
            var mandatoryParams = new List<string> { "" };
            var data = CreateData(
                mandatoryParams,
                new
                {
                    password,
                    alias,
                    appId
                });
            var result = await Client.Update<UpdateResponse<Endpoint>>(Uri + endpointId + "/", data);
            return result.Object;
        }
        #endregion
    }
}