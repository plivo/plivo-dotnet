using dict = System.Collections.Generic.Dictionary<string, string>;
using list = System.Collections.Generic.List<string>;

namespace Plivo.XML
{
    public class Record : PlivoElement
    {
        public Record(dict attributes)
            : base(attributes)
        {
            Nestables = new list() {""};
            ValidAttributes = new list()
            {
                "action",
                "method",
                "timeout",
                "finishOnKey",
                "maxLength",
                "playBeep",
                "recordSession",
                "startOnDialAnswer",
                "redirect",
                "fileFormat",
                "callbackUrl",
                "callbackMethod",
                "transcriptionType",
                "transcriptionUrl",
                "transcriptionMethod",
                "recordChannelType"
            };
            addAttributes();
        }
    }
}