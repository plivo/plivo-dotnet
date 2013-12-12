using System;
using System.Web;
using System.Collections.Generic;
using RestSharp;
using Plivo.Util;
using RestSharp.Deserializers;
using dict = System.Collections.Generic.Dictionary<string, string>;

namespace Plivo.API
{
    public class PlivoException : Exception
    {
        public PlivoException(string message) : base(message) { }
    }

    public class RestAPI
    {
        private const string PlivoUrl = "https://api.plivo.com";
        public string PlivoVersion { get; set; }
        public string AuthID { get; set; }
        public string AuthToken { get; set; }
        private RestClient client;

        public RestAPI(string auth_id, string auth_token, string version = "v1")
        {
            PlivoVersion = version;
            AuthID = auth_id;
            AuthToken = auth_token;
            // Initialize the client
            client = new RestClient();
            client.Authenticator = new HttpBasicAuthenticator(AuthID, AuthToken);
            client.UserAgent = "PlivoCsharp";
            client.BaseUrl = String.Format("{0}/{1}/Account/{2}", PlivoUrl, PlivoVersion, AuthID);
        }

        private IRestResponse<T> _request<T>(string http_method, string resource, dict data)
            where T : new()
        {
            var request = new RestRequest() { Resource = resource, RequestFormat = DataFormat.Json };

            // add the parameters to the request
            foreach (KeyValuePair<string, string> kvp in data)
				request.AddParameter(kvp.Key, HtmlEntity.Convert(kvp.Value));

            //set the HTTP method for this request
            switch (http_method.ToUpper())
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

        private string get_key_value(ref dict dict, string key)
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
        public IRestResponse<Account> get_account()
        {
            return _request<Account>("GET", "/ ", new dict());
            // had to add an additional space after / as RestSharp consumes it.
        }

        public IRestResponse<GenericResponse> modify_account(dict parameters)
        {
            // had to add an additional space after / as RestSharp consumes it.
            return _request<GenericResponse>("POST", "/ ", parameters);
        }

        public IRestResponse<SubAccountList> get_subaccounts()
        {
            return _request<SubAccountList>("GET", "/Subaccount/", new dict());
        }

        public IRestResponse<SubAccount> get_subaccount(dict parameters)
        {
            string subauth_id = get_key_value(ref parameters, "subauth_id");
            return _request<SubAccount>("GET", String.Format("/Subaccount/{0}/", subauth_id), parameters);
        }

        public IRestResponse<GenericResponse> create_subaccount(dict parameters)
        {
            return _request<GenericResponse>("POST", "/Subaccount/", parameters);
        }

        public IRestResponse<GenericResponse> modify_subaccount(dict parameters)
        {
            string subauth_id = get_key_value(ref parameters, "subauth_id");
            return _request<GenericResponse>("POST", String.Format("/Subaccount/{0}/ ", subauth_id), parameters);
        }

        public IRestResponse<GenericResponse> delete_subaccount(dict parameters)
        {
            string subauth_id = get_key_value(ref parameters, "subauth_id");
            return _request<GenericResponse>("DELETE", String.Format("/Subaccount/{0}/", subauth_id), parameters);
        }

        /* private static dict mask_if_empty_params(dict parameters)
         {
             if (parameters.Count >= 0)
             {
                 return parameters;
             }
             else{
                 return new dict();
             }

         }*/

        // Applications //
        public IRestResponse<ApplicationList> get_applications()
        {
            return _request<ApplicationList>("GET", "/Application/", new dict());
        }

        public IRestResponse<ApplicationList> get_applications(dict parameters)
        {
            return _request<ApplicationList>("GET", "/Application/", parameters);
        }

        public IRestResponse<Application> get_application(dict parameters)
        {
            string app_id = get_key_value(ref parameters, "app_id");
            return _request<Application>("GET", String.Format("/Application/{0}/", app_id), parameters);
        }

        public IRestResponse<GenericResponse> create_application(dict parameters)
        {
            return _request<GenericResponse>("POST", "/Application/", parameters);
        }

        public IRestResponse<GenericResponse> modify_application(dict parameters)
        {
            string app_id = get_key_value(ref parameters, "app_id");
            return _request<GenericResponse>("POST", String.Format("/Application/{0}/", app_id), parameters);
        }

        public IRestResponse<GenericResponse> delete_application(dict parameters)
        {
            string app_id = get_key_value(ref parameters, "app_id");
            return _request<GenericResponse>("DELETE", String.Format("/Application/{0}/", app_id), parameters);
        }


        // Numbers //
        public IRestResponse<NumberList> get_numbers()
        {
            return _request<NumberList>("GET", "/Number/", new dict());
        }

        [Obsolete("Use search_number_group() instead")]
        public IRestResponse<NumberList> search_numbers(dict parameters)
        {
            return _request<NumberList>("GET", "/AvailableNumber/", parameters);
        }

        public IRestResponse<NumberList> search_number_group(dict parameters)
        {
            return _request<NumberList>("GET", "/AvailableNumberGroup/", parameters);
        }

        public IRestResponse<Number> get_number(dict parameters)
        {
            string number = get_key_value(ref parameters, "number");
            return _request<Number>("GET", String.Format("/Number/{0}/", number), parameters);
        }

        [Obsolete("Use rent_from_number_group() instead")]
        public IRestResponse<GenericResponse> rent_number(dict parameters)
        {
            string number = get_key_value(ref parameters, "number");
            return _request<GenericResponse>("POST", String.Format("/AvailableNumber/{0}/", number), parameters);
        }

        public IRestResponse<NumberResponse> rent_from_number_group(dict parameters)
        {
            string group_id = get_key_value(ref parameters, "group_id");
            return _request<NumberResponse>("POST", String.Format("/AvailableNumberGroup/{0}/", group_id), parameters);
        }

        public IRestResponse<GenericResponse> unrent_number(dict parameters)
        {
            string number = get_key_value(ref parameters, "number");
            return _request<GenericResponse>("DELETE", String.Format("/Number/{0}/", number), parameters);
        }

        public IRestResponse<GenericResponse> link_application_number(dict parameters)
        {
            string number = get_key_value(ref parameters, "number");
            return _request<GenericResponse>("POST", String.Format("/Number/{0}/", number), parameters);
        }

        public IRestResponse<GenericResponse> unlink_application_number(dict parameters)
        {
            string number = get_key_value(ref parameters, "number");
            parameters.Add("app_id", "");
            return _request<GenericResponse>("POST", String.Format("/Number/{0}/", number), parameters);
        }


        // Calls //
        public IRestResponse<CDRList> get_cdrs()
        {
            return _request<CDRList>("GET", "/Call/", new dict());
        }

        public IRestResponse<CDRList> get_cdrs(dict parameters)
        {
            return _request<CDRList>("GET", "/Call/", parameters);
        }

        public IRestResponse<CDR> get_cdr(dict parameters)
        {
            string record_id = get_key_value(ref parameters, "record_id");
            return _request<CDR>("GET", String.Format("/Call/{0}/", record_id), parameters);
        }

        public IRestResponse<LiveCallList> get_live_calls()
        {
            dict parameters = new dict();
            parameters.Add("status", "live");
            return _request<LiveCallList>("GET", "/Call/", parameters);
        }

        public IRestResponse<LiveCall> get_live_call(dict parameters)
        {
            string call_uuid = get_key_value(ref parameters, "call_uuid");
            parameters.Add("status", "live");
            return _request<LiveCall>("GET", String.Format("/Call/{0}/", call_uuid), parameters);
        }

        public IRestResponse<Call> make_call(dict parameters)
        {
            return _request<Call>("POST", "/Call/", parameters);
        }

        public IRestResponse<Call> make_bulk_call(dict parameters, dict destNumberSipHeaders)
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
            return _request<Call>("POST", "/Call/", parameters);
        }

        public IRestResponse<GenericResponse> hangup_all_calls()
        {
            return _request<GenericResponse>("DELETE", "/Call/", new dict());
        }

        public IRestResponse<GenericResponse> hangup_call(dict parameters)
        {
            string call_uuid = get_key_value(ref parameters, "call_uuid");
            return _request<GenericResponse>("DELETE", String.Format("/Call/{0}/", call_uuid), parameters);
        }

        public IRestResponse<GenericResponse> transfer_call(dict parameters)
        {
            string call_uuid = get_key_value(ref parameters, "call_uuid");
            return _request<GenericResponse>("POST", String.Format("/Call/{0}/", call_uuid), parameters);
        }

        public IRestResponse<Record> record(dict parameters)
        {
            string call_uuid = get_key_value(ref parameters, "call_uuid");
            return _request<Record>("POST", String.Format("/Call/{0}/Record/", call_uuid), parameters);
        }

        public IRestResponse<GenericResponse> stop_record(dict parameters)
        {
            string call_uuid = get_key_value(ref parameters, "call_uuid");
            return _request<GenericResponse>("DELETE", String.Format("/Call/{0}/Record/", call_uuid), parameters);
        }

        public IRestResponse<GenericResponse> play(dict parameters)
        {
            string call_uuid = get_key_value(ref parameters, "call_uuid");
            return _request<GenericResponse>("POST", String.Format("/Call/{0}/Play/", call_uuid), parameters);
        }

        public IRestResponse<GenericResponse> stop_play(dict parameters)
        {
            string call_uuid = get_key_value(ref parameters, "call_uuid");
            return _request<GenericResponse>("DELETE", String.Format("/Call/{0}/Play/", call_uuid), parameters);
        }

        public IRestResponse<GenericResponse> speak(dict parameters)
        {
            string call_uuid = get_key_value(ref parameters, "call_uuid");
            return _request<GenericResponse>("POST", String.Format("/Call/{0}/Speak/", call_uuid), parameters);
        }

        public IRestResponse<GenericResponse> stop_speak(dict parameters)
        {
            string call_uuid = get_key_value(ref parameters, "call_uuid");
            return _request<GenericResponse>("DELETE", String.Format("/Call/{0}/Speak/", call_uuid), parameters);
        }

        public IRestResponse<GenericResponse> send_digits(dict parameters)
        {
            string call_uuid = get_key_value(ref parameters, "call_uuid");
            return _request<GenericResponse>("POST", String.Format("/Call/{0}/DTMF/", call_uuid), parameters);
        }


        // Conferences //
        public IRestResponse<LiveConferenceList> get_live_conferences()
        {
            return _request<LiveConferenceList>("GET", "/Conference/", new dict());
        }

        public IRestResponse<GenericResponse> hangup_all_conferences()
        {
            return _request<GenericResponse>("DELETE", "/Conference/", new dict());
        }

        public IRestResponse<Conference> get_live_conference(dict parameters)
        {
            string conference_name = get_key_value(ref parameters, "conference_name");
            return _request<Conference>("GET", String.Format("/Conference/{0}/", conference_name), parameters);
        }

        public IRestResponse<GenericResponse> hangup_conference(dict parameters)
        {
            string conference_name = get_key_value(ref parameters, "conference_name");
            return _request<GenericResponse>("DELETE", String.Format("/Conference/{0}/", conference_name), parameters);
        }

        public IRestResponse<GenericResponse> hangup_member(dict parameters)
        {
            string conference_name = get_key_value(ref parameters, "conference_name");
            string member_id = get_key_value(ref parameters, "member_id");
            return _request<GenericResponse>("DELETE", String.Format("/Conference/{0}/Member/{1}/", conference_name, member_id), parameters);
        }

        public IRestResponse<GenericResponse> play_member(dict parameters)
        {
            string conference_name = get_key_value(ref parameters, "conference_name");
            string member_id = get_key_value(ref parameters, "member_id");
            return _request<GenericResponse>("POST", String.Format("/Conference/{0}/Member/{1}/Play/", conference_name, member_id), parameters);
        }

        public IRestResponse<GenericResponse> stop_play_member(dict parameters)
        {
            string conference_name = get_key_value(ref parameters, "conference_name");
            string member_id = get_key_value(ref parameters, "member_id");
            return _request<GenericResponse>("DELETE", String.Format("/Conference/{0}/Member/{1}/Play/", conference_name, member_id), parameters);
        }

        public IRestResponse<GenericResponse> speak_member(dict parameters)
        {
            string conference_name = get_key_value(ref parameters, "conference_name");
            string member_id = get_key_value(ref parameters, "member_id");
            return _request<GenericResponse>("POST", String.Format("/Conference/{0}/Member/{1}/Speak/", conference_name, member_id), parameters);
        }

        public IRestResponse<GenericResponse> deaf_member(dict parameters)
        {
            string conference_name = get_key_value(ref parameters, "conference_name");
            string member_id = get_key_value(ref parameters, "member_id");
            return _request<GenericResponse>("POST", String.Format("/Conference/{0}/Member/{1}/Deaf/", conference_name, member_id), parameters);
        }

        public IRestResponse<GenericResponse> undeaf_member(dict parameters)
        {
            string conference_name = get_key_value(ref parameters, "conference_name");
            string member_id = get_key_value(ref parameters, "member_id");
            return _request<GenericResponse>("DELETE", String.Format("/Conference/{0}/Member/{1}/Deaf/", conference_name, member_id), parameters);
        }

        public IRestResponse<GenericResponse> mute_member(dict parameters)
        {
            string conference_name = get_key_value(ref parameters, "conference_name");
            string member_id = get_key_value(ref parameters, "member_id");
            return _request<GenericResponse>("POST", String.Format("/Conference/{0}/Member/{1}/Mute/", conference_name, member_id), parameters);
        }

        public IRestResponse<GenericResponse> unmute_member(dict parameters)
        {
            string conference_name = get_key_value(ref parameters, "conference_name");
            string member_id = get_key_value(ref parameters, "member_id");
            return _request<GenericResponse>("DELETE", String.Format("/Conference/{0}/Member/{1}/Mute/", conference_name, member_id), parameters);
        }

        public IRestResponse<GenericResponse> kick_member(dict parameters)
        {
            string conference_name = get_key_value(ref parameters, "conference_name");
            string member_id = get_key_value(ref parameters, "member_id");
            return _request<GenericResponse>("POST", String.Format("/Conference/{0}/Member/{1}/Kick/", conference_name, member_id), parameters);
        }

        public IRestResponse<Record> record_conference(dict parameters)
        {
            string conference_name = get_key_value(ref parameters, "conference_name");
            return _request<Record>("POST", String.Format("/Conference/{0}/Record/", conference_name), parameters);
        }

        public IRestResponse<GenericResponse> stop_record_conference(dict parameters)
        {
            string conference_name = get_key_value(ref parameters, "conference_name");
            return _request<GenericResponse>("DELETE", String.Format("/Conference/{0}/Record/", conference_name), parameters);
        }


        // Endpoints //
        public IRestResponse<EndpointList> get_endpoints()
        {
            return _request<EndpointList>("GET", "/Endpoint/", new dict());
        }

        public IRestResponse<EndpointList> get_endpoints(dict parameters)
        {
            return _request<EndpointList>("GET", "/Endpoint/", parameters);
        }

        public IRestResponse<Endpoint> create_endpoint(dict parameters)
        {
            return _request<Endpoint>("POST", "/Endpoint/", parameters);
        }

        public IRestResponse<Endpoint> get_endpoint(dict parameters)
        {
            string endpoint_id = get_key_value(ref parameters, "endpoint_id");
            return _request<Endpoint>("GET", String.Format("/Endpoint/{0}/", endpoint_id), parameters);
        }

        public IRestResponse<GenericResponse> modify_endpoint(dict parameters)
        {
            string endpoint_id = get_key_value(ref parameters, "endpoint_id");
            return _request<GenericResponse>("POST", String.Format("/Endpoint/{0}/", endpoint_id), parameters);
        }

        public IRestResponse<GenericResponse> delete_endpoint(dict parameters)
        {
            string endpoint_id = get_key_value(ref parameters, "endpoint_id");
            return _request<GenericResponse>("DELETE", String.Format("/Endpoint/{0}/", endpoint_id), parameters);
        }


        // Messages //
        public IRestResponse<MessageResponse> send_message(dict parameters)
        {
            return _request<MessageResponse>("POST", "/Message/", parameters);
        }

        public IRestResponse<Message> get_message(dict parameters)
        {
            string record_id = get_key_value(ref parameters, "record_id");
            return _request<Message>("GET", String.Format("/Message/{0}/", record_id), parameters);
        }


        public IRestResponse<MessageList> get_messages()
        {
            return _request<MessageList>("GET", "/Message/", new dict());
        }

        public IRestResponse<MessageList> get_messages(dict parameters)
        {
            return _request<MessageList>("GET", "/Message/", parameters);
        }


        // Inbound Carriers
        public IRestResponse<IncomingCarrierList> get_incoming_carriers(dict parameters)
        {
            return _request<IncomingCarrierList>("GET", "/IncomingCarrier/", parameters);
        }

        public IRestResponse<IncomingCarrier> get_incoming_carrier(dict parameters)
        {
            string carrierId = get_key_value(ref parameters, "carrier_id");
            return _request<IncomingCarrier>("GET", String.Format("/IncomingCarrier/{0}/", carrierId), parameters);
        }

        public IRestResponse<GenericResponse> create_incoming_carrier(dict parameters)
        {
            return _request<GenericResponse>("POST", "/IncomingCarrier/", parameters);
        }

        public IRestResponse<IncomingCarrier> modify_incoming_carrier(dict parameters)
        {
            string carrierId = get_key_value(ref parameters, "carrier_id");
            return _request<IncomingCarrier>("POST", String.Format("/IncomingCarrier/{0}/", carrierId), parameters);
        }

        public IRestResponse<GenericResponse> delete_incoming_carrier(dict parameters)
        {
            string carrierId = get_key_value(ref parameters, "carrier_id");
            return _request<GenericResponse>("DELETE", String.Format("/IncomingCarrier/{0}/", carrierId), parameters);
        }

        public IRestResponse<PlivoPricing> pricing(dict parameters)
        {
            return _request<PlivoPricing>("GET", "/Pricing/", parameters);
        }

        // Outgoing Carriers
        public IRestResponse<OutgoingCarrierList> get_outgoing_carriers()
        {
            return _request<OutgoingCarrierList>("GET", "/OutgoingCarrier/", new dict());
        }

        public IRestResponse<OutgoingCarrier> get_outgoing_carrier(dict parameters)
        {
            string carrierId = get_key_value(ref parameters, "carrier_id");
            return _request<OutgoingCarrier>("GET", String.Format("/OutgoingCarrier/{0}/", carrierId), parameters);
        }

        public IRestResponse<GenericResponse> create_outgoing_carrier(dict parameters)
        {
            return _request<GenericResponse>("POST", "/OutgoingCarrier/", parameters);
        }

        public IRestResponse<GenericResponse> modify_outgoing_carrier(dict parameters)
        {
            string carrierId = get_key_value(ref parameters, "carrier_id");
            return _request<GenericResponse>("POST", String.Format("/OutgoingCarrier/{0}/", carrierId), parameters);
        }

        public IRestResponse<GenericResponse> delete_outgoing_carrier(dict parameters)
        {
            string carrierId = get_key_value(ref parameters, "carrier_id");
            return _request<GenericResponse>("DELETE", String.Format("/OutgoingCarrier/{0}/", carrierId), parameters);
        }

        // Outgoing Carrier Routings
        public IRestResponse<OutgoingCarrierRoutingList> get_outgoing_carrier_routings()
        {
            return _request<OutgoingCarrierRoutingList>("GET", "/OutgoingCarrierRouting/", new dict());
        }

        public IRestResponse<OutgoingCarrierRouting> get_outgoing_carrier_routing(dict parameters)
        {
            string carrierId = get_key_value(ref parameters, "routing_id");
            return _request<OutgoingCarrierRouting>("GET", String.Format("/OutgoingCarrierRouting/{0}/", carrierId), parameters);
        }

        public IRestResponse<GenericResponse> create_outgoing_carrier_routing(dict parameters)
        {
            return _request<GenericResponse>("POST", "/OutgoingCarrierRouting/", parameters);
        }

        public IRestResponse<GenericResponse> modify_outgoing_carrier_routing(dict parameters)
        {
            string carrierId = get_key_value(ref parameters, "routing_id");
            return _request<GenericResponse>("POST", String.Format("/OutgoingCarrierRouting/{0}/", carrierId), parameters);
        }

        public IRestResponse<GenericResponse> delete_outgoing_carrier_routing(dict parameters)
        {
            string carrierId = get_key_value(ref parameters, "routing_id");
            return _request<GenericResponse>("DELETE", String.Format("/OutgoingCarrierRouting/{0}/", carrierId), parameters);
        }

        public IRestResponse<RecordingList> get_recordings()
        {
            return _request<RecordingList>("GET", "/Recording/", new dict());
        }
        public IRestResponse<Recording> get_recording(dict parameters)
        {
            string recordingId = get_key_value(ref parameters, "recording_id");
            return _request<Recording>("GET", String.Format("/Recording/{0}/", recordingId), parameters);
        }
        public IRestResponse<RecordingList> get_recording_by_call_uuid(dict parameters)
        {
            string callUUID = get_key_value(ref parameters, "call_uuid");
            return _request<RecordingList>("GET", "/Recording/?call_uuid=" + callUUID, new dict());
        }
    }
}