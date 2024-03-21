using System;
using System.Collections.Generic;
using System.Text;

namespace Protocols.Exceptions
{
    public class UnsuccessfulRequestException : Exception
    {
        private readonly int statusCode;
        public int StatusCode { get { return statusCode; } }
        public UnsuccessfulRequestException(int statusCode, string message = null, Exception innerException = null) : base(message, innerException)
        {
            this.statusCode = statusCode;
        }
    }
}
