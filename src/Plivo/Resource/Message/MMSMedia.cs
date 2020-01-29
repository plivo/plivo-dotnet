namespace Plivo.Resource.Message
{
    /// <summary>
    /// Message.
    /// </summary>
    public class MMSMedia : Resource
    {
        public new string Id => MessageUuid;

        public string ContentType { get; set; }

        public string MediaId { get; set; }

        public string MediaUrl { get; set; }

        public string MessageUuid { get; set; }

        public int Size { get; set; }

    
        public override string ToString()
        {
            return "\n" +
                    "ContentType: " + ContentType + "\n" +
                    "MediaId: " + MediaId + "\n" +
                    "MediaUrl: " + MediaUrl + "\n" +
                    "MessageUuid: " + MessageUuid + "\n" +
                    "Size: " + Size + "\n" ;
        }
    }
}