﻿using SofthinkCore.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace SofthinkCoreShowCase.Demos.Diagram.Swimlanes
{
    public class ToTransparentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            SolidColorBrush brush = value as SolidColorBrush;
            if (brush == null)
                return Brushes.Black;

            return new SolidColorBrush(new Color { A = 100, R = brush.Color.R, G = brush.Color.G, B = brush.Color.B });
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
