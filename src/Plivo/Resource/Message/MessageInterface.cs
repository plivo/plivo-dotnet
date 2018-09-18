using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        /// <summary>
        /// Create Message with the specified src, dst, text, type, url, method and log.
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
        public MessageCreateResponse Create(
            List<string> dst, string text, string type = null,string src = null,
            string url = null, string method = null, bool? log = null, bool? trackable = null, string powerpackUUID = null)
        {
          
            string _dst = string.Join("<", dst);
            var data = (dynamic)null; 
            var mandatoryParams = new List<string> {""};
            if (src != null && powerpackUUID == null){
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
                    trackable
                });
            } else if (powerpackUUID != null && src == null){
                data = CreateData(
                mandatoryParams,
                new
                {
                    powerpackUUID,
                    _dst,
                    text,
                    type,
                    url,
                    method,
                    log,
                    trackable
                });
            

            } else if ( src != null && powerpackUUID != null){
                return getResponseValidation ("Both powerpack_uuid and src cannot be specified. Specify either powerpack_uuid or src in request params to send a message.") ;
            } else if (src == null && powerpackUUID == null){
                return getResponseValidation("Specify either powerpack_uuid or src in request params to send a message.");
            }
            return Client.Update<MessageCreateResponse>(Uri, data).Object;
        }

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

        /// <summary>
        /// Get Message with the specified messageUuid.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="messageUuid">Message UUID.</param>
        public Message Get(string messageUuid)
        {
            var message = GetResource<Message>(messageUuid);
            message.Interface = this;
            return message;
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
            var resources = ListResources<ListResponse<Message>>(data);

            resources.Objects.ForEach(
                (obj) => obj.Interface = this
            );

            return resources;
        }
    }
}
