using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Plivo.Client;
using Plivo.Http;


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
            var mandatoryParams = new List<string> { "appName" }
                ;
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

        public async Task<ApplicationCreateResponse> CreateAsync(
            string appName, string answerUrl = null, string answerMethod = null,
            string hangupUrl = null, string hangupMethod = null,
            string fallbackAnswerUrl = null, string fallbackMethod = null,
            string messageUrl = null, string messageMethod = null,
            string defaultNumberApp = null, string defaultEndpointApp = null,
            string subaccount = null, bool? logIncomingMessages = null, bool? publicUri = null)
        {
            var mandatoryParams = new List<string> {"appName"}
                ;
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

            var result = await Client.Update<ApplicationCreateResponse>(Uri, data);
            result.Object.StatusCode = result.StatusCode;
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
        public async Task<Application> GetAsync(string appId)
        {
            var application = await GetResource<Application>(appId, new Dictionary<string, object> () { {"is_voice_request", true} });
            application.Interface = this;
            return application;
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
        public async Task<ListResponse<Application>> ListAsync(
            string subaccount = null, uint? limit = null, uint? offset = null)
        {
            var mandatoryParams = new List<string> {""};
            bool isVoiceRequest = true;
            var data = CreateData(
                mandatoryParams, new {subaccount, limit, offset, isVoiceRequest});

            var resources = await ListResources<ListResponse<Application>>(data);
            resources.Objects.ForEach(
                (obj) => obj.Interface = this
            );

            return resources;
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
        public async Task<DeleteResponse<Application>> DeleteAsync(string appId, bool? cascade = null, string newEndpointApplication = null)
        {
            var data = new Dictionary<string, object> { };
            bool isVoiceRequest = true;
            data = CreateData(new List<string> { }, new { cascade, newEndpointApplication, isVoiceRequest });
            return await DeleteResource<DeleteResponse<Application>>(appId, data);
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

        public async Task<UpdateResponse<Application>> UpdateAsync(
            string appId, string answerUrl = null, string answerMethod = null,
            string hangupUrl = null, string hangupMethod = null,
            string fallbackAnswerUrl = null, string fallbackMethod = null,
            string messageUrl = null, string messageMethod = null,
            bool? defaultNumberApp = null, bool? defaultEndpointApp = null,
            string subaccount = null, bool? logIncomingMessages = null, bool? publicUri = null)
        {
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
                    publicUri
                });

            var result = await Client.Update<UpdateResponse<Application>>(Uri + appId + "/", data);
            result.Object.StatusCode = result.StatusCode;
            return result.Object;
        }
        #endregion
    }
}
