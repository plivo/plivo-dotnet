using System;
using Newtonsoft.Json;

namespace Plivo.Resource.PhoneNumber
{
    public class Requirement
    {
        public string Business { get; set; }
        public string Individual { get; set; }

        public override string ToString()
        {
            return "Individual: " + Individual + "\n" +
            "Business: " + Business + "\n" ;
        }
    }
}