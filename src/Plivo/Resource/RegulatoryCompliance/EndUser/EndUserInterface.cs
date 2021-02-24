using System.Collections.Generic;
using Plivo.Client;
using System.Threading.Tasks;


namespace Plivo.Resource.RegulatoryCompliance.EndUser
{
    public class EndUserInterface : ResourceInterface
    {
        public EndUserInterface(HttpClient client) : base(client)
        {
            Uri = "Account/" + Client.GetAuthId() + "/EndUser/";
        }

        public EndUser Get(string endUserId)
        {
            return ExecuteWithExceptionUnwrap(() =>
            {
                var endUser = Task.Run(async () =>
                    await GetResource<EndUser>(endUserId).ConfigureAwait(false)).Result;
                endUser.Interface = this;
                return endUser;
            });
        }

        public ListResponse<EndUser> List(uint limit = 20, uint offset = 0, string name = null, string lastName = null,
            string endUserType = null)
        {
            var data = CreateData(new List<string> {""}, new {limit, offset, name, lastName, endUserType});
            return ExecuteWithExceptionUnwrap(() =>
            {
                var resources = Task.Run(async () =>
                    await ListResources<ListResponse<EndUser>>(data).ConfigureAwait(false)).Result;
                resources.Objects.ForEach((obj) => obj.Interface = this);
                return resources;
            });
        }

        public DeleteResponse<EndUser> Delete(string endUserId)
        {
            return Task.Run(async () => await DeleteResource<DeleteResponse<EndUser>>(endUserId).ConfigureAwait(false))
                .Result;
        }

        public CreateResponse Create(string name = null, string lastName = null, string endUserType = null)
        {
            var data = CreateData(new List<string> {""}, new {name, lastName, endUserType});
            return ExecuteWithExceptionUnwrap(() =>
            {
                var result = Task.Run(async () =>
                    await Client.Update<CreateResponse>(Uri, data).ConfigureAwait(false)).Result;
                return result.Object;
            });
        }

        public UpdateResponse Update(string endUserId, string name = null, string lastName = null,
            string endUserType = null)
        {
            var data = CreateData(new List<string> {""}, new {name, lastName, endUserType});
            return ExecuteWithExceptionUnwrap(() =>
            {
                var result = Task.Run(async () =>
                        await Client.Update<UpdateResponse>(Uri + endUserId + "/", data).ConfigureAwait(false))
                    .Result;
                return result.Object;
            });
        }
    }
}