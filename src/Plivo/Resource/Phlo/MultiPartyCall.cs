using System;
using Plivo.Exception;
using Plivo.Resource.Member;

namespace Plivo.Resource.Phlo.MultiPartyCall
{
    public class MultiPartyCall : Node.Node
    {
        public Lazy<MemberInterface> _member;
        private MemberInterface MemberI => _member.Value;
        
        public BaseResponse Call(string triggerSource, string to, string role)
        {
            
            return ((MultiPartyCallInterface) Interface).Update("call", triggerSource, to, role);
            
        }
        
        public BaseResponse WarmTransfer(string triggerSource, string to, string role="agent")
        {
            return ((MultiPartyCallInterface) Interface).Update("warm_transfer", triggerSource, to, role);
            
        }
        
        public BaseResponse ColdTransfer(string triggerSource, string to, string role="agent")
        {
            return ((MultiPartyCallInterface) Interface).Update("cold_transfer", triggerSource, to, role);
            
        }
        
        public Member.Member Member(string MemberId)
        {
            if (string.IsNullOrEmpty(MemberId))
            {
                throw new PlivoValidationException("MemberId is mandatory, can not be null or empty");
            }
            return MemberI.Get(MemberId);

        }
        
        
            
    }
}