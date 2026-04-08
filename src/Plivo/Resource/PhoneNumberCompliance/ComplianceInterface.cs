using System.Collections.Generic;
using System.Reflection;
using Plivo.Client;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Plivo.Resource.PhoneNumberCompliance
{
    public class ComplianceInterface : ResourceInterface
    {
        public ComplianceInterface(HttpClient client) : base(client)
        {
            Uri = "Account/" + Client.GetAuthId() + "/PhoneNumber/Compliance/";
        }

        public ComplianceGetResponse Get(string complianceId, string expand = null)
        {
            var data = new Dictionary<string, object>();
            if (expand != null)
            {
                data.Add("expand", expand);
            }

            return ExecuteWithExceptionUnwrap(() =>
            {
                var result = Task.Run(async () =>
                    await Client.Fetch<ComplianceGetResponse>(Uri + complianceId + "/", data)
                        .ConfigureAwait(false)).Result;
                try
                {
                    result.Object.GetType().GetRuntimeProperty("StatusCode")
                        .SetValue(result.Object, result.StatusCode, null);
                }
                catch (System.NullReferenceException)
                {
                }

                return result.Object;
            });
        }

        public ComplianceListResponse List(uint limit = 20, uint offset = 0, string status = null,
            string countryIso = null, string numberType = null, string userType = null,
            string alias = null, string expand = null)
        {
            var data = CreateData(new List<string> {""},
                new {limit, offset, status, countryIso, numberType, userType, alias, expand});
            return ExecuteWithExceptionUnwrap(() =>
            {
                var result = Task.Run(async () =>
                    await ListResources<ComplianceListResponse>(data).ConfigureAwait(false)).Result;
                return result;
            });
        }

        public ComplianceCreateResponse Create(string dataJson, Dictionary<string, string> documentFiles = null)
        {
            var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(dataJson);
            var filesToUpload = documentFiles ?? new Dictionary<string, string>();

            return ExecuteWithExceptionUnwrap(() =>
            {
                var result = Task.Run(async () =>
                    await Client.Update<ComplianceCreateResponse>(Uri, data, filesToUpload)
                        .ConfigureAwait(false)).Result;
                return result.Object;
            });
        }

        public ComplianceUpdateResponse Update(string complianceId, string dataJson,
            Dictionary<string, string> documentFiles = null)
        {
            var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(dataJson);
            var filesToUpload = documentFiles ?? new Dictionary<string, string>();

            return ExecuteWithExceptionUnwrap(() =>
            {
                var result = Task.Run(async () =>
                    await Client.Patch<ComplianceUpdateResponse>(Uri + complianceId + "/", data, filesToUpload)
                        .ConfigureAwait(false)).Result;
                return result.Object;
            });
        }

        public ComplianceDeleteResponse Delete(string complianceId)
        {
            return ExecuteWithExceptionUnwrap(() =>
            {
                var result = Task.Run(async () =>
                    await Client.Delete<ComplianceDeleteResponse>(Uri + complianceId + "/")
                        .ConfigureAwait(false)).Result;
                try
                {
                    result.Object.GetType().GetRuntimeProperty("StatusCode")
                        .SetValue(result.Object, result.StatusCode, null);
                }
                catch (System.NullReferenceException)
                {
                }

                return result.Object;
            });
        }

        public ComplianceLinkResponse LinkNumbers(object numbers)
        {
            var data = new Dictionary<string, object> {{"numbers", numbers}};
            return ExecuteWithExceptionUnwrap(() =>
            {
                var result = Task.Run(async () =>
                    await Client.Update<ComplianceLinkResponse>(Uri + "Link/", data)
                        .ConfigureAwait(false)).Result;
                return result.Object;
            });
        }
    }
}
