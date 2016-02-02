using SofthinkCore.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using System.Windows.Media;
using dd = SofthinkCore.UI.DragDrop;

namespace SofthinkCoreShowCase.Demos.DragDrop.DragDrop_FakeVisual
{
    public class DragDropOutsideBehaviour : Behavior<UIElement>
    {
        UIElement _control;
        bool isHit = false;

        public DragDropOutsideBehaviour()
        {

        }

        protected override void OnAttached()
        {
            base.OnAttached();

            dd.DragAndDrop.AddDragStartedHandler(AssociatedObject, new RoutedEventHandler(OnDragStarted));

            _control = WpfHelper.FindAncestorOfType<ItemsControl>(AssociatedObject);
        }

        private void OnDragStarted(object sender, RoutedEventArgs args)
        {
            var darg = args as dd.DragStartedArgs;
            darg.Context.Update += Context_Update;
            darg.Context.FeedbackContainer.Visibility = Visibility.Collapsed;
            darg.Context.FeedbackContainer.Opacity = 0.7;
        }

        void Context_Update(object sender, dd.DragDropArgs e)
        {
            var w = SofthinkCore.Application.SofthinkCoreContext.Instance.Window;
            isHit = false;
            VisualTreeHelper.HitTest(w, new HitTestFilterCallback(MyHitTestFilter), new HitTestResultCallback(MyHitTestResult), new PointHitTestParameters(w.PointFromScreen(e.HitPoint)));
            if (isHit)
                e.Feedback.Visibility = Visibility.Collapsed;
            else
                e.Feedback.Visibility = Visibility.Visible;
            isHit = false;
        }

        private HitTestResultBehavior MyHitTestResult(HitTestResult result)
        {
            return HitTestResultBehavior.Stop;
        }

        private HitTestFilterBehavior MyHitTestFilter(DependencyObject o)
        {

            if (o is UIElement && !((UIElement)o).IsHitTestVisible)
            {
                return HitTestFilterBehavior.ContinueSkipSelfAndChildren;
            }
            else
            {
                if (o == _control)
                {
                    isHit = true;
                    return HitTestFilterBehavior.Stop;
                }                    
                else
                    return HitTestFilterBehavior.Continue;
            }
        }
    }
}
