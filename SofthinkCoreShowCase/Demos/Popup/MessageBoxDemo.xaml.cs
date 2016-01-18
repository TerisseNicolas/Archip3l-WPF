using SofthinkCore.UI.Controls;
using SofthinkCore.UI.Popup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SofthinkCoreShowCase.Demos.Popup
{
    /// <summary>
    /// Interaction logic for MessageBoxDemo.xaml
    /// </summary>
    [SofthinkCoreShowCase.DemoManager.Demo(Name = "MessageBox", Category = "Window")]
    public partial class MessageBoxDemo : UserControl
    {
        public MessageBoxDemo()
        {
            InitializeComponent();
        }

        private void TouchButton_ButtonTap(object sender, RoutedEventArgs e)
        {
            var button = sender as TouchButton;
            UbiMessageBox.MessageBoxButtons MyStatus = (UbiMessageBox.MessageBoxButtons) Enum.Parse(typeof(UbiMessageBox.MessageBoxButtons),(string) button.Content, true);
            var box = new UbiMessageBox() { Title = "I am a message box!", Message = "Please Awnser me.", Buttons = MyStatus, PlacementTarget = button ,Placement = UbiWindow.PlacementMode.Top , IsModal = true };
            box.Show();

            box.Result += box_Result;
        }

        void box_Result(object sender, MessageBoxResultArgs e)
        {
            var toast = new ToastWindow { Message = "You Choosed :\n"+e.Result.ToString(), PlacementTarget = this };
            toast.Show();
        }
    }
}
