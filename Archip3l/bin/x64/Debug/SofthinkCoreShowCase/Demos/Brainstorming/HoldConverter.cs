﻿using System;
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
using DemoCommon.Model;
using SofthinkCore.UI.ContextMenu;

namespace SofthinkCoreShowCase.Demos.Brainstorming
{
    public class HoldConverter :Freezable, IValueConverter 
    {

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
       

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var tap = value as  SelectedMenuItemEventArgs;
            //return (Point) (VisualReference.PointFromScreen(tap.Center) - new Point(75, 75));    
            var pt = ((UIElement)tap.Menu).PointToScreen(new Point());
            return new PostitViewModel() { Text = RandomHelper.GetRandomSmallerThan(50), Position = (Point)(VisualReference.PointFromScreen(pt) ) , Color = Color };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        protected override Freezable CreateInstanceCore()
        {
            throw new NotImplementedException();
        }
    }
}
