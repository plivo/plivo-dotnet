namespace Plivo.Exception
{
    public class PlivoXMLException : PlivoRestException
    {
        public PlivoXMLException(string message, uint statusCode = 400) : base(message, statusCode)
        {
        }
    }
}