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
        public GetBrand Get(string brandID)
        {
			return ExecuteWithExceptionUnwrap(() =>
			{
				var response = Task.Run(async () => await GetResource<GetBrand>("10dlc/Brand/"+brandID).ConfigureAwait(false)).Result;
                // response.Interface = this;
				return response;
			});
        }
        /// <summary>
        /// Asynchronously get Brand with the specified brandID.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="brand_id"> BrandID.</param>
        public async Task<GetBrand> GetAsync(string brandID)
        {
            var response = await GetResource<GetBrand>("10dlc/Brand/"+brandID);
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
        public BrandListResponse<ListBrands> List()
        {

			return ExecuteWithExceptionUnwrap(() =>
			{
				var resources = Task.Run(async () => await ListResources<BrandListResponse<ListBrands>>("10dlc/Brand", null).ConfigureAwait(false)).Result;
				resources.Brands.ForEach(
					(obj) => obj.Interface = this
				);
                Console.WriteLine(resources);

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
        public async Task<BrandListResponse<ListBrands>> ListAsync()
        {
            var resources = await ListResources<BrandListResponse<ListBrands>>("10dlc/Brand", null);
            resources.Brands.ForEach(
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
        /// <param name="brand_alias">brand_alias.</param>
        /// <param name="profile_uuid">profile_uuid.</param>
        /// <param name="brand_type">brand_type.</param>
        /// <param name="secondary_vetting">secondary_vetting.</param>

        public BrandCreateResponse Create(string brand_alias, string profile_uuid, string brand_type, bool secondary_vetting)
        {
        var mandatoryParams = new List<string>{"brand_alias", "profile_uuid"};
        var data = CreateData(
            mandatoryParams,
            new
            {
                brand_alias,
                profile_uuid,
                brand_type,
                secondary_vetting
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
        /// <param name="brand_alias">brand_alias.</param>
        /// <param name="profile_uuid">profile_uuid.</param>
        /// <param name="brand_type">brand_type.</param>
        /// <param name="secondary_vetting">secondary_vetting.</param>
		public async Task<BrandCreateResponse> CreateAsync(string brand_alias, string profile_uuid, string brand_type, bool secondary_vetting)
		{

			 var mandatoryParams = new List<string>{"brand_alias", "profile_uuid"};
        var data = CreateData(
            mandatoryParams,
            new
            {
                brand_alias,
                profile_uuid,
                brand_type,
                secondary_vetting
            });

			var result = await Client.Update<BrandCreateResponse>(Uri + "10dlc/Brand/", data);
            result.Object.StatusCode = result.StatusCode;
			return result.Object;
		}
		#endregion
    }
}