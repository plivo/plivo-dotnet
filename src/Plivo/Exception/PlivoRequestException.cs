namespace Plivo.Exception
{
    public class PlivoRequestException : PlivoRestException
    {
        public PlivoRequestException(string message) : base(message)
        {
        }
    }
}