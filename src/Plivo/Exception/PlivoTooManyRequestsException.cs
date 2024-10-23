namespace Plivo.Exception
{
    public class PlivoTooManyRequestsException : PlivoRestException
    {
        public PlivoTooManyRequestsException(string message, uint statusCode = 429) : base(message, statusCode)
        {
        }
    }
}