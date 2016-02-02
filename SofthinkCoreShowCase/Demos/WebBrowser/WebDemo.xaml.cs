using System.Windows.Controls;

namespace SofthinkCoreShowCase.Demos.WebBrowser
{
    /// <summary>
    /// Logique d'interaction pour WebDemo.xaml
    /// </summary>
    [SofthinkCoreShowCase.DemoManager.Demo(Name = "Web Demo")]
    public partial class WebDemo : UserControl
    {
        public WebDemo()
        {
            InitializeComponent();

            //Set DataContext ViewFirst
            DataContext = new WebDemoViewModel();
        }

    }

}
