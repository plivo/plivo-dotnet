using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        /// <summary>
        /// Create Application with the specified appName, answerUrl, answerMethod, hangupUrl, hangupMethod, fallbackAnswerUrl,
        /// fallbackMethod, messageUrl, messageMethod, defaultNumberApp, defaultEndpointApp and subaccount.
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
        /// <param name="logIncomingMessage">Log Incoming message .</param>
        public ApplicationCreateResponse Create(
            string appName, string answerUrl = null, string answerMethod = null,
            string hangupUrl = null, string hangupMethod = null,
            string fallbackAnswerUrl = null, string fallbackMethod = null,
            string messageUrl = null, string messageMethod = null,
            string defaultNumberApp = null, string defaultEndpointApp = null,
            string subaccount = null, bool? logIncomingMessage = null)
        {
            var mandatoryParams = new List<string> {"appName"}
                ;
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
                    logIncomingMessage
                });
            return Client.Update<ApplicationCreateResponse>(Uri, data).Object;
        }

        /// <summary>
        /// Get Application with the specified appId.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="appId">App identifier.</param>
        public Application Get(string appId)
        {
            var application = GetResource<Application>(appId);
            application.Interface = this;
            return application;
        }

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
            var mandatoryParams = new List<string> {""};
            var data = CreateData(
                mandatoryParams, new {subaccount, limit, offset});

            var resources = ListResources<ListResponse<Application>>(data);
            resources.Objects.ForEach(
                (obj) => obj.Interface = this
            );

            return resources;
        }

        /// <summary>
        /// Delete Application with the specified appId.
        /// </summary>
        /// <returns>The delete.</returns>
        /// <param name="appId">App identifier.</param>
        public DeleteResponse<Application> Delete(string appId)
        {
            return DeleteResource<DeleteResponse<Application>>(appId);
        }

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
        /// <param name="logIncomingMessage">Log Incoming message .</param>
        public UpdateResponse<Application> Update(
            string appId, string answerUrl = null, string answerMethod = null,
            string hangupUrl = null, string hangupMethod = null,
            string fallbackAnswerUrl = null, string fallbackMethod = null,
            string messageUrl = null, string messageMethod = null,
            bool? defaultNumberApp = null, bool? defaultEndpointApp = null,
            string subaccount = null, bool? logIncomingMessage = null)
        {
            var mandatoryParams = new List<string> {""};
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
                    logIncomingMessage
                });
            return Client.Update<UpdateResponse<Application>>(Uri + appId + "/", data).Object;
        }
    }
}