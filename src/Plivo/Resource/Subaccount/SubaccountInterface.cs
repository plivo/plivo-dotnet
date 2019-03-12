using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Plivo.Client;


namespace Plivo.Resource.Subaccount
{
    public class SubaccountInterface : ResourceInterface
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:plivo.Resource.Subaccount.SubaccountInterface"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        public SubaccountInterface(HttpClient client) : base(client)
        {
            Uri = "Account/" + Client.GetAuthId() + "/Subaccount/";
        }

        #region Create
        /// <summary>
        /// Create Subaccount with the specified name and enabled.
        /// </summary>
        /// <returns>The create.</returns>
        /// <param name="name">Name.</param>
        /// <param name="enabled">Enabled.</param>
        public SubaccountCreateResponse Create(string name, bool? enabled = null)
        {
            var mandatoryParams = new List<string> {"name"};
            var data = CreateData(mandatoryParams, new {name, enabled});
            var result = Task.Run(async () => await Client.Update<SubaccountCreateResponse>(Uri, data).ConfigureAwait(false)).Result;
            return result.Object;
        }
        /// <summary>
        /// Asynchronously create Subaccount with the specified name and enabled.
        /// </summary>
        /// <returns>The create.</returns>
        /// <param name="name">Name.</param>
        /// <param name="enabled">Enabled.</param>
        public async Task<SubaccountCreateResponse> CreateAsync(string name, bool? enabled = null)
        {
            var mandatoryParams = new List<string> { "name" };
            var data = CreateData(mandatoryParams, new { name, enabled });
            var result = await Client.Update<SubaccountCreateResponse>(Uri, data);
            return result.Object;
        }
        #endregion

        #region Get
       
        /// <summary>
        /// Get Subaccount with the specified id.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="id">Identifier.</param>
        public Subaccount Get(string id)
        {
            var subaccount = Task.Run(async () => await GetResource<Subaccount>(id).ConfigureAwait(false)).Result;
            subaccount.Interface = this;
            return subaccount;
        }
        /// <summary>
        /// Asynchronously get Subaccount with the specified id.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="id">Identifier.</param>
        public async Task<Subaccount> GetAsync(string id)
        {
            var subaccount = await GetResource<Subaccount>(id);
            subaccount.Interface = this;
            return subaccount;
        }
        #endregion

        #region List
        /// <summary>
        /// List Subaccount with the specified limit and offset.
        /// </summary>
        /// <returns>The list.</returns>
        /// <param name="limit">Limit.</param>
        /// <param name="offset">Offset.</param>
        public ListResponse<Subaccount> List(uint? limit = null, uint? offset = null)
        {
            var mandatoryParams = new List<string> { };
            var data = CreateData(mandatoryParams, new {limit, offset});
            var resources = Task.Run(async () => await ListResources<ListResponse<Subaccount>>(data).ConfigureAwait(false)).Result;
            resources.Objects.ForEach(
                (obj) => obj.Interface = this
            );

            return resources;
        }
        /// <summary>
        /// List Subaccount with the specified limit and offset.
        /// </summary>
        /// <returns>The list.</returns>
        /// <param name="limit">Limit.</param>
        /// <param name="offset">Offset.</param>
        public async Task<ListResponse<Subaccount>> ListAsync(uint? limit = null, uint? offset = null)
        {
            var mandatoryParams = new List<string> { };
            var data = CreateData(mandatoryParams, new { limit, offset });
            var resources = await ListResources<ListResponse<Subaccount>>(data);
            resources.Objects.ForEach(
                (obj) => obj.Interface = this
            );

            return resources;
        }
        #endregion

        #region Delete
        /// <summary>
        /// Delete Subaccount with the specified id.
        /// </summary>
        /// <returns>The delete.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="cascade">Cascade.</param>
        public DeleteResponse<Subaccount> Delete(string id, bool? cascade = null)
        {
            var data = new Dictionary<string, object> {};
            if (cascade != null)
            {
                data = CreateData(new List<string> {}, new {cascade});
            }
            return Task.Run(async () => await DeleteResource<DeleteResponse<Subaccount>>(id, data).ConfigureAwait(false)).Result;
        }
        /// <summary>
        /// Asynchronously delete Subaccount with the specified id.
        /// </summary>
        /// <returns>The delete.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="cascade">Cascade.</param>
        public async Task<DeleteResponse<Subaccount>> DeleteAsync(string id, bool? cascade = null)
        {
            var data = new Dictionary<string, object> { };
            if (cascade != null)
            {
                data = CreateData(new List<string> { }, new { cascade });
            }
            return await DeleteResource<DeleteResponse<Subaccount>>(id, data);
        }
        #endregion

        #region Update
        /// <summary>
        /// Update Subaccount with the specified id, name and enabled.
        /// </summary>
        /// <returns>The update.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="name">Name.</param>
        /// <param name="enabled">Enabled.</param>
        public UpdateResponse<Subaccount> Update(string id, string name, bool? enabled = null)
        {
            var mandatoryParams = new List<string> {"id", "name"};
            var data = CreateData(
                mandatoryParams, new {name, enabled});
            var result = Task.Run(async () => await Client.Update<UpdateResponse<Subaccount>>(Uri + id + "/", data).ConfigureAwait(false)).Result;
            return result.Object;
        }
        /// <summary>
        /// Asynchronously update Subaccount with the specified id, name and enabled.
        /// </summary>
        /// <returns>The update.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="name">Name.</param>
        /// <param name="enabled">Enabled.</param>
        public async Task<UpdateResponse<Subaccount>> UpdateAsync(string id, string name, bool? enabled = null)
        {
            var mandatoryParams = new List<string> { "id", "name" };
            var data = CreateData(
                mandatoryParams, new { name, enabled });
            var result = await Client.Update<UpdateResponse<Subaccount>>(Uri + id + "/", data);
            return result.Object;
        }
        #endregion  
    }
}