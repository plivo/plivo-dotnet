using System.Collections.Generic;

namespace Plivo.Objects
{
    public class IncomingCarrierList
    {
        public IncomingCarrierMeta Meta { get; set; }
        public string ApiId { get; set; }
        public string Error { get; set; }
        public List<IncomingCarrier> Objects { get; set; }

        public IncomingCarrierList()
        {
            Objects = new List<IncomingCarrier>();
        }
    }
}