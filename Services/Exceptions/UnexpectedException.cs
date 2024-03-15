using System;

namespace Services.Exceptions
{
    public class UnexpectedException : Exception
    {
        public UnexpectedException(string message = null, Exception innerException = null) : base(message, innerException) { }
    }
}
