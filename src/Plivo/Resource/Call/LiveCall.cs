namespace Plivo.Resource.Call
{
    /// <summary>
    /// Live call.
    /// </summary>
    public class LiveCall : Resource
    {
        public string Direction { get; set; }
        public string From { get; set; }
        public string CallStatus { get; set; }
        public string To { get; set; }
        public string CallerName { get; set; }
        public string CallUuid { get; set; }
        public string RequestUuid { get; set; }
        public string SessionStart { get; set; }

        public override string ToString()
        {
            return base.ToString() +
                       "Direction: " + Direction + "\n" +
                       "From: " + From + "\n" +
                       "CallStatus: " + CallStatus + "\n" +
                       "To: " + To + "\n" +
                       "CallerName: " + CallerName + "\n" +
                       "CallUuid: " + CallUuid + "\n" +
                       "RequestUuid: " + RequestUuid + "\n" +
                       "SessionStart: " + SessionStart + "\n";
        }
    }
}