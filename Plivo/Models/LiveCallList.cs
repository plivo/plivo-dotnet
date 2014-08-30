using System.Collections.Generic;

namespace Plivo
{
    public class LiveCallList
    {
        public string api_id { get; set; }
        public List<string> calls { get; set; }
        public string error { get; set; }
    }
}