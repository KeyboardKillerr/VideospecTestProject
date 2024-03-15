using Services.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.ViewModels;
using ViewModelBase.Commands.ErrorHandlers;
using ViewModelBase.Commands.MessageHandler;

namespace ViewModel
{
    public class ViewModelHub
    {
        private readonly IApi ofdApi = new OfdApi();

        private readonly LoginViewModel loginViewModel;
        private readonly ServiceViewModel serviceViewModel;

        public ViewModelHub(IErrorHandler errorHandler = null, IMessageHandler messageHandler = null)
        {
            loginViewModel = new LoginViewModel(this, ofdApi, errorHandler, messageHandler);
            serviceViewModel = new ServiceViewModel(this, ofdApi, errorHandler, messageHandler);
        }

        public LoginViewModel LoginViewModel { get { return loginViewModel; } }
        public ServiceViewModel ServiceViewModel { get { return serviceViewModel; } }
    }
}
