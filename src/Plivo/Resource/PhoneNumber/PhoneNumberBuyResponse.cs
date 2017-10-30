using System.Collections.Generic;

namespace Plivo.Resource.PhoneNumber
{
    public class PhoneNumberBuyResponse : BaseResponse
    {
        public List<Phone> Numbers { get; set; }
        public string Status { get; set; }
    }
    
    public class Phone
    {
        public string Number { get; set; }
        public string Status { get; set; }
    }
}
