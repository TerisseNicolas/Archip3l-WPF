using SofthinkCore.UI.Base.Panels;
using SofthinkCore.Utils;
using SofthinkCore.Utils.Geometry2D;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SofthinkCoreShowCase.Demos.Logical
{
    public class LogicalCanvas : LogicalPanel
    {

        public static LogicalCanvas GetLogicalCanvas(DependencyObject obj)
        {
            return (LogicalCanvas)obj.GetValue(LogicalCanvasProperty);
        }

        public static void SetLogicalCanvas(DependencyObject obj, LogicalCanvas value)
        {
            obj.SetValue(LogicalCanvasProperty, value);
        }

        // Using a DependencyProperty as the backing store for LogicalCanvas.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LogicalCanvasProperty =
            DependencyProperty.RegisterAttached("LogicalCanvas", typeof(LogicalCanvas), typeof(LogicalCanvas), new PropertyMetadata(null));     

        public Panel TargetPanel
        {
            get { return (Panel)GetValue(TargetPanelProperty); }
            set { SetValue(TargetPanelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TargetPanel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TargetPanelProperty =
            DependencyProperty.Register("TargetPanel", typeof(Panel), typeof(LogicalCanvas), new PropertyMetadata(null,new PropertyChangedCallback(OnTargetPanelChanged)));



        public static Point GetPosition(DependencyObject obj)
        {
            return (Point)obj.GetValue(PositionProperty);
        }

        public static void SetPosition(DependencyObject obj, Point value)
        {
            obj.SetValue(PositionProperty, value);
        }

        // Using a DependencyProperty as the backing store for Position.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PositionProperty =
            DependencyProperty.RegisterAttached("Position", typeof(Point), typeof(LogicalCanvas), new PropertyMetadata(new Point(0,0)));



        public static double GetAngle(DependencyObject obj)
        {
            return (double)obj.GetValue(AngleProperty);
        }

        public static void SetAngle(DependencyObject obj, double value)
        {
            obj.SetValue(AngleProperty, value);
        }

        // Using a DependencyProperty as the backing store for Angle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AngleProperty =
            DependencyProperty.RegisterAttached("Angle", typeof(double), typeof(LogicalCanvas), new PropertyMetadata(0.0));

        
       

        private static void OnTargetPanelChanged(DependencyObject obj,DependencyPropertyChangedEventArgs arg)
        {
            LogicalCanvas canvas = obj as LogicalCanvas;
            if(arg.NewValue != null)
            {
                Panel panel = arg.NewValue as Panel;
                var watcher = new VisualPositionWatcher(panel, canvas);
                watcher.PositionChanged += canvas.watcher_PositionChanged;
                foreach(UIElement ui in canvas.Children)
                {                   
                    canvas.OnChildAdded(ui);
                }

                canvas.InvalidateArrange();
            }
        }

        void watcher_PositionChanged(object sender, VisualPositionWatcher.PositionChangedEventArgs e)
        {
            refreshChildPosition();
        }

        public  LogicalCanvas()
        {
            Loaded += LogicalCanvas_Loaded;
        }

        void LogicalCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            refreshChildPosition();
            InvalidateMeasure();
        }

        /*protected override void OnLogicalChildrenChanged(UIElement childAdded, UIElement childRemoved)
        {
            base.OnLogicalChildrenChanged(childAdded, childRemoved);

            if (TargetPanel == null)
                return;

            if(childAdded != null)
            {
                TargetPanel.Children.Add(childAdded);
            }

            if(childRemoved != null)
            {
                TargetPanel.Children.Remove(childRemoved);
            }
        }*/

        protected override void OnChildAdded(UIElement child)
        {
            base.OnChildAdded(child);

            if (TargetPanel == null)
                return;

            DependencyPropertyDescriptor.FromProperty(LogicalCanvas.PositionProperty, typeof(UIElement)).AddValueChanged(child, PositionChanged);

            SetLogicalCanvas(child, this);

            if(!TargetPanel.Children.Contains(child))
                TargetPanel.Children.Add(child);

            
        }

        protected override void OnChildRemoved(UIElement child)
        {
            base.OnChildRemoved(child);

            if (TargetPanel == null)
                return;

            DependencyPropertyDescriptor.FromProperty(LogicalCanvas.PositionProperty, typeof(UIElement)).RemoveValueChanged(child, PositionChanged);

            SetLogicalCanvas(child, null);

            TargetPanel.Children.Remove(child);

        }

        private void PositionChanged(object sender, EventArgs eventArgs)
        {
            refreshChildPosition(sender as UIElement);
        }

        private void refreshChildPosition()
        {
            foreach (UIElement ui in Children)
            {
                refreshChildPosition(ui);
            }
        }

        private void refreshChildPosition(UIElement ui)
        {
           var pt = LogicalCanvas.GetPosition(ui);

           var m = Geometry2DHelper.GetMatrix(pt, 0, new Vector(1, 1));

            var t = Geometry2DHelper.GetLocalFromRef(TargetPanel, this, m);
            ui.RenderTransform = t;
        }

        


        protected override System.Windows.Size MeasureOverride(System.Windows.Size availableSize)
        {
            foreach(UIElement ui in Children )
            {
                ui.Measure(availableSize);
            }

            return base.MeasureOverride(availableSize);
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            if(IsLoaded)
            foreach (UIElement ui in Children)
            {
                refreshChildPosition(ui);
            }

            if(TargetPanel != null)
                TargetPanel.InvalidateArrange();

            return base.ArrangeOverride(finalSize);
        }


    }
}
