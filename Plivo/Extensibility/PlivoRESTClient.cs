using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Plivo.Exceptions;
using Plivo.Objects;
using Plivo.Utility;
using RestSharp;
using RestSharp.Deserializers;

namespace Plivo.Extensibility
{
    public class PlivoRESTClient:PlivoClient 
    {   private RestClient client;
        private const string PLIVO_URL = "https://api.plivo.com";

        public PlivoRESTClient(string authId, string authToken, string version = "v1") : 
            base(authId, authToken, version)
        {
            // Initialize the client
            client = new RestClient(string.Format("{0}/{1}/Account/{2}", PLIVO_URL, version, AuthID));
            client.Authenticator = new HttpBasicAuthenticator(AuthID, AuthToken);
            client.UserAgent = "PlivoCsharp";
        }


        private IPlivoResponse<T> Request<T>(string httpMethod, string resource, Dictionary<string, string> data) where T : new()
        {
            var request = new RestRequest() { Resource = resource, RequestFormat = DataFormat.Json };

            // add the parameters to the request
            foreach (KeyValuePair<string, string> kvp in data)
                request.AddParameter(kvp.Key, HtmlEntity.Convert(kvp.Value));

            //set the HTTP method for this request
            switch (httpMethod.ToUpper())
            {
                case "GET": request.Method = Method.GET;
                    break;
                case "POST": request.Method = Method.POST;
                    request.Parameters.Clear();
                    request.AddParameter("application/json", request.JsonSerializer.Serialize(data), ParameterType.RequestBody);
                    break;
                case "DELETE": request.Method = Method.DELETE;
                    break;
                default: request.Method = Method.GET;
                    break;
            };
            client.AddHandler("application/json", new JsonDeserializer());
            IRestResponse<T> response = client.Execute<T>(request);

            PlivoResponse<T> plivoResponse = new PlivoResponse<T>()
                {
                    Data = response.Data,
                    ErrorMessage = response.ErrorMessage
                };
            return plivoResponse;
        }

        private Task<IPlivoResponse<T>> RequestAsync<T>(string httpMethod, string resource, Dictionary<string, string> data) where T : new()
        {
            var request = new RestRequest() { Resource = resource, RequestFormat = DataFormat.Json };

            // add the parameters to the request
            foreach (KeyValuePair<string, string> kvp in data)
                request.AddParameter(kvp.Key, HtmlEntity.Convert(kvp.Value));

            //set the HTTP method for this request
            switch (httpMethod.ToUpper())
            {
                case "GET": request.Method = Method.GET;
                    break;
                case "POST": request.Method = Method.POST;
                    request.Parameters.Clear();
                    request.AddParameter("application/json", request.JsonSerializer.Serialize(data), ParameterType.RequestBody);
                    break;
                case "DELETE": request.Method = Method.DELETE;
                    break;
                default: request.Method = Method.GET;
                    break;
            };
            client.AddHandler("application/json", new JsonDeserializer());

            var tcs = new TaskCompletionSource<IPlivoResponse<T>>();

            client.ExecuteAsync<T>(request, (response) =>
                {
                    try
                    {
                        IPlivoResponse<T> plivoResponse = new PlivoResponse<T>();
                        plivoResponse.Data = response.Data;
                        plivoResponse.ErrorMessage = response.ErrorMessage;
                        
                        tcs.SetResult(plivoResponse);
                    }
                    catch (Exception exc) { tcs.SetException(exc); }
                });

            return tcs.Task;
        }

        private string GetKeyValue(ref Dictionary<string, string> dict, string key)
        {
            string value = "";
            try
            {
                value = dict[key];
                dict.Remove(key);
            }
            catch (KeyNotFoundException)
            {
                throw new PlivoException(String.Format("Missing mandatory parameter {0}.", key));
            }
            return value;
        }

        // Accounts //
        public override IPlivoResponse<Account> GetAccount()
        {
            // had to add an additional space after / as RestSharp consumes it.
            return Request<Account>("/GET", "/", new Dictionary<string, string>());
        }

        public override Task<IPlivoResponse<Account>> GetAccountAsync()
        {
            return RequestAsync<Account>("/GET", "/", new Dictionary<string, string>());
        }

        public override IPlivoResponse<GenericResponse> ModifyAccount(Dictionary<string, string> parameters)
        {
            // had to add an additional space after / as RestSharp consumes it.
            return Request<GenericResponse>("POST", "/ ", parameters);
        }

        public override Task<IPlivoResponse<GenericResponse>> ModifyAccountAsync(Dictionary<string, string> parameters)
        {
            // had to add an additional space after / as RestSharp consumes it.
            return RequestAsync<GenericResponse>("POST", "/ ", parameters);
        }

        public override IPlivoResponse<SubAccountList> GetSubaccounts()
        {
            return Request<SubAccountList>("GET", "/Subaccount/", new Dictionary<string, string>());
        }

        public override Task<IPlivoResponse<SubAccountList>> GetSubaccountsAsync()
        {
            return RequestAsync<SubAccountList>("GET", "/Subaccount/", new Dictionary<string, string>());
        }

        public override IPlivoResponse<SubAccount> GetSubAccount(Dictionary<string, string> parameters)
        {
            string subauth_id = GetKeyValue(ref parameters, "subauth_id");
            return Request<SubAccount>("GET", String.Format("/Subaccount/{0}/", subauth_id), parameters);
        }

        public override Task<IPlivoResponse<SubAccount>> GetSubAccountAsync(Dictionary<string, string> parameters)
        {
            string subauth_id = GetKeyValue(ref parameters, "subauth_id");
            return RequestAsync<SubAccount>("GET", String.Format("/Subaccount/{0}/", subauth_id), parameters);
        }

        public override IPlivoResponse<GenericResponse> CreateSubAccount(Dictionary<string, string> parameters)
        {
            return Request<GenericResponse>("POST", "/Subaccount/", parameters);
        }

        public override Task<IPlivoResponse<GenericResponse>> CreateSubAccountAsync(Dictionary<string, string> parameters)
        {
            return RequestAsync<GenericResponse>("POST", "/Subaccount/", parameters);
        }

        public override IPlivoResponse<GenericResponse> ModifySubAccount(Dictionary<string, string> parameters)
        {
            string subauth_id = GetKeyValue(ref parameters, "subauth_id");
            return Request<GenericResponse>("POST", String.Format("/Subaccount/{0}/ ", subauth_id), parameters);
        }

        public override Task<IPlivoResponse<GenericResponse>> ModifySubAccountAsync(Dictionary<string, string> parameters)
        {
            string subauth_id = GetKeyValue(ref parameters, "subauth_id");
            return RequestAsync<GenericResponse>("POST", String.Format("/Subaccount/{0}/ ", subauth_id), parameters);
        }

        public override IPlivoResponse<GenericResponse> DeleteSubAccount(Dictionary<string, string> parameters)
        {
            string subauth_id = GetKeyValue(ref parameters, "subauth_id");
            return Request<GenericResponse>("DELETE", String.Format("/Subaccount/{0}/", subauth_id), parameters);
        }

        public override Task<IPlivoResponse<GenericResponse>> DeleteSubAccountAsync(Dictionary<string, string> parameters)
        {
            string subauth_id = GetKeyValue(ref parameters, "subauth_id");
            return RequestAsync<GenericResponse>("DELETE", String.Format("/Subaccount/{0}/", subauth_id), parameters);
        }

        // Applications //
        public override IPlivoResponse<ApplicationList> GetApplications()
        {
            return Request<ApplicationList>("GET", "/Application/", new Dictionary<string, string>());
        }

        public override Task<IPlivoResponse<ApplicationList>> GetApplicationsAsync()
        {
            return RequestAsync<ApplicationList>("GET", "/Application/", new Dictionary<string, string>());
        }

        public override IPlivoResponse<ApplicationList> GetApplications(Dictionary<string, string> parameters)
        {
            return Request<ApplicationList>("GET", "/Application/", parameters);
        }

        public override Task<IPlivoResponse<ApplicationList>> GetApplicationsAsync(Dictionary<string, string> parameters)
        {
            return RequestAsync<ApplicationList>("GET", "/Application/", parameters);
        }

        public override IPlivoResponse<Application> GetApplication(Dictionary<string, string> parameters)
        {
            string app_id = GetKeyValue(ref parameters, "app_id");
            return Request<Application>("GET", String.Format("/Application/{0}/", app_id), parameters);
        }

        public override Task<IPlivoResponse<Application>> GetApplicationAsync(Dictionary<string, string> parameters)
        {
            string app_id = GetKeyValue(ref parameters, "app_id");
            return RequestAsync<Application>("GET", String.Format("/Application/{0}/", app_id), parameters);
        }

        public override IPlivoResponse<GenericResponse> CreateApplication(Dictionary<string, string> parameters)
        {
            return Request<GenericResponse>("POST", "/Application/", parameters);
        }

        public override Task<IPlivoResponse<GenericResponse>> CreateApplicationAsync(Dictionary<string, string> parameters)
        {
            return RequestAsync<GenericResponse>("POST", "/Application/", parameters);
        }

        public override IPlivoResponse<GenericResponse> ModifyApplication(Dictionary<string, string> parameters)
        {
            string app_id = GetKeyValue(ref parameters, "app_id");
            return Request<GenericResponse>("POST", String.Format("/Application/{0}/", app_id), parameters);
        }

        public override Task<IPlivoResponse<GenericResponse>> ModifyApplicationAsync(Dictionary<string, string> parameters)
        {
            string app_id = GetKeyValue(ref parameters, "app_id");
            return RequestAsync<GenericResponse>("POST", String.Format("/Application/{0}/", app_id), parameters);
        }

        public override IPlivoResponse<GenericResponse> DeleteApplication(Dictionary<string, string> parameters)
        {
            string app_id = GetKeyValue(ref parameters, "app_id");
            return Request<GenericResponse>("DELETE", String.Format("/Application/{0}/", app_id), parameters);
        }

        public override Task<IPlivoResponse<GenericResponse>> DeleteApplicationAsync(Dictionary<string, string> parameters)
        {
            string app_id = GetKeyValue(ref parameters, "app_id");
            return RequestAsync<GenericResponse>("DELETE", String.Format("/Application/{0}/", app_id), parameters);
        }


        // Numbers //
        public override IPlivoResponse<NumberList> GetNumbers()
        {
            return Request<NumberList>("GET", "/Number/", new Dictionary<string, string>());
        }

        public override Task<IPlivoResponse<NumberList>> GetNumbersAsync()
        {
            return RequestAsync<NumberList>("GET", "/Number/", new Dictionary<string, string>());
        }

        [Obsolete("Use SearchNumberGroup() instead")]
        public override IPlivoResponse<NumberList> SearchNumbers(Dictionary<string, string> parameters)
        {
            return Request<NumberList>("GET", "/AvailableNumber/", parameters);
        }

        [Obsolete("Use SearchNumberGroupAsync() instead")]
        public override Task<IPlivoResponse<NumberList>> SearchNumbersAsync(Dictionary<string, string> parameters)
        {
            return RequestAsync<NumberList>("GET", "/AvailableNumber/", parameters);
        }

        public override IPlivoResponse<NumberList> SearchNumberGroup(Dictionary<string, string> parameters)
        {
            return Request<NumberList>("GET", "/AvailableNumberGroup/", parameters);
        }

        public override Task<IPlivoResponse<NumberList>> SearchNumberGroupAsync(Dictionary<string, string> parameters)
        {
            return RequestAsync<NumberList>("GET", "/AvailableNumberGroup/", parameters);
        }

        public override IPlivoResponse<Number> GetNumber(Dictionary<string, string> parameters)
        {
            string number = GetKeyValue(ref parameters, "number");
            return Request<Number>("GET", String.Format("/Number/{0}/", number), parameters);
        }

        public override Task<IPlivoResponse<Number>> GetNumberAsync(Dictionary<string, string> parameters)
        {
            string number = GetKeyValue(ref parameters, "number");
            return RequestAsync<Number>("GET", String.Format("/Number/{0}/", number), parameters);
        }

        [Obsolete("Use RentFromNumberGroup() instead")]
        public override IPlivoResponse<GenericResponse> RentNumber(Dictionary<string, string> parameters)
        {
            string number = GetKeyValue(ref parameters, "number");
            return Request<GenericResponse>("POST", String.Format("/AvailableNumber/{0}/", number), parameters);
        }

        [Obsolete("Use RentFromNumberGroupAsync() instead")]
        public override Task<IPlivoResponse<GenericResponse>> RentNumberAsync(Dictionary<string, string> parameters)
        {
            string number = GetKeyValue(ref parameters, "number");
            return RequestAsync<GenericResponse>("POST", String.Format("/AvailableNumber/{0}/", number), parameters);
        }

        public override IPlivoResponse<NumberResponse> RentFromNumberGroup(Dictionary<string, string> parameters)
        {
            string group_id = GetKeyValue(ref parameters, "group_id");
            return Request<NumberResponse>("POST", String.Format("/AvailableNumberGroup/{0}/", group_id), parameters);
        }

        public override Task<IPlivoResponse<NumberResponse>> RentFromNumberGroupAsync(Dictionary<string, string> parameters)
        {
            string group_id = GetKeyValue(ref parameters, "group_id");
            return RequestAsync<NumberResponse>("POST", String.Format("/AvailableNumberGroup/{0}/", group_id), parameters);
        }

        public override Task<IPlivoResponse<NumberResponse>> RentFromNumberAsync(Dictionary<string, string> parameters)
        {
            string group_id = GetKeyValue(ref parameters, "group_id");
            return RequestAsync<NumberResponse>("POST", String.Format("/AvailableNumberGroup/{0}/", group_id), parameters);
        }

        public override IPlivoResponse<GenericResponse> UnrentNumber(Dictionary<string, string> parameters)
        {
            string number = GetKeyValue(ref parameters, "number");
            return Request<GenericResponse>("DELETE", String.Format("/Number/{0}/", number), parameters);
        }

        public override Task<IPlivoResponse<GenericResponse>> UnrentNumberAsync(Dictionary<string, string> parameters)
        {
            string number = GetKeyValue(ref parameters, "number");
            return RequestAsync<GenericResponse>("DELETE", String.Format("/Number/{0}/", number), parameters);
        }

        public override IPlivoResponse<GenericResponse> LinkApplicationNumber(Dictionary<string, string> parameters)
        {
            string number = GetKeyValue(ref parameters, "number");
            return Request<GenericResponse>("POST", String.Format("/Number/{0}/", number), parameters);
        }

        public override Task<IPlivoResponse<GenericResponse>> LinkApplicationNumberAsync(Dictionary<string, string> parameters)
        {
            string number = GetKeyValue(ref parameters, "number");
            return RequestAsync<GenericResponse>("POST", String.Format("/Number/{0}/", number), parameters);
        }

        public override IPlivoResponse<GenericResponse> UnlinkApplicationNumber(Dictionary<string, string> parameters)
        {
            string number = GetKeyValue(ref parameters, "number");
            parameters.Add("app_id", "");
            return Request<GenericResponse>("POST", String.Format("/Number/{0}/", number), parameters);
        }

        public override Task<IPlivoResponse<GenericResponse>>  UnlinkApplicationNumberAsync(
            Dictionary<string, string> parameters)
        {
            string number = GetKeyValue(ref parameters, "number");
            parameters.Add("app_id", "");
            return RequestAsync<GenericResponse>("POST", String.Format("/Number/{0}/", number), parameters);
        }


        // Calls //
        public override IPlivoResponse<CdrList> GetCdrs()
        {
            return Request<CdrList>("GET", "/Call/", new Dictionary<string, string>());
        }

        public override Task<IPlivoResponse<CdrList>> GetCdrsAsync()
        {
            return RequestAsync<CdrList>("GET", "/Call/", new Dictionary<string, string>());
        }

        public override IPlivoResponse<CdrList> GetCdrs(Dictionary<string, string> parameters)
        {
            return Request<CdrList>("GET", "/Call/", parameters);
        }

        public override Task<IPlivoResponse<CdrList>> GetCdrsAsync(Dictionary<string, string> parameters)
        {
            return RequestAsync<CdrList>("GET", "/Call/", parameters);
        }

        public override IPlivoResponse<CDR> GetCdr(Dictionary<string, string> parameters)
        {
            string record_id = GetKeyValue(ref parameters, "record_id");
            return Request<CDR>("GET", String.Format("/Call/{0}/", record_id), parameters);
        }

        public override Task<IPlivoResponse<CDR>> GetCdrAsync(Dictionary<string, string> parameters)
        {
            string record_id = GetKeyValue(ref parameters, "record_id");
            return RequestAsync<CDR>("GET", String.Format("/Call/{0}/", record_id), parameters);
        }

        public override IPlivoResponse<LiveCallList> GetLiveCalls()
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("status", "live");
            return Request<LiveCallList>("GET", "/Call/", parameters);
        }

        public override Task<IPlivoResponse<LiveCallList>> GetLiveCallsAsync()
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("status", "live");
            return RequestAsync<LiveCallList>("GET", "/Call/", parameters);
        }

        public override IPlivoResponse<LiveCall> GetLiveCall(Dictionary<string, string> parameters)
        {
            string call_uuid = GetKeyValue(ref parameters, "call_uuid");
            parameters.Add("status", "live");
            return Request<LiveCall>("GET", String.Format("/Call/{0}/", call_uuid), parameters);
        }

        public override Task<IPlivoResponse<LiveCall>> GetLiveCallAsync(Dictionary<string, string> parameters)
        {
            string call_uuid = GetKeyValue(ref parameters, "call_uuid");
            parameters.Add("status", "live");
            return RequestAsync<LiveCall>("GET", String.Format("/Call/{0}/", call_uuid), parameters);
        }

        public override IPlivoResponse<Call> MakeCall(Dictionary<string, string> parameters)
        {
            return Request<Call>("POST", "/Call/", parameters);
        }

        public override Task<IPlivoResponse<Call>> MakeCallAsync(Dictionary<string, string> parameters)
        {
            return RequestAsync<Call>("POST", "/Call/", parameters);
        }

        public override IPlivoResponse<Call> MakeBulkCall(Dictionary<string, string> parameters, Dictionary<string, string> destNumberSipHeaders)
        {
            string destNumbers = "";
            string headerSIP = "";
            foreach (KeyValuePair<string, string> kvp in destNumberSipHeaders)
            {
                destNumbers += kvp.Key + "<";
                headerSIP += kvp.Value + "<";
            }
            parameters.Add("to", destNumbers.Substring(0, destNumbers.Length - 1));
            parameters.Add("sip_headers", headerSIP.Substring(0, headerSIP.Length - 1));
            return Request<Call>("POST", "/Call/", parameters);
        }

        public override Task<IPlivoResponse<Call>> MakeBulkCallAsync(Dictionary<string, string> parameters, Dictionary<string, string> destNumberSipHeaders)
        {
            string destNumbers = "";
            string headerSIP = "";
            foreach (KeyValuePair<string, string> kvp in destNumberSipHeaders)
            {
                destNumbers += kvp.Key + "<";
                headerSIP += kvp.Value + "<";
            }
            parameters.Add("to", destNumbers.Substring(0, destNumbers.Length - 1));
            parameters.Add("sip_headers", headerSIP.Substring(0, headerSIP.Length - 1));
            return RequestAsync<Call>("POST", "/Call/", parameters);
        }

        public override IPlivoResponse<GenericResponse> HangupAllCalls()
        {
            return Request<GenericResponse>("DELETE", "/Call/", new Dictionary<string, string>());
        }

        public override Task<IPlivoResponse<GenericResponse>> HangupAllCallsAsync()
        {
            return RequestAsync<GenericResponse>("DELETE", "/Call/", new Dictionary<string, string>());
        }

        public override IPlivoResponse<GenericResponse> HangupCall(Dictionary<string, string> parameters)
        {
            string call_uuid = GetKeyValue(ref parameters, "call_uuid");
            return Request<GenericResponse>("DELETE", String.Format("/Call/{0}/", call_uuid), parameters);
        }

        public override Task<IPlivoResponse<GenericResponse>> HangupCallAsync(Dictionary<string, string> parameters)
        {
            string call_uuid = GetKeyValue(ref parameters, "call_uuid");
            return RequestAsync<GenericResponse>("DELETE", String.Format("/Call/{0}/", call_uuid), parameters);
        }

        public override IPlivoResponse<GenericResponse> TransferCall(Dictionary<string, string> parameters)
        {
            string call_uuid = GetKeyValue(ref parameters, "call_uuid");
            return Request<GenericResponse>("POST", String.Format("/Call/{0}/", call_uuid), parameters);
        }

        public override Task<IPlivoResponse<GenericResponse>> TransferCallAsync(Dictionary<string, string> parameters)
        {
            string call_uuid = GetKeyValue(ref parameters, "call_uuid");
            return RequestAsync<GenericResponse>("POST", String.Format("/Call/{0}/", call_uuid), parameters);
        }

        public override IPlivoResponse<Record> Record(Dictionary<string, string> parameters)
        {
            string call_uuid = GetKeyValue(ref parameters, "call_uuid");
            return Request<Record>("POST", String.Format("/Call/{0}/Record/", call_uuid), parameters);
        }

        public override Task<IPlivoResponse<Record>> RecordAsync(Dictionary<string, string> parameters)
        {
            string call_uuid = GetKeyValue(ref parameters, "call_uuid");
            return RequestAsync<Record>("POST", String.Format("/Call/{0}/Record/", call_uuid), parameters);
        }

        public override IPlivoResponse<GenericResponse> StopRecord(Dictionary<string, string> parameters)
        {
            string call_uuid = GetKeyValue(ref parameters, "call_uuid");
            return Request<GenericResponse>("DELETE", String.Format("/Call/{0}/Record/", call_uuid), parameters);
        }

        public override Task<IPlivoResponse<GenericResponse>> StopRecordAsync(Dictionary<string, string> parameters)
        {
            string call_uuid = GetKeyValue(ref parameters, "call_uuid");
            return RequestAsync<GenericResponse>("DELETE", String.Format("/Call/{0}/Record/", call_uuid), parameters);
        }

        public override IPlivoResponse<GenericResponse> Play(Dictionary<string, string> parameters)
        {
            string call_uuid = GetKeyValue(ref parameters, "call_uuid");
            return Request<GenericResponse>("POST", String.Format("/Call/{0}/Play/", call_uuid), parameters);
        }

        public override Task<IPlivoResponse<GenericResponse>> PlayAsync(Dictionary<string, string> parameters)
        {
            string call_uuid = GetKeyValue(ref parameters, "call_uuid");
            return RequestAsync<GenericResponse>("POST", String.Format("/Call/{0}/Play/", call_uuid), parameters);
        }

        public override IPlivoResponse<GenericResponse> StopPlay(Dictionary<string, string> parameters)
        {
            string call_uuid = GetKeyValue(ref parameters, "call_uuid");
            return Request<GenericResponse>("DELETE", String.Format("/Call/{0}/Play/", call_uuid), parameters);
        }

        public override Task<IPlivoResponse<GenericResponse>> StopPlayAsync(Dictionary<string, string> parameters)
        {
            string call_uuid = GetKeyValue(ref parameters, "call_uuid");
            return RequestAsync<GenericResponse>("DELETE", String.Format("/Call/{0}/Play/", call_uuid), parameters);
        }

        public override IPlivoResponse<GenericResponse> Speak(Dictionary<string, string> parameters)
        {
            string call_uuid = GetKeyValue(ref parameters, "call_uuid");
            return Request<GenericResponse>("POST", String.Format("/Call/{0}/Speak/", call_uuid), parameters);
        }

        public override Task<IPlivoResponse<GenericResponse>> SpeakAsync(Dictionary<string, string> parameters)
        {
            string call_uuid = GetKeyValue(ref parameters, "call_uuid");
            return RequestAsync<GenericResponse>("POST", String.Format("/Call/{0}/Speak/", call_uuid), parameters);
        }

        public override IPlivoResponse<GenericResponse> StopSpeak(Dictionary<string, string> parameters)
        {
            string call_uuid = GetKeyValue(ref parameters, "call_uuid");
            return Request<GenericResponse>("DELETE", String.Format("/Call/{0}/Speak/", call_uuid), parameters);
        }

        public override Task<IPlivoResponse<GenericResponse>> StopSpeakAsync(Dictionary<string, string> parameters)
        {
            string call_uuid = GetKeyValue(ref parameters, "call_uuid");
            return RequestAsync<GenericResponse>("DELETE", String.Format("/Call/{0}/Speak/", call_uuid), parameters);
        }

        public override IPlivoResponse<GenericResponse> SendDigits(Dictionary<string, string> parameters)
        {
            string call_uuid = GetKeyValue(ref parameters, "call_uuid");
            return Request<GenericResponse>("POST", String.Format("/Call/{0}/DTMF/", call_uuid), parameters);
        }

        public override Task<IPlivoResponse<GenericResponse>> SendDigitsAsync(Dictionary<string, string> parameters)
        {
            string call_uuid = GetKeyValue(ref parameters, "call_uuid");
            return RequestAsync<GenericResponse>("POST", String.Format("/Call/{0}/DTMF/", call_uuid), parameters);
        }


        // Conferences //
        public override IPlivoResponse<LiveConferenceList> GetLiveConferences()
        {
            return Request<LiveConferenceList>("GET", "/Conference/", new Dictionary<string, string>());
        }

        public override Task<IPlivoResponse<LiveConferenceList>> GetLiveConferencesAsync()
        {
            return RequestAsync<LiveConferenceList>("GET", "/Conference/", new Dictionary<string, string>());
        }

        public override IPlivoResponse<GenericResponse> HangupAllConferences()
        {
            return Request<GenericResponse>("DELETE", "/Conference/", new Dictionary<string, string>());
        }

        public override Task<IPlivoResponse<GenericResponse>> HangupAllConferencesAsync()
        {
            return RequestAsync<GenericResponse>("DELETE", "/Conference/", new Dictionary<string, string>());
        }

        public override IPlivoResponse<Conference> GetLiveConference(Dictionary<string, string> parameters)
        {
            string conference_name = GetKeyValue(ref parameters, "conference_name");
            return Request<Conference>("GET", String.Format("/Conference/{0}/", conference_name), parameters);
        }

        public override Task<IPlivoResponse<Conference>> GetLiveConferenceAsync(Dictionary<string, string> parameters)
        {
            string conference_name = GetKeyValue(ref parameters, "conference_name");
            return RequestAsync<Conference>("GET", String.Format("/Conference/{0}/", conference_name), parameters);
        }

        public override IPlivoResponse<GenericResponse> HangupConference(Dictionary<string, string> parameters)
        {
            string conference_name = GetKeyValue(ref parameters, "conference_name");
            return Request<GenericResponse>("DELETE", String.Format("/Conference/{0}/", conference_name), parameters);
        }

        public override Task<IPlivoResponse<GenericResponse>> HangupConferenceAsync(Dictionary<string, string> parameters)
        {
            string conference_name = GetKeyValue(ref parameters, "conference_name");
            return RequestAsync<GenericResponse>("DELETE", String.Format("/Conference/{0}/", conference_name), parameters);
        }

        public override IPlivoResponse<GenericResponse> HangupMember(Dictionary<string, string> parameters)
        {
            string conference_name = GetKeyValue(ref parameters, "conference_name");
            string member_id = GetKeyValue(ref parameters, "member_id");
            return Request<GenericResponse>("DELETE", String.Format("/Conference/{0}/Member/{1}/", conference_name, member_id), parameters);
        }

        public override Task<IPlivoResponse<GenericResponse>> HangupMemberAsync(Dictionary<string, string> parameters)
        {
            string conference_name = GetKeyValue(ref parameters, "conference_name");
            string member_id = GetKeyValue(ref parameters, "member_id");
            return RequestAsync<GenericResponse>("DELETE", String.Format("/Conference/{0}/Member/{1}/", conference_name, member_id), parameters);
        }

        public override IPlivoResponse<GenericResponse> PlayMember(Dictionary<string, string> parameters)
        {
            string conference_name = GetKeyValue(ref parameters, "conference_name");
            string member_id = GetKeyValue(ref parameters, "member_id");
            return Request<GenericResponse>("POST", String.Format("/Conference/{0}/Member/{1}/Play/", conference_name, member_id), parameters);
        }

        public override Task<IPlivoResponse<GenericResponse>> PlayMemberAsync(Dictionary<string, string> parameters)
        {
            string conference_name = GetKeyValue(ref parameters, "conference_name");
            string member_id = GetKeyValue(ref parameters, "member_id");
            return RequestAsync<GenericResponse>("POST", String.Format("/Conference/{0}/Member/{1}/Play/", conference_name, member_id), parameters);
        }

        public override IPlivoResponse<GenericResponse> StopPlayMember(Dictionary<string, string> parameters)
        {
            string conference_name = GetKeyValue(ref parameters, "conference_name");
            string member_id = GetKeyValue(ref parameters, "member_id");
            return Request<GenericResponse>("DELETE", String.Format("/Conference/{0}/Member/{1}/Play/", conference_name, member_id), parameters);
        }

        public override Task<IPlivoResponse<GenericResponse>> StopPlayMemberAsync(Dictionary<string, string> parameters)
        {
            string conference_name = GetKeyValue(ref parameters, "conference_name");
            string member_id = GetKeyValue(ref parameters, "member_id");
            return RequestAsync<GenericResponse>("DELETE", String.Format("/Conference/{0}/Member/{1}/Play/", conference_name, member_id), parameters);
        }

        public override IPlivoResponse<GenericResponse> SpeakMember(Dictionary<string, string> parameters)
        {
            string conference_name = GetKeyValue(ref parameters, "conference_name");
            string member_id = GetKeyValue(ref parameters, "member_id");
            return Request<GenericResponse>("POST", String.Format("/Conference/{0}/Member/{1}/Speak/", conference_name, member_id), parameters);
        }

        public override Task<IPlivoResponse<GenericResponse>> SpeakMemberAsync(Dictionary<string, string> parameters)
        {
            string conference_name = GetKeyValue(ref parameters, "conference_name");
            string member_id = GetKeyValue(ref parameters, "member_id");
            return RequestAsync<GenericResponse>("POST", String.Format("/Conference/{0}/Member/{1}/Speak/", conference_name, member_id), parameters);
        }

        public override IPlivoResponse<GenericResponse> DeafMember(Dictionary<string, string> parameters)
        {
            string conference_name = GetKeyValue(ref parameters, "conference_name");
            string member_id = GetKeyValue(ref parameters, "member_id");
            return Request<GenericResponse>("POST", String.Format("/Conference/{0}/Member/{1}/Deaf/", conference_name, member_id), parameters);
        }

        public override Task<IPlivoResponse<GenericResponse>> DeafMemberAsync(Dictionary<string, string> parameters)
        {
            string conference_name = GetKeyValue(ref parameters, "conference_name");
            string member_id = GetKeyValue(ref parameters, "member_id");
            return RequestAsync<GenericResponse>("POST", String.Format("/Conference/{0}/Member/{1}/Deaf/", conference_name, member_id), parameters);
        }

        public override IPlivoResponse<GenericResponse> UndeadMember(Dictionary<string, string> parameters)
        {
            string conference_name = GetKeyValue(ref parameters, "conference_name");
            string member_id = GetKeyValue(ref parameters, "member_id");
            return Request<GenericResponse>("DELETE", String.Format("/Conference/{0}/Member/{1}/Deaf/", conference_name, member_id), parameters);
        }

        public override Task<IPlivoResponse<GenericResponse>> UndeadMemberAsync(Dictionary<string, string> parameters)
        {
            string conference_name = GetKeyValue(ref parameters, "conference_name");
            string member_id = GetKeyValue(ref parameters, "member_id");
            return RequestAsync<GenericResponse>("DELETE", String.Format("/Conference/{0}/Member/{1}/Deaf/", conference_name, member_id), parameters);
        }

        public override IPlivoResponse<GenericResponse> MuteMember(Dictionary<string, string> parameters)
        {
            string conference_name = GetKeyValue(ref parameters, "conference_name");
            string member_id = GetKeyValue(ref parameters, "member_id");
            return Request<GenericResponse>("POST", String.Format("/Conference/{0}/Member/{1}/Mute/", conference_name, member_id), parameters);
        }

        public override Task<IPlivoResponse<GenericResponse>> MuteMemberAsync(Dictionary<string, string> parameters)
        {
            string conference_name = GetKeyValue(ref parameters, "conference_name");
            string member_id = GetKeyValue(ref parameters, "member_id");
            return RequestAsync<GenericResponse>("POST", String.Format("/Conference/{0}/Member/{1}/Mute/", conference_name, member_id), parameters);
        }

        public override IPlivoResponse<GenericResponse> UnmuteMember(Dictionary<string, string> parameters)
        {
            string conference_name = GetKeyValue(ref parameters, "conference_name");
            string member_id = GetKeyValue(ref parameters, "member_id");
            return Request<GenericResponse>("DELETE", String.Format("/Conference/{0}/Member/{1}/Mute/", conference_name, member_id), parameters);
        }

        public override Task<IPlivoResponse<GenericResponse>> UnmuteMemberAsync(Dictionary<string, string> parameters)
        {
            string conference_name = GetKeyValue(ref parameters, "conference_name");
            string member_id = GetKeyValue(ref parameters, "member_id");
            return RequestAsync<GenericResponse>("DELETE", String.Format("/Conference/{0}/Member/{1}/Mute/", conference_name, member_id), parameters);
        }

        public override IPlivoResponse<GenericResponse> KickMember(Dictionary<string, string> parameters)
        {
            string conference_name = GetKeyValue(ref parameters, "conference_name");
            string member_id = GetKeyValue(ref parameters, "member_id");
            return Request<GenericResponse>("POST", String.Format("/Conference/{0}/Member/{1}/Kick/", conference_name, member_id), parameters);
        }

        public override Task<IPlivoResponse<GenericResponse>> KickMemberAsync(Dictionary<string, string> parameters)
        {
            string conference_name = GetKeyValue(ref parameters, "conference_name");
            string member_id = GetKeyValue(ref parameters, "member_id");
            return RequestAsync<GenericResponse>("POST", String.Format("/Conference/{0}/Member/{1}/Kick/", conference_name, member_id), parameters);
        }

        public override IPlivoResponse<Record> RecordConference(Dictionary<string, string> parameters)
        {
            string conference_name = GetKeyValue(ref parameters, "conference_name");
            return Request<Record>("POST", String.Format("/Conference/{0}/Record/", conference_name), parameters);
        }

        public override Task<IPlivoResponse<Record>> RecordConferenceAsync(Dictionary<string, string> parameters)
        {
            string conference_name = GetKeyValue(ref parameters, "conference_name");
            return RequestAsync<Record>("POST", String.Format("/Conference/{0}/Record/", conference_name), parameters);
        }

        public override IPlivoResponse<GenericResponse> StopRecordConference(Dictionary<string, string> parameters)
        {
            string conference_name = GetKeyValue(ref parameters, "conference_name");
            return Request<GenericResponse>("DELETE", String.Format("/Conference/{0}/Record/", conference_name), parameters);
        }

        public override Task<IPlivoResponse<GenericResponse>> StopRecordConferenceAsync(Dictionary<string, string> parameters)
        {
            string conference_name = GetKeyValue(ref parameters, "conference_name");
            return RequestAsync<GenericResponse>("DELETE", String.Format("/Conference/{0}/Record/", conference_name), parameters);
        }


        // Endpoints //
        public override IPlivoResponse<EndpointList> GetEndpoints()
        {
            return Request<EndpointList>("GET", "/Endpoint/", new Dictionary<string, string>());
        }

        public override Task<IPlivoResponse<EndpointList>> GetEndpointsAsync()
        {
            return RequestAsync<EndpointList>("GET", "/Endpoint/", new Dictionary<string, string>());
        }

        public override IPlivoResponse<EndpointList> GetEndpoints(Dictionary<string, string> parameters)
        {
            return Request<EndpointList>("GET", "/Endpoint/", parameters);
        }

        public override Task<IPlivoResponse<EndpointList>> GetEndpointsAsync(Dictionary<string, string> parameters)
        {
            return RequestAsync<EndpointList>("GET", "/Endpoint/", parameters);
        }

        public override IPlivoResponse<Endpoint> CreateEndpoint(Dictionary<string, string> parameters)
        {
            return Request<Endpoint>("POST", "/Endpoint/", parameters);
        }

        public override Task<IPlivoResponse<Endpoint>> CreateEndpointAsync(Dictionary<string, string> parameters)
        {
            return RequestAsync<Endpoint>("POST", "/Endpoint/", parameters);
        }

        public override IPlivoResponse<Endpoint> GetEndpoint(Dictionary<string, string> parameters)
        {
            string endpoint_id = GetKeyValue(ref parameters, "endpoint_id");
            return Request<Endpoint>("GET", String.Format("/Endpoint/{0}/", endpoint_id), parameters);
        }

        public override Task<IPlivoResponse<Endpoint>> GetEndpointAsync(Dictionary<string, string> parameters)
        {
            string endpoint_id = GetKeyValue(ref parameters, "endpoint_id");
            return RequestAsync<Endpoint>("GET", String.Format("/Endpoint/{0}/", endpoint_id), parameters);
        }

        public override IPlivoResponse<GenericResponse> ModifyEndpoint(Dictionary<string, string> parameters)
        {
            string endpoint_id = GetKeyValue(ref parameters, "endpoint_id");
            return Request<GenericResponse>("POST", String.Format("/Endpoint/{0}/", endpoint_id), parameters);
        }

        public override Task<IPlivoResponse<GenericResponse>> ModifyEndpointAsync(Dictionary<string, string> parameters)
        {
            string endpoint_id = GetKeyValue(ref parameters, "endpoint_id");
            return RequestAsync<GenericResponse>("POST", String.Format("/Endpoint/{0}/", endpoint_id), parameters);
        }

        public override IPlivoResponse<GenericResponse> DeleteEndpoint(Dictionary<string, string> parameters)
        {
            string endpoint_id = GetKeyValue(ref parameters, "endpoint_id");
            return Request<GenericResponse>("DELETE", String.Format("/Endpoint/{0}/", endpoint_id), parameters);
        }

        public override Task<IPlivoResponse<GenericResponse>> DeleteEndpointAsync(Dictionary<string, string> parameters)
        {
            string endpoint_id = GetKeyValue(ref parameters, "endpoint_id");
            return RequestAsync<GenericResponse>("DELETE", String.Format("/Endpoint/{0}/", endpoint_id), parameters);
        }


        // Messages //
        public override IPlivoResponse<MessageResponse> SendMessage(Dictionary<string, string> parameters)
        {
            return Request<MessageResponse>("POST", "/Message/", parameters);
        }

        public override Task<IPlivoResponse<MessageResponse>> SendMessageAsync(Dictionary<string, string> parameters)
        {
            return RequestAsync<MessageResponse>("POST", "/Message/", parameters);
        }

        public override IPlivoResponse<Message> GetMessage(Dictionary<string, string> parameters)
        {
            string record_id = GetKeyValue(ref parameters, "record_id");
            return Request<Message>("GET", String.Format("/Message/{0}/", record_id), parameters);
        }

        public override Task<IPlivoResponse<Message>> GetMessageAsync(Dictionary<string, string> parameters)
        {
            string record_id = GetKeyValue(ref parameters, "record_id");
            return RequestAsync<Message>("GET", String.Format("/Message/{0}/", record_id), parameters);
        }


        public override IPlivoResponse<MessageList> GetMessages()
        {
            return Request<MessageList>("GET", "/Message/", new Dictionary<string, string>());
        }

        public override Task<IPlivoResponse<MessageList>> GetMessagesAsync()
        {
            return RequestAsync<MessageList>("GET", "/Message/", new Dictionary<string, string>());
        }

        public override IPlivoResponse<MessageList> GetMessages(Dictionary<string, string> parameters)
        {
            return Request<MessageList>("GET", "/Message/", parameters);
        }

        public override Task<IPlivoResponse<MessageList>> GetMessagesAsync(Dictionary<string, string> parameters)
        {
            return RequestAsync<MessageList>("GET", "/Message/", parameters);
        }


        // Inbound Carriers
        public override IPlivoResponse<IncomingCarrierList> GetIncomingCarriers(Dictionary<string, string> parameters)
        {
            return Request<IncomingCarrierList>("GET", "/IncomingCarrier/", parameters);
        }

        public override Task<IPlivoResponse<IncomingCarrierList>> GetIncomingCarriersAsync(Dictionary<string, string> parameters)
        {
            return RequestAsync<IncomingCarrierList>("GET", "/IncomingCarrier/", parameters);
        }

        public override IPlivoResponse<IncomingCarrier> GetIncomingCarrier(Dictionary<string, string> parameters)
        {
            string carrierId = GetKeyValue(ref parameters, "carrier_id");
            return Request<IncomingCarrier>("GET", String.Format("/IncomingCarrier/{0}/", carrierId), parameters);
        }

        public override Task<IPlivoResponse<IncomingCarrier>> GetIncomingCarrierAsync(Dictionary<string, string> parameters)
        {
            string carrierId = GetKeyValue(ref parameters, "carrier_id");
            return RequestAsync<IncomingCarrier>("GET", String.Format("/IncomingCarrier/{0}/", carrierId), parameters);
        }

        public override IPlivoResponse<GenericResponse> CreateIncomingCarrier(Dictionary<string, string> parameters)
        {
            return Request<GenericResponse>("POST", "/IncomingCarrier/", parameters);
        }

        public override Task<IPlivoResponse<GenericResponse>> CreateIncomingCarrierAsync(Dictionary<string, string> parameters)
        {
            return RequestAsync<GenericResponse>("POST", "/IncomingCarrier/", parameters);
        }

        public override IPlivoResponse<IncomingCarrier> ModifyIncomingCarrier(Dictionary<string, string> parameters)
        {
            string carrierId = GetKeyValue(ref parameters, "carrier_id");
            return Request<IncomingCarrier>("POST", String.Format("/IncomingCarrier/{0}/", carrierId), parameters);
        }

        public override Task<IPlivoResponse<IncomingCarrier>> ModifyIncomingCarrierAsync(Dictionary<string, string> parameters)
        {
            string carrierId = GetKeyValue(ref parameters, "carrier_id");
            return RequestAsync<IncomingCarrier>("POST", String.Format("/IncomingCarrier/{0}/", carrierId), parameters);
        }

        public override IPlivoResponse<GenericResponse> DeleteIncomingCarrier(Dictionary<string, string> parameters)
        {
            string carrierId = GetKeyValue(ref parameters, "carrier_id");
            return Request<GenericResponse>("DELETE", String.Format("/IncomingCarrier/{0}/", carrierId), parameters);
        }

        public override Task<IPlivoResponse<GenericResponse>> DeleteIncomingCarrierAsync(Dictionary<string, string> parameters)
        {
            string carrierId = GetKeyValue(ref parameters, "carrier_id");
            return RequestAsync<GenericResponse>("DELETE", String.Format("/IncomingCarrier/{0}/", carrierId), parameters);
        }

        public override IPlivoResponse<PlivoPricing> Pricing(Dictionary<string, string> parameters)
        {
            return Request<PlivoPricing>("GET", "/Pricing/", parameters);
        }

        public override Task<IPlivoResponse<PlivoPricing>> PricingAsync(Dictionary<string, string> parameters)
        {
            return RequestAsync<PlivoPricing>("GET", "/Pricing/", parameters);
        }

        // Outgoing Carriers
        public override IPlivoResponse<OutgoingCarrierList> GetOutgoingCarriers()
        {
            return Request<OutgoingCarrierList>("GET", "/OutgoingCarrier/", new Dictionary<string, string>());
        }

        public override Task<IPlivoResponse<OutgoingCarrierList>> GetOutgoingCarriersAsync()
        {
            return RequestAsync<OutgoingCarrierList>("GET", "/OutgoingCarrier/", new Dictionary<string, string>());
        }

        public override IPlivoResponse<OutgoingCarrier> GetOutgoingCarrier(Dictionary<string, string> parameters)
        {
            string carrierId = GetKeyValue(ref parameters, "carrier_id");
            return Request<OutgoingCarrier>("GET", String.Format("/OutgoingCarrier/{0}/", carrierId), parameters);
        }

        public override Task<IPlivoResponse<OutgoingCarrier>> GetOutgoingCarrierAsync(Dictionary<string, string> parameters)
        {
            string carrierId = GetKeyValue(ref parameters, "carrier_id");
            return RequestAsync<OutgoingCarrier>("GET", String.Format("/OutgoingCarrier/{0}/", carrierId), parameters);
        }

        public override IPlivoResponse<GenericResponse> CreateOutgoingCarrier(Dictionary<string, string> parameters)
        {
            return Request<GenericResponse>("POST", "/OutgoingCarrier/", parameters);
        }

        public override Task<IPlivoResponse<GenericResponse>> CreateOutgoingCarrierAsync(Dictionary<string, string> parameters)
        {
            return RequestAsync<GenericResponse>("POST", "/OutgoingCarrier/", parameters);
        }

        public override IPlivoResponse<GenericResponse> ModifyOutgoingCarrier(Dictionary<string, string> parameters)
        {
            string carrierId = GetKeyValue(ref parameters, "carrier_id");
            return Request<GenericResponse>("POST", String.Format("/OutgoingCarrier/{0}/", carrierId), parameters);
        }

        public override Task<IPlivoResponse<GenericResponse>> ModifyOutgoingCarrierAsync(Dictionary<string, string> parameters)
        {
            string carrierId = GetKeyValue(ref parameters, "carrier_id");
            return RequestAsync<GenericResponse>("POST", String.Format("/OutgoingCarrier/{0}/", carrierId), parameters);
        }

        public override IPlivoResponse<GenericResponse> DeleteOutgoingCarrier(Dictionary<string, string> parameters)
        {
            string carrierId = GetKeyValue(ref parameters, "carrier_id");
            return Request<GenericResponse>("DELETE", String.Format("/OutgoingCarrier/{0}/", carrierId), parameters);
        }

        public override Task<IPlivoResponse<GenericResponse>> DeleteOutgoingCarrierAsync(Dictionary<string, string> parameters)
        {
            string carrierId = GetKeyValue(ref parameters, "carrier_id");
            return RequestAsync<GenericResponse>("DELETE", String.Format("/OutgoingCarrier/{0}/", carrierId), parameters);
        }

        // Outgoing Carrier Routings
        public override IPlivoResponse<OutgoingCarrierRoutingList> GetOutgoingCarrierRoutings()
        {
            return Request<OutgoingCarrierRoutingList>("GET", "/OutgoingCarrierRouting/", new Dictionary<string, string>());
        }

        public override Task<IPlivoResponse<OutgoingCarrierRoutingList>> GetOutgoingCarrierRoutingsAsync()
        {
            return RequestAsync<OutgoingCarrierRoutingList>("GET", "/OutgoingCarrierRouting/", new Dictionary<string, string>());
        }

        public override IPlivoResponse<OutgoingCarrierRouting> GetOutgoingCarrierRouting(Dictionary<string, string> parameters)
        {
            string carrierId = GetKeyValue(ref parameters, "routing_id");
            return Request<OutgoingCarrierRouting>("GET", String.Format("/OutgoingCarrierRouting/{0}/", carrierId), parameters);
        }

        public override Task<IPlivoResponse<OutgoingCarrierRouting>> GetOutgoingCarrierRoutingAsync(Dictionary<string, string> parameters)
        {
            string carrierId = GetKeyValue(ref parameters, "routing_id");
            return RequestAsync<OutgoingCarrierRouting>("GET", String.Format("/OutgoingCarrierRouting/{0}/", carrierId), parameters);
        }

        public override IPlivoResponse<GenericResponse> CreateOutgoingCarrierRouting(Dictionary<string, string> parameters)
        {
            return Request<GenericResponse>("POST", "/OutgoingCarrierRouting/", parameters);
        }

        public override Task<IPlivoResponse<GenericResponse>> CreateOutgoingCarrierRoutingAsync(Dictionary<string, string> parameters)
        {
            return RequestAsync<GenericResponse>("POST", "/OutgoingCarrierRouting/", parameters);
        }

        public override IPlivoResponse<GenericResponse> ModifyOutgoingCarrierRouting(Dictionary<string, string> parameters)
        {
            string carrierId = GetKeyValue(ref parameters, "routing_id");
            return Request<GenericResponse>("POST", String.Format("/OutgoingCarrierRouting/{0}/", carrierId), parameters);
        }

        public override Task<IPlivoResponse<GenericResponse>> ModifyOutgoingCarrierRoutingAsync(Dictionary<string, string> parameters)
        {
            string carrierId = GetKeyValue(ref parameters, "routing_id");
            return RequestAsync<GenericResponse>("POST", String.Format("/OutgoingCarrierRouting/{0}/", carrierId), parameters);
        }

        public override IPlivoResponse<GenericResponse> DeleteOutgoingCarrierRouting(Dictionary<string, string> parameters)
        {
            string carrierId = GetKeyValue(ref parameters, "routing_id");
            return Request<GenericResponse>("DELETE", String.Format("/OutgoingCarrierRouting/{0}/", carrierId), parameters);
        }

        public override Task<IPlivoResponse<GenericResponse>> DeleteOutgoingCarrierRoutingAsync(Dictionary<string, string> parameters)
        {
            string carrierId = GetKeyValue(ref parameters, "routing_id");
            return RequestAsync<GenericResponse>("DELETE", String.Format("/OutgoingCarrierRouting/{0}/", carrierId), parameters);
        }

        public override IPlivoResponse<RecordingList> GetRecordings()
        {
            return Request<RecordingList>("GET", "/Recording/", new Dictionary<string, string>());
        }

        public override Task<IPlivoResponse<RecordingList>> GetRecordingsAsync()
        {
            return RequestAsync<RecordingList>("GET", "/Recording/", new Dictionary<string, string>());
        }

        public override IPlivoResponse<Recording> GetRecording(Dictionary<string, string> parameters)
        {
            string recordingId = GetKeyValue(ref parameters, "recording_id");
            return Request<Recording>("GET", String.Format("/Recording/{0}/", recordingId), parameters);
        }

        public override Task<IPlivoResponse<Recording>> GetRecordingAsync(Dictionary<string, string> parameters)
        {
            string recordingId = GetKeyValue(ref parameters, "recording_id");
            return RequestAsync<Recording>("GET", String.Format("/Recording/{0}/", recordingId), parameters);
        }

        public override IPlivoResponse<RecordingList> GetRecordingByCallUuid(Dictionary<string, string> parameters)
        {
            string callUUID = GetKeyValue(ref parameters, "call_uuid");
            return Request<RecordingList>("GET", "/Recording/?call_uuid=" + callUUID, new Dictionary<string, string>());
        }

        public override Task<IPlivoResponse<RecordingList>> GetRecordingByCallUuidAsync(Dictionary<string, string> parameters)
        {
            string callUUID = GetKeyValue(ref parameters, "call_uuid");
            return RequestAsync<RecordingList>("GET", "/Recording/?call_uuid=" + callUUID, new Dictionary<string, string>());
        }

        public override IPlivoResponse<GenericResponse> DeleteRecording(Dictionary<string, string> parameters)
        {
            string recordingId = GetKeyValue(ref parameters, "recording_id");
            return Request<GenericResponse>("DELETE", String.Format("/Recording/{0}/", recordingId), parameters);
        }

        public override Task<IPlivoResponse<GenericResponse>> DeleteRecordingAsync(Dictionary<string, string> parameters)
        {
            string recordingId = GetKeyValue(ref parameters, "recording_id");
            return RequestAsync<GenericResponse>("DELETE", String.Format("/Recording/{0}/", recordingId), parameters);
        }
    }
}