using System.Collections.Generic;
using System.Reflection;
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

        /// <summary>
        /// Create Subaccount with the specified name and enabled.
        /// </summary>
        /// <returns>The create.</returns>
        /// <param name="name">Name.</param>
        /// <param name="enabled">Enabled.</param>
        public SubaccountCreateResponse Create(string name, bool? enabled = null)
        {
            var mandatory_params = new List<string> {"name"};
            var data = CreateData(mandatory_params,new {name, enabled});
            return Client.Update<SubaccountCreateResponse>(Uri, data).Object;
        }

        /// <summary>
        /// Get Subaccount with the specified id.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="id">Identifier.</param>
        public Subaccount Get(string id)
        {
            return GetResource<Subaccount>(id);
        }

        /// <summary>
        /// List Subaccount with the specified limit and offset.
        /// </summary>
        /// <returns>The list.</returns>
        /// <param name="limit">Limit.</param>
        /// <param name="offset">Offset.</param>
        public ListResponse<Subaccount> List(uint? limit = null, uint? offset = null)
        {
            var mandatory_params = new List<string> {};
            var data = CreateData(mandatory_params,new {limit, offset});
            return ListResources<ListResponse<Subaccount>>(data);
        }

        /// <summary>
        /// Delete Subaccount with the specified id.
        /// </summary>
        /// <returns>The delete.</returns>
        /// <param name="id">Identifier.</param>
        public DeleteResponse<Subaccount> Delete(string id)
        {
            return DeleteResource<DeleteResponse<Subaccount>>(id);
        }

        /// <summary>
        /// Update Subaccount with the specified id, name and enabled.
        /// </summary>
        /// <returns>The update.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="name">Name.</param>
        /// <param name="enabled">Enabled.</param>
        public UpdateResponse<Subaccount> Update(string id, string name, bool? enabled = null)
        {
            var mandatory_params = new List<string> { "id", "name" };
            var data = CreateData(
                mandatory_params,new {name, enabled});
            return Client.Update<UpdateResponse<Subaccount>>(Uri + id + "/", data).Object;
        }
        
    }
}
