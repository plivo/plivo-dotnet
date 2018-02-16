namespace Plivo.Exception
{
    public class PlivoNotFoundException : PlivoRestException
    {
        public PlivoNotFoundException(string message) : base(message)
        {
        }
    }
}