using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Plivo.Client;
using Plivo.Http;
using Plivo.Utilities;


namespace Plivo.Resource.Application
{
    /// <summary>
    /// Application interface.
    /// </summary>
    public class ApplicationInterface : ResourceInterface
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:plivo.Resource.Application.ApplicationInterface"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        public ApplicationInterface(HttpClient client) : base(client)
        {
            Uri = "Account/" + Client.GetAuthId() + "/Application/";
        }

        #region Create
        /// <summary>
        /// Create Application with the specified appName, answerUrl, answerMethod, hangupUrl, hangupMethod, fallbackAnswerUrl,
        /// fallbackMethod, messageUrl, messageMethod, defaultNumberApp, defaultEndpointApp, subaccount and logIncomingMessages.
        /// </summary>
        /// <returns>The create.</returns>
        /// <param name="appName">App name.</param>
        /// <param name="answerUrl">Answer URL.</param>
        /// <param name="answerMethod">Answer method.</param>
        /// <param name="hangupUrl">Hangup URL.</param>
        /// <param name="hangupMethod">Hangup method.</param>
        /// <param name="fallbackAnswerUrl">Fallback answer URL.</param>
        /// <param name="fallbackMethod">Fallback method.</param>
        /// <param name="messageUrl">Message URL.</param>
        /// <param name="messageMethod">Message method.</param>
        /// <param name="defaultNumberApp">Default number app.</param>
        /// <param name="defaultEndpointApp">Default endpoint app.</param>
        /// <param name="subaccount">Subaccount.</param>
        /// <param name="logIncomingMessages">Log incoming messages.</param>
        /// <param name="publicUri">Public URI.</param>

        public ApplicationCreateResponse Create(
            string appName, string answerUrl = null, string answerMethod = null,
            string hangupUrl = null, string hangupMethod = null,
            string fallbackAnswerUrl = null, string fallbackMethod = null,
            string messageUrl = null, string messageMethod = null,
            string defaultNumberApp = null, string defaultEndpointApp = null,
            string subaccount = null, bool? logIncomingMessages = null, bool? publicUri = null)
        {
            var mandatoryParams = new List<string> { "appName" };
            bool isVoiceRequest = true;
            var data = CreateData(
                mandatoryParams,
                new
                {
                    appName,
                    answerUrl,
                    answerMethod,
                    hangupUrl,
                    hangupMethod,
                    fallbackAnswerUrl,
                    fallbackMethod,
                    messageUrl,
                    messageMethod,
                    defaultNumberApp,
                    defaultEndpointApp,
                    subaccount,
                    logIncomingMessages,
                    isVoiceRequest,
                    publicUri
                });

			return ExecuteWithExceptionUnwrap(() =>
			{
				var result = Task.Run(async () => await Client.Update<ApplicationCreateResponse>(Uri, data).ConfigureAwait(false)).Result;
                result.Object.StatusCode = result.StatusCode;
				return result.Object;
			});
		}
        /// <summary>
        /// Asynchronously create Application with the specified appName, answerUrl, answerMethod, hangupUrl, hangupMethod, fallbackAnswerUrl,
        /// fallbackMethod, messageUrl, messageMethod, defaultNumberApp, defaultEndpointApp, subaccount and logIncomingMessages.
        /// </summary>
        /// <returns>The create.</returns>
        /// <param name="appName">App name.</param>
        /// <param name="answerUrl">Answer URL.</param>
        /// <param name="answerMethod">Answer method.</param>
        /// <param name="hangupUrl">Hangup URL.</param>
        /// <param name="hangupMethod">Hangup method.</param>
        /// <param name="fallbackAnswerUrl">Fallback answer URL.</param>
        /// <param name="fallbackMethod">Fallback method.</param>
        /// <param name="messageUrl">Message URL.</param>
        /// <param name="messageMethod">Message method.</param>
        /// <param name="defaultNumberApp">Default number app.</param>
        /// <param name="defaultEndpointApp">Default endpoint app.</param>
        /// <param name="subaccount">Subaccount.</param>
        /// <param name="logIncomingMessages">Log incoming messages.</param>
        /// <param name="publicUri">Public URI.</param>
        /// <param name="callbackUrl">Callback URL.</param>
        /// <param name="callbackMethod">Callback method.</param>

        public async Task<AsyncResponse> CreateAsync(
            string appName, string answerUrl = null, string answerMethod = null,
            string hangupUrl = null, string hangupMethod = null,
            string fallbackAnswerUrl = null, string fallbackMethod = null,
            string messageUrl = null, string messageMethod = null,
            string defaultNumberApp = null, string defaultEndpointApp = null,
            string subaccount = null, bool? logIncomingMessages = null, bool? publicUri = null,
            string callbackUrl = null, string callbackMethod = null)
        {
            var mandatoryParams = new List<string> {"appName"};
            MpcUtils.ValidUrl("callbackUrl", callbackUrl, true);
            bool isVoiceRequest = true;
            var data = CreateData(
                mandatoryParams,
                new
                {
                    appName,
                    answerUrl,
                    answerMethod,
                    hangupUrl,
                    hangupMethod,
                    fallbackAnswerUrl,
                    fallbackMethod,
                    messageUrl,
                    messageMethod,
                    defaultNumberApp,
                    defaultEndpointApp,
                    subaccount,
                    logIncomingMessages,
                    isVoiceRequest,
                    publicUri,
                    callbackUrl,
                    callbackMethod
                });

            if (callbackMethod == null)
            {
                data.Remove(callbackMethod);
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
        /// Get Application with the specified appId.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="appId">App identifier.</param>
        public Application Get(string appId)
        {
			return ExecuteWithExceptionUnwrap(() =>
			{
				var application = Task.Run(async () => await GetResource<Application>(appId, new Dictionary<string, object> () { {"is_voice_request", true} }).ConfigureAwait(false)).Result;
				application.Interface = this;
				return application;
			});
		}
        /// <summary>
        /// Asynchronously get Application with the specified appId.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="appId">App identifier.</param>
        /// <param name="callbackUrl">Callback URL.</param>
        /// <param name="callbackMethod">Callback method.</param>
        public async Task<AsyncResponse> GetAsync(string appId, string callbackUrl = null, string callbackMethod = null)
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
                Uri + appId + "/", data).ConfigureAwait(false)).Result;
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
        /// List Application with the specified subaccount, limit and offset.
        /// </summary>
        /// <returns>The list.</returns>
        /// <param name="subaccount">Subaccount.</param>
        /// <param name="limit">Limit.</param>
        /// <param name="offset">Offset.</param>
        public ListResponse<Application> List(
            string subaccount = null, uint? limit = null, uint? offset = null)
        {
            var mandatoryParams = new List<string> { "" };
            bool isVoiceRequest = true;
            var data = CreateData(
                mandatoryParams, new { subaccount, limit, offset, isVoiceRequest });

			return ExecuteWithExceptionUnwrap(() =>
			{
				var resources = Task.Run(async () => await ListResources<ListResponse<Application>>(data).ConfigureAwait(false)).Result;
				resources.Objects.ForEach(
					(obj) => obj.Interface = this
				);

				return resources;
			});
		}
        /// <summary>
        /// List Application with the specified subaccount, limit and offset.
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
            var mandatoryParams = new List<string> {""};
            bool isVoiceRequest = true;
            var data = CreateData(
                mandatoryParams, new {subaccount, limit, offset, callbackUrl, callbackMethod, isVoiceRequest});
            
            if (callbackMethod == null)
            {
                data.Remove(callbackMethod);
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
        /// Delete Application with the specified appId.
        /// </summary>
        /// <returns>The delete.</returns>
        /// <param name="appId">App identifier.</param>
        /// <param name="cascade">Cascade.</param>
        /// <param name="newEndpointApplication">New Endpoint Application.</param>
        public DeleteResponse<Application> Delete(string appId, bool? cascade = null, string newEndpointApplication = null)
        {
            var data = new Dictionary<string, object> {};
            bool isVoiceRequest = true;
            data = CreateData(new List<string> {}, new {cascade, newEndpointApplication, isVoiceRequest});

			return ExecuteWithExceptionUnwrap(() =>
			{
				return Task.Run(async () => await DeleteResource<DeleteResponse<Application>>(appId, data).ConfigureAwait(false)).Result;
			});
		}
        /// <summary>
        /// Asynchronously delete Application with the specified appId.
        /// </summary>
        /// <returns>The delete.</returns>
        /// <param name="appId">App identifier.</param>
        /// <param name="cascade">Cascade.</param>
        /// <param name="newEndpointApplication">New Endpoint Application.</param>
        /// <param name="callbackUrl">Callback URL.</param>
        /// <param name="callbackMethod">Callback method.</param>
        public async Task<AsyncResponse> DeleteAsync(string appId, bool? cascade = null, 
            string newEndpointApplication = null, string callbackUrl = null, string callbackMethod = null)
        {
            MpcUtils.ValidUrl("callbackUrl", callbackUrl, true);
            var data = new Dictionary<string, object> { };
            bool isVoiceRequest = true;
            data = CreateData(new List<string> { }, new
            {
                cascade, 
                newEndpointApplication,
                callbackUrl,
                callbackMethod,
                isVoiceRequest
            });
            if (callbackMethod == null)
            {
                data.Remove(callbackMethod);
            }
            var result = Task.Run(async () => await Client.Delete<AsyncResponse>(
                Uri + appId + "/", data).ConfigureAwait(false)).Result;
            await Task.WhenAll();
            result.Object.StatusCode = result.StatusCode;
            return result.Object;
        }
        #endregion

        #region Update
        /// <summary>
        /// Update Application with the specified appId, answerUrl, answerMethod, hangupUrl, hangupMethod, fallbackAnswerUrl,
        /// fallbackMethod, messageUrl, messageMethod, defaultNumberApp, defaultEndpointApp and subaccount.
        /// </summary>
        /// <returns>The update.</returns>
        /// <param name="appId">App identifier.</param>
        /// <param name="answerUrl">Answer URL.</param>
        /// <param name="answerMethod">Answer method.</param>
        /// <param name="hangupUrl">Hangup URL.</param>
        /// <param name="hangupMethod">Hangup method.</param>
        /// <param name="fallbackAnswerUrl">Fallback answer URL.</param>
        /// <param name="fallbackMethod">Fallback method.</param>
        /// <param name="messageUrl">Message URL.</param>
        /// <param name="messageMethod">Message method.</param>
        /// <param name="defaultNumberApp">Default number app.</param>
        /// <param name="defaultEndpointApp">Default endpoint app.</param>
        /// <param name="subaccount">Subaccount.</param>
        /// <param name="logIncomingMessages">Log incoming messages.</param>
        /// <param name="publicUri">Public URI.</param>

        public UpdateResponse<Application> Update(
            string appId, string answerUrl = null, string answerMethod = null,
            string hangupUrl = null, string hangupMethod = null,
            string fallbackAnswerUrl = null, string fallbackMethod = null,
            string messageUrl = null, string messageMethod = null,
            bool? defaultNumberApp = null, bool? defaultEndpointApp = null,
            string subaccount = null, bool? logIncomingMessages = null, bool? publicUri = null)
        {
            var mandatoryParams = new List<string> { "" };
            bool isVoiceRequest = true;
            var data = CreateData(
                mandatoryParams,
                new
                {
                    answerUrl,
                    answerMethod,
                    hangupUrl,
                    hangupMethod,
                    fallbackAnswerUrl,
                    fallbackMethod,
                    messageUrl,
                    messageMethod,
                    defaultNumberApp,
                    defaultEndpointApp,
                    subaccount,
                    logIncomingMessages,
                    isVoiceRequest,
                    publicUri
                });

			return ExecuteWithExceptionUnwrap(() =>
			{
				var result = Task.Run(async () => await Client.Update<UpdateResponse<Application>>(Uri + appId + "/", data).ConfigureAwait(false)).Result;
                result.Object.StatusCode = result.StatusCode;
				return result.Object;
			});
		}
        /// <summary>
        /// Asynchronously update Application with the specified appId, answerUrl, answerMethod, hangupUrl, hangupMethod, fallbackAnswerUrl,
        /// fallbackMethod, messageUrl, messageMethod, defaultNumberApp, defaultEndpointApp and subaccount.
        /// </summary>
        /// <returns>The update.</returns>
        /// <param name="appId">App identifier.</param>
        /// <param name="answerUrl">Answer URL.</param>
        /// <param name="answerMethod">Answer method.</param>
        /// <param name="hangupUrl">Hangup URL.</param>
        /// <param name="hangupMethod">Hangup method.</param>
        /// <param name="fallbackAnswerUrl">Fallback answer URL.</param>
        /// <param name="fallbackMethod">Fallback method.</param>
        /// <param name="messageUrl">Message URL.</param>
        /// <param name="messageMethod">Message method.</param>
        /// <param name="defaultNumberApp">Default number app.</param>
        /// <param name="defaultEndpointApp">Default endpoint app.</param>
        /// <param name="subaccount">Subaccount.</param>
        /// <param name="logIncomingMessages">Log incoming messages.</param>
        /// <param name="publicUri">Public URI.</param>
        /// <param name="callbackUrl">Callback URL.</param>
        /// <param name="callbackMethod">Callback method.</param>

        public async Task<AsyncResponse> UpdateAsync(
            string appId, string answerUrl = null, string answerMethod = null,
            string hangupUrl = null, string hangupMethod = null,
            string fallbackAnswerUrl = null, string fallbackMethod = null,
            string messageUrl = null, string messageMethod = null,
            bool? defaultNumberApp = null, bool? defaultEndpointApp = null,
            string subaccount = null, bool? logIncomingMessages = null, bool? publicUri = null,
            string callbackUrl = null, string callbackMethod = null)
        {
            MpcUtils.ValidUrl("callbackUrl", callbackUrl, true);
            var mandatoryParams = new List<string> {""};
            bool isVoiceRequest = true;
            var data = CreateData(
                mandatoryParams,
                new
                {
                    answerUrl,
                    answerMethod,
                    hangupUrl,
                    hangupMethod,
                    fallbackAnswerUrl,
                    fallbackMethod,
                    messageUrl,
                    messageMethod,
                    defaultNumberApp,
                    defaultEndpointApp,
                    subaccount,
                    logIncomingMessages,
                    isVoiceRequest,
                    publicUri,
                    callbackUrl,
                    callbackMethod
                });
            if (callbackMethod == null)
            {
                data.Remove(callbackMethod);
            }

            var result = Task.Run(async () => await Client.Update<AsyncResponse>(Uri + appId + "/", data).ConfigureAwait(false)).Result;
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
