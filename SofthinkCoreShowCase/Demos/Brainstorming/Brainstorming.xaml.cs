using SofthinkCore.UI.ContextMenu;
using SofthinkCore.UI.DragDrop;
using SofthinkCore.UI.Keyboard;
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

            Postits.CollectionChanged += Postits_CollectionChanged;

            DataContext = this;

            DragAndDrop.AddCanDropHandler(this, new RoutedEventHandler(OnCanDrop));
            DragAndDrop.AddDropHandler(this, new RoutedEventHandler(OnDrop));
            DragAndDrop.SetAllowDrop(this, true);
        }

        private void OnCanDrop(object sender,RoutedEventArgs arg)
        {
            var darg = arg as DragDropArgs;
            if(darg.Data is Uri)
            {
                darg.Handled = true;
                return;
            }

        }

        private void OnDrop(object sender, RoutedEventArgs arg)
        {
            var darg = arg as DragDropArgs;
            if (darg.Data is Uri)
            {
                var uri = darg.Data as Uri;
                bool gif = uri.OriginalString.Contains(".gif") || uri.OriginalString.Contains("data:image/gif");
                Postits.Add(new ImageModel { URI = uri, Position = darg.Gesture.Transform.ConvertToVisual(this).Center});
                darg.Handled = true;
                return;
            }

        }

        void Postits_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if(e.NewItems != null)
            foreach(PostitViewModel m in e.NewItems)
            {
                /*var mi = new UbiMenuItem() { Caption = "Edition" };
                mi.Selected += (s, o) =>
                {
                    var keyboard = KeyboardManager.RequestKeyboard(new KeyboardRequestArgs(o.Menu.));
                    if (keyboard == null)
                        return;

                    postit.text.ActivateGesture(true);
                    ScatterView.GetBody(postit).BodyType = BodyType.Static;

                    keyboard.KeyboardClosed += delegate
                    {
                        postit.text.ActivateGesture(false);
                        ScatterView.GetBody(postit).BodyType = BodyType.Dynamic;
                    };
                };*/
            }
        }
    }
}
