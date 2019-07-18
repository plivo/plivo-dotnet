namespace Plivo.Exception
{
    public class PlivoNotFoundException : PlivoRestException
    {
        public PlivoNotFoundException(string message, uint statusCode = 404) : base(message, statusCode)
        {
            
        }
    }
}