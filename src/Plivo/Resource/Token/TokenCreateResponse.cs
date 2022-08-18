namespace Plivo.Resource.Token
{
    public class TokenCreateResponse : CreateResponse
    {
		public string token { get; set; }

		public override string ToString()
        {
            return base.ToString() +
						"token=" + token + "\n" +
						"api_id=" + ApiId + "\n";
        }
    }
}