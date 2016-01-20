using SofthinkCore.UI.ContextMenu;
using SofthinkCoreShowCase.DemoCommon.Model;
using SofthinkCoreShowCase.DemoManager;
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

namespace SofthinkCoreShowCase.Demos.ContextMenu_MultiInstance
{
    /// <summary>
    /// Interaction logic for ContextMenuMultiInstance.xaml
    /// </summary>
    [DemoAttribute(Name = "Context Menu Multi Instance", Category = "Context Menu")]
    public partial class ContextMenuMultiInstance : UserControl
    {
        public PostitCollection Postits
        { get; private set; }

        public MenuItemCollection MenuItems
        {
            get;
            set;
        }

        public ContextMenuMultiInstance()
        {
            InitializeComponent();
            DataContext = this;

            Postits = new PostitCollection();

            MenuItems = new MenuItemCollection();
            MenuItems.Add(new UbiMenuItem() { Caption = "Add Yellow Postit", Command = Postits.CreatePostitCommand, Converter = new HoldConverter() { VisualReference = this, Color = Brushes.LemonChiffon } });
            MenuItems.Add(new UbiMenuItem() { Caption = "Add Pink Postit", Command = Postits.CreatePostitCommand, Converter = new HoldConverter() { VisualReference = this, Color = Brushes.LightPink } });
            MenuItems.Add(new UbiMenuItem() { Caption = "Add Green Postit", Command = Postits.CreatePostitCommand, Converter = new HoldConverter() { VisualReference = this, Color = Brushes.GreenYellow } });

        }

        
    }
}
