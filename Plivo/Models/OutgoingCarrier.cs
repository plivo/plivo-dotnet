namespace Plivo
{
    public class OutgoingCarrier
    {
        public string carrier_id { get; set; }
        public string ips { get; set; }
        public string prefix { get; set; }
        public string failover_prefix { get; set; }
        public string address { get; set; }
        public string failover_address { get; set; }
        public string enabled { get; set; }
        public string retries { get; set; }
        public string resource_uri { get; set; }
    }
}