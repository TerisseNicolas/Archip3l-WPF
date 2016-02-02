using SofthinkCore.Utils;
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
using model = SofthinkCoreShowCase.DemoCommon.Model;
using SofthinkCore.UI.ContextMenu;
using SofthinkCoreShowCase.DemoManager;
using SofthinkCoreShowCase.DemoCommon.Model;

namespace SofthinkCoreShowCase.Demos.ContextMenu
{
    /// <summary>
    /// Interaction logic for MenuMVVM.xaml
    /// </summary>
    [DemoAttribute(Name = "Context Menu", Category = "Context Menu")]
    public partial class ContextMenu : UserControl
    {
        public ContextMenu()
        {
            InitializeComponent();

            DataContext = this;

            Postits = new ObservableCollection<PostitViewModel>();

            var menuItems = new List<UbiMenuItem>();
            menuItems.Add(new UbiMenuItem() { Caption = "Choix 1" });
            menuItems.Add(new UbiMenuItem() { Caption = "Choix 2" });
            menuItems.Add(new UbiMenuItem() { Caption = "Choix 3" });

            for (int i = 0; i < 30; i++)
            {
                PostitViewModel model = null;
                switch (RandomHelper.GetRandomInt(0, 3))
                {
                    case 0: model = new PostitViewModelA(); break;
                    case 1: model = new PostitViewModelB(); break;
                    case 2: model = new PostitViewModelC(); break;
                }
                model.Text = RandomHelper.GetRandomSmallerThan(50);
                model.Position = new Point(RandomHelper.GetRandomDouble(0, 1500), RandomHelper.GetRandomDouble(0, 1500));
                model.MenuItems = new MenuItemCollection();
                model.MenuItems.Add(new UbiMenuItem() { Caption = "Change Text", Command = model.TextCommand });
                model.MenuItems.Add(new UbiMenuItem() { Caption = "Change Color", Command = model.ColorCommand });
                model.MenuItems.Add(new UbiMenuItem() { Caption = "Change Nothing" });

                Postits.Add(model);
            }
        }

        public ObservableCollection<PostitViewModel> Postits
        { get; private set; }
    }
}
