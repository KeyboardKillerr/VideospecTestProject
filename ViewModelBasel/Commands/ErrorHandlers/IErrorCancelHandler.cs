using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModelBase.Commands.ErrorHandlers
{
    public interface IErrorCancelHandler : IErrorHandler
    {
        void HandleCancel(OperationCanceledException ex);
    }
}
