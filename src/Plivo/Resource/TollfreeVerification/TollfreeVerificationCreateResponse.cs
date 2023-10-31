namespace Plivo.Resource.TollfreeVerification
{
    public class TollfreeVerificationCreateResponse : CreateResponse
    {
        /// <summary>
        /// Gets or sets the request uuid.
        /// </summary>
        /// <value>The tollfree verification request identifier.</value>
        public string Uuid { get; set; }
        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:plivo.Resource.TollfreeVerification.TollfreeVerificationCreateResponse"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:plivo.Resource.TollfreeVerification.TollfreeVerificationCreateResponse"/>.</returns>
        public override string ToString()
        {
            return base.ToString() +
                   "UUID: " + Uuid + "\n";
        }
    }
}