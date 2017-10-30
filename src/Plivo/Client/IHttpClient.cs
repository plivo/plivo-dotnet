using System.Collections.Generic;
using Plivo.Http;

namespace Plivo.Client
{
    /// <summary>
    /// Http client.
    /// </summary>
    public interface IHttpClient
    {
        PlivoResponse<T> SendRequest<T>(string method, string uri, Dictionary<string, object> data)
            where T : new();
    }
}
