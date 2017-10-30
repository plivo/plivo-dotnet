using dict = System.Collections.Generic.Dictionary<string, string>;
using list = System.Collections.Generic.List<string>;

namespace Plivo.XML
{
    public class Dial : PlivoElement
    {
        public Dial(dict parameters)
            : base(parameters)
        {
            Nestables = new list()
            {   "Number", "User"
            };
            ValidAttributes = new list()
            {   "action", "method", "hangupOnStar", "timeLimit", "timeout", "callerId",
                "callerName", "confirmSound", "confirmKey", "dialMusic", "callbackUrl",
                "callbackMethod", "redirect", "digitsMatch", "digitsMatchBLeg", "sipHeaders"
            };
            addAttributes();
        }
    }
}
