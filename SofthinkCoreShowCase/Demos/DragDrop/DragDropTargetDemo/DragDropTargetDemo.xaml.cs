using SofthinkCore.Utils;
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

namespace SofthinkCoreShowCase.Demos.DragDrop
{
    /// <summary>
    /// Interaction logic for DragDropTargetDemo.xaml
    /// </summary>
    [SofthinkCoreShowCase.DemoManager.Demo(Name = "Drag & Drop Target", Category = "Drag & Drop")]
    public partial class DragDropTargetDemo : UserControl
    {
        public PostitCollection Postits1
        { get; private set; }

        public PostitCollection Postits2
        { get; private set; }

        public PostitCollection Postits3
        { get; private set; }

        public DragDropTargetDemo()
        {
            InitializeComponent();

            DataContext = this;

            Loaded += DragDropTargetDemo_Loaded;

            Postits1 = new PostitCollection();
            

            Postits2 = new PostitCollection();
            

            Postits3 = new PostitCollection();
            

        }

        void DragDropTargetDemo_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                Postits1.Add(new PostitViewModelA
                {
                    Text = RandomHelper.GetRandomSmallerThan(50),
                    Position = new Point(RandomHelper.GetRandomDouble(0, items.ActualWidth - 150), RandomHelper.GetRandomDouble(0, items.ActualHeight - 150)),
                });
            }

            for (int i = 0; i < 10; i++)
            {
                Postits2.Add(new PostitViewModelB
                {
                    Text = RandomHelper.GetRandomSmallerThan(50),
                    Position = new Point(RandomHelper.GetRandomDouble(0, items2.ActualWidth - 150), RandomHelper.GetRandomDouble(0, items2.ActualHeight - 150)),
                });
            }

            for (int i = 0; i < 10; i++)
            {
                Postits3.Add(new PostitViewModelC
                {
                    Text = RandomHelper.GetRandomSmallerThan(50),
                    Position = new Point(RandomHelper.GetRandomDouble(0, items3.ActualWidth - 150), RandomHelper.GetRandomDouble(0, items3.ActualHeight - 150))
                });
            }
        }
    }
}
