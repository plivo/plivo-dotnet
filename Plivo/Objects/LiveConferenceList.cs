using System.Collections.Generic;

namespace Plivo.Objects
{
    public class LiveConferenceList
    {
        public string Error { get; set; }
        public string ApiId { get; set; }
        public List<string> Conferences { get; set; }
    }
}