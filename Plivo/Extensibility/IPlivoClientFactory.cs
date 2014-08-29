namespace Plivo.Extensibility
{
    public interface IPlivoClientFactory
    {
        PlivoClient CreateClient(string authId,string authToken,string version);
    }
}
