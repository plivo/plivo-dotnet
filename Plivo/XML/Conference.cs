using System.Collections.Generic;

namespace Plivo.XML
{
    public class Conference : PlivoElement
    {
        public Conference(string body, Dictionary<string, string> parameters)
            : base(body, parameters)
        {
            Nestables = new List<string>() { "" };
            ValidAttributes = new List<string>()
                {   "sendDigits", "muted", "enterSound", "exitSound", "startConferenceOnEnter",
                    "endConferenceOnExit", "stayAlone", "waitSound", "maxMembers", "timeLimit",
                    "hangupOnStar", "action", "method", "callbackUrl", "callbackMethod", "digitsMatch",
                    "floorEvent", "redirect", "Record", "recordFileFormat","recordWhenAlone", "transcriptionType", "transcriptionUrl",
                    "transcriptionMethod","relayDTMF"
                };
            addAttributes();
        }
    }
}