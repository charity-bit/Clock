
using System;
using Xamarin.Forms;
using Clock.Helpers;

namespace Clock.viewmodel
{
    public class TimerViewModel : BaseViewModel
    {
        private Timer _timer;

        private TimeSpan _totalSeconds = new TimeSpan(0, 10, 10);
        public TimeSpan TotalSeconds
        {
            get { return _totalSeconds; }
            set { SetProperty(ref _totalSeconds, value); }
        }

        public Command StartCommand { get; set; }
        public Command StopCommand { get; set; }
        public Command ResetCommand { get; set; }

        public TimerViewModel()
        {
            StartCommand = new Command(Start);
            StopCommand = new Command(Stop);
            ResetCommand = new Command(Reset);
            _timer = new Timer(new TimeSpan(0,0,1), CountDown);
            TotalSeconds = _totalSeconds;
        }

        private void Start()
        {
            _timer.Start();
        }

        private void CountDown()
        {
            if (_totalSeconds.TotalSeconds == 0)
            {
                
                Stop();
            }
            else
            {
                TotalSeconds = _totalSeconds.Subtract(new TimeSpan(0,0,1));
            }
        }

         private void Stop()
        {
            
            _timer.Stop();
        }

        private void Reset()
        {
            TotalSeconds = new TimeSpan(0, 0, 0);
            _timer.Stop();
        }


    }




}
