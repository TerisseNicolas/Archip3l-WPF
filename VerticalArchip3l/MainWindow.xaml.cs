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

            //Managing time------------------------------------- to be replaced with a time class
            remainingTime = new DateTime(1, 1, 1, 0, 15, 0);
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();

            //Trophies-----------------------------------------
            Trophy trophy1 = new Trophy(1, "Trophée ressources", "Gain de ressources", null);
            Trophy trophy2 = new Trophy(2, "Trophée innovation", "Multiplication de la productivité par 1.5", null);

            Image trophy1Image = new Image
            {
                Name = "trophy" + trophy1.Id,
                Source = new BitmapImage(new Uri(trophy1.Image, UriKind.Absolute)),
            };
            trophy2.changeToObtained();
            Image trophy2Image = new Image
            {
                Name = "trophy" + trophy2.Id,
                Source = new BitmapImage(new Uri(trophy2.Image, UriKind.Absolute)),
            };

            //positionnement
            ScaleTransform scaleTransform1 = new ScaleTransform(0.5, 0.5, 0, 0);
            trophy1Image.RenderTransform = scaleTransform1;
            TimerRow.Children.Add(trophy1Image);
            Canvas.SetTop(trophy1Image, 50);
            Canvas.SetLeft(trophy1Image, 50);
            trophy2Image.RenderTransform = scaleTransform1;
            TimerRow.Children.Add(trophy2Image);
            Canvas.SetTop(trophy2Image, 50);
            Canvas.SetLeft(trophy2Image, 160);
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
