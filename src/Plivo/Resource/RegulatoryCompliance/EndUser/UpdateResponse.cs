namespace Plivo.Resource.RegulatoryCompliance.EndUser
{
    public class UpdateResponse
    {
        public string ApiId { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return "ApiId: " + ApiId + "\n" +
                   "Message: " + Message + "\n";
        }
    }
}