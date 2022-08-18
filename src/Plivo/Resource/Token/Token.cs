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
        public string Iss { get; set; }
        public string Sub { get; set; }
        public int Nbf { get; set; }
        public int Exp { get; set; }
        public bool Incoming_allow { get; set; }
        public bool Outgoing_allow { get; set; }
        public string App { get; set; }


        public override string ToString()
        {
            return "Iss: " + Iss + "\n" +
                   "Sub: " + Sub + "\n" +
                   "Nbf: " + Nbf + "\n" +
                   "Exp: " + Exp + "\n" +
                   "Incoming Allow: " + Incoming_allow + "\n" +
                   "Outgoing Allow: " + Outgoing_allow + "\n" +
                   "App: " + App + "\n";
        }
    }
}

   


