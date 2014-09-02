using System.Collections.Generic;

namespace Plivo.Objects
{
    public class ApplicationList
    {
        public ApplicationMeta Meta { get; set; }
        public string Error { get; set; }
        public string ApiId { get; set; }
        public List<Application> Objects { get; set; }

        public ApplicationList()
        {
            Objects = new List<Application>();
        }
    }
}