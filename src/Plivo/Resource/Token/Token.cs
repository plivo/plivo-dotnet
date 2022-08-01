using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Plivo.Client;

namespace Plivo.Resource.Token
{
    /// <summary>
    /// Token.
    /// </summary>
    public class Token : Resource
    {
        public string iss { get; set; }
        public string sub { get; set; }
        public int nbf { get; set; }
        public int exp { get; set; }
        public bool incoming_allow { get; set; }
        public bool outgoing_allow { get; set; }
        public string app { get; set; }
    }

    public override string ToString()
    {
        return "Iss: " + Iss + "\n" +
               "Sub: " + Sub + "\n" +
               "Nbf: " + Nbf + "\n" +
               "Exp: " + Exp + "\n" +
               "Incoming_Allow: " + Incoming_Allow + "\n" +
               "Outgoing_Allow: " + Outgoing_Allow + "\n" +
               "App: " + App + "\n";
    }

    public Token()
    {
    }
}

   


