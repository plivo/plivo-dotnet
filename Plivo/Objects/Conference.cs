using System.Collections.Generic;

namespace Plivo.Objects
{
    public class Conference
    {
        public string Error { get; set; }
        public string ApiId { get; set; }
        public string ConferenceMemberCount { get; set; }
        public string ConferenceName { get; set; }
        public string ConferenceRunTime { get; set; }
        public List<ConferenceMember> Members { get; set; }
    }
}