using System;

namespace Plivo.Resource.Media
{
    public class MediaUploadResponse : Resource
    {
        public new string Id => MediaId;

        /// <summary>
        /// Gets or sets the content_type.
        /// </summary>
        /// <value>The content_type.</value>
        public string ContentType { get; set; }

        /// <summary>
        /// Gets or sets file_name.
        /// </summary>
        /// <value>file_name.</value>
        public string FileName { get; set; }

        /// <summary>
        /// Gets or sets the media_id.
        /// </summary>
        /// <value>The media_id.</value>
        public string MediaId { get; set; }

        /// <summary>
        /// Gets or sets size.
        /// </summary>
        /// <value>The state of size.</value>
        public int Size { get; set; }


        /// <summary>
        /// Gets or sets the upload_time.
        /// </summary>
        /// <value>The upload_time.</value>
        public string UploadTime { get; set; }

        /// <summary>
        /// Gets or sets the resource URI.
        /// </summary>
        /// <value>The resource URI.</value>
        public string Url { get; set; }

        public int Statuscode { get; set; }

        public string Status { get; set; }

        public override string ToString()
        {
            return "\n" +
                  "UploadTime: " + UploadTime + "\n" +
                  "Status: " + Status + "\n" +
                  "Statuscode: " + Statuscode + "\n" +
                   "URL: " + Url + "\n" +
                   "Size: " + Size + "\n" +
                   "MediaID: " + MediaId + "\n" +
                   "FileName: " + FileName + "\n" +
                   "ContentType: " + ContentType + "\n";
        }
    }
}