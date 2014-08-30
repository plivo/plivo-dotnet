using System.Collections.Generic;

namespace Plivo
{
    public class SubAccountList
    {
        public SubAccountMeta meta { get; set; }
        public string error { get; set; }
        public string api_id { get; set; }
        public List<SubAccount> objects { get; set; }
    }
}