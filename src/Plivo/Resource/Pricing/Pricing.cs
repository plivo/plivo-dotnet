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

        public override string ToString()
        {
            return "StatusCode: " + StatusCode + "\n" +
                "Country: " + Country + "\n" +
                "CountryCode: " + CountryCode + "\n" +
                "CountryIso: " + CountryIso + "\n" +
                "\n" +
                "Message: " + Message + "\n" +
                "\n" +
                "PhoneNumbers: " + PhoneNumbers + "\n" +
                "Voice: " + Voice + "\n";
        }

    }

    public class Inbound
    {
        public string Rate { get; set; }

        public override string ToString()
        {
            return "\n" +
            "Inbound: " +""+
            "Rate: " + Rate;
        }

    }

    public class Outbound
    {
        public string Rate { get; set; }
        public override string ToString()
        {
            return "outbound: " + "" + "Rate: " + Rate + "\n";
        }
    }

    public class OutboundNetworksList
    {
        public string GroupName { get; set; }
        public string Rate { get; set; }

        public override string ToString()
        {
            return 
                "GroupName: " + GroupName + "" +
                "Rate: " + Rate + "";
        }
    }

    public class Message
    {
        public Inbound Inbound { get; set; }
        public Outbound Outbound { get; set; }
        public List<OutboundNetworksList> OutboundNetworksList { get; set; }

        public override string ToString()
        {
            return 
                Inbound + "\n" +
                Outbound + "\n" +
                "[OutboundNetworkList]\n" + string.Join("\n", OutboundNetworksList);
        }
    }

    public class Local
    {
        public string Rate { get; set; }

        public override string ToString()
        {
            return "Rate: " + Rate + "\n";
        }
    }

    public class Tollfree
    {
        public string Rate { get; set; }

        public override string ToString()
        {
            return "Rate: " + Rate + "\n";
        }
    }

    public class PhoneNumbers
    {
        public Local Local { get; set; }
        public Tollfree Tollfree { get; set; }

        public override string ToString()
        {
            return  "\n" +
            "TollFree: " + Tollfree + "" + "Local: " + Local;
        }
    }

    public class Ip
    {
        public string Rate { get; set; }

        public override string ToString()
        {
            return "Ip: " +""+
                "Rate: " + Rate + "\n";
        }
    }

    public class Inbound2
    {
        public Ip Ip { get; set; }
        public Local Local { get; set; }
        public Tollfree Tollfree { get; set; }

        public override string ToString()
        {
            return "\n"+""+ Ip + "" +
                "Local" + Local + ""+
                "TollFree" + Tollfree + "";
        }
    }

    public class RateClass
    {
        public List<string> Prefix { get; set; }
        public List<string> OriginationPrefix { get; set; }
        public string Rate { get; set; }

        public override string ToString()
        {
            return "RateClass" + "" +
                "Rate: " + Rate + "";
        }

    }

    public class Outbound2
    {
        public Ip Ip { get; set; }
        public Local Local { get; set; }
        public List<RateClass> Rates { get; set; }
        public Tollfree Tollfree { get; set; }

        public override string ToString()
        {
            return Ip + "\n" + Local + "" + Tollfree + "\n"+
            "[RateClass]\n" + string.Join("\n", Rates);
        }

    }

    public class Voice
    {
        public Inbound2 Inbound { get; set; }
        public Outbound2 Outbound { get; set; }

        public override string ToString()
        {
            return  Inbound + "\n" + Outbound + "\n";
        }
    }
}