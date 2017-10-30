namespace Plivo.Exception
{
    /// <summary>
    /// Plivo response exception.
    /// </summary>
    public class PlivoResponseException : PlivoRestException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:plivo.Exception.PlivoResponseException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        public PlivoResponseException(string message) : base(message)
        {
        }
    }
}
