using System;

namespace Plivo.Exceptions
{
    public class PlivoException : Exception
    {
        public PlivoException(string message) : base(message) { }
    }
}