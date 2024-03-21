using System;
using Windows.ApplicationModel.Background;
using Windows.UI.Xaml;

namespace VideospecTestProject.Uwp.Timer
{
    //интерфейс для фоновй задачи
    public sealed class TimerBackgroundTask : IBackgroundTask
    {
        private BackgroundTaskDeferral _deferral; //объект отложенной задачи
        private int _seconds = 60; 

        public void Run(IBackgroundTaskInstance taskInstance)
        {
            //гетаем объект отложенной задачи для разрешения выполнения фоновой задачи
            _deferral = taskInstance.GetDeferral();

            //инициализируем таймер, который срабатывает каждую секунду.
            var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };

            //подписываемся на событие таймера.
            timer.Tick += Timer_Tick;

            timer.Start();
        }

        private void Timer_Tick(object sender, object e)
        {
            _seconds--;

            if (_seconds <= 0)
            {
                _deferral.Complete();
            }
        }
    }
}
