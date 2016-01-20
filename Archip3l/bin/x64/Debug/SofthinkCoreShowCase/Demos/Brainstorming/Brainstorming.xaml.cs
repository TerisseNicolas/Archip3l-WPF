using SofthinkCoreShowCase.DemoCommon.Model;
using SofthinkCoreShowCase.DemoManager;
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

namespace SofthinkCoreShowCase.Demos.Brainstorming
{
    /// <summary>
    /// Interaction logic for Brainstorming.xaml
    /// </summary>
    [DemoAttribute(Name = "Brainstorming")]
    public partial class Brainstorming : UserControl
    {
        public PostitCollection Postits
        { get; private set; }

        public Brainstorming()
        {
            InitializeComponent();           

            Postits = new PostitCollection();

            DataContext = this;
        }
    }
}
