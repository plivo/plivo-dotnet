using System;
using System.Collections.Generic;
using System.Reflection;
using Plivo.Client;


namespace Plivo.Resource.Conference
{
    /// <summary>
    /// Conference interface.
    /// </summary>
    public class ConferenceInterface : ResourceInterface
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:plivo.Resource.Conference.ConferenceInterface"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        public ConferenceInterface(HttpClient client) : base(client)
        {
            Uri = "Account/" + Client.GetAuthId() + "/Conference/";
        }

        /// <summary>
        /// Get Conference with the specified name.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="conferenceName">Name.</param>
        public Conference Get(string conferenceName)
        {
            var conference = GetResource<Conference>(conferenceName);
            conference.Interface = this;
            return conference;
        }

        /// <summary>
        /// List Conferences.
        /// </summary>
        /// <returns>The list.</returns>
        public ConferenceListResponse List()
        {
            return ListResources<ConferenceListResponse>();
        }

        /// <summary>
        /// Deletes all.
        /// </summary>
        /// <returns>The all.</returns>
        public DeleteResponse<Conference> DeleteAll()
        {
            return Client.Delete<DeleteResponse<Conference>>(Uri).Object;
        }

        /// <summary>
        /// Delete with the specified name.
        /// </summary>
        /// <returns>The delete.</returns>
        /// <param name="name">Name.</param>
        public DeleteResponse<Conference> Delete(string name)
        {
            return DeleteResource<DeleteResponse<Conference>>(name);
        }

        /// <summary>
        /// Hangups the member.
        /// </summary>
        /// <returns>The member.</returns>
        /// <param name="conferenceName">Conference name.</param>
        /// <param name="memberId">Member identifier.</param>
        public ConferenceMemberActionResponse HangupMember(
            string conferenceName, string memberId)
        {
            return 
                Client.Delete<ConferenceMemberActionResponse>(
                    Uri + conferenceName + "/Member/" + memberId + "/").Object;
        }

        /// <summary>
        /// Kicks the member.
        /// </summary>
        /// <returns>The member.</returns>
        /// <param name="conferenceName">Conference name.</param>
        /// <param name="memberId">Member identifier.</param>
        public ConferenceMemberActionResponse KickMember(
            string conferenceName, string memberId)
        {
            return Client.Update<ConferenceMemberActionResponse>(
                Uri + conferenceName + "/Member/" + memberId + "/Kick/").Object;
        }

        /// <summary>
        /// Mutes the member.
        /// </summary>
        /// <returns>The member.</returns>
        /// <param name="conferenceName">Conference name.</param>
        /// <param name="memberId">Member identifier.</param>
        public ConferenceMemberActionResponse MuteMember(
            string conferenceName, List<string> memberId)
        {
            return Client.Update<ConferenceMemberActionResponse>(
                Uri + conferenceName + "/Member/" + string.Join(",", memberId) + "/Mute/").Object;
        }

        /// <summary>
        /// Unmutes the member.
        /// </summary>
        /// <param name="conferenceName">Conference name.</param>
        /// <param name="memberId">Member identifier.</param>
        public void UnmuteMember(
            string conferenceName, List<string> memberId)
        {
            Client.Delete<ConferenceMemberActionResponse>(
                Uri + conferenceName + "/Member/" + string.Join(",", memberId) + "/Mute/");
        }

        /// <summary>
        /// Plays audio to the member.
        /// </summary>
        /// <returns>The member.</returns>
        /// <param name="conferenceName">Conference name.</param>
        /// <param name="memberId">Member identifier.</param>
        /// <param name="url">URL.</param>
        public ConferenceMemberActionResponse PlayMember(
            string conferenceName, List<string> memberId, string url)
        {
            return 
                Client.Update<ConferenceMemberActionResponse>(
                    Uri +
                    conferenceName +
                    "/Member/" +
                    string.Join(",", memberId) +
                    "/Play/",
                    new Dictionary<string, object>(){{"url", url}}
                ).Object;
        }

        /// <summary>
        /// Stops playing audio to the member.
        /// </summary>
        /// <returns>The play member.</returns>
        /// <param name="conferenceName">Conference name.</param>
        /// <param name="memberId">Member identifier.</param>
        public ConferenceMemberActionResponse StopPlayMember(
            string conferenceName, List<string> memberId)
        {
            return 
                Client.Delete<ConferenceMemberActionResponse>(
                    Uri +
                    conferenceName +
                    "/Member/" +
                    string.Join(",", memberId) +
                    "/Play/"
                ).Object;
        }

        /// <summary>
        /// Speaks text to the member.
        /// </summary>
        /// <returns>The member.</returns>
        /// <param name="conferenceName">Conference name.</param>
        /// <param name="memberId">Member identifier.</param>
        /// <param name="text">Text.</param>
        /// <param name="voice">Voice.</param>
        /// <param name="language">Language.</param>
        public ConferenceMemberActionResponse SpeakMember(
            string conferenceName, List<string> memberId, string text,
            string voice = null, string language = null)
        {
            var mandatory_params = new List<string> { "" };var data = CreateData(
                mandatory_params,
                new
                {
                    text, voice, language
                });
            return 
                Client.Update<ConferenceMemberActionResponse>(
                    Uri +
                    conferenceName +
                    "/Member/" +
                    string.Join(",", memberId) +
                    "/Speak/",
                    data
                ).Object;
        }

        /// <summary>
        /// Stops speaking text to the member.
        /// </summary>
        /// <returns>The speak member.</returns>
        /// <param name="conferenceName">Conference name.</param>
        /// <param name="memberId">Member identifier.</param>
        public ConferenceMemberActionResponse StopSpeakMember(
            string conferenceName, List<string> memberId)
        {
            return 
                Client.Delete<ConferenceMemberActionResponse>(
                    Uri +
                    conferenceName +
                    "/Member/" +
                    string.Join(",", memberId) +
                    "/Speak/"
                ).Object;
        }

        /// <summary>
        /// Deafs the member.
        /// </summary>
        /// <returns>The member.</returns>
        /// <param name="conferenceName">Conference name.</param>
        /// <param name="memberId">Member identifier.</param>
        public ConferenceMemberActionResponse DeafMember(
            string conferenceName, List<string> memberId)
        {
            return 
                Client.Update<ConferenceMemberActionResponse>(
                    Uri +
                    conferenceName +
                    "/Member/" +
                    string.Join(",", memberId) +
                    "/Deaf/"
                ).Object;
        }

        /// <summary>
        /// Enables hearing of the member.
        /// </summary>
        /// <returns>The deaf member.</returns>
        /// <param name="conferenceName">Conference name.</param>
        /// <param name="memberId">Member identifier.</param>
        public ConferenceMemberActionResponse UnDeafMember(
            string conferenceName, List<string> memberId)
        {
            return 
                Client.Delete<ConferenceMemberActionResponse>(
                    Uri +
                    conferenceName +
                    "/Member/" +
                    string.Join(",", memberId) +
                    "/Deaf/"
                ).Object;
        }

        /// <summary>
        /// Starts the recording.
        /// </summary>
        /// <returns>The recording.</returns>
        /// <param name="conferenceName">Conference name.</param>
        /// <param name="fileFormat">File format.</param>
        /// <param name="transcriptionType">Transcription type.</param>
        /// <param name="transcriptionUrl">Transcription URL.</param>
        /// <param name="transcriptionMethod">Transcription method.</param>
        /// <param name="callbackUrl">Callback URL.</param>
        /// <param name="callbackMethod">Callback method.</param>
        public RecordCreateResponse<Conference> StartRecording(
            string conferenceName, string fileFormat = null,
            string transcriptionType = null, string transcriptionUrl = null,
            string transcriptionMethod = null ,string callbackUrl = null,
            string callbackMethod = null)
        {
            var mandatory_params = new List<string> { "" };var data = CreateData(
                mandatory_params,new
            {
                fileFormat, transcriptionType, transcriptionUrl,
                transcriptionMethod, callbackUrl, callbackMethod
            });

            return
                Client.Update<RecordCreateResponse<Conference>>(
                    Uri + conferenceName + "/Record/",
                    data
                ).Object;
        }

        /// <summary>
        /// Stops the recording.
        /// </summary>
        /// <param name="conferenceName">Conference name.</param>
        public void StopRecording(
            string conferenceName)
        {
                Client.Delete<object>(
                    Uri + conferenceName + "/Record/"
                );
        }
    }
}
