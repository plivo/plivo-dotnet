using System.Collections.Generic;

namespace Plivo.Resource.Pricing
{
    public class Pricing : Resource
    {
        public new string Id => CountryIso;
        public string Country { get; set; }
        public uint CountryCode { get; set; }
        public string CountryIso { get; set; }
        public Message Message { get; set; }
        public PhoneNumbers PhoneNumbers { get; set; }
        public Voice Voice { get; set; }
    }
    
    public class Inbound
    {
        public string Rate { get; set; }
    }

    public class Outbound
    {
        public string Rate { get; set; }
    }

    public class OutboundNetworksList
    {
        public string GroupName { get; set; }
        public string Rate { get; set; }
    }

    public class Message
    {
        public Inbound Inbound { get; set; }
        public Outbound Outbound { get; set; }
        public List<OutboundNetworksList> OutboundNetworksList { get; set; }
    }

    public class Local
    {
        public string Rate { get; set; }
    }

    public class Tollfree
    {
        public string Rate { get; set; }
    }

    public class PhoneNumbers
    {
        public Local Local { get; set; }
        public Tollfree Tollfree { get; set; }
    }

    public class Ip
    {
        public string Rate { get; set; }
    }

    public class Inbound2
    {
        public Ip Ip { get; set; }
        public Local Local { get; set; }
        public Tollfree Tollfree { get; set; }
    }

    public class RateClass
    {
        public List<string> Prefix { get; set; }
        public string Rate { get; set; }
    }

    public class Outbound2
    {
        public Ip Ip { get; set; }
        public Local Local { get; set; }
        public List<RateClass> Rates { get; set; }
        public Tollfree Tollfree { get; set; }
    }

    public class Voice
    {
        public Inbound2 Inbound { get; set; }
        public Outbound2 Outbound { get; set; }
    }
}
