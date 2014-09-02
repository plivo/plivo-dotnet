namespace Plivo.Objects
{
    public class InboundVoicePricing
    {
        public SipInboundPricing Ip { get; set; }
        public LocalInboundPricing Local { get; set; }
        public TollfreeInboundPricing Tollfree { get; set; }
    }
}