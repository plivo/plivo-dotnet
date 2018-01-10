using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Plivo.Client;
using Plivo.Http;
using Plivo.Utilities;

namespace Plivo.NetCore.Test
{
    public class TestClient : IHttpClient
    {
        public uint StatusCode;
        public string Response;
        public PlivoRequest Request;

        public PlivoResponse<T> SendRequest<T>(string method, string uri, Dictionary<string, object> data) where T : new()
        {
            switch (method)
            {
                case "GET":
                    break;
                case "POST":
                    break;
                case "DELETE":
                    break;
                default:
                    throw new NotSupportedException(
                        method + " not supported");
            }

            Request = new PlivoRequest(method, uri, "", data);

            var jsonSettings = new JsonSerializerSettings
            {
                ContractResolver = new PascalCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore
            };


            // create Plivo response object along with the deserialized object
            PlivoResponse<T> plivoResponse =
                new PlivoResponse<T>(
                    StatusCode,
                    new List<string>(),
                    Response,
                    JsonConvert.DeserializeObject<T>(Response, jsonSettings),
                    new PlivoRequest(method, uri, string.Empty, data));

            return plivoResponse;
        }

        public void Setup(string response, uint statusCode)
        {
            Response = response;
            StatusCode = statusCode;
        }
    }
    public class PascalCasePropertyNamesContractResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            return StringUtilities.PascalCaseToSnakeCase(propertyName);
        }
    }
}
