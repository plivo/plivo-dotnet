using System.Collections.Generic;

namespace Plivo.Resource.Call {
    public class QueuedCallListResponse {
        public uint StatusCode { get; set; }
        public string ApiId { get; set; }
        public List<string> Calls { get; set; }

        public override string ToString () {
            return base.ToString () +
                "StatusCode: " + StatusCode + "\n" +
                "ApiId:" + ApiId + "\n" +
                "Calls:" + string.Join (",\n", Calls) + "\n";
        }
    }
}