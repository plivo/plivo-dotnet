using dict = System.Collections.Generic.Dictionary<string, string>;
using list = System.Collections.Generic.List<string>;

namespace Plivo.XML
{
    public class S : PlivoElement
    {
        public S(string body)
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
				"W"
            };
            ValidAttributes = new list() {""};
        }
    }
}