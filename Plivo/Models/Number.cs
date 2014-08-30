using System;

namespace Plivo
{
    public class Number
    {
        public string region { get; set; }
        public bool voice_enabled { get; set; }
        public bool sms_enabled { get; set; }
        public bool fax_enabled { get; set; }
        public string number { get; set; }
        public string api_id { get; set; }
        public string voice_rate { get; set; }
        public string application { get; set; }
        public string sms_rate { get; set; }
        public string number_type { get; set; }
        public string sub_account { get; set; }
        public string added_on { get; set; }
        public string resource_uri { get; set; }
        public string group_id { get; set; }
        public string prefix { get; set; }
        public string rental_rate { get; set; }
        public string setup_rate { get; set; }
        public int stock { get; set; }
        [Obsolete]
        public string country { get; set; }
        [Obsolete]
        public int lata { get; set; }
        [Obsolete("Use the attribute rental_rate instead")]
        public string monthly_rental_rate { get; set; }
    }
}