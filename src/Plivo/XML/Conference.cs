using dict = System.Collections.Generic.Dictionary<string, string>;
using list = System.Collections.Generic.List<string>;

namespace Plivo.XML
{
    public class Conference : PlivoElement
    {
        public Conference(string body, dict parameters)
            : base(body, parameters)
        {
            Nestables = new list() { "" };
            ValidAttributes = new list()
            {   "sendDigits", "muted", "enterSound", "exitSound", "startConferenceOnEnter",
                "endConferenceOnExit", "stayAlone", "waitSound", "maxMembers", "timeLimit",
                "hangupOnStar", "action", "method", "callbackUrl", "callbackMethod", "digitsMatch",
                "floorEvent", "redirect", "record", "recordFileFormat","recordWhenAlone", "transcriptionType", "transcriptionUrl",
                "transcriptionMethod","relayDTMF"
            };
            addAttributes();
        }
    }
}
