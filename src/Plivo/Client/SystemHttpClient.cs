using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using Plivo.Authentication;
using Plivo.Http;
using Plivo.Utilities;

namespace Plivo.Client
{
    /// <summary>
    /// Client.
    /// </summary>
    public class SystemHttpClient : IHttpClient
    {
        /// <summary>
        /// Gets or sets the client.
        /// </summary>
        /// <value>The client.</value>
        public System.Net.Http.HttpClient _client { get; set; }

        public class PascalCasePropertyNamesContractResolver : DefaultContractResolver
        {
            protected override string ResolvePropertyName(string propertyName)
            {
                return StringUtilities.PascalCaseToSnakeCase(propertyName);
            }
        }

        public string RuntimeVersion;

        private JsonSerializerSettings _jsonSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:plivo.Client.SystemHttpClient"/> class.
        /// </summary>
        /// <param name="basicAuth">Basic auth.</param>
        /// <param name="proxyServerSettings">Proxy settings.</param>
        public SystemHttpClient(BasicAuth basicAuth, Dictionary<string, string> proxyServerSettings)
        {
#if NETSTANDARD2_0
            IWebProxy proxy = null;
            var networkCreds = new NetworkCredential();
            networkCreds.UserName = proxyServerSettings["Username"];
            networkCreds.Password = proxyServerSettings["Password"];
            var useDefaultCreds = networkCreds.UserName.Length > 0 && networkCreds.UserName.Length > 0;

            try
            {
                if (useDefaultCreds)
                {
                    proxy = new WebProxy()
                    {
                        Address = new Uri($"{ proxyServerSettings["Address"] }:{ proxyServerSettings["Port"] }"),
                        UseDefaultCredentials = useDefaultCreds,
                        Credentials = networkCreds
                    };
                }
                else
                {
                    proxy = new WebProxy()
                    {
                        Address = new Uri($"{ proxyServerSettings["Address"] }:{ proxyServerSettings["Port"] }"),
                        UseDefaultCredentials = useDefaultCreds
                };
                }
                
            }
            catch
            {
                proxy = null;
            }

            HttpClientHandler httpClientHandler = new HttpClientHandler()
            {
                PreAuthenticate = true,
                UseDefaultCredentials = false,
                UseProxy = proxy != null, 
                Proxy = proxy
            };
#else
            HttpClientHandler httpClientHandler = new HttpClientHandler()
            {
                PreAuthenticate = true,
                UseDefaultCredentials = false
            };
#endif
            _client = new System.Net.Http.HttpClient(httpClientHandler);
            var authHeader =
                new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(Encoding.UTF8.GetBytes(
                            $"{basicAuth.AuthId}:{basicAuth.AuthToken}"
                        )
                    )
                );
            _client.DefaultRequestHeaders.Authorization = authHeader;
            _client.DefaultRequestHeaders.Add("User-Agent", "plivo-dotnet/" + ThisAssembly.AssemblyVersion);
            _client.BaseAddress = new Uri("https://api.plivo.com/" + Version.ApiVersion + "/");

            _jsonSettings = new JsonSerializerSettings
            {
                ContractResolver = new PascalCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore
            };
        }

        /// <summary>
        /// Sends the request.
        /// </summary>
        /// <returns>The request.</returns>
        /// <param name="method">Method.</param>
        /// <param name="uri">URI.</param>
        /// <param name="data">Data.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public PlivoResponse<T> SendRequest<T>(string method, string uri, Dictionary<string, object> data,
            Dictionary<string, string> filesToUpload = null)
            where T : new()
        {
            HttpResponseMessage response = null;
            HttpRequestMessage request = null;

            switch (method)
            {
                case "GET":
                    request = new HttpRequestMessage(HttpMethod.Get, uri + AsQueryString(data));
                    request.Headers.Add("Accept", "application/json");
                    break;

                case "POST":
                    request = new HttpRequestMessage(HttpMethod.Post, uri);

                    if (filesToUpload == null)
                    {
                        request.Headers.Add("Accept", "application/json");
                        request.Content = new StringContent(
                            JsonConvert.SerializeObject(data),
                            Encoding.UTF8,
                            "application/json"
                        );
                    }
                    else
                    {
                        MultipartFormDataContent multipartContent = new MultipartFormDataContent();

                        foreach (var key in filesToUpload.Keys)
                        {
                            FileInfo fileInfo = new FileInfo(filesToUpload[key]);
                            string fileName = fileInfo.Name;
                            HttpContent fileContents = new ByteArrayContent(File.ReadAllBytes(fileInfo.FullName));

                            string fileHeader = null;

                            switch (fileName.Split('.')[1].ToLower())
                            {
                                case "jpg":
                                    fileHeader = "image/jpeg";
                                    break;
                                case "png":
                                    fileHeader = "image/png";
                                    break;
                                case "jpeg":
                                    fileHeader = "image/jpeg";
                                    break;
                                case "pdf":
                                    fileHeader = "application/pdf";
                                    break;
                            }

                            fileContents.Headers.Add("Content-Type", fileHeader);
                            multipartContent.Add(fileContents, "file", fileName);
                        }

                        foreach (var key in data.Keys)
                        {
                            HttpContent stringContent = new StringContent((string) data[key].ToString());
                            multipartContent.Add(stringContent, key);
                        }

                        request.Content = multipartContent;
                    }

                    break;

                case "DELETE":
                    request = new HttpRequestMessage(HttpMethod.Delete, uri);
                    request.Headers.Add("Accept", "application/json");
                    request.Content = new StringContent(
                        JsonConvert.SerializeObject(data),
                        Encoding.UTF8,
                        "application/json"
                    );
                    break;

                default:
                    throw new NotSupportedException(
                        method + " not supported");
            }

            response = _client.SendAsync(request).Result;

            var responseContent = response.Content.ReadAsStringAsync().Result;

            // create Plivo response object along with the deserialized object
            PlivoResponse<T> plivoResponse;
            try {
                plivoResponse = new PlivoResponse<T>(
                    (uint) response.StatusCode.GetHashCode(),
                    response.Headers.Select(item => item.Key + "=" + item.Value).ToList(),
                    responseContent,
                    responseContent != string.Empty
                        ? JsonConvert.DeserializeObject<T>(responseContent, _jsonSettings)
                        : new T(),
                    new PlivoRequest(method, uri, request.Headers.ToString(), data, filesToUpload));
            }
            catch(Newtonsoft.Json.JsonReaderException){
                plivoResponse = new PlivoResponse<T>(
                    (uint) response.StatusCode.GetHashCode(),
                    response.Headers.Select(item => item.Key + "=" + item.Value).ToList(),
                    responseContent,
                    responseContent != string.Empty
                        ? JsonConvert.DeserializeObject<T>(responseContent)
                        : new T(),
                    new PlivoRequest(method, uri, request.Headers.ToString(), data, filesToUpload));
            }
            
                

            return plivoResponse;
        }

        public static string AsQueryString(IEnumerable<KeyValuePair<string, object>> parameters)
        {
            if (!parameters.Any())
                return "";

            var builder = new StringBuilder("?");

            var separator = "";
            foreach (var kvp in parameters.Where(kvp => kvp.Value != null))
            {
                builder.AppendFormat("{0}{1}={2}", separator, WebUtility.UrlEncode(kvp.Key),
                    WebUtility.UrlEncode(kvp.Value.ToString()));

                separator = "&";
            }

            return builder.ToString();
        }
    }
}