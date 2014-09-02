namespace Plivo.Objects
{
    public class Application
    {
        public string FallbackMethod { get; set; }
        public bool DefaultApp { get; set; }
        public string AppName { get; set; }
        public string SubAccount { get; set; }
        public bool Enabled { get; set; }
        public bool ProductionApp { get; set; }
        public string AppId { get; set; }
        public bool PublicUri { get; set; }
        public string HangupUrl { get; set; }
        public string SipUri { get; set; }
        public string AnswerUrl { get; set; }
        public string MessageUrl { get; set; }
        public string ResourceUri { get; set; }
        public string HangupMethod { get; set; }
        public string MessageMethod { get; set; }
        public string FallbackAnswerUrl { get; set; }
        public string AnswerMethod { get; set; }
    }
}