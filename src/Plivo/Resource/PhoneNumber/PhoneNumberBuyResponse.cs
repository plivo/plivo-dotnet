using System.Collections.Generic;

namespace Plivo.Resource.PhoneNumber
{
    public class PhoneNumberBuyResponse : BaseResponse
    {
        public List<Phone> Numbers { get; set; }
        public string Status { get; set; }

        public override string ToString()
        {
            return "StatusCode:" + Status +"\n"+"[Numbers]\n" + string.Join("\n", Numbers)+"\n"+"StatusCode:" + StatusCode + "\n";
        }

    }

    public class Phone
    {
        public string Number { get; set; }
        public string Status { get; set; }
        public string FallbackNumber { get; set; }

        public override string ToString()
        {
            return "Number:" + Number + "\n" +
                   "FallbackNumber:" + FallbackNumber + "\n";
        }

    }
}