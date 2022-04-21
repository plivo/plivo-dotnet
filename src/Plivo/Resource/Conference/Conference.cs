using System.Collections.Generic;
using System.Threading.Tasks;

namespace Plivo.Resource.Conference {
    /// <summary>
    /// Conference.
    /// </summary>
    public class Conference : Resource {
        public new string Id => ConferenceName;
        public string ConferenceName { get; set; }
        public string ConferenceRunTime { get; set; }
        public string ConferenceMemberCount { get; set; }
        public List<Member> Members { get; set; }

        public override string ToString () {
            return "StatusCode: " + StatusCode + "\n" +
                "ConferenceName: " + ConferenceName + "\n" +
                "ConferenceRunTime: " + ConferenceRunTime + "\n" +
                "ConferenceMemberCount: " + ConferenceMemberCount + "\n" +
                "[Members]\n" + string.Join ("\n", Members);
        }

        #region Delete
        /// <summary>
        /// Delete Conference.
        /// </summary>
        /// <returns>The delete.</returns>
        public DeleteResponse<Conference> Delete () {
            return ((ConferenceInterface) Interface)
                .Delete (Id);
        }

        /// <summary>
        /// Asynchronously Delete Conference.
        /// </summary>
        /// <returns>The delete.</returns>
        /// <param name="callbackUrl">Callback URL.</param>
        /// <param name="callbackMethod">Callback method.</param>
        public async Task<AsyncResponse> DeleteAsync (string callbackUrl = null, string callbackMethod = null) {
            return await ((ConferenceInterface) Interface)
                .DeleteAsync (Id, callbackUrl, callbackMethod);
        }
        #endregion

        #region HangupMember
        /// <summary>
        /// Hangups the member.
        /// </summary>
        /// <returns>The member.</returns>
        /// <param name="memberId">Member identifier.</param>
        public ConferenceMemberActionResponse HangupMember (
            string memberId) {
            return ((ConferenceInterface) Interface)
                .HangupMember (Id, memberId);
        }
        /// <summary>
        /// Asynchronously hangups the member.
        /// </summary>
        /// <returns>The member.</returns>
        /// <param name="memberId">Member identifier.</param>
        /// <param name="callbackUrl">Callback URL.</param>
        /// <param name="callbackMethod">Callback method.</param>
        public async Task<AsyncResponse> HangupMemberAsync (
            string memberId, string callbackUrl = null, string callbackMethod = null) {
            return await ((ConferenceInterface) Interface)
                .HangupMemberAsync (Id, memberId, callbackUrl, callbackMethod);
        }
        #endregion

        #region KickMember
        /// <summary>
        /// Kicks the member.
        /// </summary>
        /// <returns>The member.</returns>
        /// <param name="memberId">Member identifier.</param>
        public ConferenceMemberActionResponse KickMember (
            string memberId) {
            return ((ConferenceInterface) Interface)
                .KickMember (Id, memberId);
        }

        /// <summary>
        /// Asynchronously kicks the member.
        /// </summary>
        /// <returns>The member.</returns>
        /// <param name="memberId">Member identifier.</param>
        /// <param name="callbackUrl">Callback URL.</param>
        /// <param name="callbackMethod">Callback method.</param>
        public async Task<AsyncResponse> KickMemberAsync (
            string memberId, string callbackUrl = null, string callbackMethod = null) {
            return await ((ConferenceInterface) Interface)
                .KickMemberAsync (Id, memberId, callbackUrl, callbackMethod);
        }
        #endregion

        #region MuteMember
        /// <summary>
        /// Mutes the member.
        /// </summary>
        /// <returns>The member.</returns>
        /// <param name="memberId">Member identifier.</param>
        public ConferenceMemberActionResponse MuteMember (
            List<string> memberId) {
            return ((ConferenceInterface) Interface)
                .MuteMember (Id, memberId);
        }
        /// <summary>
        /// Asynchronously mutes the member.
        /// </summary>
        /// <returns>The member.</returns>
        /// <param name="memberId">Member identifier.</param>
        /// <param name="callbackUrl">Callback URL.</param>
        /// <param name="callbackMethod">Callback method.</param>
        public async Task<AsyncResponse> MuteMemberAsync (
            List<string> memberId, string callbackUrl = null, string callbackMethod = null) {
            return await ((ConferenceInterface) Interface)
                .MuteMemberAsync (Id, memberId, callbackUrl, callbackMethod);
        }
        #endregion

        #region UnmuteMember
        /// <summary>
        /// Unmutes the member.
        /// </summary>
        /// <param name="memberId">Member identifier.</param>
        public void UnmuteMember (
            List<string> memberId) {
            ((ConferenceInterface) Interface)
            .UnmuteMember (Id, memberId);
        }
        /// <summary>
        /// Asynchronously unmutes the member.
        /// </summary>
        /// <param name="memberId">Member identifier.</param>
        /// <param name="callbackUrl">Callback URL.</param>
        /// <param name="callbackMethod">Callback method.</param>
        public async Task<AsyncResponse> UnmuteMemberAsync (
            List<string> memberId, string callbackUrl = null, string callbackMethod = null) {

            return await ((ConferenceInterface) Interface)
            .UnmuteMemberAsync (Id, memberId, callbackUrl, callbackMethod);
        }
        #endregion

        #region PlayMember
        /// <summary>
        /// Plays audio to the member.
        /// </summary>
        /// <returns>The member.</returns>
        /// <param name="memberId">Member identifier.</param>
        /// <param name="url">URL.</param>
        public ConferenceMemberActionResponse PlayMember (
            List<string> memberId, string url) {
            return ((ConferenceInterface) Interface)
                .PlayMember (Id, memberId, url);
        }
        /// <summary>
        /// Asynchronously plays audio to the member.
        /// </summary>
        /// <returns>The member.</returns>
        /// <param name="memberId">Member identifier.</param>
        /// <param name="url">URL.</param>
        /// <param name="callbackUrl">Callback URL.</param>
        /// <param name="callbackMethod">Callback method.</param>
        public async Task<AsyncResponse> PlayMemberAsync (
            List<string> memberId, string url, string callbackUrl = null, string callbackMethod = null) {
            return await ((ConferenceInterface) Interface)
                .PlayMemberAsync (Id, memberId, url, callbackUrl, callbackMethod);
        }
        #endregion

        #region StopPlayMember
        /// <summary>
        /// Stops playing audio to the member.
        /// </summary>
        /// <returns>The play member.</returns>
        /// <param name="memberId">Member identifier.</param>
        public ConferenceMemberActionResponse StopPlayMember (
            List<string> memberId) {
            return ((ConferenceInterface) Interface)
                .StopPlayMember (Id, memberId);
        }
        /// <summary>
        /// Asynchronously stops playing audio to the member.
        /// </summary>
        /// <returns>The play member.</returns>
        /// <param name="memberId">Member identifier.</param>
        /// <param name="callbackUrl">Callback URL.</param>
        /// <param name="callbackMethod">Callback method.</param>
        public async Task<AsyncResponse> StopPlayMemberAsync (
            List<string> memberId, string callbackUrl = null, string callbackMethod = null) {
            return await ((ConferenceInterface) Interface)
                .StopPlayMemberAsync (Id, memberId, callbackUrl, callbackMethod);
        }
        #endregion

        #region SpeakMember
        /// <summary>
        /// Speaks text to the member.
        /// </summary>
        /// <returns>The member.</returns>
        /// <param name="memberId">Member identifier.</param>
        /// <param name="text">Text.</param>
        /// <param name="voice">Voice.</param>
        /// <param name="language">Language.</param>
        public ConferenceMemberActionResponse SpeakMember (
            List<string> memberId, string text,
            string voice = null, string language = null) {
            return ((ConferenceInterface) Interface)
                .SpeakMember (Id, memberId, text, voice, language);
        }
        /// <summary>
        /// Asynchronously speaks text to the member.
        /// </summary>
        /// <returns>The member.</returns>
        /// <param name="memberId">Member identifier.</param>
        /// <param name="text">Text.</param>
        /// <param name="voice">Voice.</param>
        /// <param name="language">Language.</param>
        /// <param name="callbackUrl">Callback URL.</param>
        /// <param name="callbackMethod">Callback method.</param>
        public async Task<AsyncResponse> SpeakMemberAsync (
            List<string> memberId, string text,
            string voice = null, string language = null, 
            string callbackUrl = null, string callbackMethod = null) {
            return await ((ConferenceInterface) Interface)
                .SpeakMemberAsync (Id, memberId, text, voice, language, callbackUrl, callbackMethod);
        }
        #endregion

        #region StopSpeakMember
        /// <summary>
        /// Stops speaking text to the member.
        /// </summary>
        /// <returns>The speak member.</returns>
        /// <param name="memberId">Member identifier.</param>
        public ConferenceMemberActionResponse StopSpeakMember (
            List<string> memberId) {
            return ((ConferenceInterface) Interface)
                .StopSpeakMember (Id, memberId);
        }
        /// <summary>
        /// Asynchronously stops speaking text to the member.
        /// </summary>
        /// <returns>The speak member.</returns>
        /// <param name="memberId">Member identifier.</param>
        /// <param name="callbackUrl">Callback URL.</param>
        /// <param name="callbackMethod">Callback method.</param>
        public async Task<AsyncResponse> StopSpeakMemberAsync (
            List<string> memberId, string callbackUrl = null, string callbackMethod = null) {
            return await ((ConferenceInterface) Interface)
                .StopSpeakMemberAsync (Id, memberId, callbackUrl, callbackMethod);
        }
        #endregion

        #region DeafMember
        /// <summary>
        /// Deafs the member.
        /// </summary>
        /// <returns>The member.</returns>
        /// <param name="memberId">Member identifier.</param>
        public ConferenceMemberActionResponse DeafMember (
            List<string> memberId) {
            return ((ConferenceInterface) Interface)
                .DeafMember (Id, memberId);
        }
        /// <summary>
        /// Asynchronous deafs the member.
        /// </summary>
        /// <returns>The member.</returns>
        /// <param name="memberId">Member identifier.</param>
        /// <param name="callbackUrl">Callback URL.</param>
        /// <param name="callbackMethod">Callback method.</param>
        public async Task<AsyncResponse> DeafMemberAsync (
            List<string> memberId, string callbackUrl = null, string callbackMethod = null) {
            return await ((ConferenceInterface) Interface)
                .DeafMemberAsync (Id, memberId, callbackUrl, callbackMethod);
        }
        #endregion

        #region UnDeafMember
        /// <summary>
        /// Enables hearing of the member.
        /// </summary>
        /// <returns>The deaf member.</returns>
        /// <param name="memberId">Member identifier.</param>
        public ConferenceMemberActionResponse UnDeafMember (
            List<string> memberId) {
            return ((ConferenceInterface) Interface)
                .UnDeafMember (Id, memberId);
        }
        /// <summary>
        /// Enables hearing of the member.
        /// </summary>
        /// <returns>The deaf member.</returns>
        /// <param name="memberId">Member identifier.</param>
        /// <param name="callbackUrl">Callback URL.</param>
        /// <param name="callbackMethod">Callback method.</param>
        public async Task<AsyncResponse> UnDeafMemberAsync (
            List<string> memberId, string callbackUrl = null, string callbackMethod = null) {
            return await ((ConferenceInterface) Interface)
                .UnDeafMemberAsync (Id, memberId, callbackUrl, callbackMethod);
        }
        #endregion

        #region StartRecording
        /// <summary>
        /// Starts the recording.
        /// </summary>
        /// <returns>The recording.</returns>
        /// <param name="fileFormat">File format.</param>
        /// <param name="transcriptionType">Transcription type.</param>
        /// <param name="transcriptionUrl">Transcription URL.</param>
        /// <param name="transcriptionMethod">Transcription method.</param>
        /// <param name="callbackUrl">Callback URL.</param>
        /// <param name="callbackMethod">Callback method.</param>
        public RecordCreateResponse<Conference> StartRecording (
            string fileFormat = null,
            string transcriptionType = null, string transcriptionUrl = null,
            string transcriptionMethod = null, string callbackUrl = null,
            string callbackMethod = null) {
            return ((ConferenceInterface) Interface)
                .StartRecording (
                    fileFormat,
                    transcriptionType,
                    transcriptionUrl,
                    transcriptionMethod,
                    callbackUrl,
                    callbackMethod);
        }
        /// <summary>
        /// Asynchronous starts the recording.
        /// </summary>
        /// <returns>The recording.</returns>
        /// <param name="fileFormat">File format.</param>
        /// <param name="transcriptionType">Transcription type.</param>
        /// <param name="transcriptionUrl">Transcription URL.</param>
        /// <param name="transcriptionMethod">Transcription method.</param>
        /// <param name="callbackUrl">Callback URL.</param>
        /// <param name="callbackMethod">Callback method.</param>
        public async Task<AsyncResponse> StartRecordingAsync (
            string fileFormat = null,
            string transcriptionType = null, string transcriptionUrl = null,
            string transcriptionMethod = null, string callbackUrl = null,
            string callbackMethod = null) {
            return await ((ConferenceInterface) Interface)
                .StartRecordingAsync (
                    fileFormat,
                    transcriptionType,
                    transcriptionUrl,
                    transcriptionMethod,
                    callbackUrl,
                    callbackMethod);
        }
        #endregion

        #region StopRecording
        /// <summary>
        /// Stops the recording.
        /// </summary>
        public void StopRecording () {
            ((ConferenceInterface) Interface).StopRecording (Id);
        }
        /// <summary>
        /// Asynchronous stops the recording.
        /// </summary>
        /// <param name="callbackUrl">Callback URL.</param>
        /// <param name="callbackMethod">Callback method.</param>
        public async Task<AsyncResponse> StopRecordingAsync (string callbackUrl = null,
            string callbackMethod = null) {
            return await ((ConferenceInterface) Interface).StopRecordingAsync(Id, callbackUrl, callbackMethod);
        }
        #endregion
    }

    /// <summary>
    /// Member.
    /// </summary>
    public class Member {
        public bool Muted { get; set; }
        public string MemberId { get; set; }
        public bool Deaf { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string CallerName { get; set; }
        public string Direction { get; set; }
        public string CallUuid { get; set; }
        public string JoinTime { get; set; }

        public override string ToString () {

            return "JoinTime: " + JoinTime + "\n" +
                "CallUuid: " + CallUuid + "\n" +
                "Direction: " + Direction + "\n" +
                "CallerName: " + CallerName + "\n" +
                "To: " + To + "\n" +
                "From: " + From + "\n" +
                "Deaf: " + Deaf + "\n" +
                "MemberId: " + MemberId + "\n" +
                "Muted: " + Muted + "\n";
        }
    }
}