using DemoCommon.Model;
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

namespace SofthinkCoreShowCase.Demos.GestureMVVM
{
    /// <summary>
    /// Interaction logic for GestureMVVMControl.xaml
    /// </summary>
    [SofthinkCoreShowCase.DemoManager.Demo(Name = "Gesture MVVM",Category="Gesture")]
    public partial class GestureMVVMControl : UserControl
    {
        public GestureMVVMControl()
        {
            InitializeComponent();
            DataContext = this;

            Postits = new PostitCollection();
        }    

        public PostitCollection Postits
        { get; private set; }

        
    }
}
