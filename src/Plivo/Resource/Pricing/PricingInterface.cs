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

        /// <summary>
        /// Get Procing for countryIso.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="countryIso">Country iso.</param>
        public Pricing Get(string countryIso)
        {
            return GetResource<Pricing>(countryIso);
        }
    }
}
