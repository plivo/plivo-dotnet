using System;

namespace Plivo
{
    public class PlivoException : Exception
    {
        public PlivoException(string message) : base(message) { }
    }
}