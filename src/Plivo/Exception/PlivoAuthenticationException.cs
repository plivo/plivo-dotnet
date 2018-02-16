namespace Plivo.Exception
{
    public class PlivoAuthenticationException : PlivoRestException
    {
        public PlivoAuthenticationException(string message) : base(message)
        {
        }
    }
}