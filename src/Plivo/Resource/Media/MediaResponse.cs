using System.Collections.Generic;

namespace Plivo.Resource.Media
{
    public class MediaResponse : CreateResponse
    {
        public List<MediaUploadResponse> Objects { get; set; }

        public override string ToString()
        {
            //Added logic to catch Invalid Numbers in BULK SMS

            return "\n" +
                    "ApiId: " + ApiId + "\n" +
                   "Objects: " + string.Join(",", Objects) + "\n";
        }
    }
}