using System.Collections.Generic;

namespace Plivo
{
    public class LiveConferenceList
    {
        public string error { get; set; }
        public string api_id { get; set; }
        public List<string> conferences { get; set; }
    }
}