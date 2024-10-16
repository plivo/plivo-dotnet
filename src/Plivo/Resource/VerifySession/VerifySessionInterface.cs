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
        /// <param name="locale">Locale.</param>
        /// <param name="brand_name">BrandName.</param>
        /// <param name="app_hash">AppHash.</param>
        /// <param name="code_length">CodeLength.</param>
        /// <param name="dtmf">dtmf.</param>
        /// <param name="fraud_check">FraudCheck.</param>

        public VerifySessionCreateResponse Create(
            string recipient, string app_uuid = null, string channel = null, string url = null,
            string method = null, string locale = null, string brand_name = null, string app_hash = null, int code_length = 0, int? dtmf = null, string fraud_check = null)
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
                    method,
                    locale,
                    brand_name,
                    app_hash,
                    code_length,
                    dtmf,
                    fraud_check
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
        /// <param name="locale">Locale.</param>
        /// <param name="brand_name">BrandName.</param>
        /// <param name="app_hash">AppHash.</param>
        /// <param name="code_length">CodeLength.</param>
        /// <param name="dtmf">dtmf.</param>
        /// <param name="fraud_check">FraudCheck.</param>

        public async Task<VerifySessionCreateResponse> CreateAsync(
            string recipient, string app_uuid = null, string channel = null, string url = null,
            string method = null, string locale = null, string brand_name = null, string app_hash = null, int code_length = 0,  int? dtmf = null, string fraud_check = null)
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
                    method,
                    locale,
                    brand_name,
                    app_hash,
                    code_length,
                    dtmf,
                    fraud_check
                });

            var result = await Client.Update<VerifySessionCreateResponse>(Uri, data);
            result.Object.StatusCode = result.StatusCode;
            return result.Object;
        }

        #endregion
        

        #region Get
        /// <summary>
        /// Get Session with the specified session_uuid.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="session_uuid">Session UUID.</param>
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
        /// Asynchronously get Session with the specified session_uuid.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="session_uuid">Session UUID.</param>
        public async Task<VerifySession> GetAsync(string messageUuid)
        {
            var message = await GetResource<VerifySession>(messageUuid);
            message.Interface = this;
            return message;
        }
        #endregion



        #region List
        /// <summary>
        /// List Session with the specified params.
        /// </summary>
        /// <returns>The list.</returns>
        /// <param name="limit">Limit.</param>
        /// <param name="offset">Offset.</param>
        /// <param name="status">Status.</param>
        /// <param name="recipient">Recipient.</param>
        /// <param name="app_uuid">AppUUID.</param>
        /// <param name="country">Country.</param>
        /// <param name="alias">Alias.</param>
        /// <param name="subaccount">Subaccount.</param>
        /// <param name="session_time__gt">SessionTimeGT.</param>
        /// <param name="session_time__gte">SessionTimeGTE.</param>
        /// <param name="session_time__lt">SessionTimeLT.</param>
        /// <param name="session_time__lte">SessionTimeLTE.</param>
        /// <param name="session_time">SessionTime.</param>
        /// <param name="brand_name">BrandName.</param>
        /// <param name="app_hash">AppHash.</param>
        public VerifySessionListResponse<VerifySession> List(
            uint? limit = null,
            uint? offset = null,
            string status = null,
            string recipient = null,
            string app_uuid = null,
            string country = null,
            string alias = null,
            string subaccount = null,
            string brand_name = null,
            string app_hash = null,
            DateTime? session_time__gt = null,
            DateTime? session_time__gte = null,
            DateTime? session_time__lt = null,
            DateTime? session_time__lte = null,
            DateTime? session_time = null
            )
        {
            var _session_time__gt = session_time__gt?.ToString("yyyy-MM-dd HH':'mm':'ss''") ?? null;
            var _session_time__gte = session_time__gte?.ToString("yyyy-MM-dd HH':'mm':'ss''") ?? null;
            var _session_time__lt = session_time__lt?.ToString("yyyy-MM-dd HH':'mm':'ss''") ?? null;
            var _session_time__lte = session_time__lte?.ToString("yyyy-MM-dd HH':'mm':'ss''") ?? null;
            var _session_time = session_time?.ToString("yyyy-MM-dd HH':'mm':'ss''") ?? null;
            var mandatoryParams = new List<string> { "" };
            var data = CreateData(
                mandatoryParams, new
                {
                    limit,
                    offset,
                    status,
                    recipient,
                    app_uuid,
                    country,
                    alias,
                    subaccount,
                    brand_name,
                    app_hash,
                    _session_time__gt,
                    _session_time__gte,
                    _session_time__lt,
                    _session_time__lte,
                    _session_time
                });

            return ExecuteWithExceptionUnwrap(() =>
            {
                var resources = Task.Run(async () => await ListResources<VerifySessionListResponse<VerifySession>>(data).ConfigureAwait(false)).Result;
                resources.Sessions.ForEach(
                    (obj) => obj.Interface = this
                );
                return resources;
            });
        }
        /// <summary>
        /// List Session with the specified params.
        /// </summary>
        /// <returns>The list.</returns>
        /// <param name="limit">Limit.</param>
        /// <param name="offset">Offset.</param>
        /// <param name="status">Status.</param>
        /// <param name="recipient">Recipient.</param>
        /// <param name="app_uuid">AppUUID.</param>
        /// <param name="country">Country.</param>
        /// <param name="alias">Alias.</param>
        /// <param name="subaccount">Subaccount.</param>
        /// <param name="session_time__gt">SessionTimeGT.</param>
        /// <param name="session_time__gte">SessionTimeGTE.</param>
        /// <param name="session_time__lt">SessionTimeLT.</param>
        /// <param name="session_time__lte">SessionTimeLTE.</param>
        /// <param name="session_time">SessionTime.</param>
        /// <param name="brand_name">BrandName.</param>
        /// <param name="app_hash">AppHash.</param>
        public async Task<VerifySessionListResponse<VerifySession>> ListAsync(
            uint? limit = null,
            uint? offset = null,
            string status = null,
            string recipient = null,
            string app_uuid = null,
            string country = null,
            string alias = null,
            string subaccount = null,
            string brand_name = null,
            string app_hash = null,
            DateTime? session_time__gt = null,
            DateTime? session_time__gte = null,
            DateTime? session_time__lt = null,
            DateTime? session_time__lte = null,
            DateTime? session_time = null
            )
        {
            var _session_time__gt = session_time__gt?.ToString("yyyy-MM-dd HH':'mm':'ss''") ?? null;
            var _session_time__gte = session_time__gte?.ToString("yyyy-MM-dd HH':'mm':'ss''") ?? null;
            var _session_time__lt = session_time__lt?.ToString("yyyy-MM-dd HH':'mm':'ss''") ?? null;
            var _session_time__lte = session_time__lte?.ToString("yyyy-MM-dd HH':'mm':'ss''") ?? null;
            var _session_time = session_time?.ToString("yyyy-MM-dd HH':'mm':'ss''") ?? null;
            var mandatoryParams = new List<string> { "" };
            var data = CreateData(
                mandatoryParams, new
                {
                    limit,
                    offset,
                    status,
                    recipient,
                    app_uuid,
                    country,
                    alias,
                    subaccount,
                    brand_name,
                    app_hash,
                    _session_time__gt,
                    _session_time__gte,
                    _session_time__lt,
                    _session_time__lte,
                    _session_time
                });
            var resources = await ListResources<VerifySessionListResponse<VerifySession>>(data);
            resources.Sessions.ForEach(
                (obj) => obj.Interface = this
            );

            return resources;
        }
        #endregion



        #region Validate
        /// <summary>
        /// Validate VerifySession with the specified session_uuid, otp.
        /// </summary>
        /// <returns>The validate.</returns>
        /// <param name="session_uuid">SessionUUID.</param>
        /// <param name="otp">OTP.</param> 

        public VerifySessionCreateResponse Validate(
            string session_uuid=null, string otp = null)
        {
            Dictionary<string, object> data = null;
            var mandatoryParams = new List<string> { "session_uuid", "otp" };
            data = CreateData(
                mandatoryParams,
                new
                {
                    session_uuid,
                    otp
                });

            return ExecuteWithExceptionUnwrap(() =>
            {
                var result = Task.Run(async () => await Client.Update<VerifySessionCreateResponse>(Uri+session_uuid+"/", data).ConfigureAwait(false)).Result;
                result.Object.StatusCode = result.StatusCode;
                return result.Object;
            });
        }

        /// <summary>
        /// Asynchronously Validate VerifySession with the specified session_uuid, otp.
        /// </summary>
        /// <returns>The validate.</returns>
        /// <param name="session_uuid">SessionUUID.</param>
        /// <param name="otp">OTP.</param> 
        /// 
        public async Task<VerifySessionCreateResponse> ValidateAsync(
            string session_uuid=null, string otp = null)
        {
            Dictionary<string, object> data = null;
            var mandatoryParams = new List<string> { "session_uuid", "otp" };
            data = CreateData(
                mandatoryParams,
                new
                {
                    session_uuid,
                    otp
                });

            var result = await Client.Update<VerifySessionCreateResponse>(Uri+session_uuid+"/", data);
            result.Object.StatusCode = result.StatusCode;
            return result.Object;
        }

        #endregion
    }
}
