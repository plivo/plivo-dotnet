using System.Collections.Generic;

namespace Plivo.Resource.RegulatoryCompliance.DocumentType
{
    public class DocumentType : Resource
    {
        public string DocumentTypeId { get; set; }
        public string DocumentName { get; set; }
        public string Description { get; set; }
        public string ProofRequired { get; set; }
        public List<object> Information { get; set; }

        public override string ToString()
        {
            var result = "DocumentTypeId: " + DocumentTypeId + "\n" +
                         "DocumentName: " + DocumentName + "\n" +
                         "Description: " + Description + "\n" +
                         "ProofRequired: " + ProofRequired + "\n" +
                         "Information: " + (Information != null ? string.Join(",\n", Information) + "\n" : null);
            return StatusCode != 0 ? "ApiId: " + ApiId + "\n" + result : result;
        }
    }
}