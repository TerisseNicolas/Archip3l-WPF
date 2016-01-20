using SofthinkCore.Application;
using SofthinkCore.Devices;
using SofthinkCoreShowCase.AppInfo;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SofthinkCoreShowCase.DemoManager
{
    /// <summary>
    /// Interaction logic for ConfigControl.xaml
    /// </summary>
    public partial class ConfigControl : UserControl
    {
        public ConfigControl()
        {
            InitializeComponent();
        }

        private void Orientation_ButtonTap(object sender, RoutedEventArgs e)
        {
            var ui = sender as UIElement;
            var orientation = DeviceOrientation.GetOrientation(ui);
            if (orientation.Equals(ConfigSofthink.OrientationType.Vertical))
                DeviceOrientation.SetOrientation(SofthinkCoreContext.Instance.Window, ConfigSofthink.OrientationType.Horizontal);
            else
                DeviceOrientation.SetOrientation(SofthinkCoreContext.Instance.Window, ConfigSofthink.OrientationType.Vertical);
            e.Handled = true;
        }

        private void UbiComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var enumr = e.AddedItems.GetEnumerator();
            if (enumr.MoveNext())
            {
                Application.Current.Resources.MergedDictionaries.Clear();
                Application.Current.Resources.MergedDictionaries.Add(((StyleInfo)enumr.Current).GetDictionary());
            }             

        }

        private void UbiComboBox_LanguageChanged(object sender, SelectionChangedEventArgs e)
        {
            var enumr = e.AddedItems.GetEnumerator();
            if (enumr.MoveNext())
            {
                var c= new CultureInfo((string)enumr.Current);
                Application.Current.MainWindow.Language = XmlLanguage.GetLanguage(c.TwoLetterISOLanguageName);
            }

        }

        
    }
}
