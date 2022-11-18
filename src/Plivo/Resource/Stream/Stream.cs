namespace Plivo.Resource.Stream
{
    public class Stream : SecondaryResource
    {
        public new string Id => CallUuid;
        public string AudioTrack { get; set; }
        public bool Bidirectional { get; set; }
        public string BilledAmount { get; set; }
        public uint? BilledDuration { get; set; }
        public string CallUuid { get; set; }
        public string CreatedAt { get; set; }
        public string EndTime { get; set; }
        public string PlivoAuthId { get; set; }
        public string ResourceUri { get; set; }
        public string ServiceUrl { get; set; }
        public string StartTime { get; set; }
        public string Status { get; set; }
        public string StatusCallbackUrl { get; set; }
        public string StreamId { get; set; }
        
        public override string ToString()
        {
            return
                "ApiId: " + ApiId + "\n" +
                "AudioTrack: " + AudioTrack + "\n" +
                "Bidirectional: " + Bidirectional + "\n" +
                "BilledAmount: " + BilledAmount + "\n" +
                "BilledDuration: " + BilledDuration + "\n" +
                "CallUuid: " + CallUuid + "\n" +
                "CreatedAt: " + CreatedAt + "\n" +
                "PlivoAuthId: " + PlivoAuthId + "\n" +
                "ResourceUri: " + ResourceUri + "\n" +
                "ServiceUrl: " + ServiceUrl + "\n" +
                "EndTime: " + EndTime + "\n" +
                "StartTime: " + StartTime + "\n" +
                "Status: " + Status + "\n" +
                "StatusCallbackUrl: " + StatusCallbackUrl + "\n" +
                "StreamId: " + StreamId + "\n";
        }
    }
}