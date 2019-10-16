using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Plivo.Client;


namespace Plivo.Resource.Message
{
    /// <summary>
    /// Message interface.
    /// </summary>
    public class MessageInterface : ResourceInterface
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:plivo.Resource.Message.MessageInterface"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        public MessageInterface(HttpClient client) : base(client)
        {
            Uri = "Account/" + Client.GetAuthId() + "/Message/";
        }

        #region Create
        /// <summary>
        /// Create Message with the specified src, dst, text, type, url, method , log, media_urls.
        /// </summary>
        /// <returns>The create.</returns>
        /// <param name="src">Source.</param>
        /// <param name="dst">Dst.</param>
        /// <param name="text">Text.</param>
        /// <param name="type">Type.</param>
        /// <param name="url">URL.</param>
        /// <param name="method">Method.</param>
        /// <param name="log">Log.</param>
        /// <param name="trackable">trackable.</param>
        /// <param name="powerpackUUID">powerpackUUID</param>
        ///<param name="media_urls">media_urls</param>
        public MessageCreateResponse Create(
            List<string> dst, string text = null, string src = null, string type = null,
            string url = null, string method = null, bool? log = null, bool? trackable = null, string powerpack_uuid = null, string[] media_urls = null)
        {
          
            string _dst = string.Join("<", dst);
			Dictionary<string, object> data = null; 
            var mandatoryParams = new List<string> {""};
            if (src != null && powerpack_uuid == null){
                data = CreateData(
                mandatoryParams,
                new
                {
                    src,
                    _dst,
                    text,
                    type,
                    url,
                    method,
                    log,
                    trackable,
                    media_urls
                });
            } else if (powerpack_uuid != null && src == null){
                data = CreateData(
                mandatoryParams,
                new
                {
                    powerpack_uuid,
                    _dst,
                    text,
                    type,
                    url,
                    method,
                    log,
                    trackable,
                    media_urls
                });
            

            } else if ( src != null && powerpack_uuid != null){
                return getResponseValidation ("Both powerpack_uuid and src cannot be specified. Specify either powerpack_uuid or src in request params to send a message.") ;
            } else if (src == null && powerpack_uuid == null){
                return getResponseValidation("Specify either powerpack_uuid or src in request params to send a message.");
            }

			return ExecuteWithExceptionUnwrap(() =>
			{
				var result = Task.Run(async () => await Client.Update<MessageCreateResponse>(Uri, data).ConfigureAwait(false)).Result;
				result.Object.StatusCode = result.StatusCode;
                return result.Object;
			});
        }

		/// <summary>
		/// Asynchronously Create Message with the specified src, dst, text, type, url, method and log, media_urls.
		/// </summary>
		/// <returns>The create.</returns>
		/// <param name="src">Source.</param>
		/// <param name="dst">Dst.</param>
		/// <param name="text">Text.</param>
		/// <param name="type">Type.</param>
		/// <param name="url">URL.</param>
		/// <param name="method">Method.</param>
		/// <param name="log">Log.</param>
		/// <param name="trackable">trackable.</param>
		/// <param name="powerpackUUID">powerpackUUID</param>
        ///<param name="media_urls">media_urls</param>
		public async Task<MessageCreateResponse> CreateAsync(
			List<string> dst, string text = null, string src = null, string type = null,
			string url = null, string method = null, bool? log = null, bool? trackable = null, string powerpack_uuid = null, string[] media_urls = null)
		{

			string _dst = string.Join("<", dst);
			Dictionary<string, object> data = null;
			var mandatoryParams = new List<string> { "" };
			if (src != null && powerpack_uuid == null)
			{
				data = CreateData(
				mandatoryParams,
				new
				{
					src,
					_dst,
					text,
					type,
					url,
					method,
					log,
					trackable,
                    media_urls
				});
			}
			else if (powerpack_uuid != null && src == null)
			{
				data = CreateData(
				mandatoryParams,
				new
				{
					powerpack_uuid,
					_dst,
					text,
					type,
					url,
					method,
					log,
					trackable,
                    media_urls
				});


			}
			else if (src != null && powerpack_uuid != null)
			{
				return getResponseValidation("Both powerpack_uuid and src cannot be specified. Specify either powerpack_uuid or src in request params to send a message.");
			}
			else if (src == null && powerpack_uuid == null)
			{
				return getResponseValidation("Specify either powerpack_uuid or src in request params to send a message.");
			}

			var result = await Client.Update<MessageCreateResponse>(Uri, data);
            result.Object.StatusCode = result.StatusCode;
			return result.Object;
		}

		#endregion

		#region getResponseValidation
		/// <summary>
		/// validation for src and powerpack id and return the repsonse.
		/// </summary>
		/// <returns>The get.</returns>
		/// <param name="errormessagetext">errormessagetext</param>
		private MessageCreateResponse getResponseValidation(string errorMessageText){

                MessageCreateResponse notValidResponse = new MessageCreateResponse();
                notValidResponse.ApiId = null;
                notValidResponse.Message = errorMessageText;
                notValidResponse.MessageUuid = new List<string>();
                return notValidResponse;
        }
        #endregion

        #region Get
        /// <summary>
        /// Get Message with the specified messageUuid.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="messageUuid">Message UUID.</param>
        public Message Get(string messageUuid)
        {
			return ExecuteWithExceptionUnwrap(() =>
			{
				var message = Task.Run(async () => await GetResource<Message>(messageUuid).ConfigureAwait(false)).Result;
				message.Interface = this;
				return message;
			});
        }
        /// <summary>
        /// Asynchronously get Message with the specified messageUuid.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="messageUuid">Message UUID.</param>
        public async Task<Message> GetAsync(string messageUuid)
        {
            var message = await GetResource<Message>(messageUuid);
            message.Interface = this;
            return message;
        }
        #endregion

        #region GetMedia
        public MMSMedia GetMedia(string messageUuid, string mediaID)
        {
            
        return ExecuteWithExceptionUnwrap(() => 
            {
            var mmsMedia = Task.Run(async () => await GetResource<MMSMedia>(messageUuid + "/Media/" + mediaID + "/").ConfigureAwait(false)).Result;
            mmsMedia.Interface = this;
            return mmsMedia;
        });
        }

        public async Task<MMSMedia> GetMediaAsync(string messageUuid, string mediaID)
        {
            var mmsMedia = await GetResource<MMSMedia>(messageUuid + "/Media/" + mediaID + "/");
            mmsMedia.Interface = this;
            return mmsMedia;
        }

        #endregion

        #region ListMedia

        public ListResponse<MMSMedia> ListMedia(string messageUuid){
            return ExecuteWithExceptionUnwrap(() =>
            {
                var resources = Task.Run(async () => await ListResources<ListResponse<MMSMedia>>(messageUuid + "/Media/", null).ConfigureAwait(false)).Result;

                resources.Objects.ForEach(
                    (obj) => obj.Interface = this
                );
                return resources;
            });
        }
        public async Task<ListResponse<MMSMedia>> ListMediaAsync(string messageUuid)
        {
            var resources = await ListResources<ListResponse<MMSMedia>>( messageUuid + "/Media/", null);

            resources.Objects.ForEach(
                (obj) => obj.Interface = this
            );

            return resources;

        }
        #endregion

        #region DeleteMedia
        public DeleteResponse<MMSMedia> DeleteMedia(string messageUuid)
        {
            return ExecuteWithExceptionUnwrap(() =>
            {
                var result = Task.Run(async () => await Client.Delete<DeleteResponse<MMSMedia>>(Uri + messageUuid + "/Media/").ConfigureAwait(false)).Result;
                try
                {
                    result.Object.StatusCode = result.StatusCode;
                }
                catch (System.NullReferenceException)
                {

                }
                return result.Object;
            });
        }
        public async Task<DeleteResponse<MMSMedia>> DeleteMediaAsync(string messageUuid)
        {
            var result = await Client.Delete<DeleteResponse<MMSMedia>>(Uri + messageUuid + "/Media/");
            try
            {
                result.Object.StatusCode = result.StatusCode;
            }
            catch (System.NullReferenceException)
            {

            }
            return result.Object;
        }

        #endregion

        #region List
        /// <summary>
        /// List Message with the specified subaccount, limit and offset.
        /// </summary>
        /// <returns>The list.</returns>
        /// <param name="subaccount">Subaccount.</param>
        /// <param name="limit">Limit.</param>
        /// <param name="offset">Offset.</param>
        /// <param name="message_state">MessageState.</param>
        /// <param name="message_direction">MessageDirection.</param>
        /// <param name="message_time__gt">MessageTimeGT.</param>
        /// <param name="message_time__gte">MessageTimeGTE.</param>
        /// <param name="message_time__lt">MessageTimeLT.</param>
        /// <param name="message_time__lte">MessageTimeLTE.</param>
        /// <param name="message_time">MessageTime.</param>
        /// <param name="error_code">ErrorCode.</param>
        public ListResponse<Message> List(
            string subaccount = null, 
            uint? limit = null, 
            uint? offset = null, 
            string message_state = null,
            string message_direction = null,
            DateTime? message_time__gt = null,
            DateTime? message_time__gte = null,
            DateTime? message_time__lt = null,
            DateTime? message_time__lte = null,
            DateTime? message_time = null,
            uint? error_code = null
            )
        {
            var _message_time__gt = message_time__gt?.ToString("yyyy-MM-dd HH':'mm':'ss''") ?? null;
            var _message_time__gte = message_time__gte?.ToString("yyyy-MM-dd HH':'mm':'ss''") ?? null;
            var _message_time__lt = message_time__lt?.ToString("yyyy-MM-dd HH':'mm':'ss''") ?? null;
            var _message_time__lte = message_time__lte?.ToString("yyyy-MM-dd HH':'mm':'ss''") ?? null;
            var _message_time = message_time?.ToString("yyyy-MM-dd HH':'mm':'ss''") ?? null;
            var mandatoryParams = new List<string> {""};
            var data = CreateData(
                mandatoryParams, new {
                    subaccount, 
                    limit, 
                    offset, 
                    message_state, 
                    message_direction, 
                    _message_time__gt, 
                    _message_time__gte, 
                    _message_time__lt, 
                    _message_time__lte, 
                    _message_time, 
                    error_code
                });

			return ExecuteWithExceptionUnwrap(() =>
			{
				var resources = Task.Run(async () => await ListResources<ListResponse<Message>>(data).ConfigureAwait(false)).Result;
                
				resources.Objects.ForEach(
					(obj) => obj.Interface = this
				);
				return resources;
			});
        }
        /// <summary>
        /// List Message with the specified subaccount, limit and offset.
        /// </summary>
        /// <returns>The list.</returns>
        /// <param name="subaccount">Subaccount.</param>
        /// <param name="limit">Limit.</param>
        /// <param name="offset">Offset.</param>
        /// <param name="message_state">MessageState.</param>
        /// <param name="message_direction">MessageDirection.</param>
        /// <param name="message_time__gt">MessageTimeGT.</param>
        /// <param name="message_time__gte">MessageTimeGTE.</param>
        /// <param name="message_time__lt">MessageTimeLT.</param>
        /// <param name="message_time__lte">MessageTimeLTE.</param>
        /// <param name="message_time">MessageTime.</param>
        /// <param name="error_code">ErrorCode.</param>
        public async Task<ListResponse<Message>> ListAsync(
            string subaccount = null,
            uint? limit = null,
            uint? offset = null,
            string message_state = null,
            string message_direction = null,
            DateTime? message_time__gt = null,
            DateTime? message_time__gte = null,
            DateTime? message_time__lt = null,
            DateTime? message_time__lte = null,
            DateTime? message_time = null,
            uint? error_code = null
            )
        {
            var _message_time__gt = message_time__gt?.ToString("yyyy-MM-dd HH':'mm':'ss''") ?? null;
            var _message_time__gte = message_time__gte?.ToString("yyyy-MM-dd HH':'mm':'ss''") ?? null;
            var _message_time__lt = message_time__lt?.ToString("yyyy-MM-dd HH':'mm':'ss''") ?? null;
            var _message_time__lte = message_time__lte?.ToString("yyyy-MM-dd HH':'mm':'ss''") ?? null;
            var _message_time = message_time?.ToString("yyyy-MM-dd HH':'mm':'ss''") ?? null;
            var mandatoryParams = new List<string> { "" };
            var data = CreateData(
                mandatoryParams, new
                {
                    subaccount,
                    limit,
                    offset,
                    message_state,
                    message_direction,
                    _message_time__gt,
                    _message_time__gte,
                    _message_time__lt,
                    _message_time__lte,
                    _message_time,
                    error_code
                });
            var resources = await ListResources<ListResponse<Message>>(data);

            resources.Objects.ForEach(
                (obj) => obj.Interface = this
            );

            return resources;
        }
        #endregion
    }
}
