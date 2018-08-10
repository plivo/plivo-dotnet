using System;
using System.Collections.Generic;
using System.Text;
using Plivo.Client;

namespace Plivo.Resource.Phlo
{
    /// <summary>
    ///(PHLO) Plivo High Level Objects interface 
    /// </summary>
    public class PhloInterface : ResourceInterface
    {
        /// <summary>
        /// PHLO Id
        /// </summary>
        private readonly string _phloUuid;

        /// <summary>
        /// PHLO 
        /// </summary>
        /// <param name="HTTP client"></param>
        /// <param name="PHLO Id"></param>
        internal PhloInterface(HttpClient client, string phloUuid) : base(client)
        {
            Mandatory(Tuple.Create("phloUuid", phloUuid));
            _phloUuid = phloUuid;
            Uri = string.Format("phlo/{0}", phloUuid);
        }

        /// <summary>
        /// Multi Party Call Declaration
        /// </summary>
        /// <param name="Node Id"></param>
        /// <returns>Multi Party Call Interface</returns>
        public MultiPartyCallInterface MultiPartyCall(string nodeUuid)
        {
            Mandatory(Tuple.Create("nodeUuid", nodeUuid));
            return new MultiPartyCallInterface(Client, _phloUuid, nodeUuid);
        }

        /// <summary>
        /// Delete functionality is not supported by PHLO api yet.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public new T DeleteResource<T>(string id, Dictionary<string, object> data = null) where T : new()
        {
            throw new NotImplementedException("Delete functionality is not supported by PHLO api yet.");
        }
        /// <summary>
        /// Get list functionality is not supported by PHLO api yet.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public new T ListResources<T>(Dictionary<string, object> data = null) where T : new()
        {
            throw new NotImplementedException("Get list functionality is not supported by PHLO api yet.");
        }

        /// <summary>
        /// Get functionality is not supported by PHLO api yet.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public Phlo Get()
        {
            var phlo = base.GetResource<Phlo>(string.Empty,null);
            phlo.Interface = this;
            return phlo;
        }
    }
}
