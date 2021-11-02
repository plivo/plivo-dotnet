namespace Plivo.Resource.MultiPartyCall
{
    public class MultiPartyCallParticipantPlayResponse<T> : BaseResponse
    {
        
        public string MpcMemberId { get; set; }
        public string MpcName { get; set; }
        public string Message { get; set; }
        public override string ToString()
        {
            return "Api Id: " + ApiId + "\n" +
                   "StatusCode: "+StatusCode + "\n" +
                   "Message: "+Message + "\n" +
                   "mpcMemberId: " + MpcMemberId + "\n"+ 
                   "mpcName: "+ MpcName + "\n" ;
        }
    }
}