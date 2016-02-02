using SofthinkCore.UI.DragDrop;
using SofthinkCoreShowCase.DemoCommon.Model;
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

namespace SofthinkCoreShowCase.Demos.Logical
{
    /// <summary>
    /// Interaction logic for LogicalPanelItemsControl.xaml
    /// </summary>
    [SofthinkCoreShowCase.DemoManager.Demo(Name = "Logical Panel 2")]
    public partial class LogicalPanelItemsControl : UserControl
    {
        public LogicalPanelItemsControl()
        {
            InitializeComponent();

            for (int i = 0; i < 5; i++)
            {
                panel1.Items.Add(new PostitViewModel() { Position = new Point(i * 110,i * 110) });
            }

            for (int i = 0; i < 5; i++)
            {              
                panel2.Items.Add(new PostitViewModel() { Position = new Point(i * 110, i * 110) });
            }
        }

        private void panel2_Drop(object sender, RoutedEventArgs e)
        {
            var darg = e as DragDropArgs;
            if (panel1.Items.Contains(darg.Data))
                panel1.Items.Remove(darg.Data);

            panel2.Items.Add(darg.Data);

        }

        private void panel1_Drop(object sender, RoutedEventArgs e)
        {
            var darg = e as DragDropArgs;
            if (panel2.Items.Contains(darg.Data)) 
            panel2.Items.Remove(darg.Data);

            panel1.Items.Add(darg.Data);
        }

        private void panel1_CanDrop(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
        }

        private void panel2_CanDrop(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
        }

        
    }
}
