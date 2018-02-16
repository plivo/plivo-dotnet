using System;
using System.Collections.Generic;

namespace Plivo.Resource.PhoneNumber
{
    public class Prerequisite
    {
        public string Type { get; set; }
        public string Scope { get; set; }
        public bool ProofRequired { get; set; }
        public List<string> ProofType { get; set; }
    }
}
