namespace Plivo.Resource.MultiPartyCall
{
    public class MultiPartyCallParticipantUpdateResponse<T> : BaseResponse
    {
        public string CoachMode { get; set; }
        public string Mute { get; set; }
        public string Hold { get; set; }
        
        public override string ToString()
        {
            return "Api Id: " + ApiId + "\n" +
                   "StatusCode: "+StatusCode + "\n" +
                    "CoachMode: " + CoachMode + "\n" + 
                    "Mute: " + Mute + "\n"+ 
                    "Hold: "+ Hold + "\n" ;
        }
    }
}