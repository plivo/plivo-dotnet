namespace Plivo.Exception
{
    public class PlivoValidationException : PlivoRestException
    {
        public PlivoValidationException(string message, uint statusCode = 400) : base(message, statusCode)
        {
        }
    }
}