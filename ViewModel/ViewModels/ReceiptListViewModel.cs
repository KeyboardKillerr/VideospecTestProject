using DataModel.DAOs;
using DataModel.Entities;
using Helpers;
using ReceiptService.Api;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModelBase.Commands.ErrorHandlers;
using ViewModelBase.Commands.MessageHandler;
using ViewModelBase.Commands.QuickCommands;

namespace ViewModel.ViewModels
{
    public class ReceiptListViewModel : ViewModelBase.ViewModelBase
    {
        private readonly ViewModelHub hub;
        private readonly DaoBase db;
        private readonly IApi service;
        private readonly IErrorHandler errorHandler;
        private readonly IMessageHandler messageHandler;

        private readonly Command firstPageCommand;
        private readonly Command lastPageCommand;
        private readonly Command nextPageCommand;
        private readonly Command previousPageCommand;

        private readonly ObservableCollection<Receipt> receipts = new ObservableCollection<Receipt>();
        private readonly int Step = 10;
        private Counter Skiper;
        private int currentPage = 0;
        private int maximumPage = 0;
        private int itemsFound = 0;

        public ReceiptListViewModel(
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

            firstPageCommand = new Command(FirstPage, FirstPageCanExecute);
            lastPageCommand = new Command(LastPage, LastPageCanExecute);
            nextPageCommand = new Command(NextPage, NextPageCanExecute);
            previousPageCommand = new Command(PreviousPage, PreviousPageCanExecute);
        }

        public ObservableCollection<Receipt> Receipts => receipts;
        public Command FirstPageCommand => firstPageCommand;
        public Command LastPageCommand => lastPageCommand;
        public Command NextPageCommand => nextPageCommand;
        public Command PreviousPageCommand => previousPageCommand;

        internal void Refresh()
        {
            var receipts = db.Receipts.Items;
            itemsFound = receipts.Count();
            UpdateReceipts(receipts);
        }

        private void FirstPage()
        {
            Skiper.Reset();
            Refresh();
        }
        private void LastPage()
        {
            Skiper.SetCurrentValue(Skiper.MaximumValue);
            Refresh();
        }
        private void NextPage()
        {
            Skiper.Increase();
            Refresh();
        }
        private void PreviousPage()
        {
            Skiper.Decrease();
            Refresh();
        }

        public int CurrentPage
        {
            get { return currentPage + 1; }
            private set { Set(ref currentPage, value); }
        }
        public int MaximumPage
        {
            get { return maximumPage; }
            private set { Set(ref maximumPage, value); }
        }

        private bool FirstPageCanExecute() => CurrentPage > 1;
        private bool LastPageCanExecute() => CurrentPage < MaximumPage;
        private bool NextPageCanExecute() => CurrentPage < MaximumPage;
        private bool PreviousPageCanExecute() => CurrentPage > 1;

        private void UpdateReceipts(IQueryable<Receipt> items)
        {
            var itemsPage = TakePage(items).ToList();
            var tmpItems = receipts.ToList();
            foreach (var item in tmpItems) receipts.Remove(item);
            foreach (var item in itemsPage) receipts.Add(item);
        }

        private IQueryable<Receipt> TakePage(IQueryable<Receipt> table)
        {
            AdjustSkiper();
            CurrentPage = Skiper.CurrentValue / Step;
            MaximumPage = itemsFound / Step + (itemsFound % Step == 0 ? 0 : 1);
            FirstPageCommand.RaiseCanExecuteChanged();
            LastPageCommand.RaiseCanExecuteChanged();
            NextPageCommand.RaiseCanExecuteChanged();
            PreviousPageCommand.RaiseCanExecuteChanged();
            return table.Skip(Skiper.CurrentValue).Take(Step);
        }

        private void AdjustSkiper()
        {
            var maximumSkip = CalculateMaximumSkipValue(itemsFound);
            if (Skiper is null) Skiper = new Counter(maximumSkip, Step);
            else
            {
                if (maximumSkip == Skiper.MaximumValue) return;
                Skiper = new Counter(maximumSkip, Step);
            }
        }

        private int CalculateMaximumSkipValue(int n)
        {
            n = n % Step == 0 ? n - Step : n / Step * Step;
            if (n < 0) return 0;
            return n;
        }
    }
}
