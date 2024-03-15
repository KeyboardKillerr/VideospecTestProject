using System;
using System.Security.Authentication;
using System.Threading.Tasks;
using VideospecTestProject.Uwp.Exceptions;
using ViewModelBase.Commands.ErrorHandlers;
using Windows.UI.Popups;

namespace VideospecTestProject.Uwp
{
    internal class ErrorHandler : IErrorHandler
    {
        public async void ErrorHandle(Exception e)
        {
            if (e is AuthenticationException)
            {
                await NotifyUser(e.Message);
                return;
            }
            if (e is NoAccessException)
            {
                await NotifyUser(e.Message);
                return;
            }
            if (e is UnauthorizedAccessException)
            {
                await NotifyUser(e.Message);
                return;
            }

            await NotifyUser("Произошла неизвестная ошибка.");
        }

        private async Task NotifyUser(string errorMessage)
        {
            var title = "Ошибка!";
            var messageBox = new MessageDialog(errorMessage, title);

            //Здесь можно добавить кнопки и ещё что-нибудь

            await messageBox.ShowAsync();
        }
    }
}