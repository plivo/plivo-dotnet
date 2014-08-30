using System.Collections.Generic;

namespace Plivo
{
    public class MessageList
    {
        public MessageMeta meta { get; set; }
        public string api_id { get; set; }
        public List<Message> objects { get; set; }
    }
}