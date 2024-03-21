using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.Exceptions
{
    public class UnexpectedException : Exception
    {
        public UnexpectedException(string message = null, Exception innerException = null) : base(message, innerException) { }
    }
}
