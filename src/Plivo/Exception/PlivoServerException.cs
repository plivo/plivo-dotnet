namespace Plivo.Exception
{
    public class PlivoServerException : PlivoRestException
    {
        public PlivoServerException(string message) : base(message)
        {
        }
    }
}
