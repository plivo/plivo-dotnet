namespace Plivo.Resource.CallFeedback
{
    public class CallFeedbackCreateResponse : CreateResponse
    {
        public string Data {get; set;}

        public override string ToString()
        {
            return base.ToString() + "Data: " + Data +"\n";
        }
    }
}