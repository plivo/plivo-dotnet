using System;
using System.Collections.Generic;
using RestSharp;
using RestSharp.Deserializers;
using dict = System.Collections.Generic.Dictionary<string, string>;

namespace Plivo.API
{
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

        private IRestResponse<T> _request<T>(string resource, Dictionary<string, string> data, string http_method) where T : new()
        {
            var request = new RestRequest() { Resource = resource, RequestFormat = DataFormat.Json };

            // add the parameters to the request
            foreach (KeyValuePair<string, string> kvp in data)
                request.AddParameter(kvp.Key, kvp.Value);

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

            this.client.AddHandler("application/json", new JsonDeserializer());
            IRestResponse<T> response = this.client.Execute<T>(request);
            return response;
        }

        private string get_key_value(ref Dictionary<string, string> dict, string key)
        {
            string value = "";
            try
            {
                value = dict[key];
                dict.Remove(key);
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Missing mandatory parameter {0}.", key);
            }
            return value;
        }

// Accounts //
        public IRestResponse<Account> get_account()
        {
            // had to add an additional space after / as RestSharp consumes it.
            return _request<Account>("/ ", new dict(), "GET");
        }

        public IRestResponse<GenericResponse> modify_account(dict parameters)
        {
            // had to add an additional space after / as RestSharp consumes it.
            return _request<GenericResponse>("/ ", parameters, "POST");
        }

        public IRestResponse<SubAccountList> get_subaccounts()
        {
            return _request <SubAccountList>("/Subaccount/", new dict(), "GET");
        }

        public IRestResponse<SubAccount> get_subaccount(dict parameters)
        {
            string subauth_id = get_key_value(ref parameters, "subauth_id");
            return _request<SubAccount>(String.Format("/Subaccount/{0}/", subauth_id), parameters, "GET");
        }

        public IRestResponse<GenericResponse> create_subaccount(dict parameters)
        {
            return _request<GenericResponse>("/Subaccount/", parameters, "POST");
        }

        public IRestResponse<GenericResponse> modify_subaccount(dict parameters)
        {
            string subauth_id = get_key_value(ref parameters, "subauth_id");
            string resource = String.Format("/Subaccount/{0}/ ", subauth_id);
            return _request<GenericResponse>(resource, parameters, "POST");
        }

        public IRestResponse<GenericResponse> delete_subaccount(dict parameters)
        {
            string subauth_id = get_key_value(ref parameters, "subauth_id");
            string resource = String.Format("/Subaccount/{0}/", subauth_id);
            return _request<GenericResponse>(resource, new dict(), "DELETE");
        }

        // Applications //
        public IRestResponse<ApplicationList> get_applications(dict parameters)
        {
            // had to add an additional slash as RestSharp consumes the trailing slash.
            return _request<ApplicationList>("/Application//", parameters, "GET");
        }

        public IRestResponse<Application> get_application(dict parameters)
        {
            string app_id = get_key_value(ref parameters, "app_id");
            string resource = String.Format("/Application/{0}/", app_id);
            return _request<Application>(resource, new dict(), "GET");
        }

        public IRestResponse<GenericResponse> create_application(dict parameters)
        {
            return _request <GenericResponse>("/Application/", parameters, "POST");
        }

        public IRestResponse<GenericResponse> modify_application(dict parameters)
        {
            string app_id = get_key_value(ref parameters, "app_id");
            return _request <GenericResponse>(String.Format("/Application/{0}/", app_id), parameters, "POST");
        }

        public IRestResponse<GenericResponse> delete_application(dict parameters)
        {
            string app_id = get_key_value(ref parameters, "app_id");
            return _request<GenericResponse>(String.Format("/Application/{0}/", app_id), new dict(), "DELETE");
        }

        
        // Numbers //
        public IRestResponse<NumberList> get_numbers()
        {
            // had to add an additional slash as RestSharp consumes the trailing slash.
            return _request<NumberList>("/Number//", new dict(), "GET");
        }

        public IRestResponse<NumberList> search_numbers(dict parameters)
        {
            // had to add an additional slash as RestSharp consumes the trailing slash.
            return _request<NumberList>("/AvailableNumber//", parameters, "GET");
        }

        public IRestResponse<Number> get_number(dict parameters)
        {
            string number = get_key_value(ref parameters, "number");
            return _request<Number>(String.Format("/Number/{0}/", number), new dict(), "GET");
        }

        public IRestResponse<GenericResponse> rent_number(dict parameters)
        {
            string number = get_key_value(ref parameters, "number");
            return _request<GenericResponse>(String.Format("/AvailableNumber/{0}/", number), new dict(), "POST");
        }

        public IRestResponse<GenericResponse> unrent_number(dict parameters)
        {
            string number = get_key_value(ref parameters, "number");
            return _request<GenericResponse>(String.Format("/Number/{0}/", number), new dict(), "DELETE");
        }

        public IRestResponse<GenericResponse> link_application_number(dict parameters)
        {
            string number = get_key_value(ref parameters, "number");
            return _request <GenericResponse>(String.Format("/Number/{0}/", number), parameters, "POST");
        }

        public IRestResponse<GenericResponse> unlink_application_number(dict parameters)
        {
            string number = get_key_value(ref parameters, "number");
            parameters.Add("app_id", "");
            return _request<GenericResponse>(String.Format("/Number/{0}/", number), parameters, "POST");
        }


        // Calls //
        public IRestResponse<CDRList> get_cdrs(dict parameters)
        {
            // had to add an additional slash as RestSharp consumes the trailing slash.
            return _request<CDRList>("/Call//", parameters, "GET");
        }

        public IRestResponse<CDR> get_cdr(dict parameters)
        {
            string record_id = get_key_value(ref parameters, "record_id");
            return _request<CDR>(String.Format("/Call/{0}/", record_id), new dict(), "GET");
        }

        public IRestResponse<LiveCallList> get_live_calls()
        {
            dict parameters = new dict();
            parameters.Add("status", "live");
            return _request<LiveCallList>("/Call//", parameters, "GET");
        }

        public IRestResponse<LiveCall> get_live_call(dict parameters)
        {
            string call_uuid = get_key_value(ref parameters, "call_uuid");
            parameters.Add("status", "live");
            return _request<LiveCall>(String.Format("/Call/{0}//", call_uuid), parameters, "GET");
        }

        public IRestResponse<Call> make_call(dict parameters)
        {
            return _request<Call>("/Call/", parameters, "POST");
        }

        public IRestResponse<GenericResponse> hangup_all_calls()
        {
            return _request<GenericResponse>("/Call/", new dict(), "DELETE");
        }

        public IRestResponse<GenericResponse> hangup_call(dict parameters)
        {
            string call_uuid = get_key_value(ref parameters, "call_uuid");
            return _request<GenericResponse>(String.Format("/Call/{0}/", call_uuid), new dict(), "DELETE");
        }

        public IRestResponse<GenericResponse> transfer_call(dict parameters)
        {
            string call_uuid = get_key_value(ref parameters, "call_uuid");
            return _request<GenericResponse>(String.Format("/Call/{0}/", call_uuid), parameters, "POST");
        }

        public IRestResponse<Record> record(dict parameters)
        {
            string call_uuid = get_key_value(ref parameters, "call_uuid");
            return _request<Record>(String.Format("/Call/{0}/Record/", call_uuid), parameters, "POST");
        }

        public IRestResponse<GenericResponse> stop_record(dict parameters)
        {
            string call_uuid = get_key_value(ref parameters, "call_uuid");
            return _request<GenericResponse>(String.Format("/Call/{0}/Record/", call_uuid), new dict(), "DELETE");
        }

        public IRestResponse<GenericResponse> play(dict parameters)
        {
            string call_uuid = get_key_value(ref parameters, "call_uuid");
            return _request<GenericResponse>(String.Format("/Call/{0}/Play/", call_uuid), parameters, "POST");
        }

        public IRestResponse<GenericResponse> stop_play(dict parameters)
        {
            string call_uuid = get_key_value(ref parameters, "call_uuid");
            return _request<GenericResponse>(String.Format("/Call/{0}/Play/", call_uuid), new dict(), "DELETE");
        }

        public IRestResponse<GenericResponse> speak(dict parameters)
        {
            string call_uuid = get_key_value(ref parameters, "call_uuid");
            return _request<GenericResponse>(String.Format("/Call/{0}/Speak/", call_uuid), parameters, "POST");
        }

        public IRestResponse<GenericResponse> send_digits(dict parameters)
        {
            string call_uuid = get_key_value(ref parameters, "call_uuid");
            return _request<GenericResponse>(String.Format("/Call/{0}/DTMF/", call_uuid), parameters, "POST");
        }


        // Conferences //
        public IRestResponse<LiveConferenceList> get_live_conferences()
        {
            // had to add an additional slash as RestSharp consumes the trailing slash.
            return _request<LiveConferenceList>("/Conference//", new dict(), "GET");
        }

        public IRestResponse<GenericResponse> hangup_all_conferences()
        {
            return _request<GenericResponse>("/Conference/", new dict(), "DELETE");
        }

        public IRestResponse<Conference> get_live_conference(dict parameters)
        {
            string conference_name = get_key_value(ref parameters, "conference_name");
            return _request<Conference>(String.Format("/Conference/{0}/", conference_name), new dict(), "GET");
        }

        public IRestResponse<GenericResponse> hangup_conference(dict parameters)
        {
            string conference_name = get_key_value(ref parameters, "conference_name");
            return _request<GenericResponse>(String.Format("/Conference/{0}/", conference_name), new dict(), "DELETE");
        }

        public IRestResponse<GenericResponse> hangup_member(dict parameters)
        {
            string conference_name = get_key_value(ref parameters, "conference_name");
            string member_id = get_key_value(ref parameters, "member_id");
            return _request<GenericResponse>(String.Format("/Conference/{0}/Member/{1}/", conference_name, member_id), new dict(), "DELETE");
        }

        public IRestResponse<GenericResponse> play_member(dict parameters)
        {
            string conference_name = get_key_value(ref parameters, "conference_name");
            string member_id = get_key_value(ref parameters, "member_id");
            return _request<GenericResponse>(String.Format("/Conference/{0}/Member/{1}/Play/", conference_name, member_id), new dict(), "POST");
        }

        public IRestResponse<GenericResponse> stop_play_member(dict parameters)
        {
            string conference_name = get_key_value(ref parameters, "conference_name");
            string member_id = get_key_value(ref parameters, "member_id");
            return _request<GenericResponse>(String.Format("/Conference/{0}/Member/{1}/Play/", conference_name, member_id), new dict(), "DELETE");
        }

        public IRestResponse<GenericResponse> speak_member(dict parameters)
        {
            string conference_name = get_key_value(ref parameters, "conference_name");
            string member_id = get_key_value(ref parameters, "member_id");
            return _request<GenericResponse>(String.Format("/Conference/{0}/Member/{1}/Speak/", conference_name, member_id), new dict(), "POST");
        }

        public IRestResponse<GenericResponse> deaf_member(dict parameters)
        {
            string conference_name = get_key_value(ref parameters, "conference_name");
            string member_id = get_key_value(ref parameters, "member_id");
            return _request<GenericResponse>(String.Format("/Conference/{0}/Member/{1}/Deaf/", conference_name, member_id), new dict(), "POST");
        }

        public IRestResponse<GenericResponse> undeaf_member(dict parameters)
        {
            string conference_name = get_key_value(ref parameters, "conference_name");
            string member_id = get_key_value(ref parameters, "member_id");
            return _request<GenericResponse>(String.Format("/Conference/{0}/Member/{1}/Deaf/", conference_name, member_id), new dict(), "DELETE");
        }

        public IRestResponse<GenericResponse> mute_member(dict parameters)
        {
            string conference_name = get_key_value(ref parameters, "conference_name");
            string member_id = get_key_value(ref parameters, "member_id");
            return _request<GenericResponse>(String.Format("/Conference/{0}/Member/{1}/Mute/", conference_name, member_id), new dict(), "POST");
        }

        public IRestResponse<GenericResponse> unmute_member(dict parameters)
        {
            string conference_name = get_key_value(ref parameters, "conference_name");
            string member_id = get_key_value(ref parameters, "member_id");
            return _request<GenericResponse>(String.Format("/Conference/{0}/Member/{1}/Mute/", conference_name, member_id), new dict(), "DELETE");
        }

        public IRestResponse<GenericResponse> kick_member(dict parameters)
        {
            string conference_name = get_key_value(ref parameters, "conference_name");
            string member_id = get_key_value(ref parameters, "member_id");
            return _request<GenericResponse>(String.Format("/Conference/{0}/Member/{1}/Kick/", conference_name, member_id), new dict(), "POST");
        }

        public IRestResponse<Record> record_conference(dict parameters)
        {
            string conference_name = get_key_value(ref parameters, "conference_name");
            return _request<Record>(String.Format("/Conference/{0}/Record/", conference_name), parameters, "POST");
        }

        public IRestResponse<GenericResponse> stop_record_conference(dict parameters)
        {
            string conference_name = get_key_value(ref parameters, "conference_name");
            return _request<GenericResponse>(String.Format("/Conference/{0}/Record/", conference_name), new dict(), "DELETE");
        }


        // Endpoints //
        public IRestResponse<EndpointList> get_endpoints(dict parameters)
        {
            // had to add an additional slash as RestSharp consumes the trailing slash.
            return _request<EndpointList>("/Endpoint//", parameters, "GET");
        }

        public IRestResponse<GenericResponse> create_endpoint(dict parameters)
        {
            return _request<GenericResponse>("/Endpoint/", parameters, "POST");
        }

        public IRestResponse<Endpoint> get_endpoint(dict parameters)
        {
            string endpoint_id = get_key_value(ref parameters, "endpoint_id");
            return _request<Endpoint>(String.Format("/Endpoint/{0}/", endpoint_id), new dict(), "GET");
        }

        public IRestResponse<GenericResponse> modify_endpoint(dict parameters)
        {
            string endpoint_id = get_key_value(ref parameters, "endpoint_id");
            return _request<GenericResponse>(String.Format("/Endpoint/{0}/", endpoint_id), parameters, "POST");
        }

        public IRestResponse<GenericResponse> delete_endpoint(dict parameters)
        {
            string endpoint_id = get_key_value(ref parameters, "endpoint_id");
            return _request<GenericResponse>(String.Format("/Endpoint/{0}/", endpoint_id), new dict(), "DELETE");
        }


        // Message //
        public IRestResponse<Message> send_message(dict parameters)
        {
            return _request<Message>("/Message/", parameters, "POST");
        }
    }
}