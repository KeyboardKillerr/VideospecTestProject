using Services.Api;
using Services.Models.Examples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using ViewModelBase.Commands.AsyncCommands;
using ViewModelBase.Commands.ErrorHandlers;
using ViewModelBase.Commands.MessageHandler;

namespace ViewModel.ViewModels
{
    public class ServiceViewModel : ViewModelBase.ViewModelBase
    {
        private readonly IApi service;
        private readonly IErrorHandler errorHandler;
        private readonly IMessageHandler messageHandler;
        private readonly ViewModelHub hub;

        private readonly IAsyncCommand acceptRecepitCommand;
        public IAsyncCommand AcceptReceiptCommand { get { return acceptRecepitCommand; } }

        internal ServiceViewModel(
            ViewModelHub hub,
            IApi service,
            IErrorHandler errorHandler = null,
            IMessageHandler messageHandler = null)
        {
            this.hub = hub;
            this.service = service;
            this.errorHandler = errorHandler;
            this.messageHandler = messageHandler;
            acceptRecepitCommand = new AsyncCommand(AcceptReceiptFunction, null, errorHandler);
        }

        private async Task AcceptReceiptFunction()
        {
            try
            {
                await service.AddReceiptAsync(new ExampleReceipt());
                messageHandler.MessageHandle("Чек был успешно отправлен.");
            }
            catch (Exception ex)
            {
                errorHandler.ErrorHandle(ex);
            }
        }
    }
}
