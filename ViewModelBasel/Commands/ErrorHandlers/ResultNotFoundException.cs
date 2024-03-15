using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModelBase.Commands.ErrorHandlers
{
    public class ResultNotFoundException : Exception
    {
        public ResultNotFoundException(string? message) : base(message) { }
    }
}
