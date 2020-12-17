using Plivo.Client;

using System;
using System.Collections.Generic;
namespace Plivo.Resource.Powerpack
{
    /// <summary>
    /// Numberpool.
    /// </summary>
    public class Priority : Resource
    {

        public string priority1 { get; set; }
        public string priority2 { get; set; }
        public string priority3 { get; set; }

        public override string ToString()
        {
            return "\n" +
                "Priority1: " + priority1 + "\n" +
                "Priority2: " + priority2 + "\n" +
                "Priority3: " + priority3 + "\n";
        }
        
    }
}
