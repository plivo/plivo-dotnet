using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Plivo.Client;
using Plivo.Http;
using Plivo.Utilities;

namespace Plivo.Resource.Token
{
    /// <summary>
    /// Token interface.
    /// </summary>
    public class TokenInterface : ResourceInterface
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:plivo.Resource.Call.CallInterface"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        public TokenInterface(HttpClient client) : base(client)
        {
            Uri = "Account/" + Client.GetAuthId() + "/JWT/Token/";
        }

        #region Create

        /// <summary>
        /// Create Token with the specified from iss,sub,nbf,exp,incoming_allow,outgoing_allow,app
        /// </summary>
        /// <returns>The create.</returns>
        /// <param name="iss"></param>
        /// <param name="sub"></param>
        /// <param name="nbf"></param>
        /// <param name="exp"></param>
        /// <param name="incoming_allow"></param>
        /// <param name="outgoing_allow"></param>
        /// <param name="app"></param>
        public TokenCreateResponse Create(
            string iss = null, 
            string sub = null, 
            int nbf = null, int exp = null,
            bool incoming_allow = null, bool outgoing_allow = null,
            string app = null)
            
        {
            var mandatoryParams = new List<string> { "iss" };
            bool isVoiceRequest = true;
           
           var data = CreateData(
                mandatoryParams,
                new
                {
                    iss,
                    sub,
                    nbf,
                    exp,
                    incoming_allow,
                    outgoing_allow,
                    app,
                    isVoiceRequest
                });

            return ExecuteWithExceptionUnwrap(() =>
            {
                var result = Task.Run(async () =>
                    await Client.Update<TokenCreateResponse>(Uri, data).ConfigureAwait(false)).Result;
                result.Object.StatusCode = result.StatusCode;
                JObject responseJson = JObject.Parse(result.Content);
                result.Object.ApiId = responseJson["api_id"].ToString();
                result.Object.Message = responseJson["token"].ToString();
                return result.Object;
            });
        }

        /// <summary>
        /// Asynchronously create Token with the specified from iss,sub,nbf,exp,incoming_allow,outgoing_allow,app
        /// </summary>
        /// <returns>The create.</returns>
        /// <param name="iss">Iss.</param>
        /// <param name="sub">Sub.</param>
        /// <param name="nbf">Nbf.</param>
        /// <param name="exp">Exp.</param>
        /// <param name="incoming_allow">Incoming_Allow.</param>
        /// <param name="outgoing_allow">Outgoing_Allow.</param>
        /// <param name="app">App.</param>
        public async Task<AsyncResponse> CreateAsync(
            string iss = null,
            string sub = null,
            int nbf = null, int exp = null,
            bool incoming_allow = null, bool outgoing_allow = null,
            string app = null)
        {
            var mandatoryParams = new List<string> { "iss" };
            bool isVoiceRequest = true;
            // if incoming_allow != null || outgoing_allow != null || app != null)
            // {
            //     params["per"] = new Dictionary<object, object> {};
            //         params["per"]["voice"] = new Dictionary<object, object> {};
            //     if (incoming_allow != null) {
            //         params["per"]["voice"]["incoming_allow"] = incoming_allow;
            //     }
            //     if (outgoing_allow != null) {
            //         params["per"]["voice"]["outgoing_allow"] = outgoing_allow;
            //     }
            // }
            // // if incoming_allow is true then sub should not be empty
            // if (incoming_allow == true && sub == null)
            // {
            //     throw new PlivoException("sub is mandatory when incoming_allow is true");
            // }
            // // Add sub,nbf,exp,app if they are not null
            // if (sub != null)
            // {
            //     params["sub"] = sub;
            // }
            // if (nbf != null)
            // {
            //     params["nbf"] = nbf;
            // }
            // if (exp != null)
            // {
            //     params["exp"] = exp;
            // }
            // if (app != null)
            // {
            //     params["app"] = app;
            // }
            var data = CreateData(
                mandatoryParams,
                new
                {
                    iss,
                    sub,
                    nbf,
                    exp,
                    // params
                    app,
                    isVoiceRequest
                });
            var result = Task.Run(async () => await Client.Update<AsyncResponse>(Uri, data).ConfigureAwait(false))
                .Result;
            await Task.WhenAll();
            result.Object.StatusCode = result.StatusCode;
            JObject responseJson = JObject.Parse(result.Content);
            result.Object.ApiId = responseJson["api_id"].ToString();
            result.Object.Message = responseJson["token"].ToString();
            return result.Object;
        }

        #endregion
    }
}