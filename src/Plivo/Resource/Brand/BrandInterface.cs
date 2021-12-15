using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Plivo.Client;

namespace Plivo.Resource.Brand
{
    /// <summary>
    /// Brand interface.
    /// </summary>
    public class BrandInterface : ResourceInterface
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:plivo.Resource.Brand.BrandInterface"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        public BrandInterface(HttpClient client) : base(client)
        {
            Uri = "Account/" + Client.GetAuthId() + "/";
        }

        #region GET
         /// <summary>
        /// Get Brand with the specified uuid.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="brand_id">BrandID.</param>
        public Brand Get(string brandID)
        {
			return ExecuteWithExceptionUnwrap(() =>
			{
				var response = Task.Run(async () => await GetResource<Brand>("10dlc/Brand/"+brandID).ConfigureAwait(false)).Result;
                // response.Interface = this;
				return response;
			});
        }
        /// <summary>
        /// Asynchronously get Brand with the specified brandID.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="brand_id"> BrandID.</param>
        public async Task<Brand> GetAsync(string brandID)
        {
            var response = await GetResource<Brand>("10dlc/Brand/"+brandID);
            response.Interface = this;
            return response;
        }
        #endregion
        #region List
        /// <summary>
        /// <summary>
        /// List Brand list type and status.
        /// </summary>
        /// <returns>The list.</returns>
        /// <param name="type">type.</param>
        /// <param name="status">status.</param>
        public ListResponse<Brands> List()
        {

			return ExecuteWithExceptionUnwrap(() =>
			{
				var resources = Task.Run(async () => await ListResources<ListResponse<Brands>>("10dlc/Brand/", null).ConfigureAwait(false)).Result;
				resources.Objects.ForEach(
					(obj) => obj.Interface = this
				);

				return resources;
			});
        }
        /// <summary>
        /// <summary>
        /// List Brand list type and status.
        /// </summary>
        /// <returns>The list.</returns>
        /// <param name="type">type.</param>
        /// <param name="status">status.</param>
        public async Task<ListResponse<Brands>> ListAsync()
        {

            var resources = await ListResources<ListResponse<Brands>>("10dlc/Brand/", null);
            resources.Objects.ForEach(
                (obj) => obj.Interface = this
            );

            return resources;
        }
        #endregion
        #region Create
        /// <summary>
        /// Create Brand with the specified vertical, city, ein etc.
        /// </summary>
        /// <returns>The create.</returns>
        /// <param name="city">City.</param>
        /// <param name="company_name">CompanyName.</param>
        /// <param name="country">Country.</param>
        /// <param name="Ein">Ein.</param>
        /// <param name="ein_issuing_country">EinIssuingCountry.</param>
        /// <param name="email">Email</param>
        /// <param name="entity_type">EntityType</param>
        /// <param name="postal_code">PostalCode</param>
        /// <param name="registration_status">RegistrationStatus</param>
        /// <param name="state">State</param>
        /// <param name="stock_exchange">StockExchange</param>
        /// <param name="stock_symbol">StockSymbol</param>
        /// <param name="street">Street</param>
        /// <param name="vertical">Vertical</param>

        public BrandCreateResponse Create(string city, string company_name, string country, string ein, string ein_issuing_country,
            string email, string entity_type,  string phone, string postal_code,
            string registration_status, string state, string stock_exchange, string stock_symbol, string street, string vertical,string first_name, string last_name,
            string website = null, string secondary_vetting = null,
            string alt_business_id_type = null,  string alt_business_id = null)
        {
        var mandatoryParams = new List<string>{"city", "vertical"};
        var data = CreateData(
            mandatoryParams,
            new
            {
                city,
                company_name,
                country,
                ein,
                ein_issuing_country,
                email,
                entity_type,
                phone,
                postal_code,
                registration_status,
                state,
                stock_exchange,
                stock_symbol,
                street,
                vertical,
                website,
                secondary_vetting,
                alt_business_id_type,
                first_name,
                last_name,
                alt_business_id
            });
		return ExecuteWithExceptionUnwrap(() =>
		{
				var result = Task.Run(async () => await Client.Update<BrandCreateResponse>(Uri + "10dlc/Brand/", data).ConfigureAwait(false)).Result;
				result.Object.StatusCode = result.StatusCode;
                return result.Object;
		});
        }

		 /// <summary>
        /// Create Brand .
       /// <returns>The create.</returns>
        /// <param name="city">City.</param>
        /// <param name="company_name">CompanyName.</param>
        /// <param name="country">Country.</param>
        /// <param name="Ein">Ein.</param>
        /// <param name="ein_issuing_country">EinIssuingCountry.</param>
        /// <param name="email">Email</param>
        /// <param name="entity_type">EntityType</param>
        /// <param name="postal_code">PostalCode</param>
        /// <param name="registration_status">RegistrationStatus</param>
        /// <param name="state">State</param>
        /// <param name="stock_exchange">StockExchange</param>
        /// <param name="stock_symbol">StockSymbol</param>
        /// <param name="street">Street</param>
        /// <param name="vertical">Vertical</param>
		public async Task<BrandCreateResponse> CreateAsync(
			string city, string company_name, string country, string ein, string ein_issuing_country,
            string email, string entity_type,  string phone, string postal_code,
            string registration_status, string state, string stock_exchange, string stock_symbol, string street, string vertical,string first_name, string last_name,
            string website = null, string secondary_vetting = null,
            string alt_business_id_type = null,  string alt_business_id = null)
		{

			 var mandatoryParams = new List<string>{"city", "vertical"};
        var data = CreateData(
            mandatoryParams,
            new
            {
                city,
                company_name,
                country,
                ein,
                ein_issuing_country,
                email,
                entity_type,
                phone,
                postal_code,
                registration_status,
                state,
                stock_exchange,
                stock_symbol,
                street,
                vertical,
                website,
                secondary_vetting,
                alt_business_id_type,
                first_name,
                last_name,
                alt_business_id
            });

			var result = await Client.Update<BrandCreateResponse>(Uri + "10dlc/Brand/", data);
            result.Object.StatusCode = result.StatusCode;
			return result.Object;
		}
		#endregion
    }
}