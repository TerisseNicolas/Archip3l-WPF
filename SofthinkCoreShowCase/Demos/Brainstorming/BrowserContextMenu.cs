using SofthinkCore.UI.Base.Command;
using SofthinkCore.UI.ContextMenu;
using SofthinkCore.UI.Controls;
using SofthinkCore.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace SofthinkCoreShowCase.Demos.Brainstorming
{
    public class BrowserContextMenu : ContextMenuHandler
    {    

        public override void OnShowContextMenu(TouchChromium browserControl, IList<System.Windows.Input.ICommand> AvailableCommands, HtmlAgilityPack.HtmlDocument HitHtml, System.Windows.Point p)
        {
            ((UIElement)browserControl).Dispatcher.Invoke(new Action(() =>
            {
                var cl = new MenuItemCollection();

                var elment = HitHtml.DocumentNode.FirstChild;               

                if (elment.Name.Equals("img"))
                {
                    var url = elment.Attributes["src"].Value;
                    var action = new Action<object>((o) =>
                    {

                        var View = WpfHelper.FindAncestorOfType<Brainstorming>(browserControl);

                        View.Postits.Add(new ImageModel() { URI = new Uri(url), Position = new Point(100, 100), Color = Brushes.BlanchedAlmond });
                    });

                    cl.Add(new UbiMenuItem { Caption = "Image \nurl : " + url, Command = new RelayCommand<object>(action) });
                }
                if (elment.Name.Equals("a"))
                {
                    var url = elment.Attributes["href"].Value;
                    cl.Add(new UbiMenuItem { Caption = "Link \nurl : " + url });
                }

                cl.Add(new UbiMenuItem() { Caption = "Back", Command = browserControl.BackCommand });

                if(browserControl.IsSelecting)
                {
                    var action = new Action<object>((o) =>
                    {
                        var task = ChromiumHelper.GetSelection(browserControl.GetBrowser().MainFrame);
                        task.Wait();

                        var View = WpfHelper.FindAncestorOfType<Brainstorming>(browserControl);

                        View.Postits.Add(new DemoCommon.Model.PostitViewModel() { Text = task.Result, Position = new Point(100, 100) , Color = Brushes.BlanchedAlmond });
                    });
                    cl.Add(new UbiMenuItem() { Caption = "Copy", Command = new RelayCommand<object>(action) });
                }

                var res = new SofthinkCore.UI.Controls.WebBrowserRessource();
                res.InitializeComponent();
                var template = (UbiMenuTemplate)res["context_menu_template"];
                var menu = new UbiContextMenu() { OpeningEvent = null, Template = template, MenuItems = cl, Placement = UbiContextMenu.PlacementMode.Custom };
                UbiContextMenu.SetContextMenu((UIElement)browserControl, menu);
                UbiContextMenu.Show((UIElement)browserControl, p);
            }));
        }
    }
}
