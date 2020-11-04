using System;
using System.Threading.Tasks;
using Plivo.Client;

namespace Plivo.Resource.MultiPartyCall
{
    public class MultiPartyCallParticipant : SecondaryResource
    {
        public string BilledAmount { get; set; }
        public uint? BilledDuration { get; set; }
        public string CallUuid { get; set; }
        public bool CoachMode { get; set; }
        public uint? Duration { get; set; }
        public bool EndMpcOnExit { get; set; }
        public string ExitCause { get; set; }
        public string ExitTime { get; set; }
        public bool Hold { get; set; }
        public string JoinTime { get; set; }
        public string MemberId { get; set; }
        public string MpcUuid { get; set; }
        public bool Mute { get; set; }
        public string ResourceUri { get; set; }
        public string Role { get; set; }
        public bool StartMpcOnEnter { get; set; }
        
        public override string ToString()
        {
            return "BilledAmount: " + BilledAmount + "\n" +
                   "BilledDuration: " + BilledDuration + "\n" +
                   "CallUuid: " + CallUuid + "\n" +
                   "CoachMode: " + CoachMode + "\n" +
                   "Duration: " + Duration + "\n" +
                   "EndMpcOnExit: " + EndMpcOnExit + "\n" +
                   "ExitCause: " + ExitCause + "\n" +
                   "ExitTime: " + ExitTime + "\n" +
                   "Hold: " + Hold + "\n" +
                   "JoinTime: " + JoinTime + "\n" +
                   "MemberId: " + MemberId + "\n" +
                   "MpcUuid: " + MpcUuid + "\n" +
                   "Mute: " + Mute + "\n" +
                   "ResourceUri: " + ResourceUri + "\n" +
                   "Role : " + Role + "\n" +
                   "StartMpcOnEnter: " + StartMpcOnEnter + "\n" ;
        }
    }
}