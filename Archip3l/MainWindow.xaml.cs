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
using System.Diagnostics;
using SofthinkCore.Gestures.WPF;
using SofthinkCore.Gestures.Processor;
using SofthinkCore.Gestures;

namespace Archip3l
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : SofthinkWindow
    {
        private List<Island> islands;
       
        public MainWindow()
        {
            InitializeComponent();

            islands = new List<Island>
            {
                new MajorIsland(0),
                new MinorIsland(1),
                new MinorIsland(2),
                new MinorIsland(3),
                new MinorIsland(4)
            };

            /*----------- Tests -------------*/
            islands[0].createBuilding("scierie", 200, 100, CanIsl1);    //200 & 100 got by position of touch event


            /*-------------------------------*/
        }


        private Island getIsland(int id)
        {
            return islands[id];
        }
        
       
    }
}
