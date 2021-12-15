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
        public Campaign Get(string campaignID)
        {
			return ExecuteWithExceptionUnwrap(() =>
			{
				var response = Task.Run(async () => await GetResource<Campaign>("10dlc/Campaign/"+campaignID).ConfigureAwait(false)).Result;
				return response;
			});
        }
        /// <summary>
        /// Asynchronously get Campaign with the specified campaignID.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="campaign_id"> campaignID.</param>
        public async Task<Campaign> GetAsync(string campaignID)
        {
            var response = await GetResource<Campaign>("10dlc/Campaign/"+campaignID);
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
        public ListResponse<Campaigns> List()
        {
            // var mandatoryParams = new List<string> {""};
            // var data = CreateData(
            //     mandatoryParams,
            //     new
            //     {
            //         brand,
            //         usecase
            //     });

			return ExecuteWithExceptionUnwrap(() =>
			{
				var resources = Task.Run(async () => await ListResources<ListResponse<Campaigns>>("10dlc/Campaign/",null).ConfigureAwait(false)).Result;
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
        /// <param name="brand">brand.</param>
        /// <param name="usecase">status.</param>
        public async Task<ListResponse<Campaigns>> ListAsync()
        {
           
            var resources = await ListResources<ListResponse<Campaigns>>("10dlc/Campaign", null);
            resources.Objects.ForEach(
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

        public Campaign Create(string brand_id, string vertical, string campaign_alias, string usecase, string[] sub_usecases,
            string description, bool embedded_link,  bool embedded_phone, bool age_gated,
            bool direct_lending, bool subscriber_optin, bool subscriber_optout, bool subscriber_help, string sample1, string sample2)
        {
        var mandatoryParams = new List<string>{"brand_id", "vertical"};
        var data = CreateData(
            mandatoryParams,
            new
            {
                brand_id,
                vertical,
                campaign_alias,
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
				var result = Task.Run(async () => await Client.Update<Campaign>(Uri + "10dlc/Campaign/", data).ConfigureAwait(false)).Result;
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
		public async Task<Campaign> CreateAsync(string brand_id, string vertical, string campaign_alias, string usecase, string[] sub_usecases,
            string description, bool embedded_link,  bool embedded_phone, bool age_gated,
            bool direct_lending, bool subscriber_optin, bool subscriber_optout, bool subscriber_help, string sample1, string sample2)
		{

			 var mandatoryParams = new List<string>{"city", "vertical"};
        var data = CreateData(
            mandatoryParams,
            new
            {
                 brand_id,
                vertical,
                campaign_alias,
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

			var result = await Client.Update<Campaign>(Uri + "10dlc/Campaign/", data);
            result.Object.StatusCode = result.StatusCode;
			return result.Object;
		}
		#endregion
    }
}