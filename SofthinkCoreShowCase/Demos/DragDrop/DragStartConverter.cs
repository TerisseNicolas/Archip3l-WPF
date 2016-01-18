using SofthinkCore.UI.DragDrop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SofthinkCoreShowCase.Demos.DragDrop
{
    public class DragStartConverter : IValueConverter 
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var dragArg = value as DragStartedArgs;
            dragArg.Handled = true;
            return dragArg.Parameters.Data;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
