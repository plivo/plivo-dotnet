namespace Plivo.Resource.MaskingSession
{
    public class MaskingSessionUpdateResponse<T> : BaseResponse
    {
        public object Session { get; set; }

        public string SessionUuid { get; set; }

        public override string ToString()
        {
            return base.ToString() +
                    "SessionUuid: " + SessionUuid + "\n" + 
                   "Session: " + Session + "\n";
        }
    }
}