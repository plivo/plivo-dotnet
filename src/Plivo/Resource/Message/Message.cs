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
        

        /// <summary>
        /// Gets or sets the powerpack id.
        /// </summary>
        /// <value>The powerpack id.</value>
        public string PowerpackId { get; set; }

        /// <summary>
        /// Gets or sets the tendlc_campaign_id.
        /// </summary>
        /// <value>The TendlcCampaignId.</value>
        public string TendlcCampaignId { get; set; }

        /// <summary>
        /// Gets or sets the TendlcRegistrationStatus.
        /// </summary>
        /// <value>The tendlc_registration_status.</value>
        public string TendlcRegistrationStatus { get; set; }

        /// <summary>
        /// Gets or sets the destination_country_iso2.
        /// </summary>
        /// <value>The destination_country_iso2.</value>
        public string DestinationCountryIso2 { get; set; }

        /// <summary>
        /// Gets or sets the destination_network.
        /// </summary>
        /// <value>The destination_network.</value>
        public string DestinationNetwork { get; set; }

        /// <summary>
        /// Gets or sets the carrier_fees_rate.
        /// </summary>
        /// <value>The carrier_fees_rate.</value>
        public string CarrierFeesRate { get; set; }


        /// <summary>
        /// Gets or sets the carrier_fees.
        /// </summary>
        /// <value>The carrier_fees.</value>
        public string CarrierFees { get; set; }

        /// <summary>
        /// Gets or sets the requester ip.
        /// </summary>
        /// <value>The requester ip.</value>
        public string RequesterIp { get; set; }

        /// <summary>
        /// Gets or sets the is domestic.
        /// </summary>
        /// <value>The is domestic.</value>
        public bool? IsDomestic { get; set; }

        /// <summary>
        /// Gets or sets the replaced sender.
        /// </summary>
        /// <value> The replaced sender.</value>
        public string ReplacedSender { get; set; }

        /// <summary>
        /// Gets or sets the dlt entity id.
        /// </summary>
        /// <value> DLT Entity ID.</value>
        public string DltEntityId { get; set; }

        /// <summary>
        /// Gets or sets the dlt template id.
        /// </summary>
        /// <value> DLT Template ID.</value>
        public string DltTemplateId { get; set; }

        /// <summary>
        /// Gets or sets the dlt template category.
        /// </summary>
        /// <value> DLT Template Category.</value>
        public string DltTemplateCategory { get; set; }

        /// <summary>
        /// Gets or sets the conversation id.
        /// </summary>
        /// <value>The conversation id.</value>
        public string ConversationId { get; set; }

        /// <summary>
        /// Gets or sets the conversation origin.
        /// </summary>
        /// <value>The conversation origin.</value>
        public string ConversationOrigin { get; set; }

        /// <summary>
        /// Gets or sets the conversation expiration timestamp.
        /// </summary>
        /// <value>The conversation expiration timestamp.</value>
        public string ConversationExpirationTimestamp { get; set; }

        public override string ToString()
        {
            return "\n" +
                    "StatusCode: " + StatusCode + "\n" +
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
                   "PowerpackID: " + PowerpackId + "\n" +
                   "Units: " + Units + "\n" +
                   "DestinationCountryIso2: " + DestinationCountryIso2 + "\n" +
                   "TendlcCampaignId: " + TendlcCampaignId + "\n" +
                   "TendlcRegistrationStatus: "+ TendlcRegistrationStatus + "\n" +
                   "RequesterIP: " + RequesterIp + "\n" +
                   "IsDomestic: " + IsDomestic + "\n" +
                   "DestinationNetwork: " + DestinationNetwork + "\n" +
                   "CarrierFeesRate: " + CarrierFeesRate + "\n" +
                   "CarrierFees: " + CarrierFees + "\n" +
                   "ReplacedSender: " + ReplacedSender + "\n" +
                   "DLTEntityID: " + DltEntityId + "\n" +
                   "DLTTemplateID: " + DltTemplateId + "\n" +
                   "DLTTemplateCategory: " + DltTemplateCategory + "\n" +
                   "ConversationID: " + ConversationId + "\n" +
                   "ConversationOrigin: " + ConversationOrigin + "\n" +
                   "ConversationExpirationTimestamp: " + ConversationExpirationTimestamp + "\n";
        }
        #region ListMedia
        /// <summary>
        /// List the media resource.
        /// </summary>
        /// <returns>The List of Media.</returns>
        public ListResponse<MMSMedia> ListMedia()
        {
            return ((MessageInterface)Interface)
                   .ListMedia(Id);
        }
        public async Task<ListResponse<MMSMedia>> ListMediaAsync(string mediaId)
        {
            return await ((MessageInterface)Interface)
                .ListMediaAsync(Id);
        }
        #endregion

    }
}
