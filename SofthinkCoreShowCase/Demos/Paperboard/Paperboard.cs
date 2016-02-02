using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SofthinkCoreShowCase.Demos.Paperboard
{
    public class Paperboard : Control
    {
        static Paperboard()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Paperboard),new FrameworkPropertyMetadata(typeof(Paperboard)));           
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

        }



    }
}
