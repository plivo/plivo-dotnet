namespace Plivo.Exception
{
    public class PlivoRequestException : PlivoRestException
    {
        public PlivoRequestException(string message, uint statusCode = 405) : base(message, statusCode)
        {
        }
    }
}