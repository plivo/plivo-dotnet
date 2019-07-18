namespace Plivo.Resource.Application
{
    public class ApplicationCreateResponse : CreateResponse
    {
        /// <summary>
        /// Gets or sets the app identifier.
        /// </summary>
        /// <value>The app identifier.</value>
        public string AppId { get; set; }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:plivo.Resource.Application.ApplicationCreateResponse"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:plivo.Resource.Application.ApplicationCreateResponse"/>.</returns>
        public override string ToString()
        {
            return base.ToString() +
                   "App Id: " + AppId + "\n";
        }
    }
}