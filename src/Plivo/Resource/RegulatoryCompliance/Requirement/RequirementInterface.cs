using System.Collections.Generic;
using Plivo.Client;
using System.Threading.Tasks;

namespace Plivo.Resource.RegulatoryCompliance.Requirement
{
    public class RequirementInterface : ResourceInterface
    {
        public RequirementInterface(HttpClient client) : base(client)
        {
            Uri = "Account/" + Client.GetAuthId() + "/ComplianceRequirement/";
        }

        public Requirement Get(string complianceRequirementId)
        {
            return ExecuteWithExceptionUnwrap(() =>
            {
                var requirement = Task.Run(async () => await GetResource<Requirement>(complianceRequirementId)
                    .ConfigureAwait(false)).Result;
                requirement.Interface = this;
                return requirement;
            });
        }

        public ListResponse<Requirement> List(string countryIso2 = null, string numberType = null,
            string endUserType = null, string phoneNumber = null)
        {
            var data = CreateData(new List<string> {""}, new {countryIso2, numberType, endUserType, phoneNumber});
            return ExecuteWithExceptionUnwrap(() =>
            {
                var resources = Task.Run(async () =>
                        await ListResources<ListResponse<Requirement>>(data).ConfigureAwait(false))
                    .Result;
                resources.Objects.ForEach((obj) => obj.Interface = this);
                return resources;
            });
        }
    }
}