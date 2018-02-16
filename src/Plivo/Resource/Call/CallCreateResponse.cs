namespace Plivo.Resource.Call
{
    public class CallCreateResponse : CreateResponse
    {
        public string RequestUuid { get; set; }

        public override string ToString()
        {
            return base.ToString() +
                   "Request Uuid: " + RequestUuid + "\n";
        }
    }
}