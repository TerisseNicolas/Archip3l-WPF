using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace VerticalArchip3l
{
    class Timer
    {
        public bool Running { get; private set; }
        public TimeSpan StartTimer { get; private set; }
        public TimeSpan RemainingTime { get; private set; }
        private TimeSpan EndTimer;
        private TimeSpan Interval;
        public DispatcherTimer Dispatcher;
        public Game Game { get; private set; }
        public event EventHandler<FinalTickEventArgs> FinalTick;

        public Timer(Game game, int hours, int minutes, int secondes)
        {
            this.Game = game;
            this.StartTimer = new TimeSpan(hours, minutes, secondes);
            this.EndTimer = new TimeSpan(0, 0, 0);
            this.Interval = new TimeSpan(0, 0, -1);
            this.RemainingTime = this.StartTimer;
            this.Running = false;
            this.Dispatcher = new DispatcherTimer();
            this.Dispatcher.Interval = TimeSpan.FromSeconds(1);
            this.Dispatcher.Tick += timer_Tick;
        }
        public void start()
        {
            if (!this.Running)
            {
                this.Dispatcher.Start();
                this.Running = true;
            }
        }
        public void stop()
        {
            if (this.Running)
            {
                this.Dispatcher.Stop();
                this.Running = false;
            }
        }
        private bool finished()
        {
            if (this.RemainingTime == this.EndTimer)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override string ToString()
        {
            return String.Format("{0:00}:{1:00}", this.RemainingTime.Minutes, this.RemainingTime.Seconds);
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            if (this.Running)
            {
                if (!this.finished())
                {
                    this.RemainingTime = this.RemainingTime.Add(this.Interval);
                }
                else
                {
                    if(this.FinalTick != null)
                    {
                        FinalTick(this, new FinalTickEventArgs());
                    }
                    this.stop();
                }
            }
        }
    }
    class FinalTickEventArgs : EventArgs { }
}
