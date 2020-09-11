using System;
using System.Threading.Tasks;
using Plivo.Client;

namespace Plivo.Resource.MultiPartyCall
{
    /// <summary>
    /// Application.
    /// </summary>
    public class MultiPartyCall : Resource
    {
        public string BilledAmount { get; set; }
        public string BilledDuration { get; set; }
        public string CreationTime { get; set; }
        public string Duration { get; set; }
        public string EndTime { get; set; }
        public string FriendlyName { get; set; }
        public string MpcUuid { get; set; }
        public string Participants { get; set; }
        public string Recording { get; set; }
        public string HangResourceUri { get; set; }
        public string StartTime { get; set; }
        public string Status { get; set; }
        public string StayAlone { get; set; }
        public string TerminationCause { get; set; }
        public string TerminationCauseCode { get; set; }

        // public string Role { get; set; }
        // public string From { get; set; }
        // public string To { get; set; }
        // public string CallUuid { get; set; }
        // public string CallStatusCallbackUrl { get; set; }
        // public string CallStatusCallbackMethod { get; set; }
        // public string SipHeaders { get; set; }
        // public string ConfirmKey { get; set; }
        // public string ConfirmKeySoundUrl { get; set; }
        // public string ConfirmKeySoundMethod { get; set; }
        // public string DialMusic { get; set; }
        // public string RingTimeout { get; set; }
        // public string MaxDuration { get; set; }
        // public string MaxParticipants { get; set; }
        // public string WaitMusicUrl { get; set; }
        // public string WaitMusicMethod { get; set; }
        // public string AgentHoldMusicUrl { get; set; }
        // public string AgentHoldMusicMethod { get; set; }
        // public string CustomerHoldMusicUrl { get; set; }
        // public string CustomerHoldMusicMethod { get; set; }
        // public string RecordingCallbackUrl { get; set; }
        // public string RecordingCallbackMethod { get; set; }
        // public string StatusCallbackUrl { get; set; }
        // public string StatusCallbackMethod { get; set; }
        // public string OnExitActionUrl { get; set; }
        // public string OnExitActionMethod { get; set; }
        // public string Record { get; set; }
        // public string RecordFileFormat { get; set; }
        // public string StatusCallbackEvents { get; set; }
        // public string CoachMode { get; set; }
        // public string Mute { get; set; }
        // public string Hold { get; set; }
        // public string StartMpcOnEnter { get; set; }
        // public string EndMpcOnExit { get; set; }
        // public string RelayDtmfInputs { get; set; }
        // public string EnterSound { get; set; }
        // public string EnterSoundMethod { get; set; }
        // public string ExitSound { get; set; }
        // public string ExitSoundMethod { get; set; }

        public MultiPartyCall()
        {
        }

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
                   "HangResourceUri: " + HangResourceUri + "\n" +
                   "StartTime: " + StartTime + "\n" +
                   "Status: " + Status + "\n" +
                   "StayAlone: " + StayAlone + "\n" +
                   "TerminationCause: " + TerminationCause + "\n" +
                   "TerminationCauseCode: " + TerminationCauseCode + "\n";
        }
    }
}