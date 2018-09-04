namespace Plivo.Resource.Call
{
    /// <summary>
    /// Queued call.
    /// </summary>
    public class QueuedCall : Resource
    {
        public string Direction { get; set; }
        public string From { get; set; }
        public string CallStatus { get; set; }
        public string To { get; set; }
        public string CallerName { get; set; }
        public string CallUuid { get; set; }
        public string APIId { get; set; }
    }
}