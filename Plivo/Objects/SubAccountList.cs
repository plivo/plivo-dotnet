using System.Collections.Generic;

namespace Plivo.Objects
{
    public class SubAccountList
    {
        public SubAccountMeta Meta { get; set; }
        public string Error { get; set; }
        public string ApiId { get; set; }
        public List<SubAccount> Objects { get; set; }

        public SubAccountList()
        {
            Objects = new List<SubAccount>();
        }
    }
}