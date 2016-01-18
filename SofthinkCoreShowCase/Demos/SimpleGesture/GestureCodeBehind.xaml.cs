using DemoCommon.Controls;
using SofthinkCore.Gestures;
using SofthinkCore.Gestures.Processor;
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
    /// Logique d'interaction pour GestureCodeBehind.xaml
    /// </summary>
    public partial class GestureCodeBehind : UserControl
    {
        public GestureCodeBehind()
        {
            InitializeComponent();

            //tap
            var tap = new TapProcessor();
            tap.Tap += Tap_Tap;
            Gesture.AddGesture(tap_postit,tap);

            //hold
            var hold = new HoldProcessor();
            hold.Hold += Hold_Hold;
            Gesture.AddGesture(hold_postit, hold);

            //manip
            var manip = new ManipulationProcessor();
            manip.ManipulationUpdate += Manip_ManipulationUpdate;
            Gesture.AddGesture(manipulate_postit, manip);

            //all
            /*tap = new TapProcessor();
            tap.Tap += Tap_Tap;
            Gesture.AddGesture(all_postit, tap);

            hold = new HoldProcessor();
            hold.Hold += Hold_Hold;
            Gesture.AddGesture(all_postit, hold);*/

            manip = new ManipulationProcessor();
            manip.ManipulationUpdate += Manip_ManipulationUpdate;
            Gesture.AddGesture(all_postit, manip);

        }      

        private void Tap_Tap(object sender, TapEventArgs e)
        {
            var postit = sender as Postit;
            postit.Background = new SolidColorBrush(RandomHelper.GetRandomColor());
        }

        private void Hold_Hold(object sender, HoldEventArgs e)
        {
            var postit = sender as Postit;
            postit.Background = new SolidColorBrush(RandomHelper.GetRandomColor());
        }

        private void Manip_ManipulationUpdate(object sender, ManipulationGestureEventArgs e)
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
