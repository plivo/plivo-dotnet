using System;
using System.Collections.Generic;
using RestSharp;
using RestSharp.Deserializers;

namespace Plivo.API
{
    public class RestAPI
    {
        private const string PlivoUrl = "https://api.plivo.com";
        private string PlivoVersion { get; set; }
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
            return this._request<Account>("/ ", new Dictionary<string, string>(), "GET");
        }

        public IRestResponse<GenericResponse> modify_account(Dictionary<string, string> parameters)
        {
            return this._request<GenericResponse>("/ ", parameters, "POST");
        }

        public IRestResponse<SubAccountList> get_subaccounts()
        {
            return this._request<SubAccountList>("/Subaccount/", new Dictionary<string, string>(), "GET");
        }

        public IRestResponse<SubAccount> get_subaccount(Dictionary<string, string> parameters)
        {
            string subauth_id = this.get_key_value(ref parameters, "subauth_id");
            string resource = String.Format("/Subaccount/{0}/", subauth_id);
            return this._request<SubAccount>(resource, parameters, "GET");
        }

        public IRestResponse<GenericResponse> create_subaccount(Dictionary<string, string> parameters)
        {
            return this._request<GenericResponse>("/Subaccount/", parameters, "POST");
        }

        public IRestResponse<GenericResponse> modify_subaccount(Dictionary<string, string> parameters)
        {
            string subauth_id = this.get_key_value(ref parameters, "subauth_id");
            string resource = String.Format("/Subaccount/{0}/", subauth_id);
            return this._request<GenericResponse>(resource, parameters, "POST");
        }

        public IRestResponse<GenericResponse> delete_subaccount(Dictionary<string, string> parameters)
        {
            string subauth_id = this.get_key_value(ref parameters, "subauth_id");
            string resource = String.Format("/Subaccount/{0}/", subauth_id);
            return this._request<GenericResponse>(resource, new Dictionary<string, string>(), "DELETE");
        }

        // Applications //
        public IRestResponse<ApplicationList> get_applications(Dictionary<string, string> parameters)
        {
            return this._request<ApplicationList>("/Application/", new Dictionary<string, string>(), "GET");
        }

        public IRestResponse<Application> get_application(Dictionary<string, string> parameters)
        {
            string app_id = this.get_key_value(ref parameters, "app_id");
            string resource = String.Format("/Application/{0}/", app_id);
            return this._request<Application>(resource, new Dictionary<string, string>(), "GET");
        }

        public IRestResponse<GenericResponse> create_application(Dictionary<string, string> parameters)
        {
            return this._request<GenericResponse>("/Application/", parameters, "POST");
        }

        public IRestResponse<GenericResponse> modify_application(Dictionary<string, string> parameters)
        {
            string app_id = this.get_key_value(ref parameters, "app_id");
            return this._request<GenericResponse>(String.Format("/Application/{0}/", app_id), parameters, "POST");
        }

        public IRestResponse<GenericResponse> delete_application(Dictionary<string, string> parameters)
        {
            string app_id = this.get_key_value(ref parameters, "app_id");
            return this._request<GenericResponse>(String.Format("/Application/{0}/", app_id), new Dictionary<string, string>(), "DELETE");
        }


        // Numbers //
        public IRestResponse<NumberList> get_numbers()
        {
            return this._request<NumberList>("/Number/", new Dictionary<string, string>(), "GET");
        }

        public IRestResponse<NumberList> search_numbers(Dictionary<string, string> parameters)
        {
            return this._request<NumberList>("/AvailableNumber/", new Dictionary<string, string>(), "GET");
        }

        public IRestResponse<Number> get_number(Dictionary<string, string> parameters)
        {
            string number = this.get_key_value(ref parameters, "number");
            return this._request<Number>(String.Format("/Number/{0}/", number), new Dictionary<string, string>(), "GET");
        }

        public IRestResponse<GenericResponse> rent_number(Dictionary<string, string> parameters)
        {
            string number = this.get_key_value(ref parameters, "number");
            return this._request<GenericResponse>(String.Format("/AvailableNumber/{0}/"), new Dictionary<string, string>(), "POST");
        }

        public IRestResponse<GenericResponse> unrent_number(Dictionary<string, string> parameters)
        {
            string number = this.get_key_value(ref parameters, "number");
            return this._request<GenericResponse>(String.Format("/Number/{0}", number), new Dictionary<string, string>(), "DELETE");
        }

        public IRestResponse<GenericResponse> link_application_number(Dictionary<string, string> parameters)
        {
            string number = this.get_key_value(ref parameters, "number");
            return this._request<GenericResponse>(String.Format("/Number/{0}", number), parameters, "POST");
        }

        public IRestResponse<GenericResponse> unlink_application_number(Dictionary<string, string> parameters)
        {
            string number = this.get_key_value(ref parameters, "number");
            parameters.Add("app_id", "");
            return this._request<GenericResponse>(String.Format("/Number/{0}", number), parameters, "POST");
        }


        // Calls //
        public IRestResponse<CDRList> get_cdrs()
        {
            return this._request<CDRList>("/Call/", new Dictionary<string, string>(), "GET");
        }

        public IRestResponse<CDR> get_cdr(Dictionary<string, string> parameters)
        {
            string record_id = this.get_key_value(ref parameters, "record_id");
            return this._request<CDR>(String.Format("/Call/{0}/", record_id), new Dictionary<string, string>(), "GET");
        }

        public IRestResponse<LiveCallList> get_live_calls()
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("status", "live");
            return this._request<LiveCallList>("/Call/", parameters, "GET");
        }

        public IRestResponse<LiveCall> get_live_call(Dictionary<string, string> parameters)
        {
            string call_uuid = this.get_key_value(ref parameters, "call_uuid");
            parameters.Add("status", "live");
            return this._request<LiveCall>(String.Format("/Call/{0}/", call_uuid), parameters, "GET");
        }

        public IRestResponse<Call> make_call(Dictionary<string, string> parameters)
        {
            return this._request<Call>("/Call/", parameters, "POST");
        }

        public IRestResponse<GenericResponse> hangup_all_calls()
        {
            return this._request<GenericResponse>("/Call/", new Dictionary<string, string>(), "DELETE");
        }

        public IRestResponse<GenericResponse> hangup_call(Dictionary<string, string> parameters)
        {
            string call_uuid = this.get_key_value(ref parameters, "call_uuid");
            return this._request<GenericResponse>(String.Format("/Call/{0}/", call_uuid), new Dictionary<string, string>(), "DELETE");
        }

        public IRestResponse<GenericResponse> transfer_call(Dictionary<string, string> parameters)
        {
            string call_uuid = this.get_key_value(ref parameters, "call_uuid");
            return this._request<GenericResponse>(String.Format("/Call/{0}/", call_uuid), parameters, "POST");
        }

        public IRestResponse<Record> record(Dictionary<string, string> parameters)
        {
            string call_uuid = this.get_key_value(ref parameters, "call_uuid");
            return this._request<Record>(String.Format("/Call/{0}/Record/", call_uuid), parameters, "POST");
        }

        public IRestResponse<GenericResponse> stop_record(Dictionary<string, string> parameters)
        {
            string call_uuid = this.get_key_value(ref parameters, "call_uuid");
            return this._request<GenericResponse>(String.Format("/Call/{0}/Record/", call_uuid), new Dictionary<string, string>(), "DELETE");
        }

        public IRestResponse<GenericResponse> play(Dictionary<string, string> parameters)
        {
            string call_uuid = this.get_key_value(ref parameters, "call_uuid");
            return this._request<GenericResponse>(String.Format("/Call/{0}/Play/", call_uuid), parameters, "POST");
        }

        public IRestResponse<GenericResponse> stop_play(Dictionary<string, string> parameters)
        {
            string call_uuid = this.get_key_value(ref parameters, "call_uuid");
            return this._request<GenericResponse>(String.Format("/Call/{0}/Play/", call_uuid), new Dictionary<string, string>(), "DELETE");
        }

        public IRestResponse<GenericResponse> speak(Dictionary<string, string> parameters)
        {
            string call_uuid = this.get_key_value(ref parameters, "call_uuid");
            return this._request<GenericResponse>(String.Format("/Call/{0}/Speak/", call_uuid), parameters, "POST");
        }

        public IRestResponse<GenericResponse> send_digits(Dictionary<string, string> parameters)
        {
            string call_uuid = this.get_key_value(ref parameters, "call_uuid");
            return this._request<GenericResponse>(String.Format("/Call/{0}/DTMF/", call_uuid), parameters, "POST");
        }


        // Conferences //
        public IRestResponse<LiveConferenceList> get_live_conferences()
        {
            return this._request<LiveConferenceList>("/Conference/", new Dictionary<string, string>(), "GET");
        }

        public IRestResponse<GenericResponse> hangup_all_conferences()
        {
            return this._request<GenericResponse>("/Conference/", new Dictionary<string, string>(), "DELETE");
        }

        //public Dictionary<string, string> get_live_conference(Dictionary<string, string> parameters)
        //{
        //    string conference_name = this.get_key_value(ref parameters, "conference_name");
        //    return this._request(String.Format("/Conference/{0}/", conference_name), new Dictionary<string, string>(), "GET");
        //}

        public IRestResponse<GenericResponse> hangup_conference(Dictionary<string, string> parameters)
        {
            string conference_name = this.get_key_value(ref parameters, "conference_name");
            return this._request<GenericResponse>(String.Format("/Conference/{0}/", conference_name), new Dictionary<string, string>(), "DELETE");
        }

        public IRestResponse<GenericResponse> hangup_member(Dictionary<string, string> parameters)
        {
            string conference_name = this.get_key_value(ref parameters, "conference_name");
            string member_id = this.get_key_value(ref parameters, "member_id");
            return this._request<GenericResponse>(String.Format("/Conference/{0}/Member/{1}/", conference_name, member_id), new Dictionary<string, string>(), "DELETE");
        }

        public IRestResponse<GenericResponse> play_member(Dictionary<string, string> parameters)
        {
            string conference_name = this.get_key_value(ref parameters, "conference_name");
            string member_id = this.get_key_value(ref parameters, "member_id");
            return this._request<GenericResponse>(String.Format("/Conference/{0}/Member/{1}/Play/", conference_name, member_id), new Dictionary<string, string>(), "POST");
        }

        public IRestResponse<GenericResponse> stop_play_member(Dictionary<string, string> parameters)
        {
            string conference_name = this.get_key_value(ref parameters, "conference_name");
            string member_id = this.get_key_value(ref parameters, "member_id");
            return this._request<GenericResponse>(String.Format("/Conference/{0}/Member/{1}/Play/", conference_name, member_id), new Dictionary<string, string>(), "DELETE");
        }

        public IRestResponse<GenericResponse> speak_member(Dictionary<string, string> parameters)
        {
            string conference_name = this.get_key_value(ref parameters, "conference_name");
            string member_id = this.get_key_value(ref parameters, "member_id");
            return this._request<GenericResponse>(String.Format("/Conference/{0}/Member/{1}/Speak/", conference_name, member_id), new Dictionary<string, string>(), "POST");
        }

        public IRestResponse<GenericResponse> deaf_member(Dictionary<string, string> parameters)
        {
            string conference_name = this.get_key_value(ref parameters, "conference_name");
            string member_id = this.get_key_value(ref parameters, "member_id");
            return this._request<GenericResponse>(String.Format("/Conference/{0}/Member/{1}/Deaf/", conference_name, member_id), new Dictionary<string, string>(), "POST");
        }

        public IRestResponse<GenericResponse> undeaf_member(Dictionary<string, string> parameters)
        {
            string conference_name = this.get_key_value(ref parameters, "conference_name");
            string member_id = this.get_key_value(ref parameters, "member_id");
            return this._request<GenericResponse>(String.Format("/Conference/{0}/Member/{1}/Deaf/", conference_name, member_id), new Dictionary<string, string>(), "DELETE");
        }

        public IRestResponse<GenericResponse> mute_member(Dictionary<string, string> parameters)
        {
            string conference_name = this.get_key_value(ref parameters, "conference_name");
            string member_id = this.get_key_value(ref parameters, "member_id");
            return this._request<GenericResponse>(String.Format("/Conference/{0}/Member/{1}/Mute/", conference_name, member_id), new Dictionary<string, string>(), "POST");
        }

        public IRestResponse<GenericResponse> unmute_member(Dictionary<string, string> parameters)
        {
            string conference_name = this.get_key_value(ref parameters, "conference_name");
            string member_id = this.get_key_value(ref parameters, "member_id");
            return this._request<GenericResponse>(String.Format("/Conference/{0}/Member/{1}/Mute/", conference_name, member_id), new Dictionary<string, string>(), "DELETE");
        }

        public IRestResponse<GenericResponse> kick_member(Dictionary<string, string> parameters)
        {
            string conference_name = this.get_key_value(ref parameters, "conference_name");
            string member_id = this.get_key_value(ref parameters, "member_id");
            return this._request<GenericResponse>(String.Format("/Conference/{0}/Member/{1}/Kick/", conference_name, member_id), new Dictionary<string, string>(), "POST");
        }

        public IRestResponse<Record> record_conference(Dictionary<string, string> parameters)
        {
            string conference_name = this.get_key_value(ref parameters, "conference_name");
            return this._request<Record>(String.Format("/Conference/{0}/Record/", conference_name), parameters, "POST");
        }

        public IRestResponse<GenericResponse> stop_record_conference(Dictionary<string, string> parameters)
        {
            string conference_name = this.get_key_value(ref parameters, "conference_name");
            return this._request<GenericResponse>(String.Format("/Conference/{0}/Record/", conference_name), new Dictionary<string, string>(), "DELETE");
        }


        // Endpoints //
        public IRestResponse<EndpointList> get_endpoints()
        {
            return this._request<EndpointList>("/Endpoint/", new Dictionary<string, string>(), "GET");
        }

        public IRestResponse<GenericResponse> create_endpoint(Dictionary<string, string> parameters)
        {
            return this._request<GenericResponse>("/Endpoint/", parameters, "POST");
        }

        public IRestResponse<Endpoint> get_endpoint(Dictionary<string, string> parameters)
        {
            string endpoint_id = this.get_key_value(ref parameters, "endpoint_id");
            return this._request<Endpoint>(String.Format("/Endpoint/{0}/", endpoint_id), new Dictionary<string, string>(), "GET");
        }

        public IRestResponse<GenericResponse> modify_endpoint(Dictionary<string, string> parameters)
        {
            string endpoint_id = this.get_key_value(ref parameters, "endpoint_id");
            return this._request<GenericResponse>(String.Format("/Endpoint/{0}/", endpoint_id), parameters, "POST");
        }

        public IRestResponse<GenericResponse> delete_endpoint(Dictionary<string, string> parameters)
        {
            string endpoint_id = this.get_key_value(ref parameters, "endpoint_id");
            return this._request<GenericResponse>(String.Format("/Endpoint/{0}/", endpoint_id), new Dictionary<string, string>(), "DELETE");
        }


        // Message //
        public IRestResponse<Message> send_message(Dictionary<string, string> parameters)
        {
            return this._request<Message>("/Message/", parameters, "POST");
        }
    }
}