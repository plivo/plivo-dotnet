using System;
using System.Collections.Generic;
using System.Text;

namespace Plivo.Resource.Phlo
{
    public class Phlo : Resource
    {
        public Phlo() { }
        public new string Id => PhloId;
        public string PhloId { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedOn { get; set; }

    }

    public class MultiPartyCall : Resource
    {
        public MultiPartyCall() { }
        public string Name { get; set; }
        public new string Id => NodeId;
        public string NodeId { get; set; }
        public string PhloUuid { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
    class PhloMember : Resource
    {
        public PhloMember() { }
    }

    public class MultiPartyCallResponse : BaseResponse
    {
    }
    public class MultiPartyCallMemberResponse : BaseResponse
    {
    }
}
