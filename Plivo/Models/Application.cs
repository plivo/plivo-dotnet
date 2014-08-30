namespace Plivo
{
    public class Application
    {
        public string FallbackMethod { get; set; }
        public bool default_app { get; set; }
        public string app_name { get; set; }
        public string sub_account { get; set; }
        public bool enabled { get; set; }
        public bool production_app { get; set; }
        public string app_id { get; set; }
        public bool public_uri { get; set; }
        public string hangup_url { get; set; }
        public string sip_uri { get; set; }
        public string answer_url { get; set; }
        public string message_url { get; set; }
        public string resource_uri { get; set; }
        public string hangup_method { get; set; }
        public string message_method { get; set; }
        public string fallback_answer_url { get; set; }
        public string answer_method { get; set; }
    }
}