namespace Plivo.Exception
{
    public class PlivoRestException : System.Exception
    {
        public uint StatusCode { get; set; }

        public PlivoRestException(string message, uint statusCode) : base(message)
        {
            this.StatusCode = statusCode;
        }
    }
}