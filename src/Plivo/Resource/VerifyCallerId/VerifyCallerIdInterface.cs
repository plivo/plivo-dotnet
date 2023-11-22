using System.Collections.Generic;
using System.Threading.Tasks;
using Plivo.Client;
using Plivo.Exception;
using Plivo.Resource.Application;

namespace Plivo.Resource.VerifyCallerId
{
    public class VerifyCallerIdInterface : ResourceInterface
    {
        public VerifyCallerIdInterface(HttpClient client) : base(client)
        {
            Uri = "Account/" + Client.GetAuthId() + "/VerifiedCallerId/";
        }

        #region Initiate

        public InitiateVerifyResponse Initiate(string phoneNumber, string channel = null, string alias = null, string subaccount = null)
        {
            Dictionary<string, object> data = null;
            var mandatoryParams = new List<string> { "phoneNumber" };
            data = CreateData(
                mandatoryParams,
                new
                {
                    phoneNumber,
                    channel,
                    alias,
                    subaccount
                });
            
            return ExecuteWithExceptionUnwrap(() =>
            {
                var result = Task.Run(async () => await Client.Update<InitiateVerifyResponse>(Uri, data).ConfigureAwait(false)).Result;
                result.Object.StatusCode = result.StatusCode;
                return result.Object;
            });
        }
        
        public async Task<InitiateVerifyResponse> InitiateAsync(string phoneNumber, string channel = null, string alias = null, string subaccount = null)
        {
            Dictionary<string, object> data = null;
            var mandatoryParams = new List<string> { "phoneNumber" };
            data = CreateData(
                mandatoryParams,
                new
                {
                    phoneNumber,
                    channel,
                    alias,
                    subaccount
                });

            var result = await Client.Update<InitiateVerifyResponse>(Uri, data);
            result.Object.StatusCode = result.StatusCode;
            return result.Object;
        }

        #endregion

        #region Verify
            
        public VerifyCallerId Verify(string otp, string verificationUuid)
        {
            if (string.IsNullOrEmpty(verificationUuid))
            {
                throw new PlivoValidationException("verification Uuid is a required parameter");
            }
            Dictionary<string, object> data = null;
            var mandatoryParams = new List<string> { "otp" };
            data = CreateData(
                mandatoryParams,
                new
                {
                    otp
                });
            
            return ExecuteWithExceptionUnwrap(() =>
            {
                var result = Task.Run(async () => await Client.Update<VerifyCallerId>(Uri + "Verification/" + verificationUuid, data).ConfigureAwait(false)).Result;
                result.Object.StatusCode = result.StatusCode;
                return result.Object;
            });
        }
        
        public async Task<VerifyCallerId> VerifyAsync(string otp, string verificationUuid)
        {
            if (string.IsNullOrEmpty(verificationUuid))
            {
                throw new PlivoValidationException("verification Uuid is a required parameter");
            }
            Dictionary<string, object> data = null;
            var mandatoryParams = new List<string> { "otp" };
            data = CreateData(
                mandatoryParams,
                new
                {
                    otp
                });

            var result = await Client.Update<VerifyCallerId>(Uri + "Verification/" + verificationUuid, data);
            result.Object.StatusCode = result.StatusCode;
            return result.Object;
        }

        #endregion

        #region Update
                
        public GetVerifiedCallerIdResponse Update(string phoneNumber, string alias = null, string subaccount = null)
        {
            if (string.IsNullOrEmpty(phoneNumber))
            {
                throw new PlivoValidationException("phoneNumber is a required parameter");
            }
            Dictionary<string, object> data = null;
            var mandatoryParams = new List<string> {""};
            data = CreateData(
                mandatoryParams,
                new
                {
                    alias,
                    subaccount
                });
            
            return ExecuteWithExceptionUnwrap(() =>
            {
                var result = Task.Run(async () => await Client.Update<GetVerifiedCallerIdResponse>(Uri + phoneNumber, data).ConfigureAwait(false)).Result;
                result.Object.StatusCode = result.StatusCode;
                return result.Object;
            });
        }
        
        public async Task<GetVerifiedCallerIdResponse> UpdateAsync(string phoneNumber, string alias = null, string subaccount = null)
        {
            if (string.IsNullOrEmpty(phoneNumber))
            {
                throw new PlivoValidationException("phoneNumber is a required parameter");
            }
            Dictionary<string, object> data = null;
            var mandatoryParams = new List<string> {""};
            data = CreateData(
                mandatoryParams,
                new
                {
                    alias,
                    subaccount
                });

            var result = await Client.Update<GetVerifiedCallerIdResponse>(Uri + phoneNumber, data);
            result.Object.StatusCode = result.StatusCode;
            return result.Object;
        }
        
        #endregion

        #region Get
        
        public GetVerifiedCallerIdResponse Get(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
            {
                throw new PlivoValidationException("phoneNumber is a required parameter");
            }
            return ExecuteWithExceptionUnwrap(() =>
            {
                var verifiedCallerId = Task.Run(async () => await GetResource<GetVerifiedCallerIdResponse>(phoneNumber).ConfigureAwait(false)).Result;
                verifiedCallerId.Interface = this;
                return verifiedCallerId;
            });
        }
        
        public async Task<GetVerifiedCallerIdResponse> GetAsync(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
            {
                throw new PlivoValidationException("phoneNumber is a required parameter");
            }
            var verifiedCallerId = await GetResource<GetVerifiedCallerIdResponse>(phoneNumber);
            verifiedCallerId.Interface = this;
            return verifiedCallerId;
        }
        
        #endregion

        #region List

        public ListResponse<ListVerifiedCallerIdResponse> List(uint? limit = null, uint? offset = null, 
            string country = null, string alias = null, string subaccount = null)
        {
            var mandatoryParams = new List<string> { "" };
            var data = CreateData(
                mandatoryParams,
                new 
                {
                    limit,
                    offset,
                    country,
                    alias,
                    subaccount,
                });
            return ExecuteWithExceptionUnwrap(() =>
            {
                var resources = Task.Run(async () => await ListResources<ListResponse<ListVerifiedCallerIdResponse>>(data).ConfigureAwait(false)).Result;
                resources.Objects.ForEach(
                    (obj) => obj.Interface = this
                );
                return resources;
            });            
        }

        public async Task<ListResponse<ListVerifiedCallerIdResponse>> ListAsync(uint? limit = null, uint? offset = null,
            string country = null, string alias = null, string subaccount = null)
        {
            var mandatoryParams = new List<string> { "" };
            var data = CreateData(
                mandatoryParams, new
                {
                    limit,
                    offset,
                    country,
                    alias,
                    subaccount,
                });
            
            var resources = await ListResources<ListResponse<ListVerifiedCallerIdResponse>>(data);
            resources.Objects.ForEach(
                (obj) => obj.Interface = this
            );
            return resources;
        }
        #endregion

        #region Delete

        public DeleteResponse<GetVerifiedCallerIdResponse> Delete(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
            {
                throw new PlivoValidationException("phoneNumber is a required parameter");
            }
            var mandatoryParams = new List<string> { "" };
            var data = CreateData (
                mandatoryParams, new {});
            
            return ExecuteWithExceptionUnwrap (() => {
                var result = Task.Run (async () => 
                    await Client.Delete<DeleteResponse<GetVerifiedCallerIdResponse>> (Uri + phoneNumber, data).
                        ConfigureAwait (false)).Result;
                try {
                    result.Object.StatusCode = result.StatusCode;
                } catch (System.NullReferenceException) {

                }
                return result.Object;
            });
        }
        
        public async Task<AsyncResponse> DeleteAsync(string phoneNumber) {
            if (string.IsNullOrEmpty(phoneNumber))
            {
                throw new PlivoValidationException("phoneNumber is a required parameter");
            }
            var mandatoryParams = new List<string> { "" };
            var data = CreateData (
                mandatoryParams, new {});
            
            var result = Task.Run (async () => 
                await Client.Delete<AsyncResponse> (Uri + phoneNumber, data).ConfigureAwait (false)).Result;
            await Task.WhenAll();
            result.Object.StatusCode = result.StatusCode;
            return result.Object;
        }
        
        #endregion
    }
}