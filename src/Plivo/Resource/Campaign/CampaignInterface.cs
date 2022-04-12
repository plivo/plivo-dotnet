using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Plivo.Client;

namespace Plivo.Resource.Campaign
{
    /// <summary>
    /// Campaign interface.
    /// </summary>
    public class CampaignInterface : ResourceInterface
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:plivo.Resource.Campaign.CampaignInterface"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        public CampaignInterface(HttpClient client) : base(client)
        {
            Uri = "Account/" + Client.GetAuthId() + "/";
        }

        #region GET
         /// <summary>
        /// Get Campaign with the specified uuid.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="campaign_id">campaignID.</param>
        public GetCampaign Get(string campaignID)
        {
			return ExecuteWithExceptionUnwrap(() =>
			{
				var response = Task.Run(async () => await GetResource<GetCampaign>("10dlc/Campaign/"+campaignID).ConfigureAwait(false)).Result;
				return response;
			});
        }
        /// <summary>
        /// Asynchronously get Campaign with the specified campaignID.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="campaign_id"> campaignID.</param>
        public async Task<GetCampaign> GetAsync(string campaignID)
        {
            var response = await GetResource<GetCampaign>("10dlc/Campaign/"+campaignID);
            return response;
        }
        #endregion
        #region List
        /// <summary>
        /// <summary>
        /// List campaign list type and status.
        /// </summary>
        /// <returns>The list.</returns>
        /// <param name="brand">brand.</param>
        /// <param name="usecase">usecase.</param>
        public CampaignListResponse<ListCampaigns> List()
        {
			return ExecuteWithExceptionUnwrap(() =>
			{
				var resources = Task.Run(async () => await ListResources<CampaignListResponse<ListCampaigns>>("10dlc/Campaign",null).ConfigureAwait(false)).Result;
                resources.Campaigns.ForEach(
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
        public async Task<CampaignListResponse<ListCampaigns>> ListAsync()
        {
           
            var resources = await ListResources<CampaignListResponse<ListCampaigns>>("10dlc/Campaign", null);
            resources.Campaigns.ForEach(
					(obj) => obj.Interface = this
				);
            return resources;
        }
        #endregion
        #region Create
        /// <summary>
        /// Create Campaign with the specified vertical, city, ein etc.
        /// </summary>
        /// <returns>The create.</returns>
        /// <param name="brand_id">City.</param>
        /// <param name="vertical">vertical.</param>
        /// <param name="campaign_alias">campaign_alias.</param>
        /// <param name="usecase">usecase.</param>
        /// <param name="sub_usecases">sub_usecases.</param>
        /// <param name="description">description</param>
        /// <param name="embedded_link">embedded_link</param>
        /// <param name="embedded_phone">embedded_phone</param>
        /// <param name="age_gated">age_gated</param>
        /// <param name="direct_lending">direct_lending</param>
        /// <param name="subscriber_optin">subscriber_optin</param>
        /// <param name="subscriber_optout">subscriber_optout</param>
        /// <param name="subscriber_help">subscriber_help</param>
        /// <param name="sample1">sample1</param>
        /// <param name="sample2">sample1</param>

        public GetCampaign Create(string brand_id, string vertical,  string usecase, 
            string description, bool embedded_link,  bool embedded_phone, bool age_gated,
            bool direct_lending, bool subscriber_optin, bool subscriber_optout, bool subscriber_help, string sample1, string sample2, string[] sub_usecases= null)
        {
        var mandatoryParams = new List<string>{"brand_id", "vertical"};
        var data = CreateData(
            mandatoryParams,
            new
            {
                brand_id,
                vertical,
                usecase,
                sub_usecases,
                description,
                embedded_link,
                embedded_phone,
                age_gated,
                direct_lending,
                subscriber_optin,
                subscriber_optout,
                subscriber_help,
                sample1,
                sample2
            });
		return ExecuteWithExceptionUnwrap(() =>
		{
				var result = Task.Run(async () => await Client.Update<GetCampaign>(Uri + "10dlc/Campaign/", data).ConfigureAwait(false)).Result;
				result.Object.StatusCode = result.StatusCode;
                return result.Object;
		});
        }

		 /// <summary>
        /// Create Campaign .
       /// <returns>The create.</returns>
        /// <param name="brand_id">City.</param>
        /// <param name="vertical">vertical.</param>
        /// <param name="campaign_alias">campaign_alias.</param>
        /// <param name="usecase">usecase.</param>
        /// <param name="sub_usecases">sub_usecases.</param>
        /// <param name="description">description</param>
        /// <param name="embedded_link">embedded_link</param>
        /// <param name="embedded_phone">embedded_phone</param>
        /// <param name="age_gated">age_gated</param>
        /// <param name="direct_lending">direct_lending</param>
        /// <param name="subscriber_optin">subscriber_optin</param>
        /// <param name="subscriber_optout">subscriber_optout</param>
        /// <param name="subscriber_help">subscriber_help</param>
        /// <param name="sample1">sample1</param>
        /// <param name="sample2">sample1</param>
		public async Task<GetCampaign> CreateAsync(string brand_id, string vertical, string usecase,
            string description, bool embedded_link,  bool embedded_phone, bool age_gated,
            bool direct_lending, bool subscriber_optin, bool subscriber_optout, bool subscriber_help, string sample1, string sample2,string[] sub_usecases= null)
		{

			 var mandatoryParams = new List<string>{"city", "vertical"};
        var data = CreateData(
            mandatoryParams,
            new
            {
                 brand_id,
                vertical,
                usecase,
                sub_usecases,
                description,
                embedded_link,
                embedded_phone,
                age_gated,
                direct_lending,
                subscriber_optin,
                subscriber_optout,
                subscriber_help,
                sample1,
                sample2
            });

			var result = await Client.Update<GetCampaign>(Uri + "10dlc/Campaign/", data);
            result.Object.StatusCode = result.StatusCode;
			return result.Object;
		}
		#endregion


        #region GET
         /// <summary>
        /// Get Campaign with the specified uuid.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="campaign_id">campaignID.</param>
        public GetCampaign Get(string campaignID)
        {
			return ExecuteWithExceptionUnwrap(() =>
			{
				var response = Task.Run(async () => await GetResource<GetCampaign>("10dlc/Campaign/"+campaignID).ConfigureAwait(false)).Result;
				return response;
			});
        }
        /// <summary>
        /// Asynchronously get Campaign with the specified campaignID.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="campaign_id"> campaignID.</param>
        public async Task<GetCampaign> GetAsync(string campaignID)
        {
            var response = await GetResource<GetCampaign>("10dlc/Campaign/"+campaignID);
            return response;
        }
        #endregion
        #region List
        /// <summary>
        /// <summary>
        /// List campaign list type and status.
        /// </summary>
        /// <returns>The list.</returns>
        /// <param name="brand">brand.</param>
        /// <param name="usecase">usecase.</param>
        public CampaignListResponse<ListCampaigns> List()
        {
			return ExecuteWithExceptionUnwrap(() =>
			{
				var resources = Task.Run(async () => await ListResources<CampaignListResponse<ListCampaigns>>("10dlc/Campaign",null).ConfigureAwait(false)).Result;
                resources.Campaigns.ForEach(
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
        public async Task<CampaignListResponse<ListCampaigns>> ListAsync()
        {
           
            var resources = await ListResources<CampaignListResponse<ListCampaigns>>("10dlc/Campaign", null);
            resources.Campaigns.ForEach(
					(obj) => obj.Interface = this
				);
            return resources;
        }
        #endregion
        #region GETNumber
         /// <summary>
        /// Get Campaign with the specified uuid.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="campaign_id">campaignID.</param>
        /// <param name="number">number.</param>
        public Number GetNumber(string campaignID, string number)
        {
			return ExecuteWithExceptionUnwrap(() =>
			{
				var response = Task.Run(async () => await GetResource<Number>("10dlc/Campaign/"+campaignID+"/Number/"+number+"/").ConfigureAwait(false)).Result;
				return response;
			});
        }
        /// <summary>
        /// Asynchronously get Campaign with the specified campaignID.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="campaign_id">campaignID.</param>
        /// <param name="number">number.</param>
        public async Task<Number> GetNumberAsync(string campaignID, string number)
        {
            var response = await GetResource<Number>("10dlc/Campaign/"+campaignID+"/Number/"+number+"/");
            return response;
        }
        #endregion

        #region ListNumber
         /// <summary>
        /// Get Campaign with the specified uuid.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="campaign_id">campaignID.</param>
        public Number ListNumber(string campaignID)
        {
			return ExecuteWithExceptionUnwrap(() =>
			{
				var response = Task.Run(async () => await GetResource<Number>("10dlc/Campaign/"+campaignID+"/Number/").ConfigureAwait(false)).Result;
				return response;
			});
        }
        /// <summary>
        /// Asynchronously get Campaign with the specified campaignID.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="campaign_id">campaignID.</param>
        /// <param name="number">number.</param>
        public async Task<Number> ListNumberAsync(string campaignID, string number)
        {
            var response = await GetResource<Number>("10dlc/Campaign/"+campaignID+"/Number/");
            return response;
        }
        #endregion

        #region linkNumber
        /// <summary>
        /// Link Number with the specified vertical, city, ein etc.
        /// </summary>
        /// <returns>The create.</returns>
        /// <param name="campaignId">campaignId.</param>
        /// <param name="numbers">numbers.</param>

        public LinkNumber LinkNumber(string campaignId, List<string> numbers)
        {
        var mandatoryParams = new List<string>{"numbers"};
        var data = CreateData(
            mandatoryParams,
            new
            {
                numbers
            });
		return ExecuteWithExceptionUnwrap(() =>
		{
				var result = Task.Run(async () => await Client.Update<LinkNumber>(Uri + "10dlc/Campaign/"+campaignId+"/", data).ConfigureAwait(false)).Result;
				result.Object.StatusCode = result.StatusCode;
                return result.Object;
		});
        }

		 /// <summary>
       /// </summary>
        /// <returns>The create.</returns>
        /// <param name="campaignId">campaignId.</param>
        /// <param name="numbers">numbers.</param>
		public async Task<LinkNumber> LinkNumberAsync(string campaignId, List<string> numbers)
		{

			 var mandatoryParams = new List<string>{"numbers"};
        var data = CreateData(
            mandatoryParams,
            new
            {
                numbers
            });

			var result = await Client.Update<LinkNumber>(Uri + "10dlc/Campaign/"+campaignId+"/", data);
            result.Object.StatusCode = result.StatusCode;
			return result.Object;
		}
        #endregion

        #region deleteNumber
       /// <summary>
        /// Delete Link Number .
        /// </summary>
        /// <returns>The delete.</returns>
        /// <param name="campaignId">campaignId.</param>
        /// <param name="number">Number.</param>
        public DeleteResponse<Application> DeleteNumber(string campaignId, string number)
        {
            data = CreateData(new List<string> {}, new {});
			return ExecuteWithExceptionUnwrap(() =>
			{
				return Task.Run(async () => await DeleteResource<DeleteResponse<DeleteNumber>>("10dlc/Campaign/"+campaignId+"/Number/"+number, data).ConfigureAwait(false)).Result;
			});
		}
        /// <summary>
        /// Delete Link Number .
        /// </summary>
        /// <returns>The delete.</returns>
        /// <param name="campaignId">campaignId.</param>
        /// <param name="number">Number.</param>
        public async Task<DeleteResponse<Application>> DeleteNumberAsync(string campaignId, string number)
        {
            var data = new Dictionary<string, object> { };
            return await DeleteResource<DeleteResponse<DeleteNumber>>("10dlc/Campaign/"+campaignId+"/Number/"+number, data);
        }
        #endregion
    }
}