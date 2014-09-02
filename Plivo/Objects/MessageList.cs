using System.Collections.Generic;

namespace Plivo.Objects
{
    public class MessageList
    {
        public MessageMeta Meta { get; set; }
        public string ApiId { get; set; }
        public List<Message> Objects { get; set; }

        public MessageList()
        {
            Objects = new List<Message>();
        }
    }
}