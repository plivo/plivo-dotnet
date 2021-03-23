using System;
using System.Collections.Generic;
using Plivo.Client;
using System.Threading.Tasks;
using Plivo.Resource.RegulatoryCompliance.EndUser;

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
            var data = CreateData(new List<string> {""},
                new {limit, offset, status, endUserType, numberType, countryIso2, alias, endUserId});
            return ExecuteWithExceptionUnwrap(() =>
            {
                var resources = Task.Run(async () =>
                    await ListResources<ListResponse<ComplianceApplication>>(data).ConfigureAwait(false)).Result;
                resources.Objects.ForEach((obj) => obj.Interface = this);
                return resources;
            });
        }

        public DeleteResponse<ComplianceApplication> Delete(string complianceApplicationId)
        {
            return Task.Run(async () =>
                    await DeleteResource<DeleteResponse<ComplianceApplication>>(complianceApplicationId)
                        .ConfigureAwait(false))
                .Result;
        }


        public CreateResponse Create(string complianceRequirementId = null, string endUserId = null,
            string alias = null, string endUserType = null, string countryIso2 = null, string numberType = null,
            List<string> documentIds = null)
        {
            var data = CreateData(new List<string> {""}, new
                {complianceRequirementId, endUserId, alias, endUserType, countryIso2, numberType, documentIds});
            return ExecuteWithExceptionUnwrap(() =>
            {
                var result = Task.Run(async () =>
                    await Client.Update<CreateResponse>(Uri, data).ConfigureAwait(false)).Result;
                return result.Object;
            });
        }


        public UpdateResponse Update(string complianceApplicationId, List<string> documentIds = null)
        {
            var data = CreateData(new List<string> {""}, new {documentIds});
            return ExecuteWithExceptionUnwrap(() =>
            {
                var result = Task.Run(async () =>
                    await Client.Update<UpdateResponse>(Uri + complianceApplicationId + "/", data)
                        .ConfigureAwait(false)).Result;
                return result.Object;
            });
        }

        public SubmitResponse Submit(string complianceApplicationId)
        {
            var data = CreateData(new List<string> {"complianceApplicationId"}, new { });
            return ExecuteWithExceptionUnwrap(() =>
            {
                var result = Task.Run(async () =>
                    await Client.Update<SubmitResponse>(Uri + complianceApplicationId + "/Submit/", data)
                        .ConfigureAwait(false)).Result;
                return result.Object;
            });
        }
    }
}