using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Plivo.Client;


namespace Plivo.Resource.PhoneNumber
{
    /// <summary>
    /// Phone number interface.
    /// </summary>
    public class PhoneNumberInterface : ResourceInterface
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:plivo.Resource.PhoneNumber.PhoneNumberInterface"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        public PhoneNumberInterface(HttpClient client) : base(client)
        {
            Uri = "Account/" + Client.GetAuthId() + "/PhoneNumber/";
        }
        #region List
        /// <summary>
        /// List PhoneNumber with the specified countryIso, type, pattern, region, services, lata, rateCenter, limit and offset.
        /// </summary>
        /// <returns>The list.</returns>
        /// <param name="countryIso">Country iso.</param>
        /// <param name="type">Type.</param>
        /// <param name="pattern">Pattern.</param>
        /// <param name="region">Region.</param>
        /// <param name="services">Services.</param>
        /// <param name="lata">Lata.</param>
        /// <param name="rateCenter">Rate center.</param>
        /// <param name="eligible">Eligible.</param>
        /// <param name="limit">Limit.</param>
        /// <param name="offset">Offset.</param>
        public ListResponse<PhoneNumber> List(
            string countryIso, string type = null, string pattern = null,
            string region = null, string services = null, uint? lata = null,
            string rateCenter = null, bool? eligible = null, uint? limit = null, 
            uint? offset = null)
        {
            var mandatoryParams = new List<string> {""};
            var data = CreateData(
                mandatoryParams,
                new
                {
                    countryIso,
                    type,
                    pattern,
                    region,
                    services,
                    lata,
                    rateCenter,
                    eligible,
                    limit,
                    offset
                });

			return ExecuteWithExceptionUnwrap(() =>
			{
				var resources = Task.Run(async () => await ListResources<ListResponse<PhoneNumber>>(data).ConfigureAwait(false)).Result;

				resources.Objects.ForEach(
					(obj) => obj.Interface = this
				);

				return resources;
			});
        }
        /// <summary>
        /// List PhoneNumber with the specified countryIso, type, pattern, region, services, lata, rateCenter, limit and offset.
        /// </summary>
        /// <returns>The list.</returns>
        /// <param name="countryIso">Country iso.</param>
        /// <param name="type">Type.</param>
        /// <param name="pattern">Pattern.</param>
        /// <param name="region">Region.</param>
        /// <param name="services">Services.</param>
        /// <param name="lata">Lata.</param>
        /// <param name="rateCenter">Rate center.</param>
        /// <param name="eligible">Eligible.</param>
        /// <param name="limit">Limit.</param>
        /// <param name="offset">Offset.</param>
        public async Task<ListResponse<PhoneNumber>> ListAsync(
            string countryIso, string type = null, string pattern = null,
            string region = null, string services = null, uint? lata = null,
            string rateCenter = null, bool? eligible = null, uint? limit = null,
            uint? offset = null)
        {
            var mandatoryParams = new List<string> { "" };
            var data = CreateData(
                mandatoryParams,
                new
                {
                    countryIso,
                    type,
                    pattern,
                    region,
                    services,
                    lata,
                    rateCenter,
                    eligible,
                    limit,
                    offset
                });
            var resources = await ListResources<ListResponse<PhoneNumber>>(data);

            resources.Objects.ForEach(
                (obj) => obj.Interface = this
            );

            return resources;
        }
        #endregion

        #region Buy
        /// <summary>
        /// Buy PhoneNumber with the specified number and associate it with
        /// application whose Id id appId.
        /// </summary>
        /// <returns>The buy.</returns>
        /// <param name="number">Number.</param>
        /// <param name="appId">App identifier.</param>
        /// <param name="verificationInfo">Verification information. address_id and identity_id are the keys</param>
        public PhoneNumberBuyResponse Buy(string number, string appId = null, 
                                          Dictionary<string, string> verificationInfo = null)
        {
            var mandatoryParams = new List<string> {""};
            var data = CreateData(
                mandatoryParams, new {appId, verificationInfo});

			return ExecuteWithExceptionUnwrap(() =>
			{
				var result = Task.Run(async () => await Client.Update<PhoneNumberBuyResponse>(
					Uri + number + "/",
					data
				).ConfigureAwait(false)).Result;

				return result.Object;
			});
        }
        /// <summary>
        /// Asynchronously buy PhoneNumber with the specified number and associate it with
        /// application whose Id id appId.
        /// </summary>
        /// <returns>The buy.</returns>
        /// <param name="number">Number.</param>
        /// <param name="appId">App identifier.</param>
        /// <param name="verificationInfo">Verification information. address_id and identity_id are the keys</param>
        public async Task<PhoneNumberBuyResponse> BuyAsync(string number, string appId = null,
                                          Dictionary<string, string> verificationInfo = null)
        {
            var mandatoryParams = new List<string> { "" };
            var data = CreateData(
                mandatoryParams, new { appId, verificationInfo });
            var result = await Client.Update<PhoneNumberBuyResponse>(
                  Uri + number + "/",
                  data
              );

            return result.Object;
        }
        #endregion
    }
}