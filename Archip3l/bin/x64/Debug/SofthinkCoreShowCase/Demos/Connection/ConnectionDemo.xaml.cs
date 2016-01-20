using SofthinkCore.Gestures;
using SofthinkCore.Gestures.Processor;
using SofthinkCore.Gestures.WPF;
using SofthinkCore.UI.Controls;
using SofthinkCore.UI.Controls.Connector;
using SofthinkCore.UI.DragDrop;
using SofthinkCore.UI.Keyboard;
using SofthinkCore.Utils;
using SofthinkCoreShowCase.DemoManager;
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
using System.Windows.Interactivity;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SofthinkCoreShowCase.Demos.ConnectionDemo
{
    /// <summary>
    /// Interaction logic for ConnectionDemo.xaml
    /// </summary>
    [DemoAttribute( Name = "Connection" ) ]
    public partial class ConnectionDemo : UserControl
    {
        public ConnectionDemo()
        {
            InitializeComponent();

            DragAndDrop.AddDragEnterHandler(this, onDragEnter);
            DragAndDrop.AddDragLeaveHandler(this, onDragLeave);
            DragAndDrop.AddDropHandler(this, onDrop);

            Loaded += ConnectionDemo_Loaded;

            

            var hold = new HoldProcessor() { AllowMultipleInstance = true };
            hold.Hold += hold_Hold;
            Gesture.AddGesture(canvastest, hold);
        }

        void ConnectionDemo_Loaded(object sender, RoutedEventArgs e)
        {
            UIElement prev = null;
            var h = ActualHeight * 0.8;
            for (int i = 0; i < ActualWidth; i += (int)(ActualWidth / 20.0))
            {
                var ui = AddRect(new Point(i , (System.Math.Sin(i) * (h / 2.0 )) + h / 2.0));

                if (prev != null)
                {
                    AddLink(prev, ui);
                }

                prev = ui;
            }
        }

        void hold_Hold(object sender, HoldEventArgs e)
        {
            AddRect(e.Transform.ConvertToVisual(canvastest).Center);
        }

        private UIElement AddRect(Point Position)
        {
            var ui = new Rectangle() { Stroke = Brushes.Black, Fill = Brushes.Beige, Height = 130, Width = 130 };
            Canvas.SetLeft(ui, Position.X);
            canvastest.Children.Add(ui);
            Canvas.SetTop(ui, Position.Y);

            ManipulationProcessor manip = new ManipulationProcessor() { ManipulationSuported = System.Windows.Input.Manipulations.Manipulations2D.Translate };
            manip.ManipulationUpdate += manip_ManipulationUpdate;
            ui.AddGesture(manip);

            DragAndDrop.SetAllowDrop(ui, true);

            var target = new LinkCreatorTarget();
            target.CanDropCallback = OnCanLinkDrop;
            target.LinkDropCallback = OnLinkDrop;
            Interaction.GetBehaviors(ui).Add(target);
            Interaction.GetBehaviors(ui).Add(new TemporaryLinkCreator());

            return ui;
        }

        private bool OnCanLinkDrop(DragDropArgs arg)
        {
            return true;
        }

        private void OnLinkDrop(UIElement source,UIElement sink,DragDropArgs arg)
        {
            AddLink(source, sink);
        }

        private Connection AddLink(UIElement source,UIElement sink)
        {
            var con = new Connection()
            {
                RoutingStyle = new RoutingStraightLine(),
                VisualStyle = new VisualSimpleLine() { Stroke = new Pen() { Brush = Brushes.Gray, DashStyle = new DashStyle(new double[] { 5, 5 }, 0), Thickness = 3 } },
                Source = source,
                Sink = sink,
                BeginCap = new GeometryDrawing(
                    new SolidColorBrush(Color.FromArgb(255, 181, 243, 20)),
                    new Pen(Brushes.Black, 4),
                    Geometry.Parse("M -17,0 L -24,14 L 0,0 L -25,-14 Z")
                ),
                EndCap = new GeometryDrawing(
                    new SolidColorBrush(Color.FromArgb(255, 181, 243, 20)),
                    new Pen(Brushes.Black, 4),
                    Geometry.Parse("M -17,0 L -24,14 L 0,0 L -25,-14 Z")
                )
            };
           
            AddGesture(con, con.BeginThumb);
            AddGesture(con, con.EndThumb);

            #region addTextbox

            var text = new UbiTextBox()
            {
                Padding = new Thickness(5),
                Background = Brushes.WhiteSmoke,
                Text = RandomHelper.GetRandomString(),
                FontSize = 12,
                MaxWidth = 150,
                MaxHeight = 100,
                AcceptsReturn = true,
                TextWrapping = TextWrapping.Wrap,
                TextAlignment = TextAlignment.Center,
            };
            var border = new Border() { Child = text, BorderBrush = Brushes.Black, BorderThickness = new Thickness(2) };
            var tap = new TapProcessor();
            tap.Tap += delegate(object o, TapEventArgs arg)
            {
                if (!text.IsReadOnly)
                    return;
                text.IsReadOnly = false;
                var key = KeyboardManager.RequestKeyboard(new KeyboardRequestArgs(text) { Position = arg.Transform.ConvertToVisual(text).Center /*GetCurrentPositionForElement(text)*/ });
                key.KeyboardClosed += delegate(object oo, System.EventArgs ee)
                {
                    text.IsReadOnly = true;
                };
            };
            TouchSurfaceWPF.GetOrCreateTouchSurface(border).AddGestureProcessor(tap);

            Connection.SetPlacementPercentage(text, 0.5);
            Connection.SetUseTangent(border, true);
            con.Children.Add(border);

            #endregion addTextbox

            conlayer.Children.Add(con);

            return con;
        }

        /// <summary>
        /// Add drag gesture on link end
        /// </summary>
        /// <param name="con"></param>
        /// <param name="thumb"></param>
        private void AddGesture(Connection con, UIElement thumb)
        {
            var begsurface = TouchSurfaceWPF.GetOrCreateTouchSurface(thumb);
            var drag = new DragProcessor() { UseMinimalDisplacement = false };
            drag.GestureStart += delegate(object sender, GestureEventArgs arg)
            {

                var data = new Dictionary<string, object>();
                data.Add("connector", con);
                data.Add("thumb", sender);
                var dd = DragAndDrop.StartDragDrop(drag, new DragDropParameters { Data = data }, thumb);

                if (sender == con.BeginThumb)
                {
                    con.Source = null;
                    con.SourceAnchor = new TargetAnchor() { Mode = TargetAnchor.AnchorMode.FreeAnchor, TargetPoint = new SofthinkCore.UI.Controls.Connector.Anchor { Point = arg.Transform.ConvertToVisual(conlayer).Center /*arg.GetCurrentPositionForElement(conlayer)*/ } };
                }
                else
                {
                    con.Sink = null;
                    con.SinkAnchor = new TargetAnchor() { Mode = TargetAnchor.AnchorMode.FreeAnchor, TargetPoint = new SofthinkCore.UI.Controls.Connector.Anchor { Point = arg.Transform.ConvertToVisual(conlayer).Center /*arg.GetCurrentPositionForElement(conlayer)*/ } };
                }

                con.IsHitTestVisible = false;

                dd.Cancel += delegate(object s, DragDropArgs e)
                {
                    con.IsHitTestVisible = true;
                };
            };

            drag.GestureMove += delegate(object sender, GestureEventArgs arg)
            {
                if (sender == con.BeginThumb)
                {
                    con.SourceAnchor.TargetPoint = new SofthinkCore.UI.Controls.Connector.Anchor { Point = arg.Transform.ConvertToVisual(conlayer).Center /*arg.GetCurrentPositionForElement(conlayer)*/ };
                }
                else
                {
                    con.SinkAnchor.TargetPoint = new SofthinkCore.UI.Controls.Connector.Anchor { Point = arg.Transform.ConvertToVisual(conlayer).Center /*arg.GetCurrentPositionForElement(conlayer)*/ };
                }
            };

            begsurface.AddGestureProcessor(drag);
        }

        void manip_ManipulationUpdate(object sender, ManipulationGestureEventArgs e)
        {
            e.ApplyDeltaOnRenderTransform();
        }


        public void onDragEnter(object o, RoutedEventArgs args)
        {
            var arg = args as DragDropArgs;
            var data = arg.Data as Dictionary<string, object>;
            if (data == null || !data.ContainsKey("connector"))
                return;

            var con = data["connector"] as Connection;
            ((Shape)arg.Hit).Fill = Brushes.Beige;
            var thumb = data["thumb"];

            if (arg.Hit is Shape)
            {
                if ((thumb == con.BeginThumb && con.Sink == ((Shape)arg.Hit))
                     || (thumb == con.EndThumb && con.Source == ((Shape)arg.Hit)))
                    return;

                ((Shape)arg.Hit).Fill = Brushes.Red;
                arg.Handled = true;
            }

        }

        public void onDragLeave(object o, RoutedEventArgs args)
        {
            var arg = args as DragDropArgs;
            var data = arg.Data as Dictionary<string, object>;
            if (data == null || !data.ContainsKey("connector"))
                return;

            if (arg.Hit is Shape && DragAndDrop.GetDropTargetDataCount(arg.Hit) == 0) 
            {
                ((Shape)arg.Hit).Fill = Brushes.Beige;
                arg.Handled = true;
            }
        }

        public void onDrop(object o, RoutedEventArgs args)
        {
            var arg = args as DragDropArgs;
            var data = arg.Data as Dictionary<string, object>;
            if (data == null || !data.ContainsKey("connector"))
                return;

            if (arg.Hit is Shape)
            {
                var con = data["connector"] as Connection;
                if (DragAndDrop.GetDropTargetDataCount(arg.Hit) == 0)
                    ((Shape)arg.Hit).Fill = Brushes.Beige;
                var thumb = data["thumb"];

                con.IsHitTestVisible = true;

                if (thumb == con.BeginThumb)
                {
                    if (con.Sink == ((Shape)arg.Hit))
                        return;

                    con.Source = ((Shape)arg.Hit);
                    con.SourceAnchor = new TargetAnchor() { Mode = TargetAnchor.AnchorMode.Auto };
                }
                else
                {
                    if (con.Source == ((Shape)arg.Hit))
                        return;

                    con.Sink = ((Shape)arg.Hit);
                    con.SinkAnchor = new TargetAnchor() { Mode = TargetAnchor.AnchorMode.Auto };
                }



                arg.Handled = true;
            }

        }
    }
}
