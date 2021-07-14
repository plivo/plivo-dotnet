using System;
using System.Threading.Tasks;
using Plivo.Client;

namespace Plivo.Resource.MultiPartyCall
{
    public class MultiPartyCall : Resource
    {
        public string BilledAmount { get; set; }
        public uint? BilledDuration { get; set; }
        public string CreationTime { get; set; }
        public uint? Duration { get; set; }
        public string EndTime { get; set; }
        public string FriendlyName { get; set; }
        public string MpcUuid { get; set; }
        public string Participants { get; set; }
        public string Recording { get; set; }
        public string ResourceUri { get; set; }
        public string StartTime { get; set; }
        public string Status { get; set; }
        public bool StayAlone { get; set; }
        public string SubAccount { get; set; }
        public string TerminationCause { get; set; }
        public uint? TerminationCauseCode { get; set; }

        public override string ToString()
        {
            return "BilledAmount: " + BilledAmount + "\n" +
                   "BilledDuration: " + BilledDuration + "\n" +
                   "CreationTime: " + CreationTime + "\n" +
                   "Duration: " + Duration + "\n" +
                   "EndTime: " + EndTime + "\n" +
                   "FriendlyName: " + FriendlyName + "\n" +
                   "MpcUuid: " + MpcUuid + "\n" +
                   "Participants: " + Participants + "\n" +
                   "Recording: " + Recording + "\n" +
                   "ResourceUri: " + ResourceUri + "\n" +
                   "StartTime: " + StartTime + "\n" +
                   "Status: " + Status + "\n" +
                   "StayAlone: " + StayAlone + "\n" +
                   "SubAccount: " + SubAccount + "\n" +
                   "TerminationCause: " + TerminationCause + "\n" +
                   "TerminationCauseCode: " + TerminationCauseCode + "\n";
        }
    }
} 