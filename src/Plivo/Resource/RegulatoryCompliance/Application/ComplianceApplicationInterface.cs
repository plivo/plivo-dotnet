using System.Collections.Generic;
using Plivo.Client;
using System.Threading.Tasks;

namespace Plivo.Resource.RegulatoryCompliance.Application
{
    public class ComplianceApplicationInterface : ResourceInterface
    {
        public ComplianceApplicationInterface(HttpClient client) : base(client)
        {
            Uri = "Account/" + Client.GetAuthId() + "/ComplianceApplication/";
        }

        public ComplianceApplication Get(string complianceApplicationId)
        {
            return ExecuteWithExceptionUnwrap(() =>
            {
                var application = Task.Run(async () =>
                    await GetResource<ComplianceApplication>(complianceApplicationId).ConfigureAwait(false)).Result;
                application.Interface = this;
                return application;
            });
        }

        public ListResponse<ComplianceApplication> List(uint limit = 20, uint offset = 0, string status = null,
            string endUserType = null, string numberType = null, string countryIso2 = null, string alias = null,
            string endUserId = null)
        {
            var data = CreateData( new List<string> {""}, new {limit, offset});
            return ExecuteWithExceptionUnwrap(() =>
            {
                var resources = Task.Run(async () =>
                    await ListResources<ListResponse<ComplianceApplication>>(data).ConfigureAwait(false)).Result;
                resources.Objects.ForEach((obj) => obj.Interface = this);
                return resources;
            });
        }

        public DeleteResponse<ComplianceApplication> Delete(string complianceDocumentId)
        {
            return Task.Run(async () =>
                await DeleteResource<DeleteResponse<ComplianceApplication>>(complianceDocumentId).ConfigureAwait(false)).Result;
        }
    }
}