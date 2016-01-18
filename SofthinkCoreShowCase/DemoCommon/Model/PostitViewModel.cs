using SofthinkCore.UI.ContextMenu;
using SofthinkCore.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace DemoCommon.Model
{
    public class PostitViewModel : INotifyPropertyChanged
    {

        public PostitViewModel()
        {
            TextCommand = new ChangeTextCommand(this);
            ColorCommand = new ChangeColorCommand(this);
        }

        private Point _position;
        public Point Position
        {
            get { return _position; }
            set
            {
                _position = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Position"));
            }
        }

        private double _orientation;
        public double Orientation
        {
            get { return _orientation; }
            set
            {
                _orientation = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Orientation"));
            }
        }

        private string _text;
        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Text"));
            }
        }

        private Brush _color;
        public Brush Color
        {
            get { return _color; }
            set
            {
                _color = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Color"));
            }
        }

        private MenuItemCollection _menuItems;
        public MenuItemCollection MenuItems
        {
            get { return _menuItems; }
            set
            {
                _menuItems = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("MenuItems"));
            }
        }



        public ICommand TextCommand
        {
            get;
            private set;
        }

        public ICommand ColorCommand
        {
            get;
            private set;
        }

        public class ChangeTextCommand : ICommand
        {
            private PostitViewModel model;

            public ChangeTextCommand(PostitViewModel m)
            {
                model = m;
            }

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                model.Text = RandomHelper.GetRandomSmallerThan(50);
            }
        }

        public class ChangeColorCommand : ICommand
        {
            private PostitViewModel model;

            public ChangeColorCommand(PostitViewModel m)
            {
                model = m;
            }

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                model.Color = new SolidColorBrush(ColorHelper.ColorFromHSL(RandomHelper.GetRandomDouble(0, 360), RandomHelper.GetRandomDouble(0.3, 0.9), RandomHelper.GetRandomDouble(0.6, 0.9)));
            }
        }

        public class EditTextCommand : ICommand
        {
            private PostitViewModel model;

            public EditTextCommand(PostitViewModel m)
            {
                model = m;
            }

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                model.Text = RandomHelper.GetRandomSmallerThan(50);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
