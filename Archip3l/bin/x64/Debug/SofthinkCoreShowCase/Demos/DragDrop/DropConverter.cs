using DemoCommon.Model;
using SofthinkCore.UI.DragDrop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace SofthinkCoreShowCase.Demos.DragDrop
{
    public class DropConverter : Freezable, IValueConverter 
    {


        public Visual VisualReference
        {
            get { return (Visual)GetValue(VisualReferenceProperty); }
            set { SetValue(VisualReferenceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for VisualReference.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty VisualReferenceProperty =
            DependencyProperty.Register("VisualReference", typeof(Visual), typeof(DropConverter), new PropertyMetadata(null));


        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var arg = value as DragDropArgs;
            var postit = arg.Data as PostitViewModel;
            var t = arg.Feedback.TransformToVisual(VisualReference);
            postit.Position = t.Transform(new Point(0, 0));
            arg.Handled = true;
            return postit;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        protected override Freezable CreateInstanceCore()
        {
            throw new NotImplementedException();
        }
    }
}
