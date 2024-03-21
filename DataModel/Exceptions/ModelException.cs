using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.Exceptions
{
    public class ModelException : Exception
    {
        public ModelException(string message = null, Exception innerException = null) : base(message, innerException) { }
    }
}
