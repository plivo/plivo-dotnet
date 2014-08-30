using System.Collections.Generic;

namespace Plivo
{
    public class OutgoingCarrierRoutingList
    {
        public ResourceListMeta meta { get; set; }
        public string api_id { get; set; }
        public string error { get; set; }
        public List<OutgoingCarrierRouting> objects { get; set; }
    }
}