using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Plivo.Client;
using Plivo.Exception;

namespace Plivo.Resource {
    /// <summary>
    /// Resource interface.
    /// </summary>
    public abstract class ResourceInterface {
        /// <summary>
        /// The client.
        /// </summary>
        public HttpClient Client;

        /// <summary>
        /// The URI.
        /// </summary>
        protected string Uri;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:plivo.Resource.ResourceInterface"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        protected ResourceInterface (HttpClient client) {
            Client = client ??
                throw new ArgumentNullException (nameof (client));
        }

        /// <summary>
        /// Gets the resource.
        /// </summary>
        /// <returns>The resource.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="data">Data.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public async Task<T> GetResource<T> (string id, Dictionary<string, object> data = null)
        where T : new () {
            string to_append = id;
            if (id != "") {
                to_append = to_append + "/";
            }

            var result = await Client.Fetch<T> (
                Uri + to_append, data);
            try {
                result.Object.GetType ().GetRuntimeProperty ("StatusCode").SetValue (result.Object, result.StatusCode, null);
            } catch (System.NullReferenceException) {

            }
            return result.Object;
        }

        /// <summary>
        /// Lists the resources.
        /// </summary>
        /// <returns>The resources.</returns>
        /// <param name="data">Data.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public async Task<T> ListResources<T> (Dictionary<string, object> data = null)
        where T : new () {
            var result = await Client.Fetch<T> (Uri, data);
            try {
                result.Object.GetType ().GetRuntimeProperty ("StatusCode").SetValue (result.Object, result.StatusCode, null);
            } catch (System.NullReferenceException) {

            }
            return result.Object;
        }

        /// <summary>
        /// Lists the resources.
        /// </summary>
        /// <returns>The resources.</returns>
        /// <param name="data">Data.</param>
        /// <param name="url"> URL </param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public async Task<T> ListResources<T>(string url, Dictionary<string, object> data = null)
        where T : new()
        {
            string to_append = url;
            if (url != "")
            {
                to_append = to_append + "/";
            }
            var result = await Client.Fetch<T>(Uri + to_append, data);
            try
            {
                result.Object.GetType().GetRuntimeProperty("StatusCode").SetValue(result.Object, result.StatusCode, null);
            }
            catch (System.NullReferenceException)
            {

            }
            return result.Object;
        }

        /// <summary>
        /// Deletes the resource.
        /// </summary>
        /// <returns>The resource.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="data">Data.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public async Task<T> DeleteResource<T> (string id, Dictionary<string, object> data = null)
        where T : new () {
            var result = await Client.Delete<T> (Uri + id + "/", data);
            Console.WriteLine (result.Object);
            try {
                result.Object.GetType ().GetRuntimeProperty ("StatusCode").SetValue (result.Object, result.StatusCode, null);
            } catch (System.NullReferenceException) {

            }
            return result.Object;

        }

        /// <summary>
        /// Creates the data.
        /// </summary>
        /// <returns>The data.</returns>
        /// <param name="propertyInfos"></param>
        /// <param name="data">Data.</param>
        public static Dictionary<string, object> CreateData (List<string> propertyInfos, dynamic data) {
            var dict = new Dictionary<string, object> ();
            foreach (PropertyInfo pi in data.GetType ().GetProperties ()) {
                if (propertyInfos.Contains (pi.Name)) {
                    if (string.IsNullOrEmpty (pi.GetValue (data)))
                        throw new PlivoValidationException (pi.Name + " is mandatory, can not be null or empty");
                }

                if (pi.Name.Equals ("limit")) {
                    if (pi.GetValue (data) > 20) {
                        throw new PlivoValidationException ("limit:" + pi.GetValue (data) + " is out of range [0,20]");
                    }
                }

                if (pi.GetValue (data) == null) continue;

                var name_char_array = pi.Name.ToCharArray ();
                if (name_char_array.ElementAt (0) == '_') {
                    name_char_array = string.Concat (name_char_array).Substring (1).ToCharArray ();
                }

                var value = pi.GetValue (data);

                if (name_char_array.All (char.IsUpper)) {
                    dict.Add (string.Concat (name_char_array), value);
                } else {
                    dict.Add (
                        string.Concat (
                            name_char_array.Select (
                                (x, i) => i > 0 && char.IsUpper (x) ? "_" + x.ToString ().ToLower () : x.ToString ())),
                        value);
                }
            }

            return dict;
        }

        /// <summary>
        /// Returns the list of names of parameters which are mandatory.
        /// </summary>
        /// <param name="parameterInfos"></param>
        /// <returns>List of names of mandatory parameters.</returns>
        public static List<string> GetMethodParameterProperties (ParameterInfo[] parameterInfos) {
            return (from pi in parameterInfos where!pi.IsOptional select pi.Name).ToList ();
        }

        public static T ExecuteWithExceptionUnwrap<T> (Func<T> func) where T : class {
            try {
                return func ();
            } catch (AggregateException ex) {
                ex.Flatten ();
                throw ex.InnerExceptions[0];
            }
        }

        public static void ExecuteWithExceptionUnwrap (Action func) {
            try {
                func ();
            } catch (AggregateException ex) {
                ex.Flatten ();
                throw ex.InnerExceptions[0];
            }
        }
    }
}