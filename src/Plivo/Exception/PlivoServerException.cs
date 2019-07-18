namespace Plivo.Exception
{
    public class PlivoServerException : PlivoRestException
    {
        public PlivoServerException(string message, uint statusCode = 500) : base(message, statusCode)
        {
        }
    }
}