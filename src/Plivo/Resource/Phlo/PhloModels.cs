namespace Plivo.Resource.Phlo
{
    public class PhloRunCallResponse : BaseResponse
    {
        /// <summary>
        /// API ID
        /// </summary>
        public string ApiId { get; set; }   

        /// <summary>
        /// PHLO ID
        /// </summary>
        public string PhloId { get; set; }

        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; set; }

    }
}
