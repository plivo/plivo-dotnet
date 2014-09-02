namespace Plivo.Objects
{
    public class PlivoPricing
    {
        public string CountryCode { get; set; }
        public string CountryIso { get; set; }
        public string Country { get; set; }
        public PhoneNumbers PhoneNumbers { get; set; }
        public VoiceRates Voice { get; set; }
        public SmsRates Message { get; set; }
        public string ApiId { get; set; }
    }
}