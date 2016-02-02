using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using SofthinkCore.UI.Base.Panels;

namespace SofthinkCoreShowCase.Demos.Logical
{
    public class VisualPanel : ConceptualPanel
    {
        protected override void OnChildAdded(UIElement child)
        {
            base.OnChildAdded(child);

            AddVisualChild(child);
        }

        protected override void OnChildRemoved(UIElement child)
        {
            base.OnChildRemoved(child);

            RemoveVisualChild(child);
        }

        protected override System.Windows.Size MeasureOverride(System.Windows.Size availableSize)
        {
            /*foreach (UIElement ui in Children)
            {
                ui.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
            }*/

            return base.MeasureOverride(availableSize);
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            foreach (UIElement ui in Children)
            {
                ui.Arrange(new Rect(ui.DesiredSize)); 
            }

            return base.ArrangeOverride(finalSize);
        }
    }
}
