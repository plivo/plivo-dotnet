using System.Collections.Generic;
using Plivo.Client;
using System.Threading.Tasks;

namespace Plivo.Resource.RegulatoryCompliance.DocumentType
{
    public class DocumentTypeInterface : ResourceInterface
    {
        public DocumentTypeInterface(HttpClient client) : base(client)
        {
            Uri = "Account/" + Client.GetAuthId() + "/ComplianceDocumentType/";
        }

        public DocumentType Get(string documentTypeId)
        {
            return ExecuteWithExceptionUnwrap(() =>
            {
                var documentType = Task.Run(async () =>
                    await GetResource<DocumentType>(documentTypeId).ConfigureAwait(false)).Result;
                documentType.Interface = this;
                return documentType;
            });
        }

        public ListResponse<DocumentType> List(uint? limit = null, uint? offset = null)
        {
            var mandatoryParams = new List<string> {""};
            var data = CreateData(mandatoryParams, new {limit, offset});
            return ExecuteWithExceptionUnwrap(() =>
            {
                var resources = Task.Run(async () =>
                        await ListResources<ListResponse<DocumentType>>(data).ConfigureAwait(false))
                    .Result;
                resources.Objects.ForEach((obj) => obj.Interface = this);
                return resources;
            });
        }
    }
}