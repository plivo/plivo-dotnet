using System.Threading.Tasks;

namespace Plivo.Resource.Recording
{
    public class Recording : Resource
    {
        public new string Id => RecordingId;
        public string AddTime { get; set; }
        public string CallUuid { get; set; }
        public string ConferenceName { get; set; }
        public string RecordingDurationMs { get; set; }
        public string RecordingEndMs { get; set; }
        public string RecordingFormat { get; set; }
        public string RecordingId { get; set; }
        public string RecordingStartMs { get; set; }
        public string RecordingType { get; set; }
        public string RecordingUrl { get; set; }
        public string ResourceUri { get; set; }
        public string FromNumber { get; set; }
        public string ToNumber { get; set; }

        public override string ToString()
        {
            return  "StatusCode: " + StatusCode + "\n"+
                    "AddTime: " + AddTime + "\n" +
                    "CallUuid: " + CallUuid + "\n" +
                    "ConferenceName: " + ConferenceName + "\n" +
                    "RecordingDurationMs: " + RecordingDurationMs + "\n" +
                    "RecordingEndMs: " + RecordingEndMs + "\n" +
                    "RecordingFormat: " + RecordingFormat + "\n" +
                    "RecordingId: " + RecordingId + "\n" +
                    "RecordingStartMs: " + RecordingStartMs + "\n" +
                    "RecordingType: " + RecordingType + "\n" +
                    "RecordingUrl: " + RecordingUrl + "\n" +
                    "ResourceUri: " + ResourceUri + "\n" +
                    "FromNumber: " + FromNumber + "\n" +
                    "ToNumber: " + ToNumber + "\n";
            
            
                   
        }

        #region Delete
        /// <summary>
        /// Delete this recording
        /// </summary>
        /// <returns></returns>
        public DeleteResponse<Recording> Delete()
        {
            return ((RecordingInterface) Interface).Delete(Id);
        }
        /// <summary>
        /// Asynchronously delete this recording
        /// </summary>
        /// <returns></returns>
        public async Task<DeleteResponse<Recording>> DeleteAsync()
        {
            return await ((RecordingInterface)Interface).DeleteAsync(Id);
        }
        #endregion
    }
}