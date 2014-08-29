using System.Collections.Generic;

namespace Plivo.XML
{
    public class Record : PlivoElement
    {
        public Record(Dictionary<string, string> attributes)
            : base(attributes)
        {
            Nestables = new List<string>() { "" };
            ValidAttributes = new List<string>()
                {   "action", "method", "timeout", "finishOnKey", "maxLength", "playBeep",
                    "recordSession", "startOnDialAnswer", "redirect", "fileFormat",
                    "callbackUrl", "callbackMethod", "transcriptionType", "transcriptionUrl",
                    "transcriptionMethod"
                };
            addAttributes();
        }
    }
}