using System;
using System.Security.Authentication;
using System.Threading.Tasks;
using VideospecTestProject.Core.Api;
using ViewModelBase.Commands.AsyncCommands;
using ViewModelBase.Commands.ErrorHandlers;

namespace ViewModel.ViewModels
{
    public class LoginViewModel : ViewModelBase.ViewModelBase
    {
        private readonly IApi service;
        private readonly IErrorHandler? errorHandler;
        private readonly ViewModelHub hub;

        private readonly IAsyncCommand loginCommand;
        public IAsyncCommand LoginCommand { get { return loginCommand; } }

        internal LoginViewModel(ViewModelHub hub, IApi service, IErrorHandler? errorHandler = null)
        {
            this.hub = hub;
            this.service = service;
            this.errorHandler = errorHandler;
            loginCommand = new AsyncCommand(LoginFunction, LoginCanExecute, errorHandler);
        }

        private async Task LoginFunction()
        {
            var result = await service.AuthAsync(Login, Password);

            ResetAll();

            if (!result) ErrorHandle(new AuthenticationException("Неверный логин или пароль."));
        }

        private bool LoginCanExecute()
        {
            if (string.IsNullOrWhiteSpace(login)) return false;
            return true;
        }

        #region Fields
        private string login = "";
        public string Login
        {
            get { return login; }
            set
            {
                value = value.Trim();
                if (Set(ref login, value))
                {
                    LoginCommand.RaiseCanExecuteChanged();
                }
            }
        }

        private string password = "";
        public string Password
        {
            get { return password; }
            set
            {
                if (Set(ref password, value))
                {
                    LoginCommand.RaiseCanExecuteChanged();
                }
            }
        }
        #endregion

        private void ErrorHandle(Exception exception)
        {
            if (errorHandler is null) throw exception;
            errorHandler.ErrorHandle(exception);
        }

        private void ResetAll()
        {
            Login = "";
            Password = "";
        }
    }
}
