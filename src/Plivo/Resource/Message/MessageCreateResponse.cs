using System.Collections.Generic;

namespace Plivo.Resource.Message
{
    public class MessageCreateResponse : CreateResponse
    {
        public List<string> MessageUuid { get; set; }
        public string Username { get; set; }
        public string Alias { get; set; }
        public List<string> invalid_number {get; set;}

        public override string ToString()
        {
           //Added logic to catch Invalid Numbers in BULK SMS
          if (invalid_number != null){
            return base.ToString() +
                   "Message Uuid: " + string.Join(",", MessageUuid) + "\n" +
                   "invalid_number: " + string.Join(",", invalid_number)+ "\n" +
                   "Username: " + Username + "\n" +
                   "Alias: " + Alias + "\n";
          }
          else
          {
            return base.ToString() +
                   "Message Uuid: " + string.Join(",", MessageUuid) + "\n" +
                   "Username: " + Username + "\n" +
                   "Alias: " + Alias + "\n";
          }
                   
        }
    }
}