using Plivo.Client;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System;

namespace Plivo.Resource.MaskingSession
{
    public class MaskingSessionInterface : ResourceInterface
    {
        public MaskingSessionInterface(HttpClient client) : base(client)
        {
            Uri = "Account/" + Client.GetAuthId() + "/Masking/Session/";
        }

        #region Create
        public MaskingSessionCreateResponse Create(
            string firstParty, string secondParty, uint? sessionExpiry = null, uint? callTimeLimit = null,
            bool? record = null, string recordFileFormat = null, string recordingCallbackUrl = null, bool? initiateCallToFirstParty = null,
            string callbackUrl = null, string callbackMethod = null, uint? ringTimeout = null, string firstPartyPlayUrl = null, 
            string secondPartyPlayUrl = null, string recordingCallbackMethod = null, bool? isPinAuthenticationRequired = null, 
            bool? generatePin = null, uint? generatePinLength = null, string firstPartyPin = null, string secondPartyPin = null, 
            string pinPromptPlay = null, uint? pinRetry = null, uint? pinRetryWait = null, string incorrectPinPlay = null, 
            string unknownCallerPlay = null, string subaccount = null, bool? geomatch = null
            )
        {
            var mandatoryParams = new List<string> { "firstParty", "secondParty" };
            bool isVoiceRequest = true;
            var data = CreateData(
                mandatoryParams,
                new
                {
                    firstParty,
                    secondParty,
                    sessionExpiry,
                    callTimeLimit,
                    record,
                    recordFileFormat,
                    recordingCallbackUrl,
                    initiateCallToFirstParty,
                    callbackUrl,
                    callbackMethod,
                    ringTimeout,
                    firstPartyPlayUrl,
                    secondPartyPlayUrl,
                    recordingCallbackMethod,
                    isPinAuthenticationRequired,
                    generatePin,
                    generatePinLength,
                    firstPartyPin,
                    secondPartyPin,
                    pinPromptPlay,
                    pinRetry,
                    pinRetryWait,
                    incorrectPinPlay,
                    unknownCallerPlay,
                    subaccount,
                    geomatch,
                    isVoiceRequest
                });

            return ExecuteWithExceptionUnwrap(() =>
            {
                var result = Task.Run(async () => await Client.Update<MaskingSessionCreateResponse>(Uri, data).ConfigureAwait(false)).Result;
                result.Object.StatusCode = result.StatusCode;
                return result.Object;
            });
        }

        public async Task<AsyncResponse> CreateAsync(
            string firstParty, string secondParty, uint? sessionExpiry = null, uint? callTimeLimit = null,
            bool? record = null, string recordFileFormat = null, string recordingCallbackUrl = null, bool? initiateCallToFirstParty = null,
            string callbackUrl = null, string callbackMethod = null, uint? ringTimeout = null, string firstPartyPlayUrl = null, 
            string secondPartyPlayUrl = null, string recordingCallbackMethod = null, bool? isPinAuthenticationRequired = null, 
            bool? generatePin = null, uint? generatePinLength = null, string firstPartyPin = null, string secondPartyPin = null, 
            string pinPromptPlay = null, uint? pinRetry = null, uint? pinRetryWait = null, string incorrectPinPlay = null, 
            string unknownCallerPlay = null, string subaccount = null, bool? geomatch = null
            )
        {
            var mandatoryParams = new List<string> { "firstParty", "secondParty" };
            bool isVoiceRequest = true;
            var data = CreateData(
                mandatoryParams,
                new
                {
                    firstParty,
                    secondParty,
                    sessionExpiry,
                    callTimeLimit,
                    record,
                    recordFileFormat,
                    recordingCallbackUrl,
                    initiateCallToFirstParty,
                    callbackUrl,
                    callbackMethod,
                    ringTimeout,
                    firstPartyPlayUrl,
                    secondPartyPlayUrl,
                    recordingCallbackMethod,
                    isPinAuthenticationRequired,
                    generatePin,
                    generatePinLength,
                    firstPartyPin,
                    secondPartyPin,
                    pinPromptPlay,
                    pinRetry,
                    pinRetryWait,
                    incorrectPinPlay,
                    unknownCallerPlay,
                    subaccount,
                    geomatch,
                    isVoiceRequest
                });

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
        public MaskingSession Get(string sessionUuid)
        {
            bool isVoiceRequest = true;
            var data = CreateData(new List<string> {""}, new {isVoiceRequest});
            return ExecuteWithExceptionUnwrap(() =>
            {
                var maskingSession = Task.Run(async () => await GetResource<MaskingSession>(sessionUuid, data).ConfigureAwait(false)).Result;
                maskingSession.Interface = this;
                return maskingSession;
            });
        }

        public async Task<AsyncResponse> GetAsync(string sessionUuid)
        {
            var data = new Dictionary<string, object>()
            {
                {"is_voice_request", true}
            };
            var result = Task.Run(async () => await Client.Fetch<AsyncResponse>(
                Uri + "/" + sessionUuid + "/", data).ConfigureAwait(false)).Result;
            await Task.WhenAll();
            result.Object.StatusCode = result.StatusCode;
            JObject responseJson = JObject.Parse(result.Content);
            result.Object.ApiId = responseJson["api_id"].ToString();
            result.Object.Message = responseJson["message"].ToString();
            
            Console.WriteLine($"result: {result}");
            Console.WriteLine($"responseJson: {responseJson}");
            Console.WriteLine($"StatusCode: {result.StatusCode}");
            Console.WriteLine($"Content: {result.Content}");
            Console.WriteLine($"Object: {result.Object}");
            
            return result.Object;
        }
        #endregion

        
        #region List
        public ListResponse<MaskingSession> List(
        string first_party = null, string second_party = null, string virtual_number = null, string status = null,
        string created_time = null, string created_time__lt = null,string created_time__gt = null,string created_time__lte = null,
        string created_time__gte = null, string expiry_time = null,string expiry_time__lt = null,string expiry_time__gt = null,
        string expiry_time__lte = null,string expiry_time__gte = null, uint? duration = null,uint? duration__lt = null,
        uint? duration__gt = null,uint? duration__lte = null,uint? duration__gte = null,uint? limit = null, uint? offset = null, 
        string subaccount=null)
        {
            var mandatoryParams = new List<string> { "" };
            bool isVoiceRequest = true;
            var data = CreateData(mandatoryParams,
            new { 
                first_party,
                second_party,
                virtual_number,
                status,
                created_time,
                created_time__lt,
                created_time__gt,
                created_time__lte,
                created_time__gte,
                expiry_time,
                expiry_time__lt,
                expiry_time__gt,
                expiry_time__lte,
                expiry_time__gte,
                duration,
                duration__lt,
                duration__gt,
                duration__lte,
                duration__gte,
                limit,
                offset,
                subaccount, 
                isVoiceRequest
            });
            return ExecuteWithExceptionUnwrap(() =>
            {
                var resources = Task.Run(async () => await ListResources<ListResponse<MaskingSession>>(data).ConfigureAwait(false)).Result;

                resources.Objects.ForEach(
                    (obj) => obj.Interface = this
                );

                return resources;
            });
        }

        public async Task<AsyncResponse> ListAsync(
        string first_party = null, string second_party = null, string virtual_number = null, string status = null,
        string created_time = null, string created_time__lt = null,string created_time__gt = null,string created_time__lte = null,
        string created_time__gte = null, string expiry_time = null,string expiry_time__lt = null,string expiry_time__gt = null,
        string expiry_time__lte = null,string expiry_time__gte = null, uint? duration = null,uint? duration__lt = null,
        uint? duration__gt = null,uint? duration__lte = null,uint? duration__gte = null,uint? limit = null, uint? offset = null, 
        string subaccount=null)
        {
            var mandatoryParams = new List<string> { "" };
            bool isVoiceRequest = true;
            var data = CreateData(mandatoryParams,
            new { 
                first_party,
                second_party,
                virtual_number,
                status,
                created_time,
                created_time__lt,
                created_time__gt,
                created_time__lte,
                created_time__gte,
                expiry_time,
                expiry_time__lt,
                expiry_time__gt,
                expiry_time__lte,
                expiry_time__gte,
                duration,
                duration__lt,
                duration__gt,
                duration__lte,
                duration__gte,
                limit,
                offset,
                subaccount, 
                isVoiceRequest
            });
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
        public DeleteResponse<MaskingSession> Delete(string sessionUuid)
        {
            return ExecuteWithExceptionUnwrap(() =>
            {
                return Task.Run(async () => await DeleteResource<DeleteResponse<MaskingSession>>(sessionUuid, new Dictionary<string, object> () { {"is_voice_request", true} }).ConfigureAwait(false)).Result;
            });
        }

        public async Task<AsyncResponse> DeleteAsync(string sessionUuid)
        {
            var data = new Dictionary<string, object>()
            {
                {"is_voice_request", true}
            };
            var result = Task.Run(async () => await Client.Delete<AsyncResponse>(
                Uri +  "/" + sessionUuid + "/", data).ConfigureAwait(false)).Result;
            await Task.WhenAll();
            result.Object.StatusCode = result.StatusCode;
            return result.Object;
        }
        #endregion


        #region Update
        public UpdateResponse<MaskingSession> Update(string sessionUuid, uint? session_expiry = null, uint? call_time_limit = null, 
        bool? record = null, string record_file_format = null, string recording_callback_url = null, string callback_url = null, 
        string callback_method = null, uint? ring_timeout = null, string first_party_play_url = null, string second_party_play_url = null, 
        string recording_callback_method = null, string subaccount = null, bool? geomatch = null
        )
        {
            var mandatoryParams = new List<string> { "" };
            bool isVoiceRequest = true;
            var data = CreateData(
                mandatoryParams,
                new
                {
                    session_expiry,
                    call_time_limit,
                    record,
                    record_file_format,
                    recording_callback_url,
                    callback_url,
                    callback_method,
                    ring_timeout,
                    first_party_play_url,
                    second_party_play_url,
                    recording_callback_method,
                    subaccount,
                    geomatch,
                    isVoiceRequest
                });

            return ExecuteWithExceptionUnwrap(() =>
            {
                var result = Task.Run(async () => await Client.Update<UpdateResponse<MaskingSession>>(Uri + "/" + sessionUuid + "/", data).ConfigureAwait(false)).Result;
                result.Object.StatusCode = result.StatusCode;
                return result.Object;
            });
        }

        public async Task<AsyncResponse> UpdateAsync(string sessionUuid, uint? session_expiry = null, uint? call_time_limit = null, 
        bool? record = null, string record_file_format = null, string recording_callback_url = null, string callback_url = null, 
        string callback_method = null, uint? ring_timeout = null, string first_party_play_url = null, string second_party_play_url = null, 
        string recording_callback_method = null, string subaccount = null, bool? geomatch = null
        )
        {
            var mandatoryParams = new List<string> { "" };
            bool isVoiceRequest = true;
            var data = CreateData(
                mandatoryParams,
                new
                {
                    session_expiry,
                    call_time_limit,
                    record,
                    record_file_format,
                    recording_callback_url,
                    callback_url,
                    callback_method,
                    ring_timeout,
                    first_party_play_url,
                    second_party_play_url,
                    recording_callback_method,
                    subaccount,
                    geomatch,
                    isVoiceRequest
                }
            );
            var result = Task.Run(async () => await Client.Update<AsyncResponse>(Uri + "/" + sessionUuid + "/", data).ConfigureAwait(false)).Result;
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