namespace Plivo.Resource.Phlo.Member
{
    public class Member: Resource
    {
        public BaseResponse AbortTransfer()
        {
            return ((MemberInterface) Interface)
                .Update("abort_transfer");
        }
        
        public BaseResponse ResumeCall()
        {
            return ((MemberInterface) Interface)
                .Update("resume_call");
        }
        
        public BaseResponse VoicemailDrop()
        {
            return ((MemberInterface) Interface)
                .Update("voicemail_drop");
        }
        
        public BaseResponse Hangup()
        {
            return ((MemberInterface) Interface)
                .Update("hangup");
        }
        
        public BaseResponse Hold()
        {
            return ((MemberInterface) Interface)
                .Update("hold");
        }
        
        public BaseResponse Unhold()
        {
            return ((MemberInterface) Interface)
                .Update("unhold");
        }
        
        
    }
}