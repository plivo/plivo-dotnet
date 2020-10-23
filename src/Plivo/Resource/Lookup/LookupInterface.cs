using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Plivo.Client;


namespace Plivo.Resource.Lookup
{
    public class LookupInterface : ResourceInterface
    {
        public LookupInterface(HttpClient client) : base(client)
        {
            Uri = "Number/";
        }

        // getResource is like the method 'GetResource' from parent class but
        // doesn't add a trailing slash at the end.
        private async Task<T> getResource<T>(string resource, Dictionary<string, object> data)
        where T : new()
        {
            data.Add("is_lookup_request", true);
            var result = await Client.Fetch<T>(Uri + resource, data);
            try
            {
                result.Object.GetType().GetRuntimeProperty("StatusCode").SetValue(result.Object, result.StatusCode, null);
            }
            catch (System.NullReferenceException)
            {
            }
            return result.Object;
        }

        #region Get
        public Number Get(string number, string type = "carrier")
        {
            return ExecuteWithExceptionUnwrap(() =>
            {
                var resp = Task.Run(async () => await getResource<Number>(number,
                    new Dictionary<string, object>() { { "type", type } }).ConfigureAwait(false)).Result;
                resp.Interface = this;
                return resp;
            });
        }

        public async Task<Number> GetAsync(string number, string type = "carrier")
        {
            var resp = await getResource<Number>(number,
                new Dictionary<string, object>() { { "type", type } });
            resp.Interface = this;
            return resp;
        }
        #endregion
    }
}
