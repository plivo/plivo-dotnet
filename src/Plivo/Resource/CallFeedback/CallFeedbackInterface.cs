using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Plivo.Client;

namespace Plivo.Resource.CallFeedback {
    /// <summary>
    /// CallFeedback interface.
    /// </summary>

    public class CallFeedbackInterface : ResourceInterface {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:plivo.Resource.Call.CallFeedbackInterface"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        public CallFeedbackInterface (HttpClient client) : base (client) {
            Uri = "Call/";
        }

        #region Create
        /// <summary>
        /// Create Call Feedback with the specified callUUID, rating, issues and notes
        /// </summary>
        /// <returns>The create.</returns>
        /// <param name="callUUID">Call UUID.</param>
        /// <param name="rating">Rating.</param>
        /// <param name="issues">Issues.</param>
        /// <param name="notes">Notes.</param>
        
        public CallFeedbackCreateResponse Create (string callUUID, float rating, List<string> issues = null, string notes = null) 
            {
            var mandatoryParams = new List<string> { "callUUID"};
            Uri += callUUID + "/Feedback/";
            bool isCallInsightsRequest = true;
            var data = CreateData(
                mandatoryParams,
                new 
                {
                    callUUID,
                    rating,
                    issues,
                    notes,
                    isCallInsightsRequest
                });

            return ExecuteWithExceptionUnwrap(() => 
            {
                var result = Task.Run (async () => await Client.Update<CallFeedbackCreateResponse> (Uri, data).ConfigureAwait (false)).Result;
                result.Object.StatusCode = result.StatusCode;
                return result.Object;
            });
        }
        #endregion
    }
}