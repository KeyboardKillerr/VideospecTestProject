using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModelBase.Commands.ErrorHandlers
{
    public interface IErrorNotFoundHandler : IErrorHandler
    {
        void HandleResultNotFound(ResultNotFoundException ex);
    }
}
