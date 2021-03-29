using System;
using Newtonsoft.Json;

namespace Plivo.Resource.PhoneNumber
{
    public class Requirement
    {
        public string Individual { get; set; }
        public string Business { get; set; }

        public override string ToString()
        {
            var individual =  "Individual: " + Individual + "\n" ;
            var business = "Business: " + Business + "\n" ;

            return "{\n" + individual + business + "}";

        }
    }
}