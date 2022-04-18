using System;
using System.Threading.Tasks;
using Plivo.Client;

namespace Plivo.Resource.Application
{
    /// <summary>
    /// Application.
    /// </summary>
    public class Application : Resource
    {
        public new string Id => AppId;
        public string AnswerMethod { get; set; }
        public string AnswerUrl { get; set; }
        public string AppId { get; set; }
        public string AppName { get; set; }
        public bool? DefaultApp { get; set; }
        public bool? DefaultEndpointApp { get; set; }
        public bool? Enabled { get; set; }
        public string FallbackAnswerUrl { get; set; }
        public string FallbackMethod { get; set; }
        public string HangupMethod { get; set; }
        public string HangupUrl { get; set; }
        public string MessageMethod { get; set; }
        public string MessageUrl { get; set; }
        public bool? PublicUri { get; set; }
        public string ResourceUri { get; set; }
        public string SipUri { get; set; }
        public object SubAccount { get; set; }

        public Application()
        {
        }

        #region Delete
        /// <summary>
        /// Delete this instance.
        /// </summary>
        /// <returns>The delete.</returns>
        public DeleteResponse<Application> Delete()
        {
            return ((ApplicationInterface) Interface).Delete(AppId);
        }
        /// <summary>
        /// Asynchronously delete this instance.
        /// </summary>
        /// <returns>The delete.</returns>
        /// <param name="cascade">Cascade.</param>
        /// <param name="newEndpointApplication">New Endpoint Application.</param>
        /// <param name="callbackUrl">Callback URL.</param>
        /// <param name="callbackMethod">Callback method.</param>
        public async Task<AsyncResponse> DeleteAsync(bool? cascade = null, string newEndpointApplication = null,
            string callbackUrl = null, string callbackMethod = null)
        {
            return await ((ApplicationInterface)Interface).DeleteAsync(AppId, cascade, newEndpointApplication,
                callbackUrl, callbackMethod);
        }
        #endregion

        #region Update
        /// <summary>
        /// Update the specified answerUrl, answerMethod, hangupUrl, hangupMethod, fallbackAnswerUrl, fallbackMethod,
        /// messageUrl, messageMethod, defaultNumberApp, defaultEndpointApp and subaccount.
        /// </summary>
        /// <returns>The update.</returns>
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
        public UpdateResponse<Application> Update(
            string answerUrl = null, string answerMethod = null,
            string hangupUrl = null, string hangupMethod = null,
            string fallbackAnswerUrl = null, string fallbackMethod = null,
            string messageUrl = null, string messageMethod = null,
            bool? defaultNumberApp = null, bool? defaultEndpointApp = null,
            string subaccount = null)
        {
            var updateResponse = ((ApplicationInterface)Interface).Update(
                AppId, answerUrl, answerMethod, hangupUrl, hangupMethod,
                fallbackAnswerUrl, fallbackMethod, messageUrl, messageMethod,
                defaultNumberApp, defaultEndpointApp, subaccount);

            if (answerUrl != null) AnswerUrl = answerUrl;
            if (answerMethod != null) AnswerMethod = answerMethod;
            if (hangupUrl != null) HangupUrl = hangupUrl;
            if (hangupMethod != null) HangupMethod = hangupMethod;
            if (fallbackAnswerUrl != null) FallbackAnswerUrl = fallbackAnswerUrl;
            if (fallbackMethod != null) FallbackMethod = fallbackMethod;
            if (messageUrl != null) MessageUrl = messageUrl;
            if (messageMethod != null) MessageMethod = messageMethod;
            if (defaultNumberApp != null) DefaultApp = defaultNumberApp;
            if (defaultEndpointApp != null) DefaultEndpointApp = defaultEndpointApp;
            if (subaccount != null) SubAccount = subaccount;

            return updateResponse;
        }
        /// <summary>
        /// Asynchronously update the specified answerUrl, answerMethod, hangupUrl, hangupMethod, fallbackAnswerUrl, fallbackMethod,
        /// messageUrl, messageMethod, defaultNumberApp, defaultEndpointApp and subaccount.
        /// </summary>
        /// <returns>The update.</returns>
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
        /// <param name="callbackUrl">Callback URL.</param>
        /// <param name="callbackMethod">Callback Method.</param>
        /// <param name="logIncomingMessages">Log incoming messages.</param>
        /// <param name="publicUri">Public URI.</param>
        public async Task<AsyncResponse> UpdateAsync(
            string answerUrl = null, string answerMethod = null,
            string hangupUrl = null, string hangupMethod = null,
            string fallbackAnswerUrl = null, string fallbackMethod = null,
            string messageUrl = null, string messageMethod = null,
            bool? defaultNumberApp = null, bool? defaultEndpointApp = null,
            string subaccount = null, bool? logIncomingMessages = null, bool? publicUri = null,
            string callbackUrl = null, string callbackMethod = null)
        {
            var updateResponse = await ((ApplicationInterface) Interface).UpdateAsync(
                AppId, answerUrl, answerMethod, hangupUrl, hangupMethod,
                fallbackAnswerUrl, fallbackMethod, messageUrl, messageMethod,
                defaultNumberApp, defaultEndpointApp, subaccount, logIncomingMessages,
                publicUri, callbackUrl, callbackMethod);

            if (answerUrl != null) AnswerUrl = answerUrl;
            if (answerMethod != null) AnswerMethod = answerMethod;
            if (hangupUrl != null) HangupUrl = hangupUrl;
            if (hangupMethod != null) HangupMethod = hangupMethod;
            if (fallbackAnswerUrl != null) FallbackAnswerUrl = fallbackAnswerUrl;
            if (fallbackMethod != null) FallbackMethod = fallbackMethod;
            if (messageUrl != null) MessageUrl = messageUrl;
            if (messageMethod != null) MessageMethod = messageMethod;
            if (defaultNumberApp != null) DefaultApp = defaultNumberApp;
            if (defaultEndpointApp != null) DefaultEndpointApp = defaultEndpointApp;
            if (subaccount != null) SubAccount = subaccount;

            return updateResponse;
        }
        #endregion
        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:plivo.Resource.Application.Application"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:plivo.Resource.Application.Application"/>.</returns>
        public override string ToString()
        {
            return "AnswerMethod: " + AnswerMethod + "\n" +
                   "AnswerUrl: " + AnswerUrl + "\n" +
                   "AppId: " + AppId + "\n" +
                   "AppName: " + AppName + "\n" +
                   "DefaultApp: " + DefaultApp + "\n" +
                   "DefaultEndpointApp: " + DefaultEndpointApp + "\n" +
                   "Enabled: " + Enabled + "\n" +
                   "FallbackAnswerUrl: " + FallbackAnswerUrl + "\n" +
                   "FallbackMethod: " + FallbackMethod + "\n" +
                   "HangupMethod: " + HangupMethod + "\n" +
                   "HangupUrl: " + HangupUrl + "\n" +
                   "MessageMethod: " + MessageMethod + "\n" +
                   "MessageUrl: " + MessageUrl + "\n" +
                   "PublicUri: " + PublicUri + "\n" +
                   "ResourceUri: " + ResourceUri + "\n" +
                   "SipUri: " + SipUri + "\n" +
                   "SubAccount: " + SubAccount + "\n";
        }
    }
}