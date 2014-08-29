using System;
using System.Collections.Generic;
using Plivo.Exceptions;
using RestSharp;
using RestSharp.Deserializers;

namespace Plivo
{
    public class RestApi
    {
        private const string PLIVO_URL = "https://api.plivo.com";
        public string PlivoVersion { get; set; }
        public string AuthID { get; set; }
        public string AuthToken { get; set; }
        private RestClient client;

        public RestApi(string auth_id, string auth_token, string version = "v1")
        {
            PlivoVersion = version;
            AuthID = auth_id;
            AuthToken = auth_token;
            // Initialize the client
            client = new RestClient();
            client.Authenticator = new HttpBasicAuthenticator(AuthID, AuthToken);
            client.UserAgent = "PlivoCsharp";
            client.BaseUrl = String.Format("{0}/{1}/Account/{2}", PLIVO_URL, PlivoVersion, AuthID);
        }

        private IRestResponse<T> Request<T>(string httpMethod, string resource, Dictionary<string, string> data) where T : new()
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
            return response;
        }

        private void RequestAsync<T>(string httpMethod,string resource,Dictionary<string,string> data) where T: new()
        {
            
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
        public IRestResponse<Account> GetAccount()
        {
            return Request<Account>("GET", "/ ", new Dictionary<string, string>());
            // had to add an additional space after / as RestSharp consumes it.
        }

        public IRestResponse<GenericResponse> ModifyAccount(Dictionary<string, string> parameters)
        {
            // had to add an additional space after / as RestSharp consumes it.
            return Request<GenericResponse>("POST", "/ ", parameters);
        }

        public IRestResponse<SubAccountList> GetSubaccounts()
        {
            return Request<SubAccountList>("GET", "/Subaccount/", new Dictionary<string, string>());
        }

        public IRestResponse<SubAccount> GetSubAccount(Dictionary<string, string> parameters)
        {
            string subauth_id = GetKeyValue(ref parameters, "subauth_id");
            return Request<SubAccount>("GET", String.Format("/Subaccount/{0}/", subauth_id), parameters);
        }

        public IRestResponse<GenericResponse> CreateSubAccount(Dictionary<string, string> parameters)
        {
            return Request<GenericResponse>("POST", "/Subaccount/", parameters);
        }

        public IRestResponse<GenericResponse> ModifySubAccount(Dictionary<string, string> parameters)
        {
            string subauth_id = GetKeyValue(ref parameters, "subauth_id");
            return Request<GenericResponse>("POST", String.Format("/Subaccount/{0}/ ", subauth_id), parameters);
        }

        public IRestResponse<GenericResponse> DeleteSubAccount(Dictionary<string, string> parameters)
        {
            string subauth_id = GetKeyValue(ref parameters, "subauth_id");
            return Request<GenericResponse>("DELETE", String.Format("/Subaccount/{0}/", subauth_id), parameters);
        }

        // Applications //
        public IRestResponse<ApplicationList> GetApplications()
        {
            return Request<ApplicationList>("GET", "/Application/", new Dictionary<string, string>());
        }

        public IRestResponse<ApplicationList> GetApplications(Dictionary<string, string> parameters)
        {
            return Request<ApplicationList>("GET", "/Application/", parameters);
        }

        public IRestResponse<Application> GetApplication(Dictionary<string, string> parameters)
        {
            string app_id = GetKeyValue(ref parameters, "app_id");
            return Request<Application>("GET", String.Format("/Application/{0}/", app_id), parameters);
        }

        public IRestResponse<GenericResponse> CreateApplication(Dictionary<string, string> parameters)
        {
            return Request<GenericResponse>("POST", "/Application/", parameters);
        }

        public IRestResponse<GenericResponse> ModifyApplication(Dictionary<string, string> parameters)
        {
            string app_id = GetKeyValue(ref parameters, "app_id");
            return Request<GenericResponse>("POST", String.Format("/Application/{0}/", app_id), parameters);
        }

        public IRestResponse<GenericResponse> DeleteApplication(Dictionary<string, string> parameters)
        {
            string app_id = GetKeyValue(ref parameters, "app_id");
            return Request<GenericResponse>("DELETE", String.Format("/Application/{0}/", app_id), parameters);
        }


        // Numbers //
        public IRestResponse<NumberList> GetNumbers()
        {
            return Request<NumberList>("GET", "/Number/", new Dictionary<string, string>());
        }

        [Obsolete("Use SearchNumberGroup() instead")]
        public IRestResponse<NumberList> SearchNumbers(Dictionary<string, string> parameters)
        {
            return Request<NumberList>("GET", "/AvailableNumber/", parameters);
        }

        public IRestResponse<NumberList> SearchNumberGroup(Dictionary<string, string> parameters)
        {
            return Request<NumberList>("GET", "/AvailableNumberGroup/", parameters);
        }

        public IRestResponse<Number> GetNumber(Dictionary<string, string> parameters)
        {
            string number = GetKeyValue(ref parameters, "number");
            return Request<Number>("GET", String.Format("/Number/{0}/", number), parameters);
        }

        [Obsolete("Use RentFromNumberGroup() instead")]
        public IRestResponse<GenericResponse> RentNumber(Dictionary<string, string> parameters)
        {
            string number = GetKeyValue(ref parameters, "number");
            return Request<GenericResponse>("POST", String.Format("/AvailableNumber/{0}/", number), parameters);
        }

        public IRestResponse<NumberResponse> RentFromNumberGroup(Dictionary<string, string> parameters)
        {
            string group_id = GetKeyValue(ref parameters, "group_id");
            return Request<NumberResponse>("POST", String.Format("/AvailableNumberGroup/{0}/", group_id), parameters);
        }

        public IRestResponse<GenericResponse> UnrentNumber(Dictionary<string, string> parameters)
        {
            string number = GetKeyValue(ref parameters, "number");
            return Request<GenericResponse>("DELETE", String.Format("/Number/{0}/", number), parameters);
        }

        public IRestResponse<GenericResponse> LinkApplicationNumber(Dictionary<string, string> parameters)
        {
            string number = GetKeyValue(ref parameters, "number");
            return Request<GenericResponse>("POST", String.Format("/Number/{0}/", number), parameters);
        }

        public IRestResponse<GenericResponse> UnlinkApplicationNumber(Dictionary<string, string> parameters)
        {
            string number = GetKeyValue(ref parameters, "number");
            parameters.Add("app_id", "");
            return Request<GenericResponse>("POST", String.Format("/Number/{0}/", number), parameters);
        }


        // Calls //
        public IRestResponse<CDRList> GetCdrs()
        {
            return Request<CDRList>("GET", "/Call/", new Dictionary<string, string>());
        }

        public IRestResponse<CDRList> GetCdrs(Dictionary<string, string> parameters)
        {
            return Request<CDRList>("GET", "/Call/", parameters);
        }

        public IRestResponse<CDR> GetCdr(Dictionary<string, string> parameters)
        {
            string record_id = GetKeyValue(ref parameters, "record_id");
            return Request<CDR>("GET", String.Format("/Call/{0}/", record_id), parameters);
        }

        public IRestResponse<LiveCallList> GetLiveCalls()
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("status", "live");
            return Request<LiveCallList>("GET", "/Call/", parameters);
        }

        public IRestResponse<LiveCall> GetLiveCall(Dictionary<string, string> parameters)
        {
            string call_uuid = GetKeyValue(ref parameters, "call_uuid");
            parameters.Add("status", "live");
            return Request<LiveCall>("GET", String.Format("/Call/{0}/", call_uuid), parameters);
        }

        public IRestResponse<Call> MakeCall(Dictionary<string, string> parameters)
        {
            return Request<Call>("POST", "/Call/", parameters);
        }

        public IRestResponse<Call> MakeBulkCall(Dictionary<string, string> parameters, Dictionary<string, string> destNumberSipHeaders)
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

        public IRestResponse<GenericResponse> HangupAllCalls()
        {
            return Request<GenericResponse>("DELETE", "/Call/", new Dictionary<string, string>());
        }

        public IRestResponse<GenericResponse> HangupCall(Dictionary<string, string> parameters)
        {
            string call_uuid = GetKeyValue(ref parameters, "call_uuid");
            return Request<GenericResponse>("DELETE", String.Format("/Call/{0}/", call_uuid), parameters);
        }

        public IRestResponse<GenericResponse> TransferCall(Dictionary<string, string> parameters)
        {
            string call_uuid = GetKeyValue(ref parameters, "call_uuid");
            return Request<GenericResponse>("POST", String.Format("/Call/{0}/", call_uuid), parameters);
        }

        public IRestResponse<Record> Record(Dictionary<string, string> parameters)
        {
            string call_uuid = GetKeyValue(ref parameters, "call_uuid");
            return Request<Record>("POST", String.Format("/Call/{0}/Record/", call_uuid), parameters);
        }

        public IRestResponse<GenericResponse> StopRecord(Dictionary<string, string> parameters)
        {
            string call_uuid = GetKeyValue(ref parameters, "call_uuid");
            return Request<GenericResponse>("DELETE", String.Format("/Call/{0}/Record/", call_uuid), parameters);
        }

        public IRestResponse<GenericResponse> Play(Dictionary<string, string> parameters)
        {
            string call_uuid = GetKeyValue(ref parameters, "call_uuid");
            return Request<GenericResponse>("POST", String.Format("/Call/{0}/Play/", call_uuid), parameters);
        }

        public IRestResponse<GenericResponse> StopPlay(Dictionary<string, string> parameters)
        {
            string call_uuid = GetKeyValue(ref parameters, "call_uuid");
            return Request<GenericResponse>("DELETE", String.Format("/Call/{0}/Play/", call_uuid), parameters);
        }

        public IRestResponse<GenericResponse> Speak(Dictionary<string, string> parameters)
        {
            string call_uuid = GetKeyValue(ref parameters, "call_uuid");
            return Request<GenericResponse>("POST", String.Format("/Call/{0}/Speak/", call_uuid), parameters);
        }

        public IRestResponse<GenericResponse> StopSpeak(Dictionary<string, string> parameters)
        {
            string call_uuid = GetKeyValue(ref parameters, "call_uuid");
            return Request<GenericResponse>("DELETE", String.Format("/Call/{0}/Speak/", call_uuid), parameters);
        }

        public IRestResponse<GenericResponse> SendDigits(Dictionary<string, string> parameters)
        {
            string call_uuid = GetKeyValue(ref parameters, "call_uuid");
            return Request<GenericResponse>("POST", String.Format("/Call/{0}/DTMF/", call_uuid), parameters);
        }


        // Conferences //
        public IRestResponse<LiveConferenceList> GetLiveConferences()
        {
            return Request<LiveConferenceList>("GET", "/Conference/", new Dictionary<string, string>());
        }

        public IRestResponse<GenericResponse> HangupAllConferences()
        {
            return Request<GenericResponse>("DELETE", "/Conference/", new Dictionary<string, string>());
        }

        public IRestResponse<Conference> GetLiveConference(Dictionary<string, string> parameters)
        {
            string conference_name = GetKeyValue(ref parameters, "conference_name");
            return Request<Conference>("GET", String.Format("/Conference/{0}/", conference_name), parameters);
        }

        public IRestResponse<GenericResponse> HangupConference(Dictionary<string, string> parameters)
        {
            string conference_name = GetKeyValue(ref parameters, "conference_name");
            return Request<GenericResponse>("DELETE", String.Format("/Conference/{0}/", conference_name), parameters);
        }

        public IRestResponse<GenericResponse> HangupMember(Dictionary<string, string> parameters)
        {
            string conference_name = GetKeyValue(ref parameters, "conference_name");
            string member_id = GetKeyValue(ref parameters, "member_id");
            return Request<GenericResponse>("DELETE", String.Format("/Conference/{0}/Member/{1}/", conference_name, member_id), parameters);
        }

        public IRestResponse<GenericResponse> PlayMember(Dictionary<string, string> parameters)
        {
            string conference_name = GetKeyValue(ref parameters, "conference_name");
            string member_id = GetKeyValue(ref parameters, "member_id");
            return Request<GenericResponse>("POST", String.Format("/Conference/{0}/Member/{1}/Play/", conference_name, member_id), parameters);
        }

        public IRestResponse<GenericResponse> StopPlayMember(Dictionary<string, string> parameters)
        {
            string conference_name = GetKeyValue(ref parameters, "conference_name");
            string member_id = GetKeyValue(ref parameters, "member_id");
            return Request<GenericResponse>("DELETE", String.Format("/Conference/{0}/Member/{1}/Play/", conference_name, member_id), parameters);
        }

        public IRestResponse<GenericResponse> SpeakMember(Dictionary<string, string> parameters)
        {
            string conference_name = GetKeyValue(ref parameters, "conference_name");
            string member_id = GetKeyValue(ref parameters, "member_id");
            return Request<GenericResponse>("POST", String.Format("/Conference/{0}/Member/{1}/Speak/", conference_name, member_id), parameters);
        }

        public IRestResponse<GenericResponse> DeafMember(Dictionary<string, string> parameters)
        {
            string conference_name = GetKeyValue(ref parameters, "conference_name");
            string member_id = GetKeyValue(ref parameters, "member_id");
            return Request<GenericResponse>("POST", String.Format("/Conference/{0}/Member/{1}/Deaf/", conference_name, member_id), parameters);
        }

        public IRestResponse<GenericResponse> UndeadMember(Dictionary<string, string> parameters)
        {
            string conference_name = GetKeyValue(ref parameters, "conference_name");
            string member_id = GetKeyValue(ref parameters, "member_id");
            return Request<GenericResponse>("DELETE", String.Format("/Conference/{0}/Member/{1}/Deaf/", conference_name, member_id), parameters);
        }

        public IRestResponse<GenericResponse> MuteMember(Dictionary<string, string> parameters)
        {
            string conference_name = GetKeyValue(ref parameters, "conference_name");
            string member_id = GetKeyValue(ref parameters, "member_id");
            return Request<GenericResponse>("POST", String.Format("/Conference/{0}/Member/{1}/Mute/", conference_name, member_id), parameters);
        }

        public IRestResponse<GenericResponse> UnmuteMember(Dictionary<string, string> parameters)
        {
            string conference_name = GetKeyValue(ref parameters, "conference_name");
            string member_id = GetKeyValue(ref parameters, "member_id");
            return Request<GenericResponse>("DELETE", String.Format("/Conference/{0}/Member/{1}/Mute/", conference_name, member_id), parameters);
        }

        public IRestResponse<GenericResponse> KickMember(Dictionary<string, string> parameters)
        {
            string conference_name = GetKeyValue(ref parameters, "conference_name");
            string member_id = GetKeyValue(ref parameters, "member_id");
            return Request<GenericResponse>("POST", String.Format("/Conference/{0}/Member/{1}/Kick/", conference_name, member_id), parameters);
        }

        public IRestResponse<Record> RecordConference(Dictionary<string, string> parameters)
        {
            string conference_name = GetKeyValue(ref parameters, "conference_name");
            return Request<Record>("POST", String.Format("/Conference/{0}/Record/", conference_name), parameters);
        }

        public IRestResponse<GenericResponse> StopRecordConference(Dictionary<string, string> parameters)
        {
            string conference_name = GetKeyValue(ref parameters, "conference_name");
            return Request<GenericResponse>("DELETE", String.Format("/Conference/{0}/Record/", conference_name), parameters);
        }


        // Endpoints //
        public IRestResponse<EndpointList> GetEndpoints()
        {
            return Request<EndpointList>("GET", "/Endpoint/", new Dictionary<string, string>());
        }

        public IRestResponse<EndpointList> GetEndpoints(Dictionary<string, string> parameters)
        {
            return Request<EndpointList>("GET", "/Endpoint/", parameters);
        }

        public IRestResponse<Endpoint> CreateEndpoint(Dictionary<string, string> parameters)
        {
            return Request<Endpoint>("POST", "/Endpoint/", parameters);
        }

        public IRestResponse<Endpoint> GetEndpoint(Dictionary<string, string> parameters)
        {
            string endpoint_id = GetKeyValue(ref parameters, "endpoint_id");
            return Request<Endpoint>("GET", String.Format("/Endpoint/{0}/", endpoint_id), parameters);
        }

        public IRestResponse<GenericResponse> ModifyEndpoint(Dictionary<string, string> parameters)
        {
            string endpoint_id = GetKeyValue(ref parameters, "endpoint_id");
            return Request<GenericResponse>("POST", String.Format("/Endpoint/{0}/", endpoint_id), parameters);
        }

        public IRestResponse<GenericResponse> DeleteEndpoint(Dictionary<string, string> parameters)
        {
            string endpoint_id = GetKeyValue(ref parameters, "endpoint_id");
            return Request<GenericResponse>("DELETE", String.Format("/Endpoint/{0}/", endpoint_id), parameters);
        }


        // Messages //
        public IRestResponse<MessageResponse> SendMessage(Dictionary<string, string> parameters)
        {
            return Request<MessageResponse>("POST", "/Message/", parameters);
        }

        public IRestResponse<Message> GetMessage(Dictionary<string, string> parameters)
        {
            string record_id = GetKeyValue(ref parameters, "record_id");
            return Request<Message>("GET", String.Format("/Message/{0}/", record_id), parameters);
        }


        public IRestResponse<MessageList> GetMessages()
        {
            return Request<MessageList>("GET", "/Message/", new Dictionary<string, string>());
        }

        public IRestResponse<MessageList> GetMessages(Dictionary<string, string> parameters)
        {
            return Request<MessageList>("GET", "/Message/", parameters);
        }


        // Inbound Carriers
        public IRestResponse<IncomingCarrierList> GetIncomingCarriers(Dictionary<string, string> parameters)
        {
            return Request<IncomingCarrierList>("GET", "/IncomingCarrier/", parameters);
        }

        public IRestResponse<IncomingCarrier> GetIncomingCarrier(Dictionary<string, string> parameters)
        {
            string carrierId = GetKeyValue(ref parameters, "carrier_id");
            return Request<IncomingCarrier>("GET", String.Format("/IncomingCarrier/{0}/", carrierId), parameters);
        }

        public IRestResponse<GenericResponse> CreateIncomingCarrier(Dictionary<string, string> parameters)
        {
            return Request<GenericResponse>("POST", "/IncomingCarrier/", parameters);
        }

        public IRestResponse<IncomingCarrier> ModifyIncomingCarrier(Dictionary<string, string> parameters)
        {
            string carrierId = GetKeyValue(ref parameters, "carrier_id");
            return Request<IncomingCarrier>("POST", String.Format("/IncomingCarrier/{0}/", carrierId), parameters);
        }

        public IRestResponse<GenericResponse> DeleteIncomingCarrier(Dictionary<string, string> parameters)
        {
            string carrierId = GetKeyValue(ref parameters, "carrier_id");
            return Request<GenericResponse>("DELETE", String.Format("/IncomingCarrier/{0}/", carrierId), parameters);
        }

        public IRestResponse<PlivoPricing> Pricing(Dictionary<string, string> parameters)
        {
            return Request<PlivoPricing>("GET", "/Pricing/", parameters);
        }

        // Outgoing Carriers
        public IRestResponse<OutgoingCarrierList> GetOutgoingCarriers()
        {
            return Request<OutgoingCarrierList>("GET", "/OutgoingCarrier/", new Dictionary<string, string>());
        }

        public IRestResponse<OutgoingCarrier> GetOutgoingCarrier(Dictionary<string, string> parameters)
        {
            string carrierId = GetKeyValue(ref parameters, "carrier_id");
            return Request<OutgoingCarrier>("GET", String.Format("/OutgoingCarrier/{0}/", carrierId), parameters);
        }

        public IRestResponse<GenericResponse> CreateOutgoingCarrier(Dictionary<string, string> parameters)
        {
            return Request<GenericResponse>("POST", "/OutgoingCarrier/", parameters);
        }

        public IRestResponse<GenericResponse> ModifyOutgoingCarrier(Dictionary<string, string> parameters)
        {
            string carrierId = GetKeyValue(ref parameters, "carrier_id");
            return Request<GenericResponse>("POST", String.Format("/OutgoingCarrier/{0}/", carrierId), parameters);
        }

        public IRestResponse<GenericResponse> DeleteOutgoingCarrier(Dictionary<string, string> parameters)
        {
            string carrierId = GetKeyValue(ref parameters, "carrier_id");
            return Request<GenericResponse>("DELETE", String.Format("/OutgoingCarrier/{0}/", carrierId), parameters);
        }

        // Outgoing Carrier Routings
        public IRestResponse<OutgoingCarrierRoutingList> GetOutgoingCarrierRoutings()
        {
            return Request<OutgoingCarrierRoutingList>("GET", "/OutgoingCarrierRouting/", new Dictionary<string, string>());
        }

        public IRestResponse<OutgoingCarrierRouting> GetOutgoingCarrierRouting(Dictionary<string, string> parameters)
        {
            string carrierId = GetKeyValue(ref parameters, "routing_id");
            return Request<OutgoingCarrierRouting>("GET", String.Format("/OutgoingCarrierRouting/{0}/", carrierId), parameters);
        }

        public IRestResponse<GenericResponse> CreateOutgoingCarrierRouting(Dictionary<string, string> parameters)
        {
            return Request<GenericResponse>("POST", "/OutgoingCarrierRouting/", parameters);
        }

        public IRestResponse<GenericResponse> ModifyOutgoingCarrierRouting(Dictionary<string, string> parameters)
        {
            string carrierId = GetKeyValue(ref parameters, "routing_id");
            return Request<GenericResponse>("POST", String.Format("/OutgoingCarrierRouting/{0}/", carrierId), parameters);
        }

        public IRestResponse<GenericResponse> DeleteOutgoingCarrierRouting(Dictionary<string, string> parameters)
        {
            string carrierId = GetKeyValue(ref parameters, "routing_id");
            return Request<GenericResponse>("DELETE", String.Format("/OutgoingCarrierRouting/{0}/", carrierId), parameters);
        }

        public IRestResponse<RecordingList> GetRecordings()
        {
            return Request<RecordingList>("GET", "/Recording/", new Dictionary<string, string>());
        }
        public IRestResponse<Recording> GetRecording(Dictionary<string, string> parameters)
        {
            string recordingId = GetKeyValue(ref parameters, "recording_id");
            return Request<Recording>("GET", String.Format("/Recording/{0}/", recordingId), parameters);
        }
        public IRestResponse<RecordingList> GetRecordingByCallUuid(Dictionary<string, string> parameters)
        {
            string callUUID = GetKeyValue(ref parameters, "call_uuid");
            return Request<RecordingList>("GET", "/Recording/?call_uuid=" + callUUID, new Dictionary<string, string>());
        }

        public IRestResponse<GenericResponse> DeleteRecording(Dictionary<string, string> parameters)
        {
            string recordingId = GetKeyValue(ref parameters, "recording_id");
            return Request<GenericResponse>("DELETE", String.Format("/Recording/{0}/", recordingId), parameters);
        }
    }
}