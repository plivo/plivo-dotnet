namespace Plivo.Resource.Call
{
    /// <summary>
    /// Live call.
    /// </summary>
    public class LiveCall : Resource
    {
        public string Direction { get; set; }
        public string From { get; set; }
        public string CallStatus { get; set; }
        public string To { get; set; }
        public string CallerName { get; set; }
        public string CallUuid { get; set; }
        public string RequestUuid { get; set; }
        public string SessionStart { get; set; }
    }
}