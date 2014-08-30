using System.Collections.Generic;

namespace Plivo
{
    public class MessageResponse
    {
        public string message { get; set; }
        public List<string> message_uuid { get; set; }
        public string error { get; set; }
        public string api_id { get; set; }
    }
}