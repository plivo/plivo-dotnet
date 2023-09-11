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
        /// <param name="campaign_source">campaign_source</param>
        public CampaignListResponse<ListCampaigns> List(uint? limit = null, uint? offset = null, string campaign_source="plivo")
        {
            var mandatoryParams = new List<string> {""};
            var data = CreateData(
                mandatoryParams,
                new
                {
                    limit,
                    offset,
                    campaign_source
                });

			return ExecuteWithExceptionUnwrap(() =>
			{
				var resources = Task.Run(async () => await ListResources<CampaignListResponse<ListCampaigns>>("10dlc/Campaign",data).ConfigureAwait(false)).Result;
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
        /// <param name="campaign_source">campaign_source</param>
        public async Task<CampaignListResponse<ListCampaigns>> ListAsync(uint? limit = null, uint? offset = null, string campaign_source="plivo")
        {
            var mandatoryParams = new List<string> {""};
            var data = CreateData(
                mandatoryParams,
                new
                {
                    limit,
                    offset,
                    campaign_source
                });

            var resources = await ListResources<CampaignListResponse<ListCampaigns>>("10dlc/Campaign", data);
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
        /// <param name="affiliate_marketing">affiliate_marketing</param>
        /// <param name="sample1">sample1</param>
        /// <param name="sample2">sample1</param>
        ///<param name="message_flow">message_flow<param>
        ///<param name="help_message">help_message<param>
        ///<param name="optout_message">optout_message<param>
        ///<param name="optin_keywords">optin_keywords<param>
        ///<param name="optin_message">optin_message<param>
        ///<param name="optout_keywords">optout_keywords<param>
         ///<param name="help_keywords">optout_keywords<param>
        public CreateCampaign Create(string campaign_alias,string brand_id, string vertical,  string usecase, 
            string description, bool embedded_link,  bool embedded_phone, bool age_gated,
            bool direct_lending, bool subscriber_optin, bool subscriber_optout, bool subscriber_help, 
            bool affiliate_marketing, string sample1, string sample2, string message_flow, string help_message, string optout_message, string[] sub_usecases= null, string url=null, string method=null,string optin_keywords=null,string optin_message=null,string optout_keywords=null,string help_keywords=null)
        {
        var mandatoryParams = new List<string>{"brand_id", "vertical"};
        var data = CreateData(
            mandatoryParams,
            new
            {   
                campaign_alias,
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
                affiliate_marketing,
                sample1,
                sample2,
                url,
                method,
                message_flow,
                help_message,
                optout_message,
                optin_keywords,
                optin_message,
                optout_keywords,
                help_keywords
            });
		return ExecuteWithExceptionUnwrap(() =>
		{
				var result = Task.Run(async () => await Client.Update<CreateCampaign>(Uri + "10dlc/Campaign/", data).ConfigureAwait(false)).Result;
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
        /// <param name="affiliate_marketing">affiliate_marketing</param>
        /// <param name="sample1">sample1</param>
        /// <param name="sample2">sample1</param>
        ///<param name="message_flow">message_flow<param>
        ///<param name="help_message">help_message<param>
        ///<param name="optout_message">optout_message<param>
         ///<param name="optin_keywords">optin_keywords<param>
        ///<param name="optin_message">optin_message<param>
        ///<param name="optout_keywords">optout_keywords<param>
         ///<param name="help_keywords">optout_keywords<param>
		public async Task<CreateCampaign> CreateAsync(string campaign_alias, string brand_id, string vertical, string usecase,
            string description, bool embedded_link,  bool embedded_phone, bool age_gated,
            bool direct_lending, bool subscriber_optin, bool subscriber_optout, bool subscriber_help, 
            bool affiliate_marketing, string sample1, string sample2, string message_flow, string help_message, string optout_message, string[] sub_usecases= null, string url=null, string method=null, string optin_keywords=null,string optin_message=null,string optout_keywords=null,string help_keywords=null)
		{

			 var mandatoryParams = new List<string>{"city", "vertical"};
        var data = CreateData(
            mandatoryParams,
            new
            {
                campaign_alias,
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
                affiliate_marketing,
                sample1,
                sample2,
                url,
                method,
                message_flow,
                help_message,
                optout_message,
                optin_keywords,
                optin_message,
                optout_keywords,
                help_keywords,
            });

			var result = await Client.Update<CreateCampaign>(Uri + "10dlc/Campaign/", data);
            result.Object.StatusCode = result.StatusCode;
			return result.Object;
		}
		#endregion

        #region Update
        /// <summary>
        /// Update Campaign with the specified sample, keyword etc.
        /// </summary>
        /// <returns>The update.</returns>
        /// <param name="campaign_id">campaign_id</param>
        /// <param name="reseller_id">reseller_id</param>
        /// <param name="description">description</param>
        /// <param name="sample1">sample1</param>
        /// <param name="sample2">sample2</param>
        ///<param name="message_flow">message_flow<param>
        ///<param name="help_message">help_message<param>
        ///<param name="optin_keywords">optin_keywords<param>
        ///<param name="optin_message">optin_message<param>
        ///<param name="optout_keywords">optout_keywords<param>
        ///<param name="optout_message">optout_message<param>
         ///<param name="help_keywords">help_keywords<param>
        public UpdateCampaign Update(string campaign_id,string reseller_id="", string description="",  string sample1="", 
            string sample2="", string message_flow="", string help_message="", string optin_keywords="", string optin_message="", 
            string optout_keywords="", string optout_message="", string help_keywords="")
        {
            var mandatoryParams = new List<string>{};
            var data = CreateData(
                mandatoryParams,
                new
                {   
                    reseller_id,
                    description,
                    sample1,
                    sample2,
                    message_flow,
                    help_message,
                    optin_keywords,
                    optin_message,
                    optout_keywords,
                    optout_message,
                    help_keywords,
                    
                });
            return ExecuteWithExceptionUnwrap(() =>
            {
                    var result = Task.Run(async () => await Client.Update<UpdateCampaign>(Uri + "10dlc/Campaign/"+campaign_id+"/", data).ConfigureAwait(false)).Result;
                    result.Object.StatusCode = result.StatusCode;
                    return result.Object;
            });
        }

		/// <summary>
        /// Update Campaign with the specified sample, keyword etc.
        /// </summary>
        /// <returns>The update.</returns>
        /// <param name="campaign_id">campaign_id</param>
        /// <param name="reseller_id">reseller_id</param>
        /// <param name="description">description</param>
        /// <param name="sample1">sample1</param>
        /// <param name="sample2">sample2</param>
        ///<param name="message_flow">message_flow<param>
        ///<param name="help_message">help_message<param>
        ///<param name="optin_keywords">optin_keywords<param>
        ///<param name="optin_message">optin_message<param>
        ///<param name="optout_keywords">optout_keywords<param>
        ///<param name="optout_message">optout_message<param>
        ///<param name="help_keywords">help_keywords<param>
		public async Task<UpdateCampaign> UpdateAsync(string campaign_id,string reseller_id="", string description="",  string sample1="", 
            string sample2="", string message_flow="", string help_message="", string optin_keywords="", string optin_message="", 
            string optout_keywords="", string optout_message="", string help_keywords="")
		{

			var mandatoryParams = new List<string>{};
            var data = CreateData(
                mandatoryParams,
                new
                {   
                    reseller_id,
                    description,
                    sample1,
                    sample2,
                    message_flow,
                    help_message,
                    optin_keywords,
                    optin_message,
                    optout_keywords,
                    optout_message,
                    help_keywords,
                    
                });

			var result = await Client.Update<UpdateCampaign>(Uri + "10dlc/Campaign/"+campaign_id+"/", data);
            result.Object.StatusCode = result.StatusCode;
			return result.Object;
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
				var response = Task.Run(async () => await GetResource<Number>("10dlc/Campaign/"+campaignID+"/Number/"+number).ConfigureAwait(false)).Result;
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
            var response = await GetResource<Number>("10dlc/Campaign/"+campaignID+"/Number/"+number);
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
				var response = Task.Run(async () => await GetResource<Number>("10dlc/Campaign/"+campaignID+"/Number").ConfigureAwait(false)).Result;
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
            var response = await GetResource<Number>("10dlc/Campaign/"+campaignID+"/Number");
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

        public LinkNumber LinkNumber(string campaignId, List<string> numbers,  string url=null, string method=null)
        {
        var mandatoryParams = new List<string> { "" };
        var data = CreateData(
            mandatoryParams,
            new
            {
                numbers,
                url,
                method
            });
		return ExecuteWithExceptionUnwrap(() =>
		{
				var result = Task.Run(async () => await Client.Update<LinkNumber>(Uri + "10dlc/Campaign/"+campaignId+"/Number/", data).ConfigureAwait(false)).Result;
				result.Object.StatusCode = result.StatusCode;
                return result.Object;
		});
        }

		 /// <summary>
       /// </summary>
        /// <returns>The create.</returns>
        /// <param name="campaignId">campaignId.</param>
        /// <param name="numbers">numbers.</param>
		public async Task<LinkNumber> LinkNumberAsync(string campaignId, List<string> numbers, string url=null, string method=null)
		{

			var mandatoryParams = new List<string>{ "" };
            var data = CreateData(
                mandatoryParams,
                new
                {
                    numbers,
                    url,
                    method
            });

			var result = await Client.Update<LinkNumber>(Uri + "10dlc/Campaign/"+campaignId+"/Number/", data);
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
        public DeleteResponse<DeleteNumber> UnlinkNumber(string campaignId, string number, string url = null, string method = null)
        {
            var mandatoryParams = new List<string>{""};
            var data = CreateData(
                mandatoryParams,
                new
                {
                    url,
                    method
                });
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
        public async Task<DeleteResponse<DeleteNumber>> UnlinkNumberNumberAsync(string campaignId, string number, string url = null, string method = null)
        {
            var mandatoryParams = new List<string>{""};
            var data = CreateData(
                mandatoryParams,
                new
                {
                    url,
                    method
                });
            return await DeleteResource<DeleteResponse<DeleteNumber>>("10dlc/Campaign/"+campaignId+"/Number/"+number, data);
        }
        #endregion
        #region Delete
         /// <summary>
        /// Delete Campaign with the specified uuid.
        /// </summary>
        /// <returns>message</returns>
        /// <param name="campaign_id">campaignID.</param>
        public DeleteResponse<DeleteCampaign> Delete(string campaignID)
        {
			return ExecuteWithExceptionUnwrap(() =>
			{
				var response = Task.Run(async () => await DeleteResource<DeleteResponse<DeleteCampaign>>("10dlc/Campaign/"+campaignID).ConfigureAwait(false)).Result;
				return response;
			});
        }
        /// <summary>
        /// Asynchronously delete Campaign with the specified campaignID.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="campaign_id"> campaignID.</param>
        public async Task<DeleteResponse<DeleteCampaign>> DeleteAsync(string campaignID)
        {
            var response = await DeleteResource<DeleteResponse<DeleteCampaign>>("10dlc/Campaign/"+campaignID);
            return response;
        }
        #endregion
    }
}