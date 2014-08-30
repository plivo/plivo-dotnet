namespace Plivo
{
    public class ConferenceMember
    {
        public string call_uuid { get; set; }
        public string caller_name { get; set; }
        public bool deaf { get; set; }
        public string direction { get; set; }
        public string from { get; set; }
        public string join_time { get; set; }
        public string member_id { get; set; }
        public bool muted { get; set; }
        public string to { get; set; }
    }
}