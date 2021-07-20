using System.Collections.Generic;
using Newtonsoft.Json.Linq;
namespace Plivo.Resource.MultiPartyCall
{
    public class Call
    {
        public string To { get; set; }
        public string From { get; set; }
        public string CallUuid { get; set; }
    }
    public class MultiPartyCallAddParticipantResponse : CreateResponse
    {
        /// <summary>
        /// Gets or sets the app identifier.
        /// </summary>
        /// <value>The app identifier.</value>
        public List<Call> Calls { get; set; }
        public string RequestUuid { get; set; }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:plivo.Resource.Application.ApplicationCreateResponse"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:plivo.Resource.Application.ApplicationCreateResponse"/>.</returns>
        public override string ToString()
        {
            return "ApiId: " + ApiId + "\n" +
                   "Calls: " + Calls + "\n" +  
                   "Message: " + Message + "\n" +
                   "RequestUuid: " + RequestUuid + "\n";
        }
    }
}