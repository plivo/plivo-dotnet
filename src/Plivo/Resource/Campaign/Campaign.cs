using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Plivo.Client;

namespace Plivo.Resource.Campaign
{
    /// <summary>
    /// Campaign.
    /// </summary>
    public class CampaignResponse : Resource
    {

        public string brand_id { get; set; }
        public string campaign_id { get; set; }
        public MnoMetaData mno_metadata { get; set; }
        public string reseller_id { get; set; }
        public string usecase { get; set; }        
    }
    public class MnoMetaData : Resource{
        public TPMDetail at_t { get; set; }
        public TPMDetail t_mobile { get; set; }
        public TPMDetail us_cellular { get; set; }
        public TPMDetail verizon_wireless { get; set; }
    }
    public class TPMDetail :Resource{
        public string tpm { get; set; }
        public string brand_tier { get; set; }
    }
    public class Campaign: Resource
    {   public string api_id {get; set;}
        public CampaignResponse campaign {get; set;}
    }

    public class Campaigns: Resource
    {   public string api_id {get; set;}
        public CampaignResponse campaigns {get; set;}
    }

}