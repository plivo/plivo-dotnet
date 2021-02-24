using System;
using System.Collections.Generic;
using Plivo.Client;
using System.Threading.Tasks;

namespace Plivo.Resource.RegulatoryCompliance.Document
{
    public class DocumentInterface : ResourceInterface
    {
        public DocumentInterface(HttpClient client) : base(client)
        {
            Uri = "Account/" + Client.GetAuthId() + "/ComplianceDocument/";
        }

        public GetResponse Get(string complianceDocumentId)
        {
            return ExecuteWithExceptionUnwrap(() =>
            {
                var document = Task.Run(async () =>
                    await GetResource<GetResponse>(complianceDocumentId).ConfigureAwait(false)).Result;
                document.Interface = this;
                return document;
            });
        }

        public ListResponse<Document> List(uint limit = 20, uint offset = 0, string endUserId = null,
            string documentTypeId = null, string alias = null)
        {
            var data = CreateData(new List<string> {""}, new {limit, offset, endUserId, documentTypeId, alias});
            return ExecuteWithExceptionUnwrap(() =>
            {
                var resources = Task.Run(async () =>
                    await ListResources<ListResponse<Document>>(data).ConfigureAwait(false)).Result;
                resources.Objects.ForEach((obj) => obj.Interface = this);
                return resources;
            });
        }

        public DeleteResponse<Document> Delete(string complianceDocumentId)
        {
            return Task.Run(async () =>
                    await DeleteResource<DeleteResponse<Document>>(complianceDocumentId).ConfigureAwait(false))
                .Result;
        }

        public CreateResponse Create(string endUserId = null, string documentTypeId = null, string alias = null,
            string inputFile = null, object dataFields = null)
        {
            var data = CreateData(new List<string> {""}, new {endUserId, documentTypeId, alias});
            var fileToUpload = new Dictionary<string, string>();
            if (inputFile != null)
            {
                fileToUpload.Add("file", inputFile);
            }

            return ExecuteWithExceptionUnwrap(() =>
            {
                var result = Task.Run(async () =>
                    await Client.Update<CreateResponse>(Uri, data, fileToUpload).ConfigureAwait(false)).Result;
                return result.Object;
            });
        }

        public UpdateResponse Update(string endUserId = null, string documentTypeId = null, string alias = null,
            string inputFile = null, object dataFields = null)
        {
            var data = CreateData(new List<string> {""}, new {endUserId, documentTypeId, alias});
            var fileToUpload = new Dictionary<string, string>();
            if (inputFile != null)
            {
                fileToUpload.Add("file", inputFile);
            }
            return ExecuteWithExceptionUnwrap(() =>
            {
                var result = Task.Run(async () =>
                        await Client.Update<UpdateResponse>(Uri, data, fileToUpload).ConfigureAwait(false))
                    .Result;
                return result.Object;
            });
        }
    }
}