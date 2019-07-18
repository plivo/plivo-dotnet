using System.Collections.Generic;

namespace Plivo.Resource.Message
{
    public class MessageCreateResponse : CreateResponse
    {
        public List<string> MessageUuid { get; set; }
        public string Username { get; set; }
        public string Alias { get; set; }


        public override string ToString()
        {
            return base.ToString() +
                   "Message Uuid: " + string.Join(",", MessageUuid) +
                   "Username: " + Username + "\n" +
                   "Alias: " + Alias + "\n";
                   
        }
    }
}