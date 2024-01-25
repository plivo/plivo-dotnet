using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Plivo.Client;

namespace Plivo.Resource.Profile
{
    /// <summary>
    /// Profile interface.
    /// </summary>
    public class ProfileInterface : ResourceInterface
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:plivo.Resource.Profile.ProfileInterface"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        public ProfileInterface(HttpClient client) : base(client)
        {
            Uri = "Account/" + Client.GetAuthId() + "/";
        }

        #region GET
         /// <summary>
        /// Get Profile with the specified uuid.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="profileUuid">profileUuid.</param>
        public GetProfile Get(string profileUuid)
        {
			return ExecuteWithExceptionUnwrap(() =>
			{
				var response = Task.Run(async () => await GetResource<GetProfile>("Profile/"+profileUuid).ConfigureAwait(false)).Result;
                return response;
			});
        }
        /// <summary>
        /// Asynchronously get Profile with the specified profileUuid.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="profileUuid"> profileUuid.</param>
        public async Task<GetProfile> GetAsync(string profileUuid)
        {
            var response = await GetResource<GetProfile>("Profile/"+profileUuid);
            return response;
        }
        #endregion

        #region List
        /// <summary>
        /// <summary>
        /// List profile
        /// </summary>
        /// <returns>The list.</returns>
        /// <param name="limit">limit.</param>
        /// <param name="offset">offset.</param>
        public ProfileListResponse<ListProfiles> List(uint? limit = null,uint? offset = null,string type = null, string entity_type=null,string vertical=null)
        {
            var mandatoryParams = new List<string> { "" };
            var data = CreateData(
                mandatoryParams, new
                {
                    type,
                    entity_type,
                    vertical,
                    limit,
                    offset,
                });
			return ExecuteWithExceptionUnwrap(() =>
			{
				var resources = Task.Run(async () => await ListResources<ProfileListResponse<ListProfiles>>("Profile",data).ConfigureAwait(false)).Result;
                resources.Profiles.ForEach(
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
        /// <param name="brand">brand.</param>
        /// <param name="usecase">status.</param>
        public async Task<ProfileListResponse<ListProfiles>> ListAsync(uint? limit = null,uint? offset = null,string type = null, string entity_type=null,string vertical=null)
        {
           var mandatoryParams = new List<string> { "" };
            var data = CreateData(
                mandatoryParams, new
                {
                    type,
                    entity_type,
                    vertical,
                    limit,
                    offset,
                });
            var resources = await ListResources<ProfileListResponse<ListProfiles>>("Profile", data);
            resources.Profiles.ForEach(
					(obj) => obj.Interface = this
				);
            return resources;
        }
        #endregion

        #region Create
        /// <summary>
        /// Create Profile with the specified fields
        /// </summary>
        /// <returns>The create.</returns>
        /// <param name="profile_alias">profile_alias.</param>
        /// <param name="customer_type">customer_type.</param>
        /// <param name="entity_type">entity_type.</param>
        /// <param name="company_name">company_name.</param>
        /// <param name="ein">ein</param>
        /// <param name="vertical">vertical</param>
        /// <param name="ein_issuing_country">ein_issuing_country</param>
        /// <param name="stock_symbol">stock_symbol</param>
        /// <param name="stock_exchange">stock_exchange</param>
        /// <param name="alt_business_id">alt_business_id</param>
        /// <param name="alt_business_id_type">alt_business_id_type</param>
        /// <param name="authorized_contact">authorized_contact</param>
        /// <param name="address">address</param>

        public ProfileResponse Create(string profile_alias, string plivo_subaccount,  string customer_type, 
            string entity_type, string company_name,  string ein, string vertical,
            string ein_issuing_country, string stock_symbol, string stock_exchange, string website,string alt_business_id, string alt_business_id_type, AuthorizedContact authorized_contact, Address address)
        {
        var mandatoryParams = new List<string>{"profile_alias"};
        Console.WriteLine(entity_type);
        var data = CreateData(
            mandatoryParams,
            new
            {
                profile_alias,
                plivo_subaccount,
                customer_type,
                entity_type,
                company_name,
                ein,
                vertical,
                ein_issuing_country,
                stock_symbol,
                stock_exchange,
                alt_business_id,
                alt_business_id_type,
                authorized_contact,
                address,
                website
            });
		return ExecuteWithExceptionUnwrap(() =>
		{
				var result = Task.Run(async () => await Client.Update<ProfileResponse>(Uri + "Profile/", data).ConfigureAwait(false)).Result;
				result.Object.StatusCode = result.StatusCode;
                return result.Object;
		});
        }

		 /// <summary>
        /// Create Profile with the specified fields
        /// </summary>
        /// <returns>The create.</returns>
        /// <param name="profile_alias">profile_alias.</param>
        /// <param name="plivo_subaccount">plivo_subaccount.</param>
        /// <param name="customer_type">customer_type.</param>
        /// <param name="entity_type">entity_type.</param>
        /// <param name="company_name">company_name.</param>
        /// <param name="ein">ein</param>
        /// <param name="vertical">vertical</param>
        /// <param name="ein_issuing_country">ein_issuing_country</param>
        /// <param name="stock_symbol">stock_symbol</param>
        /// <param name="stock_exchange">stock_exchange</param>
        /// <param name="alt_business_id">alt_business_id</param>
        /// <param name="alt_business_id_type">alt_business_id_type</param>
        /// <param name="authorized_contact">authorized_contact</param>
        /// <param name="address">address</param>
		public async Task<ProfileResponse> CreateAsync(string profile_alias, string plivo_subaccount,  string customer_type, 
            string entity_type, string company_name,  string ein, string vertical, string website,
            string ein_issuing_country, string stock_symbol, string stock_exchange, string alt_business_id, string alt_business_id_type, AuthorizedContact authorized_contact, Address address)
		{
         var mandatoryParams = new List<string>{"profile_alias"};
          var data = CreateData(
            mandatoryParams,
            new
            {
                profile_alias,
                customer_type,
                entity_type,
                company_name,
                ein,
                vertical,
                ein_issuing_country,
                stock_symbol,
                stock_exchange,
                alt_business_id,
                alt_business_id_type,
                authorized_contact,
                address,
                website
            });
			var result = await Client.Update<ProfileResponse>(Uri + "Profile/", data);
            result.Object.StatusCode = result.StatusCode;
			return result.Object;
		}
		#endregion

        #region Update
        /// <summary>
        /// Update Profile with the specified fields
        /// </summary>
        /// <returns>The create.</returns>
        /// <param name="profile_uuid">profileUuid</param>
        /// <param name="company_name">company_name.</param>
        /// <param name="entity_type">entity_type.</param>
        /// <param name="website">website.</param>
        /// <param name="entity_type">entity_type.</param>
        /// <param name="vertical">vertical.</param>
        /// <param name="authorized_contact">authorized_contact</param>
        /// <param name="address">address</param>

        public GetProfile Update(string profile_uuid, string company_name =null,  string website = null, 
            string entity_type=null, string vertical= null,  AuthorizedContact authorized_contact=null, Address address=null)
        {
             var mandatoryParams = new List<string>{"profile_uuid"};
        var data = CreateData(
            mandatoryParams,
            new
            {
                company_name,
                website,
                entity_type,
                authorized_contact,
                address,
                vertical
            });
		return ExecuteWithExceptionUnwrap(() =>
		{
				var result = Task.Run(async () => await Client.Update<GetProfile>(Uri + "Profile/"+profile_uuid+"/", data).ConfigureAwait(false)).Result;
				result.Object.StatusCode = result.StatusCode;
                return result.Object;
		});
        }

		         /// <summary>
        /// Update Profile with the specified fields
        /// </summary>
        /// <returns>The create.</returns>
        /// <param name="profile_uuid">profileUuid</param>
        /// <param name="company_name">company_name.</param>
        /// <param name="entity_type">entity_type.</param>
        /// <param name="website">website.</param>
        /// <param name="entity_type">entity_type.</param>
        /// <param name="vertical">vertical.</param>
        /// <param name="authorized_contact">authorized_contact</param>
        /// <param name="address">address</param>
		public async Task<ProfileResponse> UpdateAsync(string profile_uuid, string company_name =null,  string website = null, 
            string entity_type=null, string vertical= null,  AuthorizedContact authorized_contact=null, Address address=null)
        {
             var mandatoryParams = new List<string>{"profile_uuid"};
        var data = CreateData(
            mandatoryParams,
            new
            {
                company_name,
                website,
                entity_type,
                authorized_contact,
                address,
                vertical
            });
			var result = await Client.Update<ProfileResponse>(Uri + "Profile/"+profile_uuid+"/", data);
            result.Object.StatusCode = result.StatusCode;
			return result.Object;
		}
		#endregion

        #region Delete
        /// <summary>
        ///  delete Profile with the specified profileuuid.
        /// </summary>
        /// <returns>The delete.</returns>
        /// <param name="uuid">profile identifier.</param>
         public DeleteResponse<ProfileDeleteResponse> Delete(string profileUuid)
        {
            var data = new Dictionary<string, object> { };
			return ExecuteWithExceptionUnwrap(() =>
			{
				return Task.Run(async () => await DeleteResource<DeleteResponse<ProfileDeleteResponse>>("Profile/"+profileUuid, data).ConfigureAwait(false)).Result;
			});
        }
        /// <summary>
        /// Asynchronously delete Profile with the specified profileuuid.
        /// </summary>
        /// <returns>The delete.</returns>
        /// <param name="profileID">profileUUId.</param>
        public async Task<DeleteResponse<ProfileDeleteResponse>> DeleteAsync(string profileUuid)
        {
            var data = new Dictionary<string, object> { };
            return await DeleteResource<DeleteResponse<ProfileDeleteResponse>>(profileUuid);
        }
        #endregion
    }
}