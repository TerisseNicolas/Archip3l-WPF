using SofthinkCore.Gestures;
using SofthinkCore.Gestures.Processor;
using SofthinkCore.Utils;
using SofthinkCoreShowCase.AppInfo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SofthinkCoreShowCase.DemoManager
{
    public class DemoManager : Control
    {
        public ObservableCollection<object> DemoCollection
        {
            get { return (ObservableCollection<object>)GetValue(DemoCollectionProperty); }
            set { SetValue(DemoCollectionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DemosCollection.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DemoCollectionProperty =
            DependencyProperty.Register("DemoCollection", typeof(ObservableCollection<object>), typeof(MainWindow), new PropertyMetadata(null));



        public string CurrentDemoName
        {
            get { return (string)GetValue(CurrentDemoNameProperty); }
            set { SetValue(CurrentDemoNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentDemoName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentDemoNameProperty =
            DependencyProperty.Register("CurrentDemoName", typeof(string), typeof(MainWindow), new PropertyMetadata("Choose a Demo"));



        public DemoInfo Demo
        {
            get { return (DemoInfo)GetValue(DemoProperty); }
            set { SetValue(DemoProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Demo.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DemoProperty =
            DependencyProperty.Register("Demo", typeof(DemoInfo), typeof(DemoManager), new PropertyMetadata(null, new PropertyChangedCallback(OnDemoChanged)));

        private static void OnDemoChanged(DependencyObject obj,DependencyPropertyChangedEventArgs arg)
        {
            var manager = obj as DemoManager;
            var demo = arg.NewValue as DemoInfo;

            manager.ShowDemo(demo);
        }

        

        ContentPresenter DemoContainer;
        UIElement DemoList;
        UIElement Config;

        static DemoManager()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DemoManager), new FrameworkPropertyMetadata(typeof(DemoManager)));
            Exit = new ExitCommand();
        }

        public class ExitCommand : ICommand
        {

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                System.Windows.Application.Current.Shutdown();
            }
        }

        public static ExitCommand  Exit{ get; set;}

        private UIElement currentDemoUI = null;

        static IEnumerable<Type> GetTypesWithHelpAttribute()
        {
            var assembly = Assembly.GetExecutingAssembly();
            foreach (Type type in assembly.GetTypes())
            {
                if (type.GetCustomAttributes(typeof(DemoAttribute), true).Length > 0)
                {
                    yield return type;
                }
            }
        }

        public DemoManager()
        {
            DataContext = this;

            var demoTypeLst = GetTypesWithHelpAttribute();

            DemoCollection = new ObservableCollection<object>();

            var dic = new Dictionary<string, DemoCategory>();

            foreach(Type type in demoTypeLst)
            {
                var attribute = type.GetCustomAttribute<DemoAttribute>();
                if(attribute.Category != null)
                {
                    DemoCategory cat = null;
                    if(dic.ContainsKey(attribute.Category))
                        cat = dic[attribute.Category];
                    else
                    {
                        cat = new DemoCategory { Name = attribute.Category };
                        dic.Add(cat.Name, cat);
                        DemoCollection.Add(cat);
                    }
                    cat.DemoList.Add(new DemoInfo() { Name = attribute.Name, ClassName = type.FullName });
                        
                }
                else
                    DemoCollection.Add(new DemoInfo() { Name = attribute.Name, ClassName = type.FullName });
            }         

            TapProcessor.AddTapBubbleHandler(this, new RoutedEventHandler(TapProcessor_Tap));

        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            DemoContainer = GetTemplateChild("DemoContainer") as ContentPresenter;
            DemoList = GetTemplateChild("demoList") as UIElement;
            Config = GetTemplateChild("config") as UIElement;

            if (currentDemoUI != null)
                DemoContainer.Content = currentDemoUI;
            else
            if (Demo != null)
                ShowDemo(Demo);
        }

        private void ShowDemo(DemoInfo demo)
        {
            var type = Type.GetType(demo.ClassName);
            if (type != null)
            {
                CurrentDemoName = demo.Name;
                var myObject = ReflectionHelper.InstanciateType<UIElement>(type);
                DemoContainer.Content = (UIElement)myObject;

                currentDemoUI = (UIElement) DemoContainer.Content;
            }
        }

        public void ShowHome()
        {
            var home = new ShowcaseHome(); 
            DemoContainer.Content = home;
            currentDemoUI = home;           
        }

        private void TapProcessor_Tap(object sender, RoutedEventArgs e)
        {

            if (((GestureEventArgs)e).Data is DemoInfo)
            {
                var demo = (DemoInfo)((GestureEventArgs)e).Data;

                Demo = demo;

                e.Handled = true;
            }

            if(((GestureEventArgs)e).Data.Equals("collapse list") )
            {
                if (DemoList.Visibility.Equals(System.Windows.Visibility.Visible))
                    DemoList.Visibility = System.Windows.Visibility.Collapsed;
                else
                    DemoList.Visibility = System.Windows.Visibility.Visible;

                e.Handled = true;
            }
           
        }

        private void Config_ButtonTap(object sender, RoutedEventArgs e)
        {
            if (Config.IsVisible)
                Config.Visibility = Visibility.Hidden;
            else
                Config.Visibility = Visibility.Visible;
        }
    }
}
