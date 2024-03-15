﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ViewModelBase.Commands.ErrorHandlers;

namespace ViewModelBase.Commands.AsyncCommands
{
    public abstract class AsyncCommandBase : IDisposable
    {
        public event EventHandler CanExecuteChanged;

        protected bool IsExecuting { get; set; }
        protected readonly IErrorHandler ErrorCancelHandler;
        protected CancellationToken InnerCancellationToken { get; set; } = CancellationToken.None;
        protected CancellationTokenSource ProxyCancellationTokenSource;

        protected AsyncCommandBase(IErrorHandler errorCancelHandler,
             bool cancellationSupport, CancellationToken cancelToken)
        {
            if (cancellationSupport)
            {
                if (cancelToken == CancellationToken.None)
                {
                    ProxyCancellationTokenSource = new CancellationTokenSource();
                    InnerCancellationToken = ProxyCancellationTokenSource.Token;
                }
                else InnerCancellationToken = cancelToken;
            }
            ErrorCancelHandler = errorCancelHandler;
        }

        public void RaiseCanExecuteChanged() =>
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);

        public bool IsNotCancelled
        {
            get
            {
                CancelException();
                return !InnerCancellationToken.IsCancellationRequested;
            }
        }

        protected void CancelException()
        {
            if (InnerCancellationToken == CancellationToken.None)
                throw new NotSupportedException("Данная команда не поддерживает отмену.");
        }

        public void Cancel()
        {
            CancelException();
            if (ProxyCancellationTokenSource is null)
                throw new TaskCanceledException("Управляйте отменой внешним ресурсом (CancellationTokenSource).");
            if (!ProxyCancellationTokenSource.IsCancellationRequested)
                ProxyCancellationTokenSource.Cancel();
        }

        public void ResetCancel()
        {
            CancelException();
            if (ProxyCancellationTokenSource is null)
                throw new TaskCanceledException(
                        "Управляйте отменой внешним ресурсом (CancellationTokenSource).");
            if (ProxyCancellationTokenSource.IsCancellationRequested)
            {
                ProxyCancellationTokenSource.Dispose();
                ProxyCancellationTokenSource = new CancellationTokenSource();
            }
            InnerCancellationToken = ProxyCancellationTokenSource.Token;
        }

        public void ResetCancel(ref CancellationTokenSource newCancellationTokenSource)
        {
            CancelException();
            if (ProxyCancellationTokenSource != null)
            {
                ProxyCancellationTokenSource.Dispose();
                ProxyCancellationTokenSource = null;
            }

            if (newCancellationTokenSource.IsCancellationRequested)
            {
                newCancellationTokenSource.Dispose();
                newCancellationTokenSource = new CancellationTokenSource();
            }
            InnerCancellationToken = newCancellationTokenSource.Token;
        }

        private bool _disposedValue;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    ProxyCancellationTokenSource?.Dispose();
                }

                // TODO: освободить неуправляемые ресурсы (неуправляемые объекты) и переопределить метод завершения
                // TODO: установить значение NULL для больших полей
                _disposedValue = true;
            }
        }

        // // TODO: переопределить метод завершения, только если "Dispose(bool disposing)" содержит код для освобождения неуправляемых ресурсов
        // ~AsyncCommandBase()
        // {
        //     // Не изменяйте этот код. Разместите код очистки в методе "Dispose(bool disposing)".
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Не изменяйте этот код. Разместите код очистки в методе "Dispose(bool disposing)".
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
