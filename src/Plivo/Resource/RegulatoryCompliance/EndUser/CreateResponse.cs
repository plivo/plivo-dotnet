namespace Plivo.Resource.RegulatoryCompliance.EndUser
{
    public class CreateResponse
    {
        public new string ApiId { get; set; }
        public string CreatedAt { get; set; }
        public string EndUserId { get; set; }
        public string EndUserType { get; set; }
        public string LastName { get; set; }
        public new string Message { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return "ApiId: " + ApiId + "\n" +
                   "CreatedAt: " + CreatedAt + "\n" +
                   "EndUserId: " + EndUserId + "\n" +
                   "EndUserType: " + EndUserType + "\n" +
                   "LastName: " + LastName + "\n" +
                   "Message: " + Message + "\n" +
                   "Name: " + Name + "\n";
        }
    }
}