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
        private DispatcherTimer dispatcher;

        public Timer(int hours, int minutes, int secondes)
        {
            this.StartTimer = new TimeSpan(hours, minutes, secondes);
            this.EndTimer = new TimeSpan(0, 0, 0);
            this.Interval = new TimeSpan(0, 0, -1);
            this.RemainingTime = this.StartTimer;
            this.Running = false;
            this.dispatcher = new DispatcherTimer();
            this.dispatcher.Interval = TimeSpan.FromSeconds(1);
            this.dispatcher.Tick += timer_Tick;
        }
        public void start()
        {
            if (!this.Running)
            {
                this.dispatcher.Start();
                this.Running = true;
            }
        }
        public void stop()
        {
            if (this.Running)
            {
                this.dispatcher.Stop();
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
        private void updateAftermath()
        {
            // mettre a jour l'affichage
            Console.WriteLine("Temps restant : " + this.ToString());
            // gerer la liste des processus en cours (construction batiments..)
            // production des ressources
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
                    this.stop();
                }
                this.updateAftermath();
            }
        }
    }
}
