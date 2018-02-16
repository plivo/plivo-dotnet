using dict = System.Collections.Generic.Dictionary<string, string>;
using list = System.Collections.Generic.List<string>;

namespace Plivo.XML
{
    public class User : PlivoElement
    {
        public User(string body, dict parameters)
            : base(body, parameters)
        {
            Nestables = new list() {""};
            ValidAttributes = new list()
            {
                "sendDigits",
                "sendOnPreAnswer",
                "sipHeaders"
            };
            addAttributes();
        }
    }
}