using System.Collections.Generic;

namespace Plivo.Objects
{
    public class EndpointList
    {
        public EndpointMeta Meta { get; set; }
        public string Error { get; set; }
        public string ApiId { get; set; }
        public List<Endpoint> Objects { get; set; }

        public EndpointList()
        {
            Objects = new List<Endpoint>();
        }
    }
}