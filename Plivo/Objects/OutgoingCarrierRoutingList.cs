using System.Collections.Generic;

namespace Plivo.Objects
{
    public class OutgoingCarrierRoutingList
    {
        public ResourceListMeta Meta { get; set; }
        public string ApiId { get; set; }
        public string Error { get; set; }
        public List<OutgoingCarrierRouting> Objects { get; set; }

        public OutgoingCarrierRoutingList()
        {
            Objects = new List<OutgoingCarrierRouting>();
        }
    }
}