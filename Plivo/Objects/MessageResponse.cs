using System.Collections.Generic;

namespace Plivo.Objects
{
    public class MessageResponse
    {
        public string Message { get; set; }
        public List<string> MessageUuid { get; set; }
        public string Error { get; set; }
        public string ApiId { get; set; }

        public MessageResponse()
        {
            MessageUuid = new List<string>();
        }
    }
}