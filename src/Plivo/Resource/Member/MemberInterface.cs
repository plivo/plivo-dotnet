using Plivo.Client;
using System.Threading.Tasks;

namespace Plivo.Resource.Member
{
    public class MemberInterface: ResourceInterface
    {
        /// <summary>
        /// PHLO Id
        /// </summary>
        private string _phloId;
        /// <summary>
        /// Node type
        /// </summary>
        private string _nodeType;
        /// <summary>
        /// Node Id
        /// </summary>
        private string _nodeId;
        /// <summary>
        /// Member Id
        /// </summary>
        private string _memberId;
        
        public MemberInterface(HttpClient client, string phloId, string nodeType, string nodeId) : base(client)
        {
            _phloId = phloId;
            _nodeType = nodeType;
            _nodeId = nodeId;
            
            
            Uri = $"phlo/{_phloId}/";
           
        }
        
        public BaseResponse Update(string action)
        {
            var result = Task.Run(async () => await Client.Update<BaseResponse>(Uri + $"{_nodeType}/{_nodeId}/members/{_memberId}?action={action}").ConfigureAwait(false)).Result;
            return result.Object;

        }

        public Member Get(string memberId)
        {
            var member = new Member();
            member.Interface = this;
            _memberId = memberId;
            return member;
        }
       
        
        
    }
}