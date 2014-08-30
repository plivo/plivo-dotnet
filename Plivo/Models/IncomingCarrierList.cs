using System.Collections.Generic;

namespace Plivo
{
    public class IncomingCarrierList
    {
        public IncomingCarrierMeta meta { get; set; }
        public string api_id { get; set; }
        public string error { get; set; }
        public List<IncomingCarrier> objects { get; set; }
    }
}