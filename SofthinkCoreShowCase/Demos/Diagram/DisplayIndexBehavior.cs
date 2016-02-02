using SofthinkCore.Views.DragNDrop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Interactivity;

namespace SofthinkCoreShowCase.Demos.Diagram
{
    public class DisplayIndexBehavior : Behavior<UIElement>
    {
        private AdornerContentPresenter adorner;

        protected override void OnAttached()
        {
            base.OnAttached();

            var zProperty = DependencyPropertyDescriptor.FromProperty(Panel.ZIndexProperty, typeof(UIElement));
            zProperty.AddValueChanged(AssociatedObject, new EventHandler(ZChanged));

            if(!TryInit())
                AssociatedObject.LayoutUpdated += AssociatedObject_LayoutUpdated;
        }

        void AssociatedObject_LayoutUpdated(object sender, EventArgs e)
        {
            if (TryInit())
                AssociatedObject.LayoutUpdated -= AssociatedObject_LayoutUpdated;
        }

        private bool TryInit()
        {
            var myAdornerLayer = AdornerLayer.GetAdornerLayer(AssociatedObject);
            if (myAdornerLayer == null)
                return false;
            adorner = new AdornerContentPresenter(AssociatedObject);
            adorner.Content = new TextBlock() { Text = Panel.GetZIndex(AssociatedObject).ToString(), FontSize = 15, Margin = new Thickness(10) };
            myAdornerLayer.Add(adorner);

            return true;
        }

        private void ZChanged(object sender, EventArgs eventArgs)
        {
            var ui = sender as UIElement;
            ((TextBlock)adorner.Content).Text = Panel.GetZIndex(AssociatedObject).ToString();
        }
    }
}
