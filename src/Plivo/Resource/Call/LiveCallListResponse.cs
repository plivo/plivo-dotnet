using System.Collections.Generic;

namespace Plivo.Resource.Call {
    public class LiveCallListResponse {
        public string ApiId { get; set; }
        public List<string> Calls { get; set; }

        public uint StatusCode { get; set; }

        public override string ToString () {
            return base.ToString () + "\n" +
                "StatusCode: " + StatusCode + "\n" +
                "ApiId:" + ApiId + "\n" +
                "Calls:" + string.Join (",\n", Calls) + "\n";
        }
    }
}