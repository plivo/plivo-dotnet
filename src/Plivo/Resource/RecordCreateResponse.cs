namespace Plivo.Resource
{
    public class RecordCreateResponse<T> : UpdateResponse<T>
    {
        public string Url { get; set; }
        public string RecordingId { get; set; }
    }
}