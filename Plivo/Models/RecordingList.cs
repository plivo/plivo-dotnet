using System.Collections.Generic;

namespace Plivo
{
    public class RecordingList
    {
        public RecordingMeta meta { get; set; }
        public string error { get; set; }
        public string api_id { get; set; }
        public List<Recording> objects { get; set; }
    }
}