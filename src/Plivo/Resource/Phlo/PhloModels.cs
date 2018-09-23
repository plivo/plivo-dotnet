using System;
using System.Collections.Generic;
using System.Text;

namespace Plivo.Resource.Phlo
{
    public class PhloRunCallResponse : BaseResponse
    {
        /// <summary>
        /// PHLO Run ID
        /// </summary>
        public string PhloRunId { get; set; }

        /// <summary>
        /// PHLO ID
        /// </summary>
        public string PhloId { get; set; }

        /// <summary>
        /// Error detail
        /// </summary>
        public string Error { get; set; }

    }
    public class MultiPartyCallResponse : BaseResponse
    {
    }
    public class MultiPartyCallMemberResponse : BaseResponse
    {
    }
}
