using System;
namespace Plivo.Resource.RentedNumber
{
    public class VerificationInfo
    {
        public string Type { get; set; }
        public string Id { get; set; }

        public override string ToString()
        {
            return 
            "Type: " + Type +
            "Id: " + Id;
        }
    }
}
