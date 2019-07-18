namespace Plivo.Exception
{
    public class PlivoAuthenticationException : PlivoRestException
    {
        public PlivoAuthenticationException(string message, uint statusCode = 401) : base(message, statusCode)
        {
        }
    }
}