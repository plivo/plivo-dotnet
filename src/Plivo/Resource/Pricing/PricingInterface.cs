using System.Collections.Generic;
using System.Threading.Tasks;
using Plivo.Client;


namespace Plivo.Resource.Pricing
{
    /// <summary>
    /// Pricing interface.
    /// </summary>
    public class PricingInterface : ResourceInterface
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:plivo.Resource.Pricing.PricingInterface"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        public PricingInterface(HttpClient client) : base(client)
        {
            Uri = "Account/" + Client.GetAuthId() + "/Pricing/";
        }

        #region Get
        /// <summary>
        /// Get Procing for countryIso.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="countryIso">Country iso.</param>
        public Pricing Get(string countryIso)
        {

			return ExecuteWithExceptionUnwrap(() =>
			{
				return Task.Run(async () => await GetResource<Pricing>("", new Dictionary<string, object>()
				{
					{"country_iso", countryIso}
				}).ConfigureAwait(false)).Result;
			});
        }
        /// <summary>
        /// Asynchronously get Procing for countryIso.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="countryIso">Country iso.</param>
        public async Task<Pricing> GetAsync(string countryIso)
        {
            return await GetResource<Pricing>("", new Dictionary<string, object>()
            {
                {"country_iso", countryIso}
            });
        }
        #endregion
    }
}