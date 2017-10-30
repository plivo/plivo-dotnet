namespace Plivo.Resource.Subaccount
{
    public class SubaccountCreateResponse : CreateResponse
    {
        public string AuthId { get; set; }
        public string AuthToken { get; set; }

        public override string ToString()
        {
            return base.ToString() +
                   "Auth Id: " + AuthId + "\n" +
                   "Auth Token: " + AuthToken + "\n";
        }
    }
}
