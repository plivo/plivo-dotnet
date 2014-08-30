namespace Plivo.Models
{
    public class CDR
    {
        public int BillDuration { get; set; }
        public string TotalAmount { get; set; }
        public string ParentCallUuid { get; set; }
        public string CallDirection { get; set; }
        public string ToNumber { get; set; }
        public string TotalRate { get; set; }
        public string FromNumber { get; set; }
        public string EndTime { get; set; }
        public string CallUuid { get; set; }
        public string ResourceUri { get; set; }
        public string Error { get; set; }
        public string ApiId { get; set; }
    }
}