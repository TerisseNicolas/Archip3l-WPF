using SofthinkCore.Utils;
using SofthinkCoreShowCase.DemoCommon.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace SofthinkCoreShowCase.Demos.DragDrop
{
    /// <summary>
    /// Interaction logic for DragDropDemo.xaml
    /// </summary>
    [SofthinkCoreShowCase.DemoManager.Demo(Name = "Drag & Drop", Category = "Drag & Drop")]
    public partial class DragDropDemo : UserControl
    {
        public PostitCollection Postits
        { get; private set; }

        public DragDropDemo()
        {
            InitializeComponent();

            DataContext = this;

            Postits = new PostitCollection();

            for (int i = 0; i < 20; i++)
            {
                Postits.Add(new PostitViewModel
                {
                    Text = RandomHelper.GetRandomSmallerThan(50),
                    Position = new Point(RandomHelper.GetRandomDouble(0, 1000), RandomHelper.GetRandomDouble(0, 1000)),
                    Color = new SolidColorBrush(ColorHelper.ColorFromHSL(RandomHelper.GetRandomDouble(0, 360), RandomHelper.GetRandomDouble(0.3, 0.9), RandomHelper.GetRandomDouble(0.6, 0.9)))
                });
            }
        }

        private void items_CanDrop(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
        }

       

    }
}
