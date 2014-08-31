namespace Plivo.Extensibility
{
    public interface IPlivoResponse<T>
    {
        T Data { get; set; }
        string ErrorMessage { get; set; }
        
        
    }

    public class PlivoResponse<T>:IPlivoResponse<T>
    {
        public T Data { get; set; }
        public string ErrorMessage { get; set; }
    }
}