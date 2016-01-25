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
        //DateTime remainingTime;
        private Timer timer;

        public MainWindow()
        {
            InitializeComponent();

            //Managing time------------------------------------
            this.timer = new Timer(0, 15, 0);
            this.timer.start();

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
    }
}
