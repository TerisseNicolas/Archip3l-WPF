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

namespace SofthinkCoreShowCase.Demos.DragDrop
{
    /// <summary>
    /// Interaction logic for DragDropHitTest.xaml
    /// </summary>
    [SofthinkCoreShowCase.DemoManager.Demo(Name = "Drag & Drop Hit Test", Category = "Drag & Drop")]
    public partial class DragDropHitTest : UserControl
    {
        public DragDropHitTest()
        {
            InitializeComponent();

            targetdrop.AddHandler(SofthinkCore.UI.DragDrop.DragAndDrop.CanDropEvent, new RoutedEventHandler(OnCanDrop));
            targetdrop2.AddHandler(SofthinkCore.UI.DragDrop.DragAndDrop.CanDropEvent, new RoutedEventHandler(OnCanDrop));
            targetdrop3.AddHandler(SofthinkCore.UI.DragDrop.DragAndDrop.CanDropEvent, new RoutedEventHandler(OnCanDrop));
        }

        private void OnCanDrop(object sender,RoutedEventArgs arg)
        {
            arg.Handled = true;
        }

        private void targetdrop_CanDrop(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
        }
    }
}
