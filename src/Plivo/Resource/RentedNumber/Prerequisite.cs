using System;
using System.Collections.Generic;

namespace Plivo.Resource.RentedNumber
{
    public class Prerequisite
    {
        public string Type { get; set; }
        public string Scope { get; set; }
        public bool ProofRequired { get; set; }
        public List<string> ProofType { get; set; }

        public override string ToString()
        {
            return "Type: " + Type + "\n"+
                "Scope" + Scope + "\n" +
                "ProofRequired" + ProofRequired + "\n" +
                "[ProofType]\n" + string.Join("\n", ProofType);
        }
    }
}
