using System.Collections.Generic;
using Plivo.Client;
using System.Threading.Tasks;

namespace Plivo.Resource.PhoneNumberCompliance
{
    public class PhoneNumberComplianceRequirementInterface : ResourceInterface
    {
        public PhoneNumberComplianceRequirementInterface(HttpClient client) : base(client)
        {
            Uri = "Account/" + Client.GetAuthId() + "/PhoneNumber/Compliance/Requirements/";
        }

        public PhoneNumberComplianceRequirement Get(string countryIso, string numberType, string userType)
        {
            var data = CreateData(new List<string> {""}, new {countryIso, numberType, userType});
            return ExecuteWithExceptionUnwrap(() =>
            {
                var result = Task.Run(async () =>
                    await ListResources<PhoneNumberComplianceRequirement>(data).ConfigureAwait(false)).Result;
                return result;
            });
        }
    }
}
