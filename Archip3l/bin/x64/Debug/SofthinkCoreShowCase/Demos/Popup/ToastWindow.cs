using SofthinkCore.UI.Popup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace SofthinkCoreShowCase.Demos.Popup
{
    public class ToastWindow : UbiWindow   
    {
        static ToastWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ToastWindow), new FrameworkPropertyMetadata(typeof(ToastWindow)));
        }

        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Message.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", typeof(string), typeof(ToastWindow), new PropertyMetadata(""));

        public ToastWindow()
        {
            Loaded += ToastWindow_Loaded;
        }

        void ToastWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var st = (Template.Resources["ToastAnim"] as Storyboard).Clone();
            st.Completed += st_Completed;
            st.Begin(this,Template);
        }

        void st_Completed(object sender, EventArgs e)
        {
            Hide();
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
        }
       

        
    }
}
