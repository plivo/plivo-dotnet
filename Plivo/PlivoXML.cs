using System;

namespace Plivo.XML
{
    public class PlivoException : Exception
    {
        public PlivoException(string message) : base(message) { }
    }
}
