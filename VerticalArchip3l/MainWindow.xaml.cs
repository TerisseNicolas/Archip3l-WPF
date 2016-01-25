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
    public partial class MainWindow : SofthinkWindow
    {
        private Timer timer;
        private List<Trophy> Trophies;

        public MainWindow()
        {
            InitializeComponent();
            this.Trophies = new List<Trophy>();

            //Managing time=================================================================================================
            this.timer = new Timer(0, 15, 0);
            this.timer.start();

            //Trophies======================================================================================================
            Trophy trophy1 = new Trophy(1, "Trophée ressources", "Gain de ressources", null);
            Trophy trophy2 = new Trophy(2, "Trophée innovation", "Multiplication de la productivité par 1.5", null);
            Trophy trophy3 = new Trophy(3, "Trophée rapidité", "Multiplication de la productivité par 1.5", null);
            Trophy trophy4 = new Trophy(4, "Trophée stratégie", "Une description", null);
            Trophy trophy5 = new Trophy(5, "Trophée légende", "Une description", null);
            this.Trophies.Add(trophy1);
            this.Trophies.Add(trophy2);
            this.Trophies.Add(trophy3);
            this.Trophies.Add(trophy4);
            this.Trophies.Add(trophy5);
            trophy2.changeToObtained();
            trophy3.changeToObtained();
            trophy5.changeToObtained();

            //Scaling
            ScaleTransform trophyScaleTransform = new ScaleTransform(0.5, 0.5, 0, 0);
            foreach(Trophy t in Trophies)
            {
                //scaling
                t.Image.RenderTransform = trophyScaleTransform;
                //positioning
                TimerRow.Children.Add(t.Image);
                Canvas.SetTop(t.Image, 50);
            }
            Canvas.SetLeft(trophy1.Image, 50);
            Canvas.SetLeft(trophy2.Image, 160);
            Canvas.SetLeft(trophy3.Image, 270);
            Canvas.SetLeft(trophy4.Image, 380);
            Canvas.SetLeft(trophy5.Image, 490);
        }
    }
}
