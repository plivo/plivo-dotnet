using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Plivo.Client;


namespace Plivo.Resource.VerifySession
{
    /// <summary>
    /// VerifySession interface.
    /// </summary>
    public class VerifySessionInterface : ResourceInterface
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:plivo.Resource.VerifySession.VerifySessionInterface"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        public VerifySessionInterface(HttpClient client) : base(client)
        {
            Uri = "Account/" + Client.GetAuthId() + "/Verify/Session/";
        }

        #region Create
        /// <summary>
        /// Create VerifySession with the specified recipient, app_uuid, channel, url, method.
        /// </summary>
        /// <returns>The create.</returns>
        /// <param name="recipient">Recipient.</param>
        /// <param name="app_uuid">App UUID.</param>
        /// <param name="channel">Channel.</param>
        /// <param name="url">URL.</param>
        /// <param name="method">Method.</param>
        /// 

        public VerifySessionCreateResponse Create(
            string recipient=null, string app_uuid = null, string channel = null, string url = null,
            string method = null)
        {
            Dictionary<string, object> data = null;
            var mandatoryParams = new List<string> { "recipient" };
            data = CreateData(
                mandatoryParams,
                new
                {
                    recipient,
                    app_uuid,
                    channel,
                    url,
                    method
                });

            return ExecuteWithExceptionUnwrap(() =>
            {
                var result = Task.Run(async () => await Client.Update<VerifySessionCreateResponse>(Uri, data).ConfigureAwait(false)).Result;
                result.Object.StatusCode = result.StatusCode;
                return result.Object;
            });
        }

        /// <summary>
        /// Asynchronously Create VerifySession with the specified recipient, app_uuid, channel, url, method.
        /// </summary>
        /// <returns>The create.</returns>
        /// <param name="recipient">Recipient.</param>
        /// <param name="app_uuid">App UUID.</param>
        /// <param name="channel">Channel.</param>
        /// <param name="url">URL.</param>
        /// <param name="method">Method.</param>
        /// 
        public async Task<VerifySessionCreateResponse> CreateAsync(
            string recipient=null, string app_uuid = null, string channel = null, string url = null,
            string method = null)
        {
            Dictionary<string, object> data = null;
            var mandatoryParams = new List<string> { "recipient" };
            data = CreateData(
                mandatoryParams,
                new
                {
                    recipient,
                    app_uuid,
                    channel,
                    url,
                    method
                });

            var result = await Client.Update<VerifySessionCreateResponse>(Uri, data);
            result.Object.StatusCode = result.StatusCode;
            return result.Object;
        }

        #endregion
        

        #region Get
        /// <summary>
        /// Get Message with the specified messageUuid.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="messageUuid">Message UUID.</param>
        public VerifySession Get(string session_uuid)
        {
            return ExecuteWithExceptionUnwrap(() =>
            {
                var verify_session = Task.Run(async () => await GetResource<VerifySession>(session_uuid).ConfigureAwait(false)).Result;
                verify_session.Interface = this;
                return verify_session;
            });
        }
        /// <summary>
        /// Asynchronously get Message with the specified messageUuid.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="messageUuid">Message UUID.</param>
        public async Task<VerifySession> GetAsync(string messageUuid)
        {
            var message = await GetResource<VerifySession>(messageUuid);
            message.Interface = this;
            return message;
        }
        #endregion



        #region List
        /// <summary>
        /// List Message with the specified subaccount, limit and offset.
        /// </summary>
        /// <returns>The list.</returns>
        /// <param name="subaccount">Subaccount.</param>
        /// <param name="limit">Limit.</param>
        /// <param name="offset">Offset.</param>
        /// <param name="message_state">MessageState.</param>
        /// <param name="message_direction">MessageDirection.</param>
        /// <param name="message_time__gt">MessageTimeGT.</param>
        /// <param name="message_time__gte">MessageTimeGTE.</param>
        /// <param name="message_time__lt">MessageTimeLT.</param>
        /// <param name="message_time__lte">MessageTimeLTE.</param>
        /// <param name="message_time">MessageTime.</param>
        /// <param name="error_code">ErrorCode.</param>
        /// <param name="powerpack_id">PowerpackID.</param>
        /// <param name="destination_country_iso2">DestinationCountryIso2.</param>
        /// <param name="tendlc_campaign_id">TendlcCampaignId.</param>
        /// <param name="tendlc_registration_status">TendlcRegistrationStatus.</param>
        public VerifySessionListResponse<VerifySession> List(
            string subaccount = null,
            uint? limit = null,
            uint? offset = null,
            string message_state = null,
            string message_direction = null,
            DateTime? message_time__gt = null,
            DateTime? message_time__gte = null,
            DateTime? message_time__lt = null,
            DateTime? message_time__lte = null,
            DateTime? message_time = null,
            uint? error_code = null,
            string powerpack_id = null ,
            string tendlc_campaign_id = null,
            string destination_country_iso2 = null,
            string tendlc_registration_status = null
            )
        {
            var _message_time__gt = message_time__gt?.ToString("yyyy-MM-dd HH':'mm':'ss''") ?? null;
            var _message_time__gte = message_time__gte?.ToString("yyyy-MM-dd HH':'mm':'ss''") ?? null;
            var _message_time__lt = message_time__lt?.ToString("yyyy-MM-dd HH':'mm':'ss''") ?? null;
            var _message_time__lte = message_time__lte?.ToString("yyyy-MM-dd HH':'mm':'ss''") ?? null;
            var _message_time = message_time?.ToString("yyyy-MM-dd HH':'mm':'ss''") ?? null;
            var mandatoryParams = new List<string> { "" };
            var data = CreateData(
                mandatoryParams, new
                {
                    subaccount,
                    limit,
                    offset,
                    message_state,
                    message_direction,
                    _message_time__gt,
                    _message_time__gte,
                    _message_time__lt,
                    _message_time__lte,
                    _message_time,
                    error_code,
                    powerpack_id,
                    tendlc_campaign_id,
                    destination_country_iso2,
                    tendlc_registration_status
                });

            return ExecuteWithExceptionUnwrap(() =>
            {
                var resources = Task.Run(async () => await ListResources<VerifySessionListResponse<VerifySession>>(data).ConfigureAwait(false)).Result;
                resources.Objects.ForEach(
                    (obj) => obj.Interface = this
                );
                return resources;
            });
        }
        /// <summary>
        /// List Message with the specified subaccount, limit and offset.
        /// </summary>
        /// <returns>The list.</returns>
        /// <param name="subaccount">Subaccount.</param>
        /// <param name="limit">Limit.</param>
        /// <param name="offset">Offset.</param>
        /// <param name="message_state">MessageState.</param>
        /// <param name="message_direction">MessageDirection.</param>
        /// <param name="message_time__gt">MessageTimeGT.</param>
        /// <param name="message_time__gte">MessageTimeGTE.</param>
        /// <param name="message_time__lt">MessageTimeLT.</param>
        /// <param name="message_time__lte">MessageTimeLTE.</param>
        /// <param name="message_time">MessageTime.</param>
        /// <param name="error_code">ErrorCode.</param>
        /// <param name="powerpack_id">PowerpackID.</param>
        /// <param name="destination_country_iso2">DestinationCountryIso2.</param>
        /// <param name="tendlc_campaign_id">TendlcCampaignID.</param>
        /// <param name="tendlc_registration_status">TendlcRegistrationStatus.</param>
        public async Task<VerifySessionListResponse<VerifySession>> ListAsync(
            string subaccount = null,
            uint? limit = null,
            uint? offset = null,
            string message_state = null,
            string message_direction = null,
            DateTime? message_time__gt = null,
            DateTime? message_time__gte = null,
            DateTime? message_time__lt = null,
            DateTime? message_time__lte = null,
            DateTime? message_time = null,
            uint? error_code = null,
            string powerpack_id = null,
            string tendlc_campaign_id = null,
            string destination_country_iso2 = null,
            string tendlc_registration_status = null
            )
        {
            var _message_time__gt = message_time__gt?.ToString("yyyy-MM-dd HH':'mm':'ss''") ?? null;
            var _message_time__gte = message_time__gte?.ToString("yyyy-MM-dd HH':'mm':'ss''") ?? null;
            var _message_time__lt = message_time__lt?.ToString("yyyy-MM-dd HH':'mm':'ss''") ?? null;
            var _message_time__lte = message_time__lte?.ToString("yyyy-MM-dd HH':'mm':'ss''") ?? null;
            var _message_time = message_time?.ToString("yyyy-MM-dd HH':'mm':'ss''") ?? null;
            var mandatoryParams = new List<string> { "" };
            var data = CreateData(
                mandatoryParams, new
                {
                    subaccount,
                    limit,
                    offset,
                    message_state,
                    message_direction,
                    _message_time__gt,
                    _message_time__gte,
                    _message_time__lt,
                    _message_time__lte,
                    _message_time,
                    error_code,
                    powerpack_id,
                    tendlc_campaign_id,
                    destination_country_iso2,
                    tendlc_registration_status
                });
            var resources = await ListResources<VerifySessionListResponse<VerifySession>>(data);
            resources.Objects.ForEach(
                (obj) => obj.Interface = this
            );

            return resources;
        }
        #endregion
    }
}
