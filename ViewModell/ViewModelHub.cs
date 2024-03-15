using System;
using System.Collections.Generic;
using System.Text;
using VideospecTestProject.Core.Api;
using ViewModel.ViewModels;
using ViewModelBase.Commands.ErrorHandlers;

namespace ViewModel
{
    public class ViewModelHub
    {
        private readonly IApi ofdApi = new OfdApi();

        private readonly LoginViewModel loginViewModel;

        public ViewModelHub(IErrorHandler? errorHandler = null)
        {
            loginViewModel = new LoginViewModel(this, ofdApi, errorHandler);
        }

        public LoginViewModel LoginViewModel { get { return loginViewModel; } }
    }
}
