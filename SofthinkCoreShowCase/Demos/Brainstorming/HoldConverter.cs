using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using SofthinkCore.Gestures.Processor;
using System.Windows;
using System.Windows.Media;
using SofthinkCore.Utils;
using SofthinkCore.UI.ContextMenu;
using SofthinkCoreShowCase.DemoCommon.Model;

namespace SofthinkCoreShowCase.Demos.Brainstorming
{
    

    public class HoldConverter :Freezable, IValueConverter 
    {

        public enum DataType
        {
            Text,
            Browser
        }

        public Brush Color
        {
            get { return (Brush)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Color.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ColorProperty =
            DependencyProperty.Register("Color", typeof(Brush), typeof(HoldConverter), new PropertyMetadata(Brushes.Gold));
        

        public Visual VisualReference
        {
            get { return (Visual)GetValue(VisualReferenceProperty); }
            set { SetValue(VisualReferenceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty VisualReferenceProperty =
            DependencyProperty.Register("VisualReference", typeof(Visual), typeof(HoldConverter), new PropertyMetadata(null));
       
        protected override Freezable CreateInstanceCore()
        {
            throw new NotImplementedException();
        }

        public object Convert(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            var tap = value as SelectedMenuItemEventArgs;
            //return (Point) (VisualReference.PointFromScreen(tap.Center) - new Point(75, 75));    
            var pt = ((UIElement)tap.Menu).PointToScreen(new Point());
            switch ((DataType)parameter)
            {
                case DataType.Text:
                    return new PostitViewModel() { Text = RandomHelper.GetRandomSmallerThan(50), Position = (Point)(VisualReference.PointFromScreen(pt) - new Point(75, 75)), Color = Color, Orientation = WpfHelper.getAngleForPosOnScreen(pt) };
                case DataType.Browser:
                    return new BrowserModel() { Position = (Point)(VisualReference.PointFromScreen(pt) - new Point(75, 75)), Color = Color, Orientation = WpfHelper.getAngleForPosOnScreen(pt) };
            }

            return null;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
