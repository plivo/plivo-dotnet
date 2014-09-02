using System.Collections.Generic;

namespace Plivo.Objects
{
    public class OutboundVoicePricing
    {
        public SipOutboundPricing Ip { get; set; }
        public LocalOutboundPricing Local { get; set; }
        public TollfreeOutboundPricing Tollfree { get; set; }
        public List<RatesPrefixes> Rates { get; set; }

        public OutboundVoicePricing()
        {
            Rates = new List<RatesPrefixes>();
        }
    }
}