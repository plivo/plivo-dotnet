using System.Collections.Generic;

namespace Plivo.Resource.Conference
{
    /// <summary>
    /// Conference.
    /// </summary>
    public class Conference : Resource
    {
        public new string Id => ConferenceName;
        public string ConferenceName { get; set; }
        public string ConferenceRunTime { get; set; }
        public string ConferenceMemberCount { get; set; }
        public List<Member> Members { get; set; }

        /// <summary>
        /// Delete Conference.
        /// </summary>
        /// <returns>The delete.</returns>
        public DeleteResponse<Conference> Delete()
        {
            return ((ConferenceInterface) Interface)
                .Delete(Id);
        }

        /// <summary>
        /// Hangups the member.
        /// </summary>
        /// <returns>The member.</returns>
        /// <param name="memberId">Member identifier.</param>
        public ConferenceMemberActionResponse HangupMember(
            string memberId)
        {
            return ((ConferenceInterface) Interface)
                .HangupMember(Id, memberId);
        }

        /// <summary>
        /// Kicks the member.
        /// </summary>
        /// <returns>The member.</returns>
        /// <param name="memberId">Member identifier.</param>
        public ConferenceMemberActionResponse KickMember(
            string memberId)
        {
            return ((ConferenceInterface) Interface)
                .KickMember(Id, memberId);
        }

        /// <summary>
        /// Mutes the member.
        /// </summary>
        /// <returns>The member.</returns>
        /// <param name="memberId">Member identifier.</param>
        public ConferenceMemberActionResponse MuteMember(
            List<string> memberId)
        {
            return ((ConferenceInterface) Interface)
                .MuteMember(Id, memberId);
        }

        /// <summary>
        /// Unmutes the member.
        /// </summary>
        /// <param name="memberId">Member identifier.</param>
        public void UnmuteMember(
            List<string> memberId)
        {
            ((ConferenceInterface) Interface)
                .UnmuteMember(Id, memberId);
        }

        /// <summary>
        /// Plays audio to the member.
        /// </summary>
        /// <returns>The member.</returns>
        /// <param name="memberId">Member identifier.</param>
        /// <param name="url">URL.</param>
        public ConferenceMemberActionResponse PlayMember(
            List<string> memberId, string url)
        {
            return ((ConferenceInterface) Interface)
                .PlayMember(Id, memberId, url);
        }

        /// <summary>
        /// Stops playing audio to the member.
        /// </summary>
        /// <returns>The play member.</returns>
        /// <param name="memberId">Member identifier.</param>
        public ConferenceMemberActionResponse StopPlayMember(
            List<string> memberId)
        {
            return ((ConferenceInterface) Interface)
                .StopPlayMember(Id, memberId);
        }

        /// <summary>
        /// Speaks text to the member.
        /// </summary>
        /// <returns>The member.</returns>
        /// <param name="memberId">Member identifier.</param>
        /// <param name="text">Text.</param>
        /// <param name="voice">Voice.</param>
        /// <param name="language">Language.</param>
        public ConferenceMemberActionResponse SpeakMember(
            List<string> memberId, string text,
            string voice = null, string language = null)
        {
            return ((ConferenceInterface) Interface)
                .SpeakMember(Id, memberId, text, voice, language);
        }

        /// <summary>
        /// Stops speaking text to the member.
        /// </summary>
        /// <returns>The speak member.</returns>
        /// <param name="memberId">Member identifier.</param>
        public ConferenceMemberActionResponse StopSpeakMember(
            List<string> memberId)
        {
            return ((ConferenceInterface) Interface)
                .StopSpeakMember(Id, memberId);
        }

        /// <summary>
        /// Deafs the member.
        /// </summary>
        /// <returns>The member.</returns>
        /// <param name="memberId">Member identifier.</param>
        public ConferenceMemberActionResponse DeafMember(
            List<string> memberId)
        {
            return ((ConferenceInterface) Interface)
                .DeafMember(Id, memberId);
        }

        /// <summary>
        /// Enables hearing of the member.
        /// </summary>
        /// <returns>The deaf member.</returns>
        /// <param name="memberId">Member identifier.</param>
        public ConferenceMemberActionResponse UnDeafMember(
            List<string> memberId)
        {
            return ((ConferenceInterface) Interface)
                .UnDeafMember(Id, memberId);
        }

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
        public RecordCreateResponse<Conference> StartRecording(
            string fileFormat = null,
            string transcriptionType = null, string transcriptionUrl = null,
            string transcriptionMethod = null, string callbackUrl = null,
            string callbackMethod = null)
        {
            return ((ConferenceInterface) Interface)
                .StartRecording(
                    fileFormat,
                    transcriptionType,
                    transcriptionUrl,
                    transcriptionMethod,
                    callbackUrl,
                    callbackMethod);
        }

        /// <summary>
        /// Stops the recording.
        /// </summary>
        public void StopRecording()
        {
            ((ConferenceInterface) Interface).StopRecording(Id);
        }
    }

    /// <summary>
    /// Member.
    /// </summary>
    public class Member
    {
        public bool Muted { get; set; }
        public string MemberId { get; set; }
        public bool Deaf { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string CallerName { get; set; }
        public string Direction { get; set; }
        public string CallUuid { get; set; }
        public string JoinTime { get; set; }
    }
}