using System.Collections.Generic;

namespace Plivo
{
    public class EndpointList
    {
        public EndpointMeta meta { get; set; }
        public string error { get; set; }
        public string api_id { get; set; }
        public List<Endpoint> objects { get; set; }
    }
}