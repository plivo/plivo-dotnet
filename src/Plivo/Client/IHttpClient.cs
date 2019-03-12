using System.Collections.Generic;
using System.Threading.Tasks;
using Plivo.Http;

namespace Plivo.Client
{
    /// <summary>
    /// Http client.
    /// </summary>
    public interface IHttpClient
    {
        Task<PlivoResponse<T>> SendRequest<T>(string method, string uri, Dictionary<string, object> data,
            Dictionary<string, string> filesToUpload = null)
            where T : new();
        
        string AsQueryString(IEnumerable<KeyValuePair<string, object>> parameters);
    }    
}