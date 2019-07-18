using dict = System.Collections.Generic.Dictionary<string, string>;
using list = System.Collections.Generic.List<string>;

namespace Plivo.XML
{
    public class P : PlivoElement
    {
        public P(string body)
            : base(body)
        {
            Nestables = new list() {
            	"Break", 
				"Emphasis", 
				"Lang", 
				"Phoneme", 
				"Prosody", 
				"SayAs", 
				"Sub", 
				"S", 
				"W"
            };
            ValidAttributes = new list() {""};
        }
    }
}