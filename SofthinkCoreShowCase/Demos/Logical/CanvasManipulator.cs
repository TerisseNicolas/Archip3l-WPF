using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using m = SofthinkCore.UI.Base.Manipulators;

namespace SofthinkCoreShowCase.Demos.Logical
{
    public class CanvasManipulator : m.GestureManipulator
    {
        static CanvasManipulator()
        {
            EffectProperty.OverrideMetadata(typeof(CanvasManipulator), new System.Windows.PropertyMetadata(null));
        }

        public CanvasManipulator()
        {

        }

        protected override void OnManipulationUpdate(m.ManipulationEventArgs arg)
        {
            var canvas = LogicalCanvas.GetLogicalCanvas(AssociatedObject);

            var delta = arg.Transform.ConvertToVisual(canvas).Delta;
            var pt = LogicalCanvas.GetPosition(AssociatedObject);
            pt.X += delta.Translation.X;
            pt.Y += delta.Translation.Y;
            LogicalCanvas.SetPosition(AssociatedObject,pt);
        }

        protected override System.Windows.Freezable CreateInstanceCore()
        {
            return new CanvasManipulator();
        }

        
    }
}
