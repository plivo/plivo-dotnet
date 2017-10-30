using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        /// <param name="limit">Limit.</param>
        /// <param name="offset">Offset.</param>
        public ListResponse<PhoneNumber> List(
            string countryIso, string type = null, string pattern = null,
            string region = null, string services = null, uint? lata = null,
            string rateCenter = null, uint? limit = null, uint? offset = null)
        {
            var mandatory_params = new List<string> { "" };var data = CreateData(
            mandatory_params,
                new
                {
                    countryIso, type, pattern, region, services, lata,
                    rateCenter, limit, offset
                });
            var resources = ListResources<ListResponse<PhoneNumber>>(data);
            resources.Objects.Select(obj => obj.Interface = this);
            return resources;
        }

        /// <summary>
        /// Buy PhoneNumber with the specified number and associate it with
        /// application whose Id id appId.
        /// </summary>
        /// <returns>The buy.</returns>
        /// <param name="number">Number.</param>
        /// <param name="appId">App identifier.</param>
        public PhoneNumberBuyResponse Buy(string number, string appId = null)
        {
            var mandatory_params = new List<string> { "" };var data = CreateData(
                mandatory_params,new {appId});
            return
                Client.Update<PhoneNumberBuyResponse>(
                    Uri + number + "/",
                    data
                ).Object;
        }
    }
}
