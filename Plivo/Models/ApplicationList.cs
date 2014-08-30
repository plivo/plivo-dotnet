using System.Collections.Generic;

namespace Plivo
{
    public class ApplicationList
    {
        public ApplicationMeta meta { get; set; }
        public string error { get; set; }
        public string api_id { get; set; }
        public List<Application> objects { get; set; }
    }
}