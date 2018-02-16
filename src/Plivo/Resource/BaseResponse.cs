namespace Plivo.Resource
{
    /// <summary>
    /// Base response.
    /// </summary>
    public class BaseResponse
    {
        /// <summary>
        /// Gets or sets the API identifier.
        /// </summary>
        /// <value>The API identifier.</value>
        public string ApiId { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        public string Message { get; set; }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:plivo.Resource.BaseResponse"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:plivo.Resource.BaseResponse"/>.</returns>
        public override string ToString()
        {
            return "Api Id: " + ApiId + "\n" +
                   "Message: " + Message + "\n";
        }
    }
}