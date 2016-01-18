using SofthinkCore.UI.Base.Zoom;
using SofthinkCore.UI.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SofthinkCoreShowCase.Demos.Zoom
{
    /// <summary>
    /// Interaction logic for ZoomTest.xaml
    /// </summary>
    [SofthinkCoreShowCase.DemoManager.Demo(Name = "Zoom Virtualized",Category="Zoom")]
    public partial class ZoomVirtualized : UserControl
    {
        public ZoomVirtualized()
        {
            InitializeComponent();

            canvas.ContentCanvas.Background = FindResource("brush") as Brush;

            var zoom = new MapZoom(canvas.ContentCanvas);
            int x = 0;
            int y = 200;

            for(int i = 0;i < 10000;i++)
            {
                var e = new Grid { Width = 100, Height = 100 ,ClipToBounds = false};
                var el = new Ellipse { Fill = Brushes.Red, Stroke = Brushes.Black, StrokeThickness = 2 };
                e.Children.Add(el);
                var t = new TextBlock {  Text = i.ToString(), FontSize = 30 , ClipToBounds = false , VerticalAlignment = System.Windows.VerticalAlignment.Center,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center};
                e.Children.Add(t);
                VirtualCanvas.SetX(e,x * 100);
                VirtualCanvas.SetY(e, Math.Sin(i) * 200 + y);
                e.CacheMode = new BitmapCache();
                canvas.VirtualChildren.Add(e);

                var zoomProperty = DependencyPropertyDescriptor.FromProperty(TouchScrollViewer.ScrollViewerZoomProperty, typeof(Grid));
                zoomProperty.AddValueChanged(e, new EventHandler(ZoomChanged));

                e.RenderTransformOrigin = new Point(0.5,0.5);
                e.RenderTransform = new ScaleTransform();

                //el.Loaded += e_Loaded;
                

                x++;

                if (i % 500 == 0)
                {
                    x = 0;
                    y += 500;
                }                  
                
            }
                
            //LayoutUpdated += ZoomTest_LayoutUpdated;

            scroll.ScrollChanged += scroll_ScrollChanged;
            
        }

        /*void e_Loaded(object sender, RoutedEventArgs e)
        {
            var ui = sender as UIElement;
            ui.RenderTransformOrigin = new Point(0.5, 0.5);
            var scale = new ScaleTransform(0.5,0.5);
            ui.RenderTransform = scale;

            var stb = new Storyboard() { Duration = TimeSpan.FromMilliseconds(1000) , RepeatBehavior = RepeatBehavior.Forever };
            var dba = new DoubleAnimation { From = 0.0001, To = 1.0 };
            Storyboard.SetTargetProperty(dba, new PropertyPath(ScaleTransform.ScaleXProperty));
            Storyboard.SetTarget(dba, scale);
            stb.Children.Add(dba);
            var dba2 = new DoubleAnimation { From = 0.0001, To = 1.0 };
            Storyboard.SetTargetProperty(dba2, new PropertyPath(ScaleTransform.ScaleYProperty));
            Storyboard.SetTarget(dba2, scale);
            stb.Children.Add(dba2);
            //Storyboard.SetTarget(stb, ui);
            stb.Begin(this);        

        }*/

        private void ZoomChanged(object sender, EventArgs eventArgs)
        {
            var ui = sender as UIElement;
            var scale = ui.RenderTransform as ScaleTransform;
            var zoom = TouchScrollViewer.GetScrollViewerZoom(ui);
            scale.ScaleX = scale.ScaleY = 1.0 / zoom;
        }

        void scroll_ScrollChanged(object sender, System.Windows.Controls.ScrollChangedEventArgs e)
        {
            text_visual_child.Text = canvas.ContentCanvas.Children.Count.ToString();
            text_virtual_child.Text = canvas.VirtualChildren.Count.ToString();
        }

        void ZoomTest_LayoutUpdated(object sender, EventArgs e)
        {
            //text_virtual_child.GetBindingExpression(TextBlock.TextProperty).UpdateSource();
            //text_visual_child.GetBindingExpression(TextBlock.TextProperty).UpdateSource();
            
        }

        private void plus_ButtonTap(object sender, RoutedEventArgs e)
        {
            if (scroll.Zoom >= 1)
                scroll.Zoom++;
            else
                scroll.Zoom *= 2.0;
        }

        private void minus_ButtonTap(object sender, RoutedEventArgs e)
        {
            if (scroll.Zoom <= 1)
                scroll.Zoom /= 2.0;
            else
                scroll.Zoom--;
        }

        private void reset_ButtonTap(object sender, RoutedEventArgs e)
        {
            scroll.Zoom = 1;
        }
    }
}
