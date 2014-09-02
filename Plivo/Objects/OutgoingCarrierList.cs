using System.Collections.Generic;

namespace Plivo.Objects
{
    public class OutgoingCarrierList
    {
        public OutgoingCarrierMeta Meta { get; set; }
        public string ApiId { get; set; }
        public string Error { get; set; }
        public List<OutgoingCarrier> Objects { get; set; }

        public OutgoingCarrierList()
        {
            Objects = new List<OutgoingCarrier>();
        }
    }
}