using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using System.Text.Json;
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
	   	public JsonElement emptyJsonObject = JsonSerializer.Deserialize<JsonElement>("{}");
        public string app { get; set; }
    }

    public override string ToString()
    {
        return "Iss: " + Iss + "\n" +
               "Sub: " + Sub + "\n" +
               "Nbf: " + Nbf + "\n" +
               "Exp: " + Exp + "\n" +
	           "Incoming Allow: " + IncomingAllow + "\n" +	
               "Outgoing Allow: " + OutgoingAllow + "\n" +
               "App: " + App + "\n";
    }
}

   


