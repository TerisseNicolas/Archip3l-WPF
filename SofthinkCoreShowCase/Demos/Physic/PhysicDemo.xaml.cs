using DemoCommon.Model;
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

namespace SofthinkCoreShowCase.Demos.Physic
{
    /// <summary>
    /// Interaction logic for PhysicDemo.xaml
    /// </summary>
    [SofthinkCoreShowCase.DemoManager.Demo(Name = "Physic")]
    public partial class PhysicDemo : UserControl
    {
        public PostitCollection Postits
        { get; private set; }

        public PhysicDemo()
        {
            InitializeComponent();

            DataContext = this;

            Postits = new PostitCollection();

            Loaded += PhysicDemo_Loaded;

            
        }

        void PhysicDemo_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 50; i++)
            {
                Postits.Add(new PostitViewModel
                {
                    Text = RandomHelper.GetRandomSmallerThan(100),
                    Position = new Point(RandomHelper.GetRandomDouble(0, ActualWidth), RandomHelper.GetRandomDouble(0, ActualHeight)),
                    Orientation = RandomHelper.GetRandomDouble(0, 360),
                    Color = new SolidColorBrush(ColorHelper.ColorFromHSL(RandomHelper.GetRandomDouble(0, 360), RandomHelper.GetRandomDouble(0.3, 0.9), RandomHelper.GetRandomDouble(0.6, 0.9)))
                });
            }
        }
    }
}
