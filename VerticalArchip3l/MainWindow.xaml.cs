using SofthinkCore.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace VerticalArchip3l
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : SofthinkWindow
    {
        DateTime remainingTime;

        public MainWindow()
        {
            InitializeComponent();

            //Managing time
            remainingTime = new DateTime(1, 1, 1, 0, 0, 15);
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }
        void timer_Tick(object sender, EventArgs e)
        {
            string minutes, secondes;
            if (remainingTime.Minute != 0 || remainingTime.Second != 0)
            {
                remainingTime = remainingTime.AddSeconds(-1);
                if (remainingTime.Minute > 9)
                    minutes = remainingTime.Minute.ToString();
                else
                    minutes = "0" + remainingTime.Minute.ToString();
                if (remainingTime.Second > 9)
                    secondes = remainingTime.Second.ToString();
                else
                    secondes = "0" + remainingTime.Second.ToString();
                TextBlockRemainingTime.Content = "Temps restant : " + minutes + ":" + secondes;
            }
            else
            {
                TextBlockRemainingTime.Foreground = Brushes.Red;
            }
        }
    }
}
