using System.Collections.Generic;

namespace Plivo.Resource.Call
{
    public class QueuedCallListResponse
    {
        public string ApiId { get; set; }
        public List<string> Calls { get; set; }
    }
}