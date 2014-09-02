namespace Plivo.Objects
{
    public class OutgoingCarrier
    {
        public string CarrierId { get; set; }
        public string Ips { get; set; }
        public string Prefix { get; set; }
        public string FailoverPrefix { get; set; }
        public string Address { get; set; }
        public string FailoverAddress { get; set; }
        public string Enabled { get; set; }
        public string Retries { get; set; }
        public string ResourceUri { get; set; }
    }
}