using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using VideospecTestProject.Uwp.Exceptions;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
    public sealed partial class MainHubPage : Page
    {
        public MainHubPage()
        {
            InitializeComponent();
        }

        private void Ofd_Click(object sender, RoutedEventArgs e) => mainFrame.Navigate(typeof(ServicePage));

        private void Service1_Click(object sender, RoutedEventArgs e) => ShowNoAccesMessageBox();

        private void Service2_Click(object sender, RoutedEventArgs e) => ShowNoAccesMessageBox();

        private void ShowNoAccesMessageBox()
        {
            App.ErrorHandler.ErrorHandle(new NoAccessException("Нет доступа."));
        }
    }
}
