using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using VideospecTestProject.Uwp.Timer;
using ViewModel.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace VideospecTestProject.Uwp.Pages
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class PayByCashPage : Page
    {
        private readonly UtilitiesTimer timer;
        private readonly PaymentViewModel viewModel;

        public PayByCashPage()
        {
            InitializeComponent();
            viewModel = App.ViewModels.PaymentViewModel;
            timer = new UtilitiesTimer(textTimerBlock, Frame);
            timer.RegisterBackgroundTask();
            timer.StartTimer();
        }

        internal PaymentViewModel ViewModel => viewModel;

        private void AutorizationButtonPage_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AuthPage));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
