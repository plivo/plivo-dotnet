namespace Plivo.Exception
{
    public class PlivoGeoPermissionException : PlivoRestException
    {
        public PlivoGeoPermissionException(string message, uint statusCode = 403) : base(message, statusCode)
        {
        }
    }
}