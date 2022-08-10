namespace Plivo.Resource.Token
{
    public class TokenCreateResponse : CreateResponse
    {
		public string token;
		public string app_id;

        public override string ToString()
        {
            return base.ToString() +
						"token=" + token + "\n" +
						"app_id=" + app_id + "\n";
        }
    }
}