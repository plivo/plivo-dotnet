using System.Collections.Generic;

namespace Plivo.Resource.Call
{
    public class QueuedCallListResponse
    {
        public string ApiId { get; set; }
        public List<string> Calls { get; set; }

        public override string ToString()
        {
            return base.ToString() +
                       "ApiId: \n" + ApiId + "\n" +
                       "Calls: \n" + string.Join(",\n", Calls ) + "\n";
        }
    }
}