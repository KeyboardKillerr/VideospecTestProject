using System;
using VideospecTestProject.Uwp.Pages;
using Windows.ApplicationModel.Background;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace VideospecTestProject.Uwp.Timer
{

    public class UtilitiesTimer
    {
        private DispatcherTimer _timer;
        private int _seconds = 60;
        private TextBlock _timerTextBlock;
        private Frame _frame;


        public UtilitiesTimer(TextBlock timerTextBlock, Frame frame)
        {
            _timerTextBlock = timerTextBlock;
            _frame = Window.Current.Content as Frame;
        }


        /// <summary>
        ///регистрируем фоновую задачу для отслеживания времени.
        /// </summary>
        public async void RegisterBackgroundTask()
        {
            var backgroundAccessStatus = await BackgroundExecutionManager.RequestAccessAsync();
            if (backgroundAccessStatus == BackgroundAccessStatus.AlwaysAllowed)
            {
                var builder = new BackgroundTaskBuilder();
                builder.Name = "TimerBackgroundTask";
                builder.TaskEntryPoint = "VendiosRuntime.TimerBackgroundTask";
                builder.SetTrigger(new TimeTrigger(60, false)); //триггер запускается через 60 секунд
                builder.Register();
            }
        }

        /// <summary>
        ///запускаем таймер
        /// </summary>
        public void StartTimer()
        {
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }

        /// <summary>
        ///обработчик события таймера. Вызывается каждую сек
        /// </summary>
        private void Timer_Tick(object sender, object e)
        {
            _seconds--;
            UpdateTimerText();

            if (_seconds <= 0)
            {
                _timer.Stop();
                _timer = null;
                _frame.Navigate(typeof(MainPage));
            }
        }

        /// <summary>
        ///обновляет текстбокс с отображаемым временем
        /// </summary>
        private void UpdateTimerText()
        {
            _timerTextBlock.Text = _seconds.ToString();
        }
    }
}
