using System;
using System.Threading.Tasks;

namespace Plivo.Resource.TollfreeVerification
{
    /// <summary>
    /// TollfreeVerification.
    /// </summary>
    public class TollfreeVerification : Resource
    {
        public string Uuid { get; set; }
        public string ProfileUuid { get; set; }
        public string Number { get; set; }
        public string Usecase { get; set; }
        public string UsecaseSummary { get; set; }
        public string MessageSample { get; set; }
        public string OptinImageUrl { get; set; }
        public string OptinType { get; set; }
        public string Volume { get; set; }
        public string AdditionalInformation { get; set; }
        public string ExtraData { get; set; }
        public string CallbackUrl { get; set; }
        public string CallbackMethod { get; set; }
        public string Status { get; set; }
        public string RejectionReason { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }

        public TollfreeVerification()
        {
        }

        #region Delete

        /// <summary>
        /// Delete this instance.
        /// </summary>
        /// <returns>The delete.</returns>
        public DeleteResponse<TollfreeVerification> Delete()
        {
            return ((TollfreeVerificationInterface)Interface).Delete(Uuid);
        }

        /// <summary>
        /// Asynchronously delete this instance.
        /// </summary>
        /// <returns>The delete.</returns>
        public async Task<AsyncResponse> DeleteAsync()
        {
            return await ((TollfreeVerificationInterface)Interface).DeleteAsync(Uuid);
        }

        #endregion

        #region Update

        /// <summary>
        /// Update Tollfree Verification request with the specified profileUuid, usecase, usecaseSummary, messageSample, optinImageUrl,
        /// optinType, volume, additionalInformation, extraData, callbackUrl, callbackMethod.
        /// </summary>
        /// <returns>The update.</returns>
        /// <param name="profileUuid">The profile UUID.</param>
        /// <param name="usecase">The use case, e.g., "2FA, App Notifications".</param>
        /// <param name="usecaseSummary">The summary of the use case.</param>
        /// <param name="messageSample">Sample messages associated with the use case.</param>
        /// <param name="optinImageUrl">The URL of the opt-in image.</param>
        /// <param name="optinType">The type of opt-in.</param>
        /// <param name="volume">The message volume.</param>
        /// <param name="additionalInformation">Additional information.</param>
        /// <param name="extraData">Extra data.</param>
        /// <param name="callbackUrl">The callback URL.</param>
        /// <param name="callbackMethod">The callback method.</param>
        public UpdateResponse<TollfreeVerification> Update(
            string profileUuid = null, string usecase = null, string usecaseSummary = null,
            string messageSample = null, string optinImageUrl = null, string optinType = null, string volume = null,
            string additionalInformation = null, string extraData = null, string callbackUrl = null,
            string callbackMethod = null)
        {
            var updateResponse = ((TollfreeVerificationInterface)Interface).Update(
                Uuid, profileUuid, usecase, usecaseSummary, messageSample,
                optinImageUrl, optinType, volume, additionalInformation,
                extraData, callbackUrl, callbackMethod);

            if (profileUuid != null) ProfileUuid = profileUuid;
            if (usecase != null) Usecase = usecase;
            if (usecaseSummary != null) UsecaseSummary = usecaseSummary;
            if (messageSample != null) MessageSample = messageSample;
            if (optinImageUrl != null) OptinImageUrl = optinImageUrl;
            if (optinType != null) OptinType = optinType;
            if (volume != null) Volume = volume;
            if (additionalInformation != null) AdditionalInformation = additionalInformation;
            if (extraData != null) ExtraData = extraData;
            if (callbackUrl != null) CallbackUrl = callbackUrl;
            if (callbackMethod != null) CallbackMethod = callbackMethod;

            return updateResponse;
        }

        /// <summary>
        /// Asynchronously Update Tollfree Verification request with the specified profileUuid, usecase, usecaseSummary, messageSample, optinImageUrl,
        /// optinType, volume, additionalInformation, extraData, callbackUrl, callbackMethod.
        /// </summary>
        /// <returns>The update.</returns>
        /// <param name="profileUuid">The profile UUID.</param>
        /// <param name="usecase">The use case, e.g., "2FA, App Notifications".</param>
        /// <param name="usecaseSummary">The summary of the use case.</param>
        /// <param name="messageSample">Sample messages associated with the use case.</param>
        /// <param name="optinImageUrl">The URL of the opt-in image.</param>
        /// <param name="optinType">The type of opt-in.</param>
        /// <param name="volume">The message volume.</param>
        /// <param name="additionalInformation">Additional information.</param>
        /// <param name="extraData">Extra data.</param>
        /// <param name="callbackUrl">The callback URL.</param>
        /// <param name="callbackMethod">The callback method.</param>
        public async Task<AsyncResponse> UpdateAsync(
            string profileUuid = null, string usecase = null, string usecaseSummary = null,
            string messageSample = null, string optinImageUrl = null, string optinType = null, string volume = null,
            string additionalInformation = null, string extraData = null, string callbackUrl = null,
            string callbackMethod = null)
        {
            var updateResponse = await ((TollfreeVerificationInterface)Interface).UpdateAsync(
                Uuid, profileUuid, usecase, usecaseSummary, messageSample, optinImageUrl, optinType, volume,
                additionalInformation, extraData, callbackUrl, callbackMethod);

            if (profileUuid != null) ProfileUuid = profileUuid;
            if (usecase != null) Usecase = usecase;
            if (usecaseSummary != null) UsecaseSummary = usecaseSummary;
            if (messageSample != null) MessageSample = messageSample;
            if (optinImageUrl != null) OptinImageUrl = optinImageUrl;
            if (optinType != null) OptinType = optinType;
            if (volume != null) Volume = volume;
            if (additionalInformation != null) AdditionalInformation = additionalInformation;
            if (extraData != null) ExtraData = extraData;
            if (callbackUrl != null) CallbackUrl = callbackUrl;
            if (callbackMethod != null) CallbackMethod = callbackMethod;

            return updateResponse;
        }

        #endregion

        public override string ToString()
        {
            return "\n" +
                   "UUID: " + Uuid + "\n" +
                   "ProfileUuid: " + ProfileUuid + "\n" +
                   "Number: " + Number + "\n" +
                   "Usecase: " + Usecase + "\n" +
                   "UsecaseSummary: " + UsecaseSummary + "\n" +
                   "MessageSample: " + MessageSample + "\n" +
                   "OptinImageUrl: " + OptinImageUrl + "\n" +
                   "OptinType: " + OptinType + "\n" +
                   "Volume: " + Volume + "\n" +
                   "AdditionalInformation: " + AdditionalInformation + "\n" +
                   "ExtraData: " + ExtraData + "\n" +
                   "CallbackUrl: " + CallbackUrl + "\n" +
                   "CallbackMethod: " + CallbackMethod + "\n" +
                   "Status: " + Status + "\n" +
                   "RejectionReason: " + RejectionReason + "\n" +
                   "CreatedAt: " + CreatedAt + "\n" +
                   "UpdatedAt: " + UpdatedAt + "\n";
        }
    }
}