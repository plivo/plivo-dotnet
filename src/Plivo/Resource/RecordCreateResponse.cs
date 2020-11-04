namespace Plivo.Resource
{
    public class RecordCreateResponse<T> : UpdateResponse<T>
    {
        public string RecordingUrl { get; set; }
        public string Url { get; set; }
        public string RecordingId { get; set; }
        
        public override string ToString()
        {
            return base.ToString() +
                   "RecordingId: " + RecordingId + "\n" +  
                   "RecordingUrl: " + RecordingUrl + "\n";
        }
    }
}