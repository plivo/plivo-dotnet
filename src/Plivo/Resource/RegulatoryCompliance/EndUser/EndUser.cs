namespace Plivo.Resource.RegulatoryCompliance.EndUser
{
    public class EndUser : Resource
    {
        public new string ApiId { get; set; }
        public string EndUserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string EndUserType { get; set; }
        public string CreatedAt { get; set; }

        public override string ToString()
        {
            var result = "EndUserId: " + EndUserId + "\n" +
                         "Name: " + Name + "\n" +
                         "LastName: " + LastName + "\n" +
                         "EndUserType: " + EndUserType + "\n" +
                         "CreatedAt: " + CreatedAt + "\n";
            return StatusCode != 0 ? "ApiId: " + ApiId + "\n" + result : result;
        }
    }
}