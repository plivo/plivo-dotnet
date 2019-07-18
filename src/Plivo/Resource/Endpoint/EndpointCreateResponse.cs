namespace Plivo.Resource.Endpoint
{
    public class EndpointCreateResponse : CreateResponse
    {
        public string EndpointId { get; set; }
        public string Username { get; set; }
        public string Alias { get; set; }

        public override string ToString()
        {
            return base.ToString() +
                   "Endpoint Id: " + EndpointId + "\n" +
                   "Username: " + Username + "\n" +
                   "Alias: " + Alias + "\n";
        }
    }
}