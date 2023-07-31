using System.Collections.Generic;

namespace Plivo.Resource.PhoneNumber
{
    public class PhoneNumberBuyResponse : BaseResponse
    {
        public List<Phone> Numbers { get; set; }
        public string Status { get; set; }

        public override string ToString()
        {
            return "Status:" + Status +"\n"+"[Numbers]\n" + string.Join("\n", Numbers)+"\n"+"StatusCode:" + StatusCode + "\n";
        }

    }

    public class Phone
    {
        public string Number { get; set; }
        public string Status { get; set; }
        public string NewCnam { get; set; }
        public string CnamUpdateStatus { get; set; }

        public override string ToString()
        {
            if (NewCnam != "") {
               return "Number:" + Number + "\n" + "Status:" + Status + "\n" + "NewCnam:" + NewCnam + "\n" +"CnamUpdateStatus:" + CnamUpdateStatus + "\n";
            }
            return "Number:" + Number + "\n" + "Status:" + Status + "\n";
        }
                
    }
}