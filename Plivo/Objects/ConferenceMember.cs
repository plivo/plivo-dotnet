namespace Plivo.Objects
{
    public class ConferenceMember
    {
        public string CallUuid { get; set; }
        public string CallerName { get; set; }
        public bool Deaf { get; set; }
        public string Direction { get; set; }
        public string From { get; set; }
        public string JoinTime { get; set; }
        public string MemberId { get; set; }
        public bool Muted { get; set; }
        public string To { get; set; }
    }
}