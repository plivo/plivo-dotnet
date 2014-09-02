using System.Collections.Generic;

namespace Plivo.Objects
{
    public class RecordingList
    {
        public RecordingMeta Meta { get; set; }
        public string Error { get; set; }
        public string ApiId { get; set; }
        public List<Recording> Objects { get; set; }

        public RecordingList()
        {
            Objects = new List<Recording>();
        }
    }
}