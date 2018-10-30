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
            var mandatoryParams = new List<string> {"name"};
            var data = CreateData(mandatoryParams, new {name, enabled});
            return Client.Update<SubaccountCreateResponse>(Uri, data).Object;
        }

        /// <summary>
        /// Get Subaccount with the specified id.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="id">Identifier.</param>
        public Subaccount Get(string id)
        {
            var subaccount = GetResource<Subaccount>(id);
            subaccount.Interface = this;
            return subaccount;
        }

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
            var resources = ListResources<ListResponse<Subaccount>>(data);
            resources.Objects.ForEach(
                (obj) => obj.Interface = this
            );

            return resources;
        }

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
            return DeleteResource<DeleteResponse<Subaccount>>(id, data);
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
            var mandatoryParams = new List<string> {"id", "name"};
            var data = CreateData(
                mandatoryParams, new {name, enabled});
            return Client.Update<UpdateResponse<Subaccount>>(Uri + id + "/", data).Object;
        }
    }
}