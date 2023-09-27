using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Plivo.Client;

namespace Plivo.Resource.TollfreeVerification
{
    public class TollfreeVerificationInterface : ResourceInterface
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:plivo.Resource.TollfreeVerification.TollfreeVerificationInterface"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        public TollfreeVerificationInterface(HttpClient client) : base(client)
        {
            Uri = "Account/" + Client.GetAuthId() + "/TollfreeVerification/";
        }

        #region create

        /// <summary>
        /// Create TollfreeVerification request with the specified parameters.
        /// </summary>
        /// <param name="profileUuid">The profile UUID.</param>
        /// <param name="number">The toll-free number.</param>
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
        public TollfreeVerificationCreateResponse Create(
            string profileUuid, string number, string usecase,
            string usecaseSummary, string messageSample, string optinImageUrl, string optinType,
            string volume, string additionalInformation=null, string extraData=null, string callbackUrl=null,
            string callbackMethod=null)
        {
            var mandatoryParams = new List<string>
            {
                "profileUuid", "usecase", "usecaseSummary", "messageSample", "optInImageUrl", "optInType", "volume",
                "number"
            };
            var data = CreateData(
                mandatoryParams, new
                {
                    profileUuid,
                    number,
                    usecase,
                    usecaseSummary,
                    messageSample,
                    optinType,
                    optinImageUrl,
                    volume,
                    additionalInformation,
                    extraData,
                    callbackUrl,
                    callbackMethod
                });
            return ExecuteWithExceptionUnwrap(() =>
            {
                var result = Task.Run(async () =>
                    await Client.Update<TollfreeVerificationCreateResponse>(Uri, data).ConfigureAwait(false)).Result;
                JObject responseJson = JObject.Parse(result.Content);
                result.Object.StatusCode = result.StatusCode;
                result.Object.ApiId = responseJson["api_id"].ToString();
                result.Object.Message = responseJson["message"].ToString();
                return result.Object;
            });
        }

        #endregion
    }
}