namespace Plivo
{
    public class LiveCall
    {
        public string direction { get; set; }
        public string from { get; set; }
        public string call_status { get; set; }
        public string api_id { get; set; }
        public string to { get; set; }
        public string caller_name { get; set; }
        public string call_uuid { get; set; }
        public string session_start { get; set; }
        public string error { get; set; }
    }
}