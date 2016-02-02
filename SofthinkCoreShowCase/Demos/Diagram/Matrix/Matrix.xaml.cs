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

namespace SofthinkCoreShowCase.Demos.Diagram.Matrix
{
    /// <summary>
    /// Interaction logic for Matrix.xaml
    /// </summary>
    [SofthinkCoreShowCase.DemoManager.Demo(Name = "Matrix", Category = "UbiDiagram")]
    public partial class Matrix : UserControl
    {
        public Matrix()
        {
            InitializeComponent();

            for (int i = 0; i < 10; i++)
            {
                S.Items.Add(new PostitViewModel() { Position = new Point(i * 200, i * 100), Text = RandomHelper.GetRandomSmallerThan(20) });
                W.Items.Add(new PostitViewModel() { Position = new Point(i * 200, i * 100), Text = RandomHelper.GetRandomSmallerThan(20) });
                O.Items.Add(new PostitViewModel() { Position = new Point(i * 200, i * 100), Text = RandomHelper.GetRandomSmallerThan(20) });
                T.Items.Add(new PostitViewModel() { Position = new Point(i * 200, i * 100), Text = RandomHelper.GetRandomSmallerThan(20) });
            }
        }
    }
}
