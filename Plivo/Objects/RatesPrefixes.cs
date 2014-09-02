using System.Collections.Generic;

namespace Plivo.Objects
{
    public class RatesPrefixes
    {
        public string Rate { get; set; }
        public List<string> Prefix { get; set; }

        public RatesPrefixes()
        {
            Prefix = new List<string>();
        }
    }
}