using DemoCommon.Controls;
using SofthinkCore.Utils;
using SofthinkCore.Utils.Geometry2D;
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

namespace SimpleGesture
{
    /// <summary>
    /// Logique d'interaction pour GestureXaml.xaml
    /// </summary>
    public partial class GestureXaml : UserControl
    {
        public GestureXaml()
        {
            InitializeComponent();
        }

        private void TapProcessor_Tap(object sender, SofthinkCore.Gestures.Processor.TapEventArgs e)
        {
            var postit = sender as Postit;
            postit.Background = new SolidColorBrush(RandomHelper.GetRandomColor());
        }

        private void HoldProcessor_Hold(object sender, SofthinkCore.Gestures.Processor.HoldEventArgs e)
        {
            var postit = sender as Postit;
            postit.Background = new SolidColorBrush(RandomHelper.GetRandomColor());
        }

        private void ManipulationProcessor_ManipulationUpdate(object sender, SofthinkCore.Gestures.Processor.ManipulationGestureEventArgs e)
        {
            var postit = sender as Postit;

            var matrix = (postit.RenderTransform != null) ? postit.RenderTransform.Value : new Matrix();

            Point ct = new Point(postit.RenderSize.Width / 2, postit.RenderSize.Height / 2);
            // transform it to take into account transforms from previous manipulations 
            ct = matrix.Transform(ct);
            //this will be a Zoom. 
            matrix.ScaleAt(e.Delta.ScaleX, e.Delta.ScaleY, ct.X, ct.Y);
            // Rotation 
            matrix.RotateAt(Geometry2DHelper.RadiansToDegree(e.Delta.Rotation), ct.X, ct.Y);
            //Translation (pan) 
            matrix.Translate(e.Delta.TranslationX, e.Delta.TranslationY);

            postit.RenderTransform = new MatrixTransform(matrix);
        }
    }
}
