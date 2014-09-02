using System.Collections.Generic;

namespace Plivo.Objects
{
    public class NumberList
    {
        public NumberMeta Meta { get; set; }
        public string ApiId { get; set; }
        public string Error { get; set; }
        public List<Number> Objects { get; set; }

        public NumberList()
        {
            Objects = new List<Number>();
        }
    }
}