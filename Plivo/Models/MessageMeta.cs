namespace Plivo
{
    public class MessageMeta
    {
        public string previous { get; set; }
        public int total_count { get; set; }
        public int offset { get; set; }
        public int limit { get; set; }
        public string next { get; set; }
    }
}