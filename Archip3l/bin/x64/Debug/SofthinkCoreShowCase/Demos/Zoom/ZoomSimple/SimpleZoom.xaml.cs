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

namespace SofthinkCoreShowCase.Demos.Zoom
{
    /// <summary>
    /// Interaction logic for SimpleZoom.xaml
    /// </summary>
    [SofthinkCoreShowCase.DemoManager.Demo(Name = "Zoom Simple",Category="Zoom")]
    public partial class SimpleZoom : UserControl
    {
        public SimpleZoom()
        {
            InitializeComponent();

            for(int i = 0; i < 20 ; i++)
            {
                grid.Children.Add(new Ellipse { Width = 100, Height = 100, Fill = Brushes.Red, Stroke = Brushes.Black, StrokeThickness = 5 , Margin = new Thickness(10)});
            }
        }
    }
}
