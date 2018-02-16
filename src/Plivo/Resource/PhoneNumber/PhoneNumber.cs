using System.Collections.Generic;

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

        /// <summary>
        /// Buy PhoneNumber and associate it with
        /// application whose Id id appId.
        /// </summary>
        /// <returns>The buy.</returns>
        /// <param name="appId">App identifier.</param>
        public PhoneNumberBuyResponse Buy(string appId = null)
        {
            return ((PhoneNumberInterface) Interface).Buy(Id, appId);
        }
    }
}