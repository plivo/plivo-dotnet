using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
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

        #region Get
        /// <summary>
        /// Get Conference with the specified name.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="conferenceName">Name.</param>
        public Conference Get(string conferenceName)
        {
            return ExecuteWithExceptionUnwrap(() =>
            {
                var conference = Task.Run(async () => await GetResource<Conference>(conferenceName,new Dictionary<string, object> () { {"is_voice_request", true} }).ConfigureAwait(false)).Result;
                conference.Interface = this;
                return conference;
            });
        }
        /// <summary>
        /// Asynchronously Get Conference with the specified name.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="conferenceName">Name.</param>
        /// <param name="callbackUrl">Callback URL.</param>
        /// <param name="callbackMethod">Callback Method.</param>
        public async Task<Conference> GetAsync(string conferenceName, string callbackUrl = null, string callbackMethod = null)
        {
            var conference = Task.Run(async () => await GetResource<Conference>(conferenceName,new Dictionary<string, object> ()
            {
                {"callback_url", callbackUrl},
                {"callback_method", callbackMethod},
                {"is_voice_request", true}
            }).ConfigureAwait(false)).Result;
            await Task.WhenAll();
            conference.Interface = this;
            return conference;
        }
        #endregion

        #region List
        /// <summary>
        /// List Conferences.
        /// </summary>
        /// <returns>The list.</returns>
        public ConferenceListResponse List()
        {
            return ExecuteWithExceptionUnwrap(() =>
            {
                return Task.Run(async () => await ListResources<ConferenceListResponse>(new Dictionary<string, object> () { {"is_voice_request", true} }).ConfigureAwait(false)).Result;
            });
        }
        /// <summary>
        /// List Conferences.
        /// </summary>
        /// <returns>The list.</returns>
        /// <param name="callbackUrl">Callback URL.</param>
        /// <param name="callbackMethod">Callback Method.</param>
        public async Task<ConferenceListResponse> ListAsync(string callbackUrl = null, string callbackMethod = null)
        {
            var result = Task.Run(async () => await ListResources<ConferenceListResponse>(new Dictionary<string, object> ()
            {
                {"callback_url", callbackUrl},
                {"callback_method", callbackMethod},
                {"is_voice_request", true}
            }).ConfigureAwait(false)).Result;
            await Task.WhenAll();
            return result;
        }
        #endregion

        #region DeleteAll
        /// <summary>
        /// Deletes all.
        /// </summary>
        /// <returns>The all.</returns>
        public DeleteResponse<Conference> DeleteAll()
        {
            return ExecuteWithExceptionUnwrap(() =>
            {
                var result = Task.Run(async () => await Client.Delete<DeleteResponse<Conference>>(Uri, new Dictionary<string, object> () { {"is_voice_request", true} }).ConfigureAwait(false)).Result;
                result.Object.StatusCode = result.StatusCode;
                return result.Object;
            });
        }
        /// <summary>
        /// Asynchronously deletes all.
        /// </summary>
        /// <returns>The all.</returns>
        /// <param name="callbackUrl">Callback URL.</param>
        /// <param name="callbackMethod">Callback Method.</param>
        public async Task<DeleteResponse<Conference>> DeleteAllAsync(string callbackUrl = null, string callbackMethod = null)
        {
            var result = Task.Run(async () => await Client.Delete<DeleteResponse<Conference>>(Uri, new Dictionary<string, object> ()
            {
                {"callback_url", callbackUrl},
                {"callback_method", callbackMethod},
                {"is_voice_request", true}
            }).ConfigureAwait(false)).Result;
            await Task.WhenAll();
            result.Object.StatusCode = result.StatusCode;
            return result.Object;
        }
        #endregion

        #region Delete
        /// <summary>
        /// Delete with the specified name.
        /// </summary>
        /// <returns>The delete.</returns>
        /// <param name="name">Name.</param>
        public DeleteResponse<Conference> Delete(string name)
        {
            return ExecuteWithExceptionUnwrap(() =>
            {
                return Task.Run(async () => await DeleteResource<DeleteResponse<Conference>>(name,new Dictionary<string, object> () { {"is_voice_request", true} }).ConfigureAwait(false)).Result;
            });
        }
        /// <summary>
        /// Asynchronously delete with the specified name.
        /// </summary>
        /// <returns>The delete.</returns>
        /// <param name="name">Name.</param>
        /// <param name="callbackUrl">Callback URL.</param>
        /// <param name="callbackMethod">Callback Method.</param>
        public async Task<DeleteResponse<Conference>> DeleteAsync(string name, string callbackUrl = null, string callbackMethod = null)
        {
            var result = Task.Run(async () => await DeleteResource<DeleteResponse<Conference>>(name,new Dictionary<string, object> ()
            {
                {"callback_url", callbackUrl},
                {"callback_method", callbackMethod},
                {"is_voice_request", true}
            }).ConfigureAwait(false)).Result;
            await Task.WhenAll();
            return result;
        }
        #endregion

        #region HangupMember
        /// <summary>
        /// Hangups the member.
        /// </summary>
        /// <returns>The member.</returns>
        /// <param name="conferenceName">Conference name.</param>
        /// <param name="memberId">Member identifier.</param>
        public ConferenceMemberActionResponse HangupMember(
            string conferenceName, string memberId)
        {
            return ExecuteWithExceptionUnwrap(() =>
            {
                var result = Task.Run(async () => await Client.Delete<ConferenceMemberActionResponse>(Uri + conferenceName + "/Member/" + memberId + "/",new Dictionary<string, object> () { {"is_voice_request", true} }).ConfigureAwait(false)).Result;
                result.Object.StatusCode = result.StatusCode;
                return result.Object;
            });
        }
        /// <summary>
        /// Asynchronously hangups the member.
        /// </summary>
        /// <returns>The member.</returns>
        /// <param name="conferenceName">Conference name.</param>
        /// <param name="memberId">Member identifier.</param>
        /// <param name="callbackUrl">Callback URL.</param>
        /// <param name="callbackMethod">Callback Method.</param>
        public async Task<ConferenceMemberActionResponse> HangupMemberAsync(
            string conferenceName, string memberId, string callbackUrl = null, string callbackMethod = null)
        {
            var result = Task.Run(async () => await Client.Delete<ConferenceMemberActionResponse>(Uri + conferenceName + "/Member/" + memberId + "/",new Dictionary<string, object> ()
            {
                {"callback_url", callbackUrl},
                {"callback_method", callbackMethod},
                {"is_voice_request", true}
            }).ConfigureAwait(false)).Result;
            await Task.WhenAll();
            result.Object.StatusCode = result.StatusCode;
            return result.Object;
        }
        #endregion

        #region KickMember
        /// <summary>
        /// Kicks the member.
        /// </summary>
        /// <returns>The member.</returns>
        /// <param name="conferenceName">Conference name.</param>
        /// <param name="memberId">Member identifier.</param>
        public ConferenceMemberActionResponse KickMember(
            string conferenceName, string memberId)
        {
            return ExecuteWithExceptionUnwrap(() =>
            {
                var result = Task.Run(async () => await Client.Update<ConferenceMemberActionResponse>(Uri + conferenceName + "/Member/" + memberId + "/Kick/",new Dictionary<string, object> () { {"is_voice_request", true} }).ConfigureAwait(false)).Result;
                result.Object.StatusCode = result.StatusCode;
                return result.Object;
            });
        }

        /// <summary>
        /// Asynchronously kicks the member.
        /// </summary>
        /// <returns>The member.</returns>
        /// <param name="conferenceName">Conference name.</param>
        /// <param name="memberId">Member identifier.</param>
        ///  <param name="callbackUrl">Callback URL.</param>
        /// <param name="callbackMethod">Callback Method.</param>
        public async Task<ConferenceMemberActionResponse> KickMemberAsync(
            string conferenceName, string memberId, string callbackUrl = null, string callbackMethod = null)
        {
            var result = Task.Run(async () => await Client.Update<ConferenceMemberActionResponse>(Uri + conferenceName + "/Member/" + memberId + "/Kick/",new Dictionary<string, object> ()
            {
                {"callback_url", callbackUrl},
                {"callback_method", callbackMethod},
                {"is_voice_request", true}
            }).ConfigureAwait(false)).Result;
            await Task.WhenAll();
            result.Object.StatusCode = result.StatusCode;
            return result.Object;
        }
        #endregion

        #region MuteMember
        /// <summary>
        /// Mutes the member.
        /// </summary>
        /// <returns>The member.</returns>
        /// <param name="conferenceName">Conference name.</param>
        /// <param name="memberId">Member identifier.</param>
        public ConferenceMemberActionResponse MuteMember(
            string conferenceName, List<string> memberId)
        {
            return ExecuteWithExceptionUnwrap(() =>
            {
                var result = Task.Run(async () => await Client.Update<ConferenceMemberActionResponse>(Uri + conferenceName + "/Member/" + string.Join(",", memberId) + "/Mute/", new Dictionary<string, object> () { {"is_voice_request", true} }).ConfigureAwait(false)).Result;
                result.Object.StatusCode = result.StatusCode;
                return result.Object;
            });
        }
        /// <summary>
        /// Asynchronously mutes the member.
        /// </summary>
        /// <returns>The member.</returns>
        /// <param name="conferenceName">Conference name.</param>
        /// <param name="memberId">Member identifier.</param>
        /// <param name="callbackUrl">Callback URL.</param>
        /// <param name="callbackMethod">Callback Method.</param>
        public async Task<ConferenceMemberActionResponse> MuteMemberAsync(
            string conferenceName, List<string> memberId, string callbackUrl = null, string callbackMethod = null)
        {
            var result = Task.Run(async () => await Client.Update<ConferenceMemberActionResponse>(Uri + conferenceName + "/Member/" + string.Join(",", memberId) + "/Mute/", new Dictionary<string, object> ()
            {
                {"callback_url", callbackUrl},
                {"callback_method", callbackMethod},
                {"is_voice_request", true}
            }).ConfigureAwait(false)).Result;
            await Task.WhenAll();
            result.Object.StatusCode = result.StatusCode;
            return result.Object;
        }
        #endregion

        #region UnmuteMember
        /// <summary>
        /// Unmutes the member.
        /// </summary>
        /// <param name="conferenceName">Conference name.</param>
        /// <param name="memberId">Member identifier.</param>
        public void UnmuteMember(
            string conferenceName, List<string> memberId)
        {
            ExecuteWithExceptionUnwrap(() =>
            {
                Task.Run(async () => await Client.Delete<ConferenceMemberActionResponse>(
                    Uri + conferenceName + "/Member/" + string.Join(",", memberId) + "/Mute/",new Dictionary<string, object> () { {"is_voice_request", true} }).ConfigureAwait(false)).Wait();
            });
        }
        /// <summary>
        /// Asynchronously unmutes the member.
        /// </summary>
        /// <param name="conferenceName">Conference name.</param>
        /// <param name="memberId">Member identifier.</param>
        /// <param name="callbackUrl">Callback URL.</param>
        /// <param name="callbackMethod">Callback Method.</param>
        public async Task UnmuteMemberAsync(
            string conferenceName, List<string> memberId, string callbackUrl = null, string callbackMethod = null)
        {
            Task.Run(async () => await Client.Delete<ConferenceMemberActionResponse>(
                Uri + conferenceName + "/Member/" + string.Join(",", memberId) + "/Mute/",new Dictionary<string, object> ()
                {
                    {"callback_url", callbackUrl},
                    {"callback_method", callbackMethod},
                    {"is_voice_request", true}
                }).ConfigureAwait(false)).Wait();
            await Task.WhenAll();
        }
        #endregion

        #region PlayMember
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
            return ExecuteWithExceptionUnwrap(() =>
            {
                var result = Task.Run(async () => await Client.Update<ConferenceMemberActionResponse>(
                        Uri +
                        conferenceName +
                        "/Member/" +
                        string.Join(",", memberId) +
                        "/Play/",
                        new Dictionary<string, object>() { { "url", url } , {"is_voice_request", true}}
                    ).ConfigureAwait(false)).Result;
                result.Object.StatusCode = result.StatusCode;
                return result.Object;
            
            });
        }
        /// <summary>
        /// Asynchronously plays audio to the member.
        /// </summary>
        /// <returns>The member.</returns>
        /// <param name="conferenceName">Conference name.</param>
        /// <param name="memberId">Member identifier.</param>
        /// <param name="url">URL.</param>
        /// <param name="callbackUrl">Callback URL.</param>
        /// <param name="callbackMethod">Callback Method.</param>
        public async Task<ConferenceMemberActionResponse> PlayMemberAsync(
            string conferenceName, List<string> memberId, string url, string callbackUrl = null, string callbackMethod = null)
        {
            var result = Task.Run(async () => await Client.Update<ConferenceMemberActionResponse>(
                Uri +
                conferenceName +
                "/Member/" +
                string.Join(",", memberId) +
                "/Play/",
                new Dictionary<string, object>()
                {
                    { "url", url } , 
                    {"is_voice_request", true},
                    {"callback_url", callbackUrl},
                    {"callback_method", callbackMethod},
                }
            ).ConfigureAwait(false)).Result;
            await Task.WhenAll();
            result.Object.StatusCode = result.StatusCode;
            return result.Object;
        }
        #endregion

        #region StopPlayMember
        /// <summary>
        /// Stops playing audio to the member.
        /// </summary>
        /// <returns>The play member.</returns>
        /// <param name="conferenceName">Conference name.</param>
        /// <param name="memberId">Member identifier.</param>
        public ConferenceMemberActionResponse StopPlayMember(
            string conferenceName, List<string> memberId)
        {
            return ExecuteWithExceptionUnwrap(() =>
            {
                var result = Task.Run(async () => await
                    Client.Delete<ConferenceMemberActionResponse>(
                        Uri +
                        conferenceName +
                        "/Member/" +
                        string.Join(",", memberId) +
                        "/Play/",
                        new Dictionary<string, object> () { {"is_voice_request", true} }
                    ).ConfigureAwait(false)).Result;
                result.Object.StatusCode = result.StatusCode;
                return result.Object;
            });
        }
        /// <summary>
        /// Asynchronously stops playing audio to the member.
        /// </summary>
        /// <returns>The play member.</returns>
        /// <param name="conferenceName">Conference name.</param>
        /// <param name="memberId">Member identifier.</param>
        /// <param name="callbackUrl">Callback URL.</param>
        /// <param name="callbackMethod">Callback Method.</param>
        public async Task<ConferenceMemberActionResponse> StopPlayMemberAsync(
            string conferenceName, List<string> memberId, string callbackUrl = null, string callbackMethod = null)
        {
            var result = Task.Run(async () => await
                Client.Delete<ConferenceMemberActionResponse>(
                    Uri +
                    conferenceName +
                    "/Member/" +
                    string.Join(",", memberId) +
                    "/Play/",
                    new Dictionary<string, object> ()
                    {
                        {"callback_url", callbackUrl},
                        {"callback_method", callbackMethod},
                        {"is_voice_request", true}
                    }
                ).ConfigureAwait(false)).Result;
            await Task.WhenAll();
            result.Object.StatusCode = result.StatusCode;
            return result.Object;
        }
        #endregion

        #region SpeakMember
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
            var mandatoryParams = new List<string> { "" };
            bool isVoiceRequest = true;
            var data = CreateData(
                mandatoryParams,
                new
                {
                    text,
                    voice,
                    language,
                    isVoiceRequest
                });

            return ExecuteWithExceptionUnwrap(() =>
            {
                var result = Task.Run(async () => await Client.Update<ConferenceMemberActionResponse>(
                        Uri +
                        conferenceName +
                        "/Member/" +
                        string.Join(",", memberId) +
                        "/Speak/",
                        data
                    ).ConfigureAwait(false)).Result;
                result.Object.StatusCode = result.StatusCode;
                return result.Object;
            });
        }
        /// <summary>
        /// Asynchronously speaks text to the member.
        /// </summary>
        /// <returns>The member.</returns>
        /// <param name="conferenceName">Conference name.</param>
        /// <param name="memberId">Member identifier.</param>
        /// <param name="text">Text.</param>
        /// <param name="voice">Voice.</param>
        /// <param name="language">Language.</param>
        /// <param name="callbackUrl">Callback URL.</param>
        /// <param name="callbackMethod">Callback Method.</param>
        public async Task<ConferenceMemberActionResponse> SpeakMemberAsync(
            string conferenceName, List<string> memberId, string text,
            string voice = null, string language = null, 
            string callbackUrl = null, string callbackMethod = null)
        {
            var mandatoryParams = new List<string> { "" };
            bool isVoiceRequest = true;
            var data = CreateData(
                mandatoryParams,
                new
                {
                    text,
                    voice,
                    language,
                    callbackUrl,
                    callbackMethod,
                    isVoiceRequest
                });
            var result = Task.Run(async () => await Client.Update<ConferenceMemberActionResponse>(
                Uri +
                conferenceName +
                "/Member/" +
                string.Join(",", memberId) +
                "/Speak/",
                data
            ).ConfigureAwait(false)).Result;
            await Task.WhenAll();
            result.Object.StatusCode = result.StatusCode;
            return result.Object;
        }
        #endregion

        #region StopSpeakMember
        /// <summary>
        /// Stops speaking text to the member.
        /// </summary>
        /// <returns>The speak member.</returns>
        /// <param name="conferenceName">Conference name.</param>
        /// <param name="memberId">Member identifier.</param>
        public ConferenceMemberActionResponse StopSpeakMember(
            string conferenceName, List<string> memberId)
        {
            return ExecuteWithExceptionUnwrap(() =>
            {
                var result = Task.Run(async () => await Client.Delete<ConferenceMemberActionResponse>(
                        Uri +
                        conferenceName +
                        "/Member/" +
                        string.Join(",", memberId) +
                        "/Speak/",
                        new Dictionary<string, object> () { {"is_voice_request", true} }).ConfigureAwait(false))
                        .Result;
                result.Object.StatusCode = result.StatusCode;
                return result.Object;
            });
        }
        /// <summary>
        /// Asynchronously stops speaking text to the member.
        /// </summary>
        /// <returns>The speak member.</returns>
        /// <param name="conferenceName">Conference name.</param>
        /// <param name="memberId">Member identifier.</param>
        /// <param name="callbackUrl">Callback URL.</param>
        /// <param name="callbackMethod">Callback Method.</param>
        public async Task<ConferenceMemberActionResponse> StopSpeakMemberAsync(
            string conferenceName, List<string> memberId,
            string callbackUrl = null, string callbackMethod = null)
        {
            var result = Task.Run(async () => await Client.Delete<ConferenceMemberActionResponse>(
                    Uri +
                    conferenceName +
                    "/Member/" +
                    string.Join(",", memberId) +
                    "/Speak/",
                    new Dictionary<string, object> ()
                    {
                        {"callback_url", callbackUrl},
                        {"callback_method", callbackMethod},
                        {"is_voice_request", true}
                    }).ConfigureAwait(false))
                .Result;
            await Task.WhenAll();
            result.Object.StatusCode = result.StatusCode;
            return result.Object;
        }
        #endregion

        #region DeafMember
        /// <summary>
        /// Deafs the member.
        /// </summary>
        /// <returns>The member.</returns>
        /// <param name="conferenceName">Conference name.</param>
        /// <param name="memberId">Member identifier.</param>
        public ConferenceMemberActionResponse DeafMember(
            string conferenceName, List<string> memberId)
        {
            return ExecuteWithExceptionUnwrap(() =>
            {
                var result = Task.Run(async () => await Client.Update<ConferenceMemberActionResponse>(
                        Uri +
                        conferenceName +
                        "/Member/" +
                        string.Join(",", memberId) +
                        "/Deaf/",
                        new Dictionary<string, object> () { {"is_voice_request", true} }
                    ).ConfigureAwait(false)).Result;
                result.Object.StatusCode = result.StatusCode;
                return result.Object;
            });
        }
        /// <summary>
        /// Asynchronously deafs the member.
        /// </summary>
        /// <returns>The member.</returns>
        /// <param name="conferenceName">Conference name.</param>
        /// <param name="memberId">Member identifier.</param>
        /// <param name="callbackUrl">Callback URL.</param>
        /// <param name="callbackMethod">Callback Method.</param>
        public async Task<ConferenceMemberActionResponse> DeafMemberAsync(
            string conferenceName, List<string> memberId,
            string callbackUrl = null, string callbackMethod = null)
        {
            var result = Task.Run(async () => await Client.Update<ConferenceMemberActionResponse>(
                Uri +
                conferenceName +
                "/Member/" +
                string.Join(",", memberId) +
                "/Deaf/",
                new Dictionary<string, object> ()
                {
                    {"callback_url", callbackUrl},
                    {"callback_method", callbackMethod},
                    {"is_voice_request", true}
                }
            ).ConfigureAwait(false)).Result;
            await Task.WhenAll();
            result.Object.StatusCode = result.StatusCode;
            return result.Object;
        }
        #endregion

        #region UnDeafMember
        /// <summary>
        /// Enables hearing of the member.
        /// </summary>
        /// <returns>The deaf member.</returns>
        /// <param name="conferenceName">Conference name.</param>
        /// <param name="memberId">Member identifier.</param>
        public ConferenceMemberActionResponse UnDeafMember(
            string conferenceName, List<string> memberId)
        {
            return ExecuteWithExceptionUnwrap(() =>
            {
                var result = Task.Run(async () => await Client.Delete<ConferenceMemberActionResponse>(
                        Uri +
                        conferenceName +
                        "/Member/" +
                        string.Join(",", memberId) +
                        "/Deaf/",
                        new Dictionary<string, object> () { {"is_voice_request", true} }
                    ).ConfigureAwait(false)).Result;
                try{
                    result.Object.StatusCode = result.StatusCode;
                }
                catch (System.NullReferenceException){

                }

                return result.Object;
            });
        }
        public async Task<ConferenceMemberActionResponse> UnDeafMemberAsync(
         string conferenceName, List<string> memberId,
         string callbackUrl = null, string callbackMethod = null)
        {
            var result = Task.Run(async () => await Client.Delete<ConferenceMemberActionResponse>(
                Uri +
                conferenceName +
                "/Member/" +
                string.Join(",", memberId) +
                "/Deaf/",
                new Dictionary<string, object> ()
                {
                    {"callback_url", callbackUrl},
                    {"callback_method", callbackMethod},
                    {"is_voice_request", true}
                }
            ).ConfigureAwait(false)).Result;
            await Task.WhenAll();
            result.Object.StatusCode = result.StatusCode;
            return result.Object;
        }
        #endregion

        #region StartRecording
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
            string transcriptionMethod = null, string callbackUrl = null,
            string callbackMethod = null)
        {
            var mandatoryParams = new List<string> { "" };
            bool isVoiceRequest = true;
            var data = CreateData(
                mandatoryParams, new
                {
                    fileFormat,
                    transcriptionType,
                    transcriptionUrl,
                    transcriptionMethod,
                    callbackUrl,
                    callbackMethod,
                    isVoiceRequest
                });

            return ExecuteWithExceptionUnwrap(() =>
            {
                var result = Task.Run(async () => await Client.Update<RecordCreateResponse<Conference>>(
                        Uri + conferenceName + "/Record/",
                        data
                    ).ConfigureAwait(false)).Result;
                result.Object.StatusCode = result.StatusCode;
                return result.Object;
            });
        }
        /// <summary>
        /// Asynchronously starts the recording.
        /// </summary>
        /// <returns>The recording.</returns>
        /// <param name="conferenceName">Conference name.</param>
        /// <param name="fileFormat">File format.</param>
        /// <param name="transcriptionType">Transcription type.</param>
        /// <param name="transcriptionUrl">Transcription URL.</param>
        /// <param name="transcriptionMethod">Transcription method.</param>
        /// <param name="callbackUrl">Callback URL.</param>
        /// <param name="callbackMethod">Callback method.</param>
        public async Task<RecordCreateResponse<Conference>> StartRecordingAsync(
            string conferenceName, string fileFormat = null,
            string transcriptionType = null, string transcriptionUrl = null,
            string transcriptionMethod = null, string callbackUrl = null,
            string callbackMethod = null)
        {
            var mandatoryParams = new List<string> { "" };
            bool isVoiceRequest = true;
            var data = CreateData(
                mandatoryParams, new
                {
                    fileFormat,
                    transcriptionType,
                    transcriptionUrl,
                    transcriptionMethod,
                    callbackUrl,
                    callbackMethod,
                    isVoiceRequest
                });

            var result = Task.Run(async () => await Client.Update<RecordCreateResponse<Conference>>(
                Uri + conferenceName + "/Record/",
                data
            ).ConfigureAwait(false)).Result;
            await Task.WhenAll();
            result.Object.StatusCode = result.StatusCode;
            return result.Object;
        }
        #endregion

        #region StopRecording
        /// <summary>
        /// Stops the recording.
        /// </summary>
        /// <param name="conferenceName">Conference name.</param>
        public void StopRecording(
            string conferenceName)
        {
            ExecuteWithExceptionUnwrap(() =>
            {
                Task.Run(async () => await Client.Delete<object>(
                    Uri + conferenceName + "/Record/",
                    new Dictionary<string, object> () { {"is_voice_request", true} }
                ).ConfigureAwait(false)).Wait();
            });
        }
        /// <summary>
        /// Asynchronously stops the recording.
        /// </summary>
        /// <param name="conferenceName">Conference name.</param>
        /// <param name="callbackUrl">Callback URL.</param>
        /// <param name="callbackMethod">Callback method.</param>
        public async Task StopRecordingAsync(
         string conferenceName, string callbackUrl = null,
         string callbackMethod = null)
        {
            Task.Run(async () => await Client.Delete<object>(
                Uri + conferenceName + "/Record/",
                new Dictionary<string, object> ()
                {
                    {"callback_url", callbackUrl},
                    {"callback_method", callbackMethod},
                    {"is_voice_request", true}
                }
            ).ConfigureAwait(false)).Wait();
            await Task.WhenAll();
        }
        #endregion
    }
}