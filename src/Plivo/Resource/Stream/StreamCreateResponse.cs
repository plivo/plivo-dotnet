namespace Plivo.Resource.Call
{
    public class StreamCreateResponse : CreateResponse
    {
        
        public string StreamId { get; set; }
        
        public uint StautsCode { get; set; }
        
        public override string ToString()
        {
            return base.ToString() +
                   "StreamId: " + StreamId + "\n";
        }
    }
}