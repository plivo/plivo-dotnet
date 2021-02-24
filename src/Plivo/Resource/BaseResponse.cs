using Newtonsoft.Json;

namespace Plivo.Resource
{
    /// <summary>
    /// Base response.
    /// </summary>
    public class BaseResponse
    {
        [JsonProperty("status_code")]
        public uint StatusCode { get; set; }
        /// <summary>
        /// Gets or sets the API identifier.
        /// </summary>
        /// <value>The API identifier.</value>
        [JsonProperty("api_id")]
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
                   "Message: " + Message + "\n" +
                   "StatusCode: "+StatusCode + "\n";
        }
    }
}