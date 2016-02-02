using SofthinkCore.Utils;
using SofthinkCoreShowCase.DemoCommon.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace SofthinkCoreShowCase.Demos.Manipulation
{
    /// <summary>
    /// Interaction logic for ManipulationDemoControl.xaml
    /// </summary>
    [SofthinkCoreShowCase.DemoManager.Demo(Name = "Manipulation", Category = "Gesture")]
    public partial class ManipulationDemoControl : UserControl
    {
        public ManipulationDemoControl()
        {
            InitializeComponent();
            DataContext = this;

            Postits = new ObservableCollection<PostitViewModel>();
            for (int i = 0; i < 10; i++ )
                Postits.Add(new PostitViewModel { Text = RandomHelper.GetRandomSmallerThan(50) });
        }

        public ObservableCollection<PostitViewModel> Postits
        { get; private set; }
    }
}
