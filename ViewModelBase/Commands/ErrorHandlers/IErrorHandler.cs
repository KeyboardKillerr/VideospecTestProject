using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModelBase.Commands.ErrorHandlers
{
    public interface IErrorHandler
    {
        void ErrorHandle(Exception ex);
    }
}
