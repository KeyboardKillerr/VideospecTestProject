using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideospecTestProject.Uwp.Exceptions
{
    public class NoAccessException : Exception
    {
        public NoAccessException(string message = null, Exception innerException = null) : base(message, innerException) { }
    }
}
