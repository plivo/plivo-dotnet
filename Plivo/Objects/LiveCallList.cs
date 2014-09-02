using System.Collections.Generic;

namespace Plivo.Objects
{
    public class LiveCallList
    {
        public string ApiId { get; set; }
        public List<string> Calls { get; set; }
        public string Error { get; set; }

        public LiveCallList()
        {
            Calls = new List<string>();
        }
    }
}