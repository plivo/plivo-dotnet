using System;

namespace Plivo.Resource.TollfreeVerification
{  
    /// <summary>
    /// TollfreeVerification.
    /// </summary>
    public class TollfreeVerification : Resource
    {
        public string Uuid { get; set; }
        public string ProfileUUID { get; set; }
        public string Number { get; set; }
        public string Usecase { get; set; }
        public string UsecaseSummary { get; set; }
        public string MessageSample { get; set; }
        public string OptinImageUrl { get; set; }
        public string OptinType { get; set; }
        public string Volume { get; set; }
        public string AdditionalInformation { get; set; }
        public string ExtraData { get; set; }
        public string CallbackUrl { get; set; }
        public string CallbackMethod { get; set; }
        public string Status { get; set; }
        public string RejectionReason { get; set; }
        public DateTime CreatedAt { get; set; }

        public TollfreeVerification()
        {
            
        }
    }
}