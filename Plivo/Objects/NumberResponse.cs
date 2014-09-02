using System.Collections.Generic;

namespace Plivo.Objects
{
    public class NumberResponse
    {
        public List<NumberStatus> Numbers { get; set; }
        public string Status { get; set; }

        public NumberResponse()
        {
            Numbers = new List<NumberStatus>();
        }
    }
}