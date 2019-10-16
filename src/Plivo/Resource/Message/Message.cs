using System.Threading.Tasks;
namespace Plivo.Resource.Message
{
    /// <summary>
    /// Message.
    /// </summary>
    public class Message : Resource
    {
        public new string Id => MessageUuid;

        /// <summary>
        /// Gets or sets the error code.
        /// </summary>
        /// <value>The error code.</value>
        public string ErrorCode { get; set; }

        /// <summary>
        /// Gets or sets from number.
        /// </summary>
        /// <value>From number.</value>
        public string FromNumber { get; set; }

        /// <summary>
        /// Gets or sets the message direction.
        /// </summary>
        /// <value>The message direction.</value>
        public string MessageDirection { get; set; }

        /// <summary>
        /// Gets or sets the state of the message.
        /// </summary>
        /// <value>The state of the message.</value>
        public string MessageState { get; set; }

        /// <summary>
        /// Gets or sets the message time.
        /// </summary>
        /// <value>The message time.</value>
        public string MessageTime { get; set; }

        /// <summary>
        /// Gets or sets the type of the message.
        /// </summary>
        /// <value>The type of the message.</value>
        public string MessageType { get; set; }

        /// <summary>
        /// Gets or sets the message UUID.
        /// </summary>
        /// <value>The message UUID.</value>
        public string MessageUuid { get; set; }

        /// <summary>
        /// Gets or sets the resource URI.
        /// </summary>
        /// <value>The resource URI.</value>
        public string ResourceUri { get; set; }

        /// <summary>
        /// Gets or sets the To number.
        /// </summary>
        /// <value>The To number.</value>
        public string ToNumber { get; set; }

        /// <summary>
        /// Gets or sets the total amount.
        /// </summary>
        /// <value>The total amount.</value>
        public string TotalAmount { get; set; }

        /// <summary>
        /// Gets or sets the total rate.
        /// </summary>
        /// <value>The total rate.</value>
        public string TotalRate { get; set; }

        /// <summary>
        /// Gets or sets the units.
        /// </summary>
        /// <value>The units.</value>
        public uint Units { get; set; }

        public override string ToString()
        {
            return "\n" +
                    "StatusCode: " + StatusCode +"\n" +
                    "ErrorCode: " + ErrorCode + "\n" + 
                   "FromNumber: " + FromNumber + "\n" +
                   "MessageDirection: " + MessageDirection + "\n" +
                   "MessageState: " + MessageState + "\n" +
                   "MessageTime: " + MessageTime + "\n" +
                   "MessageType: " + MessageType + "\n" +
                   "MessageUuid: " + MessageUuid + "\n" +
                   "ResourceUri: " + ResourceUri + "\n" +
                   "ToNumber: " + ToNumber + "\n" +
                   "TotalAmount: " + TotalAmount + "\n" +
                   "TotalRate: " + TotalRate + "\n" +
                   "Units: " + Units + "\n";
        }
        #region GetMedia
        /// <summary>
        /// Get the media resource.
        /// </summary>
        /// <returns>The Media.</returns>
        public MMSMedia GetMedia(string mediaId)
        {
            return ((MessageInterface)Interface)
                    .GetMedia(Id, mediaId);
        }

        public async Task<MMSMedia> GetMediaAsync(string mediaId)
        {
            return await ((MessageInterface)Interface)
                .GetMediaAsync(Id, mediaId);
        }
        #endregion 

        #region ListMedia
        /// <summary>
        /// List the media resource.
        /// </summary>
        /// <returns>The List of Media.</returns>
        public ListResponse<MMSMedia> ListMedia(){
            return ((MessageInterface)Interface)
                   .ListMedia(Id);
        }
        public async Task<ListResponse<MMSMedia>> ListMediaAsync(string mediaId)
        {
            return await ((MessageInterface)Interface)
                .ListMediaAsync(Id);
        }
        #endregion

        #region DeleteMedia
        /// <summary>
        /// Delete the media resource.
        /// </summary>
        /// <returns>The status code .</returns>

        public DeleteResponse<MMSMedia> DeleteMedia(){
            return ((MessageInterface)Interface)
                               .DeleteMedia(Id);
        }
        public async Task<DeleteResponse<MMSMedia>> DeleteMediaAsync()
        {
            return await ((MessageInterface)Interface)
                .DeleteMediaAsync(Id);
        }
        #endregion
    }
}