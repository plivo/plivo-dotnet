namespace Plivo.Resource.MultiPartyCall
{
    public class MultiPartyCallAddParticipantResponse : CreateResponse
    {
        /// <summary>
        /// Gets or sets the app identifier.
        /// </summary>
        /// <value>The app identifier.</value>
        public string ApiId { get; set; }

        public string Message { get; set; }
        public string RequestUuid { get; set; }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:plivo.Resource.Application.ApplicationCreateResponse"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:plivo.Resource.Application.ApplicationCreateResponse"/>.</returns>
        public override string ToString()
        {
            return "ApiId Id: " + ApiId + "\n" + "Message: " + Message + "\n" + "Request UUID: " + "\n" + RequestUuid + "\n";
        }
    }
}