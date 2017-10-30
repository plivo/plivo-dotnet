namespace Plivo.Exception
{
    public class PlivoValidationException : PlivoRestException
    {
        public PlivoValidationException(string message) : base(message)
        {
        }
    }
}
