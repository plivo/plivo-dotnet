namespace Plivo.Objects
{
    public class LiveCall
    {
        public string Direction { get; set; }
        public string From { get; set; }
        public string CallStatus { get; set; }
        public string ApiId { get; set; }
        public string To { get; set; }
        public string CallerName { get; set; }
        public string CallUuid { get; set; }
        public string SessionStart { get; set; }
        public string Error { get; set; }
    }
}