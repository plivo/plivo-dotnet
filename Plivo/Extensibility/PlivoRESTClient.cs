using System;
using RestSharp;

namespace Plivo.Extensibility
{
    public class PlivoRESTClient:PlivoClient
    {
        private RestClient client;
        private const string PLIVO_URL = "https://api.plivo.com";

        public PlivoRESTClient(string authId, string authToken, string version = "v1") : 
            base(authId, authToken, version)
        {
            // Initialize the client
            client = new RestClient();
            client.Authenticator = new HttpBasicAuthenticator(AuthID, AuthToken);
            client.UserAgent = "PlivoCsharp";
            client.BaseUrl = String.Format("{0}/{1}/Account/{2}", PLIVO_URL, version, AuthID);
        }
    }
}