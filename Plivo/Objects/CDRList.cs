using System.Collections.Generic;

namespace Plivo.Objects
{
    public class CdrList
    {
        public CDRMeta Meta { get; set; }
        public string Error { get; set; }
        public string ApiID { get; set; }
        public List<CDR> Objects { get; set; }

    }
}