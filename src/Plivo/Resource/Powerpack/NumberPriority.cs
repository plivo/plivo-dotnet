
using Plivo.Client;

using System;
using System.Collections.Generic;
namespace Plivo.Resource.Powerpack
{
    /// <summary>
    /// Numberpool.
    /// </summary>
    public class NumberPriority : Resource
    {
        public string service_type { get; set; }
        public string country_iso { get; set; }
        public  Priority priority  { get; set; }

        public override string ToString()
        {
            return "\n" +
                "CountryISO: " + country_iso + "\n" +
                "ServiceType: " + service_type + "\n" +
                "Priority: " + priority + "\n" ;
        }
    }
}
