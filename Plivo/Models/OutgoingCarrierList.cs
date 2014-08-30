using System.Collections.Generic;

namespace Plivo
{
    public class OutgoingCarrierList
    {
        public OutgoingCarrierMeta meta { get; set; }
        public string api_id { get; set; }
        public string error { get; set; }
        public List<OutgoingCarrier> objects { get; set; }
    }
}