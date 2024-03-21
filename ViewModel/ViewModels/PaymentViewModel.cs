using ReceiptService.Api;
using Helpers.Examples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using ViewModelBase.Commands.AsyncCommands;
using ViewModelBase.Commands.ErrorHandlers;
using ViewModelBase.Commands.MessageHandler;
using System.Windows.Input;
using ViewModelBase.Commands.QuickCommands;
using DataModel.Entities;
using DataModel.DAOs;

namespace ViewModel.ViewModels
{
    public class PaymentViewModel : ViewModelBase.ViewModelBase
    {
        private readonly ViewModelHub hub;
        private readonly DaoBase db;
        private readonly IApi service;
        private readonly IErrorHandler errorHandler;
        private readonly IMessageHandler messageHandler;

        private readonly IAsyncCommand acceptRecepitCommand;
        private readonly ICommand selectToiletCommand;
        private readonly ICommand selectShowerCommand;
        private readonly ICommand selectLaundryCommand;

        private Service selectedService = Service.None;

        public IAsyncCommand AcceptReceiptCommand => acceptRecepitCommand;
        public ICommand SelectToiletCommand => selectToiletCommand;
        public ICommand SelectShowerCommand => selectShowerCommand;
        public ICommand SelectLaundryCommand => selectLaundryCommand;

        internal PaymentViewModel(
            ViewModelHub hub,
            DaoBase db,
            IApi service,
            IErrorHandler errorHandler = null,
            IMessageHandler messageHandler = null)
        {
            this.hub = hub;
            this.db = db;
            this.service = service;
            this.errorHandler = errorHandler;
            this.messageHandler = messageHandler;

            selectToiletCommand = new Command(SelectToilet);
            selectShowerCommand = new Command(SelectShower);
            selectLaundryCommand = new Command(SelectLaundry);
            acceptRecepitCommand = new AsyncCommand(AcceptReceiptFunction, null, errorHandler);
        }

        private void SelectToilet() => selectedService = Service.Toilet;
        private void SelectShower() => selectedService = Service.Shower;
        private void SelectLaundry() => selectedService = Service.Laundry;

        private async Task AcceptReceiptFunction()
        {
            await db.Receipts.CreateAsync(createReceipt());
            //hub.ReceiptListViewModel.Refresh();
            //await service.AddReceiptAsync(createReceipt());
            messageHandler.MessageHandle("Чек был успешно отправлен.");
        }

        private Receipt createReceipt()
        {
            var receipt = new Receipt();
            receipt.Total = calculatePrice();
            return receipt;
        }

        private float calculatePrice()
        {
            switch (selectedService)
            {
                case Service.Toilet:
                    return 25;
                case Service.Shower:
                    return 200;
                case Service.Laundry:
                    return 200;
                default:
                    return 0;
            }
        }

        private enum Service
        {
            None,
            Toilet,
            Shower,
            Laundry
        }
    }
}
