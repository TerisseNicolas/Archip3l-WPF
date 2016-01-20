using SofthinkCore.Application;
using SofthinkCore.Devices;
using SofthinkCore.Utils;
using SofthinkCoreShowCase.AppInfo;
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

namespace SofthinkCoreShowCase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : SofthinkWindow
    {
       

        /*public ObservableCollection<DemoInfo> DemoCollection
        {
            get { return (ObservableCollection<DemoInfo>)GetValue(DemoCollectionProperty); }
            set { SetValue(DemoCollectionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DemosCollection.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DemoCollectionProperty =
            DependencyProperty.Register("DemoCollection", typeof(ObservableCollection<DemoInfo>), typeof(MainWindow), new PropertyMetadata(null));



        public string CurrentDemoName
        {
            get { return (string)GetValue(CurrentDemoNameProperty); }
            set { SetValue(CurrentDemoNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentDemoName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentDemoNameProperty =
            DependencyProperty.Register("CurrentDemoName", typeof(string), typeof(MainWindow), new PropertyMetadata("Choose a Demo"));        */    

        public MainWindow()
        {
            InitializeComponent();

            /*DataContext = this;

            DemoCollection = new ObservableCollection<DemoInfo>();

            DemoCollection.Add(new DemoInfo() { Name = "Home", ClassName = "SofthinkCoreShowCase.ShowcaseHome" });
            DemoCollection.Add(new DemoInfo() { Name = "Gesture Simple" , ClassName = "SofthinkCoreShowCase.Demos.SimpleGesture.SimpleGesture"});
            DemoCollection.Add(new DemoInfo() { Name = "Gesture MVVM", ClassName = "SofthinkCoreShowCase.Demos.GestureMVVM.GestureMVVMControl" });
            DemoCollection.Add(new DemoInfo() { Name = "Manipulation", ClassName = "SofthinkCoreShowCase.Demos.Manipulation.ManipulationDemoControl" });
            DemoCollection.Add(new DemoInfo() { Name = "Context Menu", ClassName = "SofthinkCoreShowCase.Demos.ContextMenu.ContextMenu" });
            DemoCollection.Add(new DemoInfo() { Name = "Physic", ClassName = "SofthinkCoreShowCase.Demos.Physic.PhysicDemo" });

            //CurrentDemoName = DeviceOrientation.GetOrientation(DemoContainer).ToString();
            //System.Diagnostics.Debug.WriteLine("orientation inherited :"+DeviceOrientation.GetOrientation(DemoContainer));
            //for(int i = 0; i < 50 ; i++)
            //{ DemoCollection.Add(new DemoInfo() { Name = RandomHelper.GetRandomSmallerThan(30), ClassName = "SofthinkCoreShowCase.Demos.GestureMVVM.GestureMVVMControl" }); }*/
        }

        /*private void TapProcessor_Tap(object sender, SofthinkCore.Gestures.Processor.TapEventArgs e)
        {
            var fm = sender as FrameworkElement;
            var demo = fm.DataContext as DemoInfo;

            var type = Type.GetType(demo.ClassName);
            if(type != null)
            {
                CurrentDemoName = demo.Name;
                var myObject = Activator.CreateInstance(type);
                DemoContainer.Content = (UIElement)myObject;
            }         

            //e.Handled = true;
        }*/
    }
}
