using System.Collections.Generic;

namespace Plivo.XML
{
    public class User : PlivoElement
    {
        public User(string body, Dictionary<string, string> parameters)
            : base(body, parameters)
        {
            Nestables = new List<string>() { "" };
            ValidAttributes = new List<string>()
                {   "sendDigits","sendOnPreAnswer", "sipHeaders"
                };
            addAttributes();
        }
    }
}