namespace Plivo.Objects
{
    public class ResourceListMeta
    {
        public object Previous { get; set; }
        public int TotalCount { get; set; }
        public int Offset { get; set; }
        public int Limit { get; set; }
        public string Next { get; set; }
    }
}