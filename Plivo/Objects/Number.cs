using System;

namespace Plivo.Objects
{
    public class Number
    {
        public string Region { get; set; }
        public bool VoiceEnabled { get; set; }
        public bool SmsEnabled { get; set; }
        public bool FaxEnabled { get; set; }
        public string Value { get; set; }
        public string ApiId { get; set; }
        public string VoiceRate { get; set; }
        public string Application { get; set; }
        public string SmsRate { get; set; }
        public string NumberType { get; set; }
        public string SubAccount { get; set; }
        public string AddedOn { get; set; }
        public string ResourceUri { get; set; }
        public string GroupId { get; set; }
        public string Prefix { get; set; }
        public string RentalRate { get; set; }
        public string SetupRate { get; set; }
        public int Stock { get; set; }
        [Obsolete]
        public string Country { get; set; }
        [Obsolete]
        public int Lata { get; set; }
        [Obsolete("Use the attribute rental_rate instead")]
        public string MonthlyRentalRate { get; set; }
    }
}