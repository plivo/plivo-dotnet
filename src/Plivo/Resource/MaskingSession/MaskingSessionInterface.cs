using Plivo.Client;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

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
            string unknownCallerPlay = null, string subaccount = null, bool? geomatch = null, bool? forcePinAuthentication = null,
            bool? createSessionWithSingleParty= null, uint? virtualNumberCooloffPeriod = 0
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
                    isVoiceRequest,
                    forcePinAuthentication,
                    createSessionWithSingleParty,
                    virtualNumberCooloffPeriod
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
            string unknownCallerPlay = null, string subaccount = null, bool? geomatch = null, bool? forcePinAuthentication = null,
            bool? createSessionWithSingleParty= null, uint? virtualNumberCooloffPeriod = 0
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
                    isVoiceRequest,
                    forcePinAuthentication,
                    createSessionWithSingleParty,
                    virtualNumberCooloffPeriod
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
            return result.Object;
        }
        #endregion

        
        #region List
        public ListMaskingSessionResponse<MaskingSessionListResponse> List(
        string firstParty = null, string secondParty = null, string virtualNumber = null, string status = null,
        string createdTime = null, string createdTime_Lt = null,string createdTime_Gt = null,string createdTime_Lte = null,
        string createdTime_Gte = null, string expiryTime = null,string expiryTime_Lt = null,string expiryTime_Gt = null,
        string expiryTime_Lte = null,string expiryTime_Gte = null, uint? duration = null,uint? duration_Lt = null,
        uint? duration_Gt = null,uint? duration_Lte = null,uint? duration_Gte = null,uint? limit = null, uint? offset = null, 
        string subaccount=null)
        {
            var mandatoryParams = new List<string> { "" };
            bool isVoiceRequest = true;
            var data = CreateData(mandatoryParams,
            new { 
                firstParty,
                secondParty,
                virtualNumber,
                status,
                createdTime,
                createdTime_Lt,
                createdTime_Gt,
                createdTime_Lte,
                createdTime_Gte,
                expiryTime,
                expiryTime_Lt,
                expiryTime_Gt,
                expiryTime_Lte,
                expiryTime_Gte,
                duration,
                duration_Lt,
                duration_Gt,
                duration_Lte,
                duration_Gte,
                limit,
                offset,
                subaccount, 
                isVoiceRequest
            });
            return ExecuteWithExceptionUnwrap(() =>
            {
                var resources = Task.Run(async () => await ListResources<ListMaskingSessionResponse<MaskingSessionListResponse>>(data).ConfigureAwait(false)).Result;
                if (resources.Response == null) {
                    return resources;
                } else {
                resources.Meta = resources.Response.Meta;
                JArray responseArray = resources.Response.Objects as JArray;
                List<MaskingSessionListResponse> maskingSessionList = responseArray.ToObject<List<MaskingSessionListResponse>>();
                resources.Objects = maskingSessionList;
                return resources;
                }
            });
        }

        public async Task<AsyncResponse> ListAsync(
        string firstParty = null, string secondParty = null, string virtualNumber = null, string status = null,
        string createdTime = null, string createdTime_Lt = null,string createdTime_Gt = null,string createdTime_Lte = null,
        string createdTime_Gte = null, string expiryTime = null,string expiryTime_Lt = null,string expiryTime_Gt = null,
        string expiryTime_Lte = null,string expiryTime_Gte = null, uint? duration = null,uint? duration_Lt = null,
        uint? duration_Gt = null,uint? duration_Lte = null,uint? duration_Gte = null,uint? limit = null, uint? offset = null, 
        string subaccount=null)
        {
            var mandatoryParams = new List<string> { "" };
            bool isVoiceRequest = true;
            var data = CreateData(mandatoryParams,
            new { 
                firstParty,
                secondParty,
                virtualNumber,
                status,
                createdTime,
                createdTime_Lt,
                createdTime_Gt,
                createdTime_Lte,
                createdTime_Gte,
                expiryTime,
                expiryTime_Lt,
                expiryTime_Gt,
                expiryTime_Lte,
                expiryTime_Gte,
                duration,
                duration_Lt,
                duration_Gt,
                duration_Lte,
                duration_Gte,
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
        public MaskingSessionUpdateResponse<MaskingSession> Update(string sessionUuid, uint? sessionExpiry = null, uint? callTimeLimit = null, 
        bool? record = null, string recordFileFormat = null, string recordingCallbackUrl = null, string callbackUrl = null, 
        string callbackMethod = null, uint? ringTimeout = null, string firstPartyPlayUrl = null, string secondPartyPlayUrl = null, 
        string recordingCallbackMethod = null, string subaccount = null, bool? geomatch = null
        )
        {
            var mandatoryParams = new List<string> { "" };
            bool isVoiceRequest = true;
            var data = CreateData(
                mandatoryParams,
                new
                {
                    sessionExpiry,
                    callTimeLimit,
                    record,
                    recordFileFormat,
                    recordingCallbackUrl,
                    callbackUrl,
                    callbackMethod,
                    ringTimeout,
                    firstPartyPlayUrl,
                    secondPartyPlayUrl,
                    recordingCallbackMethod,
                    subaccount,
                    geomatch,
                    isVoiceRequest
                });

            return ExecuteWithExceptionUnwrap(() =>
            {
                var result = Task.Run(async () => await Client.Update<MaskingSessionUpdateResponse<MaskingSession>>(Uri  + sessionUuid + "/", data).ConfigureAwait(false)).Result;
                var contentJson = JObject.Parse(result.Content);
                result.Object.SessionUuid = contentJson["session"]["session_uuid"].ToString();
                result.Object.StatusCode = result.StatusCode;
                return result.Object;
            });
        }

        public async Task<AsyncResponse> UpdateAsync(string sessionUuid, uint? sessionExpiry = null, uint? callTimeLimit = null, 
        bool? record = null, string recordFileFormat = null, string recordingCallbackUrl = null, string callbackUrl = null, 
        string callbackMethod = null, uint? ringTimeout = null, string firstPartyPlayUrl = null, string secondPartyPlayUrl = null, 
        string recordingCallbackMethod = null, string subaccount = null, bool? geomatch = null
        )
        {
            var mandatoryParams = new List<string> { "" };
            bool isVoiceRequest = true;
            var data = CreateData(
                mandatoryParams,
                new
                {
                    sessionExpiry,
                    callTimeLimit,
                    record,
                    recordFileFormat,
                    recordingCallbackUrl,
                    callbackUrl,
                    callbackMethod,
                    ringTimeout,
                    firstPartyPlayUrl,
                    secondPartyPlayUrl,
                    recordingCallbackMethod,
                    subaccount,
                    geomatch,
                    isVoiceRequest
                });
            var result = Task.Run(async () => await Client.Update<AsyncResponse>(Uri  + sessionUuid + "/", data).ConfigureAwait(false)).Result;
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