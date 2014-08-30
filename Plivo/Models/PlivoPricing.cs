namespace Plivo
{
    public class PlivoPricing
    {
        public string country_code { get; set; }
        public string country_iso { get; set; }
        public string country { get; set; }
        public PhoneNumbers phone_numbers { get; set; }
        public VoiceRates voice { get; set; }
        public SmsRates message { get; set; }
        public string api_id { get; set; }
    }
}