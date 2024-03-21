using DataModel.DAOs;
using ReceiptService.Api;
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
        private readonly DaoBase db = new SqlServer();

        private readonly LoginViewModel loginViewModel;
        private readonly PaymentViewModel paymentViewModel;
        private readonly ReceiptListViewModel receiptListViewModel;

        public ViewModelHub(IErrorHandler errorHandler = null, IMessageHandler messageHandler = null)
        {
            loginViewModel = new LoginViewModel(this, ofdApi, errorHandler, messageHandler);
            paymentViewModel = new PaymentViewModel(this, db, ofdApi, errorHandler, messageHandler);
            receiptListViewModel = new ReceiptListViewModel(this, db, ofdApi, errorHandler, messageHandler);
        }

        public LoginViewModel LoginViewModel => loginViewModel;
        public PaymentViewModel PaymentViewModel => paymentViewModel;
        public ReceiptListViewModel ReceiptListViewModel => receiptListViewModel;
    }
}
