using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Plivo.Client;
using Newtonsoft.Json;


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
        /// Create Message with the specified src, dst, text, type, url, method , log, media_urls, media_ids.
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
        /// <param name="media_urls">media_urls</param>
        /// <param name="media_ids">media_ids</param>
        /// <param name="dlt_entity_id">dlt_entity_id</param>
        /// <param name="dlt_template_id">dlt_template_id</param>
        /// <param name="dlt_template_category">dlt_template_category</param>
        /// <param name="template">template</param>
        /// <param name="template_json_string">template_json_string</param>
        /// <param name="interactive">interactive</param>
        /// <param name="interactive_json_string">interactive_json_string</param>
        /// <param name="location">location</param>
        /// <param name="location_json_string">location_json_string</param>
        public MessageCreateResponse Create(
            List<string> dst, string text = null, string src = null, string type = null,
            string url = null, string method = null, object log = null, bool? trackable = null,
            string powerpack_uuid = null, string[] media_urls = null, string[] media_ids = null,
            string dlt_entity_id = null, string dlt_template_id = null, string dlt_template_category = null,
             Template template = null, string template_json_string = null,
             Interactive interactive = null, string interactive_json_string = null,
             Location location = null, string location_json_string = null)
        {
            // Check if log is a boolean
            string logString="";
            if (log is bool)
            {
                bool logValue = (bool)log;
                logString = logValue ? "true" : "false";
            }
            // Check if log is a string
            else if (log is string)
            {
                logString = (string)log;
            }
            else if (log != null)
            {
                throw new ArgumentException("Invalid type for log parameter. Expected boolean or string.");
            }
            log = logString;

            string _dst = string.Join("<", dst);
            Dictionary<string, object> data = null;
            var mandatoryParams = new List<string> { "" };
            // Adding validations for whatsapp cases with template passed
            if (template_json_string != null && template != null)
            {
                return getResponseValidation("Template parameter is already set.");
            }
            else 
            {
                if (template_json_string != null)
                {
                    var settings = new JsonSerializerSettings{NullValueHandling = NullValueHandling.Ignore};
                    template = JsonConvert.DeserializeObject<Template>(template_json_string, settings);
                }
            }
            if (template != null && ( template.Name == null || template.Name.Length == 0))
            {
                return getResponseValidation("Template name must not be null or empty.");
            }
            if (template != null && ( template.Language == null || template.Language.Length == 0 ))
            {
                return getResponseValidation("Template language must not be null or empty.");
            }
            if (interactive_json_string != null && interactive != null)
            {
                return getResponseValidation("Interactive parameter is already set.");
            }
            else 
            {
                if (interactive_json_string != null)
                {
                    var settings = new JsonSerializerSettings{NullValueHandling = NullValueHandling.Ignore};
                    interactive = JsonConvert.DeserializeObject<Interactive>(interactive_json_string, settings);
                }
            }
            if (location_json_string != null && location != null)
            {
                return getResponseValidation("Location parameter is already set.");
            }
            else 
            {
                if (location_json_string != null)
                {
                    var settings = new JsonSerializerSettings{NullValueHandling = NullValueHandling.Ignore};
                    location = JsonConvert.DeserializeObject<Location>(location_json_string, settings);
                }
            }
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
                    media_urls,
                    media_ids,
                    dlt_entity_id,
                    dlt_template_id,
                    dlt_template_category,
                    template,
                    interactive,
                    location
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
                    media_urls,
                    media_ids,
                    dlt_entity_id,
                    dlt_template_id,
                    dlt_template_category
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
        ///<param name="media_ids">media_ids</param>
        /// <param name="dlt_entity_id">dlt_entity_id</param>
        /// <param name="dlt_template_id">dlt_template_id</param>
        /// <param name="dlt_template_category">dlt_template_category</param>
        /// <param name="template">template</param>
        /// <param name="template_json_string">template_json_string</param>
        /// <param name="interactive">interactive</param>
        /// <param name="interactive_json_string">interactive_json_string</param>
        /// <param name="location">location</param>
        /// <param name="location_json_string">location_json_string</param>
        public async Task<MessageCreateResponse> CreateAsync(
            List<string> dst, string text = null, string src = null, string type = null,
            string url = null, string method = null, object log = null, bool? trackable = null,
            string powerpack_uuid = null, string[] media_urls = null, string[] media_ids = null,
            string dlt_entity_id = null, string dlt_template_id = null, string dlt_template_category = null, 
            Template template = null, string template_json_string = null, 
            Interactive interactive = null, string interactive_json_string = null,
            Location location = null, string location_json_string = null)
        {
            // Check if log is a boolean
            string logString="";
            if (log is bool)
            {
                bool logValue = (bool)log;
                logString = logValue ? "true" : "false";
            }
            // Check if log is a string
            else if (log is string)
            {
                logString = (string)log;
            }
            else if (log != null)
            {
                throw new ArgumentException("Invalid type for log parameter. Expected boolean or string.");
            }
            log = logString;


            string _dst = string.Join("<", dst);
            Dictionary<string, object> data = null;
            var mandatoryParams = new List<string> { "" };
            // Adding validations for whatsapp cases with template passed
            if (template_json_string != null && template != null)
            {
                return getResponseValidation("Template parameter is already set.");
            }
            else 
            {
                if (template_json_string != null)
                {
                    var settings = new JsonSerializerSettings{NullValueHandling = NullValueHandling.Ignore};
                    template = JsonConvert.DeserializeObject<Template>(template_json_string, settings);
                }
            }
            if (template != null && ( template.Name == null || template.Name.Length == 0))
            {
                return getResponseValidation("Template name must not be null or empty.");
            }
            if (template != null && ( template.Language == null || template.Language.Length == 0 ))
            {
                return getResponseValidation("Template language must not be null or empty.");
            }
            if (interactive_json_string != null && interactive != null)
            {
                return getResponseValidation("Interactive parameter is already set.");
            }
            else 
            {
                if (interactive_json_string != null)
                {
                    var settings = new JsonSerializerSettings{NullValueHandling = NullValueHandling.Ignore};
                    interactive = JsonConvert.DeserializeObject<Interactive>(interactive_json_string, settings);
                }
            }
            if (location_json_string != null && location != null)
            {
                return getResponseValidation("Location parameter is already set.");
            }
            else 
            {
                if (location_json_string != null)
                {
                    var settings = new JsonSerializerSettings{NullValueHandling = NullValueHandling.Ignore};
                    location = JsonConvert.DeserializeObject<Location>(location_json_string, settings);
                }
            }
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
                    media_urls,
                    media_ids,
                    dlt_entity_id,
                    dlt_template_id,
                    dlt_template_category,
                    template,
                    interactive,
                    location
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
                    media_urls,
                    media_ids,
                    dlt_entity_id,
                    dlt_template_id,
                    dlt_template_category
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
        
        //Handling dst(string)
        #region Create
        /// <summary>
        /// Create Message with the specified src, dst, text, type, url, method , log, media_urls, media_ids.
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
        ///<param name="media_ids">media_ids</param>
        ///<param name="message_expiry">message_expiry</param>
        /// <param name="dlt_entity_id">dlt_entity_id</param>
        /// <param name="dlt_template_id">dlt_template_id</param>
        /// <param name="dlt_template_category">dlt_template_category</param>
        /// <param name="template">template</param>
        /// <param name="template_json_string">template_json_string</param>
        /// <param name="interactive">interactive</param>
        /// <param name="interactive_json_string">interactive_json_string</param>
        /// <param name="location">location</param>
        /// <param name="location_json_string">location_json_string</param>
        public MessageCreateResponse Create(
            string dst, string text = null, string src = null, string type = null,
            string url = null, string method = null, object log = null, bool? trackable = null,
            string powerpack_uuid = null, string[] media_urls = null, string[] media_ids = null,
            uint? message_expiry = null, string dlt_entity_id = null, string dlt_template_id = null,
            string dlt_template_category = null, 
            Template template = null, string template_json_string = null, 
            Interactive interactive = null, string interactive_json_string = null,
            Location location = null, string location_json_string = null)
        {
            string logString="";
            if (log is bool)
            {
                bool logValue = (bool)log;
                logString = logValue ? "true" : "false";
            }
            // Check if log is a string
            else if (log is string)
            {
                logString = (string)log;
            }
            else if (log != null)
            {
                throw new ArgumentException("Invalid type for log parameter. Expected boolean or string.");
            }
            log = logString;
            string _dst = dst;
            Dictionary<string, object> data = null;
            var mandatoryParams = new List<string> { "" };
            // Adding validations for whatsapp cases with template passed
            if (template_json_string != null && template != null)
            {
                return getResponseValidation("Template parameter is already set.");
            }
            else 
            {
                if (template_json_string != null)
                {
                    var settings = new JsonSerializerSettings{NullValueHandling = NullValueHandling.Ignore};
                    template = JsonConvert.DeserializeObject<Template>(template_json_string, settings);
                }
            }
            if (template != null && ( template.Name == null || template.Name.Length == 0))
            {
                return getResponseValidation("Template name must not be null or empty.");
            }
            if (template != null && ( template.Language == null || template.Language.Length == 0 ))
            {
                return getResponseValidation("Template language must not be null or empty.");
            }
            if (interactive_json_string != null && interactive != null)
            {
                return getResponseValidation("Interactive parameter is already set.");
            }
            else 
            {
                if (interactive_json_string != null)
                {
                    var settings = new JsonSerializerSettings{NullValueHandling = NullValueHandling.Ignore};
                    interactive = JsonConvert.DeserializeObject<Interactive>(interactive_json_string, settings);
                }
            }
            if (location_json_string != null && location != null)
            {
                return getResponseValidation("Location parameter is already set.");
            }
            else 
            {
                if (location_json_string != null)
                {
                    var settings = new JsonSerializerSettings{NullValueHandling = NullValueHandling.Ignore};
                    location = JsonConvert.DeserializeObject<Location>(location_json_string, settings);
                }
            }
            if (src != null && powerpack_uuid == null)
            {
                data = CreateData(
                mandatoryParams,
                new
                {
                    src,
                    dst,
                    text,
                    type,
                    url,
                    method,
                    log,
                    trackable,
                    media_urls,
                    media_ids,
                    message_expiry,
                    dlt_entity_id,
                    dlt_template_id,
                    dlt_template_category,
                    template,
                    interactive,
                    location
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
                    media_urls,
                    media_ids,
                    message_expiry,
                    dlt_entity_id,
                    dlt_template_id,
                    dlt_template_category
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
        ///<param name="media_ids">media_ids</param>
        ///<param name="message_expiry">message_expiry</param>
        /// <param name="dlt_entity_id">dlt_entity_id</param>
        /// <param name="dlt_template_id">dlt_template_id</param>
        /// <param name="dlt_template_category">dlt_template_category</param>
        /// <param name="template">template</param>
        /// <param name="template_json_string">template</param>
        /// <param name="interactive">interactive</param>
        /// <param name="interactive_json_string">interactive_json_string</param>
        /// <param name="location">location</param>
        /// <param name="location_json_string">location_json_string</param>
        public async Task<MessageCreateResponse> CreateAsync(
            string dst, string text = null, string src = null, string type = null,
            string url = null, string method = null, object log = null, bool? trackable = null,
            string powerpack_uuid = null, string[] media_urls = null, string[] media_ids = null,
            uint? message_expiry = null, string dlt_entity_id = null, string dlt_template_id = null,
            string dlt_template_category = null, 
            Template template = null, string template_json_string = null, 
            Interactive interactive = null, string interactive_json_string = null,
            Location location = null, string location_json_string = null)
        {
            string logString="";
            if (log is bool)
            {
                bool logValue = (bool)log;
                logString = logValue ? "true" : "false";
            }
            // Check if log is a string
            else if (log is string)
            {
                logString = (string)log;
            }
            else if (log != null)
            {
                throw new ArgumentException("Invalid type for log parameter. Expected boolean or string.");
            }
            log = logString;
            string _dst = dst;
            Dictionary<string, object> data = null;
            var mandatoryParams = new List<string> { "" };
            // Adding validations for whatsapp cases with template passed
            // Adding validations for whatsapp cases with template passed
            if (template_json_string != null && template != null)
            {
                return getResponseValidation("Template parameter is already set.");
            }
            else 
            {
                if (template_json_string != null)
                {
                    var settings = new JsonSerializerSettings{NullValueHandling = NullValueHandling.Ignore};
                    template = JsonConvert.DeserializeObject<Template>(template_json_string, settings);
                }
            }
            if (template != null && ( template.Name == null || template.Name.Length == 0))
            {
                return getResponseValidation("Template name must not be null or empty.");
            }
            if (template != null && ( template.Language == null || template.Language.Length == 0 ))
            {
                return getResponseValidation("Template language must not be null or empty.");
            }
            if (interactive_json_string != null && interactive != null)
            {
                return getResponseValidation("Interactive parameter is already set.");
            }
            else 
            {
                if (interactive_json_string != null)
                {
                    var settings = new JsonSerializerSettings{NullValueHandling = NullValueHandling.Ignore};
                    interactive = JsonConvert.DeserializeObject<Interactive>(interactive_json_string, settings);
                }
            }
            if (location_json_string != null && location != null)
            {
                return getResponseValidation("Location parameter is already set.");
            }
            else 
            {
                if (location_json_string != null)
                {
                    var settings = new JsonSerializerSettings{NullValueHandling = NullValueHandling.Ignore};
                    location = JsonConvert.DeserializeObject<Location>(location_json_string, settings);
                }
            }
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
                    media_urls,
                    media_ids,
                    message_expiry,
                    dlt_entity_id,
                    dlt_template_id,
                    dlt_template_category,
                    template,
                    interactive,
                    location
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
                    media_urls,
                    media_ids,
                    message_expiry,
                    dlt_entity_id,
                    dlt_template_id,
                    dlt_template_category
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
        private MessageCreateResponse getResponseValidation(string errorMessageText)
        {

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

        #region ListMedia

        public ListResponse<MMSMedia> ListMedia(string messageUuid)
        {
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
            var resources = await ListResources<ListResponse<MMSMedia>>(messageUuid + "/Media/", null);

            resources.Objects.ForEach(
                (obj) => obj.Interface = this
            );

            return resources;

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
        /// <param name="from_number">FromNumber.</param>
        /// <param name="to_number">ToNumber.</param>
        /// <param name="message_state">MessageState.</param>
        /// <param name="message_type">MessageType.</param>
        /// <param name="message_direction">MessageDirection.</param>
        /// <param name="message_time__gt">MessageTimeGT.</param>
        /// <param name="message_time__gte">MessageTimeGTE.</param>
        /// <param name="message_time__lt">MessageTimeLT.</param>
        /// <param name="message_time__lte">MessageTimeLTE.</param>
        /// <param name="message_time">MessageTime.</param>
        /// <param name="error_code">ErrorCode.</param>
        /// <param name="powerpack_id">PowerpackID.</param>
        /// <param name="destination_country_iso2">DestinationCountryIso2.</param>
        /// <param name="tendlc_campaign_id">TendlcCampaignId.</param>
        /// <param name="tendlc_registration_status">TendlcRegistrationStatus.</param>
        /// <param name="conversation_id">ConversationID.</param>
        /// <param name="conversation_origin">ConversationOrigin.</param>
        public MessageListResponse<Message> List(
            string subaccount = null,
            uint? limit = null,
            uint? offset = null,
            string from_number = null,
            string to_number = null,
            string message_state = null,
            string message_type = null,
            string message_direction = null,
            DateTime? message_time__gt = null,
            DateTime? message_time__gte = null,
            DateTime? message_time__lt = null,
            DateTime? message_time__lte = null,
            DateTime? message_time = null,
            uint? error_code = null,
            string powerpack_id = null ,
            string tendlc_campaign_id = null,
            string destination_country_iso2 = null,
            string tendlc_registration_status = null,
            string conversation_id = null,
            string conversation_origin = null
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
                    from_number,
                    to_number,
                    message_state,
                    message_type,
                    message_direction,
                    _message_time__gt,
                    _message_time__gte,
                    _message_time__lt,
                    _message_time__lte,
                    _message_time,
                    error_code,
                    powerpack_id,
                    tendlc_campaign_id,
                    destination_country_iso2,
                    tendlc_registration_status,
                    conversation_id,
                    conversation_origin
                });

            return ExecuteWithExceptionUnwrap(() =>
            {
                var resources = Task.Run(async () => await ListResources<MessageListResponse<Message>>(data).ConfigureAwait(false)).Result;
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
        /// <param name="from_number">FromNumber.</param>
        /// <param name="to_number">ToNumber.</param>
        /// <param name="message_state">MessageState.</param>
        /// <param name="message_type">MessageType.</param>
        /// <param name="message_direction">MessageDirection.</param>
        /// <param name="message_time__gt">MessageTimeGT.</param>
        /// <param name="message_time__gte">MessageTimeGTE.</param>
        /// <param name="message_time__lt">MessageTimeLT.</param>
        /// <param name="message_time__lte">MessageTimeLTE.</param>
        /// <param name="message_time">MessageTime.</param>
        /// <param name="error_code">ErrorCode.</param>
        /// <param name="powerpack_id">PowerpackID.</param>
        /// <param name="destination_country_iso2">DestinationCountryIso2.</param>
        /// <param name="tendlc_campaign_id">TendlcCampaignID.</param>
        /// <param name="tendlc_registration_status">TendlcRegistrationStatus.</param>
        /// <param name="conversation_id">ConversationID.</param>
        /// <param name="conversation_origin">ConversationOrigin.</param>
        public async Task<MessageListResponse<Message>> ListAsync(
            string subaccount = null,
            uint? limit = null,
            uint? offset = null,
            string from_number = null,
            string to_number = null,
            string message_state = null,
            string message_type = null,
            string message_direction = null,
            DateTime? message_time__gt = null,
            DateTime? message_time__gte = null,
            DateTime? message_time__lt = null,
            DateTime? message_time__lte = null,
            DateTime? message_time = null,
            uint? error_code = null,
            string powerpack_id = null,
            string tendlc_campaign_id = null,
            string destination_country_iso2 = null,
            string tendlc_registration_status = null,
            string conversation_id = null,
            string conversation_origin = null
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
                    from_number,
                    to_number,
                    message_state,
                    message_type,
                    message_direction,
                    _message_time__gt,
                    _message_time__gte,
                    _message_time__lt,
                    _message_time__lte,
                    _message_time,
                    error_code,
                    powerpack_id,
                    tendlc_campaign_id,
                    destination_country_iso2,
                    tendlc_registration_status,
                    conversation_id,
                    conversation_origin
                });
            var resources = await ListResources<MessageListResponse<Message>>(data);
            resources.Objects.ForEach(
                (obj) => obj.Interface = this
            );

            return resources;
        }
        #endregion
    }

    // Template structure required for whatsapp messages
    public class Template
    {
        /// <summary>
        /// Gets or sets the name of the template.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the language of the template.
        /// </summary>
        [JsonProperty("language")]
        public string Language { get; set; }

        /// <summary>
        /// Gets or sets the list of components in the template.
        /// </summary>
        [JsonProperty("components")]
        public List<Component> Components { get; set; }
    }

    public class Component
    {
        /// <summary>
        /// Gets or sets the type of the component.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the sub-type of the component.
        /// </summary>
        [JsonProperty("sub_type")]
        public string SubType { get; set; }

        /// <summary>
        /// Gets or sets the index of the component.
        /// </summary>
        [JsonProperty("index")]
        public string Index { get; set; }

        /// <summary>
        /// Gets or sets the list of parameters for the component.
        /// </summary>
        [JsonProperty("parameters")]
        public List<Parameter> Parameters { get; set; }
    }

    public class Parameter
    {
        /// <summary>
        /// Gets or sets the type of the parameter.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the name of the parameter.
        /// </summary>
        [JsonProperty("parameter_name")]
        public string ParameterName { get; set; }

        /// <summary>
        /// Gets or sets the text value of the parameter.
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the media value of the parameter.
        /// </summary>
        [JsonProperty("media")]
        public string Media { get; set; }

        /// <summary>
        /// Gets or sets the payload value of the parameter.
        /// </summary>
        [JsonProperty("payload")]
        public string Payload { get; set; }

        /// <summary>
        /// Gets or sets the currency information for the parameter.
        /// </summary>
        [JsonProperty("currency")]
        public Currency Currency { get; set; }

        /// <summary>
        /// Gets or sets the date and time value of the parameter.
        /// </summary>
        [JsonProperty("date_time")]
        public DateTimeValue DateTime { get; set; }

        /// <summary>
        /// Gets or sets the location value of the parameter.
        /// </summary>
        [JsonProperty("location")]
        public Location Location { get; set; }
    }

    public class Currency
    {
        /// <summary>
        /// Gets or sets the fallback value for the currency.
        /// </summary>
        [JsonProperty("fallback_value")]
        public string FallbackValue { get; set; }

        /// <summary>
        /// Gets or sets the currency code for the currency.
        /// </summary>
        [JsonProperty("currency_code")]
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets the amount in 1/1000th units for the currency.
        /// </summary>
        [JsonProperty("amount_1000")]
        public int Amount1000 { get; set; }
    }

    public class DateTimeValue
    {
        /// <summary>
        /// Gets or sets the fallback value for the date and time.
        /// </summary>
        [JsonProperty("fallback_value")]
        public string FallbackValue { get; set; }
    }

    /// <summary>
    /// Represents an interactive WhatsApp message.
    /// </summary>
    public class Interactive
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("header")]
        public Header Header { get; set; }

        [JsonProperty("body")]
        public Body Body { get; set; }

        [JsonProperty("footer")]
        public Footer Footer { get; set; }

        [JsonProperty("action")]
        public MessageAction Action { get; set; }
    }

    public class Header
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("media")]
        public string Media { get; set; }
    }

    public class Body
    {
        [JsonProperty("text")]
        public string Text { get; set; }
    }

    public class Footer
    {
        [JsonProperty("text")]
        public string Text { get; set; }
    }

    public class MessageAction
    {
        [JsonProperty("buttons")]
        public List<Button> Buttons { get; set; }

        [JsonProperty("sections")]
        public List<Section> Sections { get; set; }
    }

    public class Button
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("cta_url")]
        public string CtaUrl { get; set; }
    }

    public class Section
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("rows")]
        public List<Row> Rows { get; set; }
    }

    public class Row
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public class Location
    {
        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }
    }
}
