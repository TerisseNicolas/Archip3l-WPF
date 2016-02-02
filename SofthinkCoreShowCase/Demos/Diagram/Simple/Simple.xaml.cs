using SofthinkCore.Gestures;
using SofthinkCore.Gestures.Processor;
using SofthinkCore.UI.Diagram;
using SofthinkCoreShowCase.DemoCommon.Model;
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

namespace SofthinkCoreShowCase.Demos.Diagram
{
    /// <summary>
    /// Interaction logic for Diagram2.xaml
    /// </summary>
    [SofthinkCoreShowCase.DemoManager.Demo(Name = "Diagram Simple", Category = "UbiDiagram")]
    public partial class Simple : UserControl
    {
        public Simple()
        {
            InitializeComponent();

            for (int i = 0; i < 10; i++)
            {
                diagram.Items.Add(new PostitViewModel() { Position = new Point(i * 200, i * 100) });
            }

            for (int i = 0; i < diagram.Items.Count - 1; i++)
            {
                var link = new UbiLink { SourceModel = diagram.Items[i], SinkModel = diagram.Items[i + 1] };
                var tap = new TapProcessor();
                tap.Tap += tap_Tap;
                link.Items.Add(new Ellipse { Width = 30, Height = 30, Fill = Brushes.Black });
                Gesture.AddGesture(link, tap);
                masterDiagram.Links.Add(link);
            }
        }

            void tap_Tap(object sender, TapEventArgs e)
        {
            var link = sender as UbiLink;
            var source = link.SourceModel;
            link.SourceModel = link.SinkModel;
            link.SinkModel = source;
        
        }
    }
}
