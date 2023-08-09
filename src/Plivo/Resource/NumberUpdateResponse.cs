namespace Plivo.Resource
{
    public class NumberUpdateResponse<T> : UpdateResponse<T>
    {
        public string NewCnam { get; set; }
        public string CnamUpdateStatus { get; set; }

        public override string ToString()
        {
            return base.ToString() +
                   "NewCnam: " + NewCnam + "\n" +
                   "CnamUpdateStatus: " + CnamUpdateStatus + "\n";
        }
    }
}