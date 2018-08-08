using System;
using System.Collections.Generic;
using System.Text;

namespace Plivo.Resource.Phlo
{
    class Phlo : Resource
    {
        public new string Id => PhloUuid;
        public string PhloUuid { get; set; }
    }

    class MultiPartyCall : Resource
    {

    }
    class PhloMember : Resource
    {

    }

    public class MultiPartyCallResponse : BaseResponse
    {
    }
    public class MultiPartyCallMemberResponse : BaseResponse
    {
    }
}
