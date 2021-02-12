namespace Plivo.Resource.RegulatoryComplianceEndUser
{
    public class RegulatoryComplianceEndUser : Resource
    {
        public new string Id => EndUserId;
        public string EndUserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string EndUserType { get; set; }

        public override string ToString()
        {
            return
                "EndUserId: " + EndUserId + "\n" +
                "Name: " + Name + "\n" +
                "LastName: " + LastName + "\n" +
                "EndUserType: " + EndUserType + "\n";
        }
    }
}