using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModelBase.Commands.MessageHandler
{
    public interface IMessageHandler
    {
        void MessageHandle(string message);
    }
}
