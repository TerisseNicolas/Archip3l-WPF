using SofthinkCore.Gestures.Processor;
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
using cm = SofthinkCore.UI.Base.Manipulators;

namespace SofthinkCoreShowCase.Demos.Logical
{
    /// <summary>
    /// Interaction logic for LogicalPanel.xaml
    /// </summary>
    [SofthinkCoreShowCase.DemoManager.Demo(Name = "Logical Panel")]
    public partial class LogicalPanelDemo : UserControl
    {
        public LogicalPanelDemo()
        {
            InitializeComponent();

            for(int i = 0 ; i < 5 ; i++)
            {
                var p = new Rectangle { Width = 100, Height = 100, Fill = Brushes.YellowGreen, Stroke = Brushes.Black, StrokeThickness = 2 };
                LogicalCanvas.SetPosition(p, new Point(i * 110, i * 110));
                addGesture(p);
                panel1.Children.Add(p);
            }

            for (int i = 0; i < 5; i++)
            {
                var p = new Rectangle { Width = 100, Height = 100, Fill = Brushes.YellowGreen, Stroke = Brushes.Black, StrokeThickness = 2 };
                LogicalCanvas.SetPosition(p, new Point(i * 110, i * 110));
                addGesture(p);
                panel2.Children.Add(p);
            }
        }

        public void addGesture(UIElement ui)
        {
            var manip = new cm.GestureManipulator { Effect = null, Gesture = new DragProcessor() };
            cm.Manipulator.SetManipulator(ui, manip);
            manip.ManipulationUpdated += manip_ManipulationUpdated;
        }

        void manip_ManipulationUpdated(object sender, cm.ManipulationEventArgs e)
        {
            UIElement ui = ((cm.GestureManipulator)sender).AssociatedObject;
            var canvas = LogicalCanvas.GetLogicalCanvas(ui);

            var delta = e.Transform.ConvertToVisual(canvas).Delta;
            var pt = LogicalCanvas.GetPosition(ui);
            pt.X += delta.Translation.X;
            pt.Y += delta.Translation.Y;
            LogicalCanvas.SetPosition(ui, pt);

        }
    }
}
