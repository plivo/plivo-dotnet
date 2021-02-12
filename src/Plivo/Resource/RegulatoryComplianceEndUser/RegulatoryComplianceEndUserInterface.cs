using System.Collections.Generic;
using Plivo.Client;
using System.Threading.Tasks;


namespace Plivo.Resource.RegulatoryComplianceEndUser
{
    public class RegulatoryComplianceEndUserInterface : ResourceInterface
    {
        public RegulatoryComplianceEndUserInterface(HttpClient client) : base(client)
        {
            Uri = "Account/" + Client.GetAuthId() + "/EndUser/";
        }

        public RegulatoryComplianceEndUser Get(string endUserId)
        {
            return ExecuteWithExceptionUnwrap(() =>
            {
                var regulatoryComplianceEndUser = Task.Run(async () =>
                    await GetResource<RegulatoryComplianceEndUser>(endUserId).ConfigureAwait(false)).Result;
                regulatoryComplianceEndUser.Interface = this;
                return regulatoryComplianceEndUser;
            });
        }

        public ListResponse<RegulatoryComplianceEndUser> List(uint? limit = null, uint? offset = null)
        {
            var mandatoryParams = new List<string> {""};
            var data = CreateData(mandatoryParams, new {limit, offset});
            return ExecuteWithExceptionUnwrap(() =>
            {
                var resources = Task.Run(async () =>
                    await ListResources<ListResponse<RegulatoryComplianceEndUser>>(data).ConfigureAwait(false)).Result;
                resources.Objects.ForEach(
                    (obj) => obj.Interface = this
                );
                return resources;
            });
        }
    }
}