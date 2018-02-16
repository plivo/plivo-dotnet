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
        public MessageCreateResponse Create(
            string src, List<string> dst, string text, string type = null,
            string url = null, string method = null, bool? log = null)
        {
            string _dst = string.Join("<", dst);
            var mandatoryParams = new List<string> {""};
            var data = CreateData(
                mandatoryParams,
                new
                {
                    src,
                    _dst,
                    text,
                    type,
                    url,
                    method,
                    log
                });
            return Client.Update<MessageCreateResponse>(Uri, data).Object;
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
        public ListResponse<Message> List(
            string subaccount = null, uint? limit = null, uint? offset = null)
        {
            var mandatoryParams = new List<string> {""};
            var data = CreateData(
                mandatoryParams, new {subaccount, limit, offset});
            var resources = ListResources<ListResponse<Message>>(data);

            resources.Objects.ForEach(
                (obj) => obj.Interface = this
            );

            return resources;
        }
    }
}