using System.Collections.Generic;

namespace Plivo
{
    public class NumberResponse
    {
        public List<NumberStatus> numbers { get; set; }
        public string status { get; set; }
    }
}