using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Plivo.Client;
using Newtonsoft.Json.Linq;
using Plivo.Utilities;


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
            var mandatoryParams = new List<string> { "" };
            bool isVoiceRequest = true;
            var data = CreateData(
                mandatoryParams,
                new
                {
                    username,
                    password,
                    alias,
                    appId,
                    isVoiceRequest
                });

            return ExecuteWithExceptionUnwrap(() =>
            {
                var result = Task.Run(async () => await Client.Update<EndpointCreateResponse>(Uri, data).ConfigureAwait(false)).Result;
                result.Object.StatusCode = result.StatusCode;
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
        /// <param name="callbackUrl">Callback URL.</param>
        /// <param name="callbackMethod">Callback Method.</param>
        public async Task<AsyncResponse> CreateAsync(
            string username, string password, string alias, string appId = null,
            string callbackUrl = null, string callbackMethod = null)
        {
            MpcUtils.ValidUrl("callbackUrl", callbackUrl, true);
            var mandatoryParams = new List<string> { "" };
            bool isVoiceRequest = true;
            var data = CreateData(
                mandatoryParams,
                new
                {
                    username,
                    password,
                    alias,
                    appId,
                    callbackUrl,
                    callbackMethod,
                    isVoiceRequest
                });
            if (data.ContainsKey("callback_method") && callbackMethod == null) {
                data.Remove("callback_method");
            }
            var result = Task.Run(async () => await Client.Update<AsyncResponse>(Uri, data).ConfigureAwait(false)).Result;
            await Task.WhenAll();
            result.Object.StatusCode = result.StatusCode;
            JObject responseJson = JObject.Parse(result.Content);
            result.Object.ApiId = responseJson["api_id"].ToString();
            result.Object.Message = responseJson["message"].ToString();
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
                var endpoint = Task.Run(async () => await GetResource<Endpoint>(endpointId, new Dictionary<string, object> () { {"is_voice_request", true} }).ConfigureAwait(false)).Result;
                endpoint.Interface = this;
                return endpoint;
            });
        }

        /// <summary>
        /// Asynchronous get Endpoint with the specified endpointId.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="endpointId">App identifier.</param>
        /// <param name="callbackUrl">Callback URL.</param>
        /// <param name="callbackMethod">Callback method.</param>
        public async Task<AsyncResponse> GetAsync(string endpointId, string callbackUrl = null, string callbackMethod = null)
        {
            MpcUtils.ValidUrl("callbackUrl", callbackUrl, true);
            var data = new Dictionary<string, object>()
            {
                {"is_voice_request", true},
                {"callback_url", callbackUrl},
                {"callback_method", callbackMethod}
            };
            if (data.ContainsKey("callback_method") && callbackMethod == null) {
                data.Remove("callback_method");
            }
            var result = Task.Run(async () => await Client.Fetch<AsyncResponse>(
                Uri + endpointId + "/", data).ConfigureAwait(false)).Result;
            await Task.WhenAll();
            result.Object.StatusCode = result.StatusCode;
            JObject responseJson = JObject.Parse(result.Content);
            result.Object.ApiId = responseJson["api_id"].ToString();
            result.Object.Message = responseJson["message"].ToString();
            return result.Object;
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
            var mandatoryParams = new List<string> { "" };
            bool isVoiceRequest = true;
            var data = CreateData(
                mandatoryParams, new { subaccount, limit, offset, isVoiceRequest});

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
        /// <param name="callbackUrl">Callback URL.</param>
        /// <param name="callbackMethod">Callback method.</param>
        public async Task<AsyncResponse> ListAsync(
            string subaccount = null, uint? limit = null, uint? offset = null,
            string callbackUrl = null, string callbackMethod = null)
        {
            MpcUtils.ValidUrl("callbackUrl", callbackUrl, true);
            var mandatoryParams = new List<string> { "" };
            bool isVoiceRequest = true;
            var data = CreateData(
                mandatoryParams, new { subaccount, limit, offset, callbackUrl, callbackMethod, isVoiceRequest });
            if (data.ContainsKey("callback_method") && callbackMethod == null) {
                data.Remove("callback_method");
            }
            var result = Task.Run(async () => await Client.Fetch<AsyncResponse>(
                Uri, data).ConfigureAwait(false)).Result;
            await Task.WhenAll();
            result.Object.StatusCode = result.StatusCode;
            JObject responseJson = JObject.Parse(result.Content);
            result.Object.ApiId = responseJson["api_id"].ToString();
            result.Object.Message = responseJson["message"].ToString();
            return result.Object;
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
                return Task.Run(async () => await DeleteResource<DeleteResponse<Endpoint>>(endpointId, new Dictionary<string, object> () { {"is_voice_request", true} }).ConfigureAwait(false)).Result;
            });
        }
        /// <summary>
        /// Asynchronously delete Endpoint with the specified endpointId.
        /// </summary>
        /// <returns>The delete.</returns>
        /// <param name="endpointId">Endpoint identifier.</param>
        /// <param name="callbackUrl">Callback URL.</param>
        /// <param name="callbackMethod">Callback method.</param>
        public async Task<AsyncResponse> DeleteAsync(string endpointId, 
            string callbackUrl = null, string callbackMethod = null)
        {
            MpcUtils.ValidUrl("callbackUrl", callbackUrl, true);
            var data = new Dictionary<string, object>()
            {
                {"is_voice_request", true},
                {"callback_url", callbackUrl},
                {"callback_method", callbackMethod}
            };
            if (data.ContainsKey("callback_method") && callbackMethod == null) {
                data.Remove("callback_method");
            }
            var result = Task.Run(async () => await Client.Delete<AsyncResponse>(
                Uri + endpointId + "/", data).ConfigureAwait(false)).Result;
            await Task.WhenAll();
            result.Object.StatusCode = result.StatusCode;
            return result.Object;
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
            var mandatoryParams = new List<string> { "" };
            bool isVoiceRequest = true;
            var data = CreateData(
                mandatoryParams,
                new
                {
                    password,
                    alias,
                    appId,
                    isVoiceRequest
                });

            return ExecuteWithExceptionUnwrap(() =>
            {
                var result = Task.Run(async () => await Client.Update<UpdateResponse<Endpoint>>(Uri + endpointId + "/", data).ConfigureAwait(false)).Result;
                result.Object.StatusCode = result.StatusCode;
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
        /// <param name="callbackUrl">Callback URL.</param>
        /// <param name="callbackMethod">Callback Method.</param>
        public async Task<AsyncResponse> UpdateAsync(
            string endpointId, string password = null, string alias = null,
            string appId = null, string callbackUrl = null, string callbackMethod = null)
        {
            MpcUtils.ValidUrl("callbackUrl", callbackUrl, true);
            var mandatoryParams = new List<string> { "" };
            bool isVoiceRequest = true;
            var data = CreateData(
                mandatoryParams,
                new
                {
                    password,
                    alias,
                    appId,
                    callbackUrl,
                    callbackMethod,
                    isVoiceRequest
                });
            if (data.ContainsKey("callback_method") && callbackMethod == null) {
                data.Remove("callback_method");
            }
            var result = Task.Run(async () => await Client.Update<AsyncResponse>(Uri + endpointId + "/", data).ConfigureAwait(false)).Result;
            await Task.WhenAll();
            result.Object.StatusCode = result.StatusCode;
            JObject responseJson = JObject.Parse(result.Content);
            result.Object.ApiId = responseJson["api_id"].ToString();
            result.Object.Message = responseJson["message"].ToString();
            return result.Object;
        }
        #endregion
    }
}