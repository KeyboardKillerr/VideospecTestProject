using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModelBase.Commands.MessageHandler;
using Windows.UI.Popups;

namespace VideospecTestProject.Uwp
{
    internal class MessageHandler : IMessageHandler
    {
        public async void MessageHandle(string message)
        {
            var messageBox = new MessageDialog(message);

            //Здесь можно добавить кнопки и ещё что-нибудь

            await messageBox.ShowAsync();
        }
    }
}
