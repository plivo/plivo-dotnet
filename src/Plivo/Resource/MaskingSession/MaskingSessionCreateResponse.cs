
namespace Plivo.Resource.MaskingSession
{
    public class MaskingSessionCreateResponse : CreateResponse
    {
        public string SessionUuid { get; set; }
        public string VirtualNumber { get; set; }
        public string SessionMessage { get; set; }
        public string Session { get; set; }

        public override string ToString()
        {
            return base.ToString() +
                   "Session Uuid: " + SessionUuid + "\n" +
                   "VirtualNumber: " + VirtualNumber + "\n" +
                   "Message: " + SessionMessage + "\n" +
                   "Session: " + Session + "\n";
        }
    }
}