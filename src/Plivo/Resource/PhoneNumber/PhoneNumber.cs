using System.Collections.Generic;
using System.Threading.Tasks;

namespace Plivo.Resource.PhoneNumber
{
    public class PhoneNumber : Resource
    {
        public new string Id => Number;
        public string Country { get; set; }
        public uint Lata { get; set; }
        public string MonthlyRentalRate { get; set; }
        public string Number { get; set; }
        public string Type { get; set; }
        public string Prefix { get; set; }
        public string RateCenter { get; set; }
        public string Region { get; set; }
        public string ResourceUri { get; set; }
        public object Restriction { get; set; }
        public object RestrictionText { get; set; }
        public string SetupRate { get; set; }
        public bool SmsEnabled { get; set; }
        public string SmsRate { get; set; }
        public bool VoiceEnabled { get; set; }
        public string VoiceRate { get; set; }
        public List<Prerequisite> Prerequisites { get; set; }
        public string City { get; set; }

        public bool MmsEnabled { get; set; }
        public string MmsRate { get; set; }

        public Requirement ComplianceRequirement { get; set; }

        public override string ToString()
        {
            return 
                "Country: " + Country + "\n" +
                "Lata: " + Lata + "\n" +
                "MonthlyRentalRate: " + MonthlyRentalRate + "\n" +
                "Number: " + Number + "\n" +
                "Type: " + Type + "\n" +
                "Prefix: " + Prefix + "\n" +
                "RateCenter:" + RateCenter + "\n" +
                "Region: " + Region + "\n" +
                "ResourceUri: " + ResourceUri + "\n" +
                "Restriction: " + Restriction + "\n" +
                "RestrictionText: " + RestrictionText + "\n" +
                "SetupRate: " + SetupRate + "\n" +
                "SmsEnabled: " + SmsEnabled + "\n" +
                "SmsRate: " + SmsRate + "\n" +
                "VoiceEnabled: " + VoiceEnabled + "\n" +
                "VoiceRate: " + VoiceRate + "\n" +
                "City: " + City + "\n" + 
                "MmsEnabled: " + MmsEnabled + "\n" +
                "MmsRate: " + MmsRate + "\n" +
                "ComplianceRequirement: " + ComplianceRequirement + "\n" +
                "Prerequisites: " + Prerequisites + "\n";
                
        }

        #region Buy
        /// <summary>
        /// Buy PhoneNumber and associate it with
        /// application whose Id id appId.
        /// </summary>
        /// <returns>The buy.</returns>
        /// <param name="appId">App identifier.</param>
        /// <param name="cnamLookup">CnamLookup.</param>
        /// <param name="haEnabled">HA Enabled.</param>
        public PhoneNumberBuyResponse Buy(string appId = null, string cnamLookup = null, bool? haEnabled = null)
        {
            return ((PhoneNumberInterface) Interface).Buy(Id, appId, cnamLookup, null, haEnabled);
        }
        /// <summary>
        /// Asynchronously buy PhoneNumber and associate it with
        /// application whose Id id appId.
        /// </summary>
        /// <returns>The buy.</returns>
        /// <param name="appId">App identifier.</param>
        /// <param name="cnamLookup">Cnam Lookup</param>
        /// <param name="haEnabled">HA Enabled.</param>
        public async Task<PhoneNumberBuyResponse> BuyAsync(string appId = null, string cnamLookup = null, bool? haEnabled = null)
        {
            return await ((PhoneNumberInterface)Interface).BuyAsync(Id, appId, cnamLookup, null, haEnabled);
        }
        #endregion
    }
}