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
        
        /// <summary>
        /// Delete this recording
        /// </summary>
        /// <returns></returns>
        public DeleteResponse<Recording> Delete()
        {
            return ((RecordingInterface)Interface).Delete(Id);
        }
    }
}
