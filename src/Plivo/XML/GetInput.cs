using dict = System.Collections.Generic.Dictionary<string, string>;
using list = System.Collections.Generic.List<string>;

namespace Plivo.XML
{
    public class GetInput : PlivoElement
    {
        public GetInput(string body, dict parameters)
            : base(body, parameters)
        {
            Nestables = new list()
            {
                "Speak",
                "Play",
                "Wait"
            };
            ValidAttributes = new list()
            {
                "action",
                "method",
                "inputType",
                "executionTimeout",
                "digitEndTimeout",
                "speechEndTimeout",
                "finishOnKey",
                "speechModel",
                "hints",
                "language",
                "interimSpeechResultsCallback",
                "interimSpeechResultsCallbackMethod",
                "log",
                "redirect",
                "profanityFilter"
            };
            addAttributes();
        }
    }
}