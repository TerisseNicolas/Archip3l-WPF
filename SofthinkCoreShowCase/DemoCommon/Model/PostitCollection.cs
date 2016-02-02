using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace SofthinkCoreShowCase.DemoCommon.Model
{
    public class PostitCollection : ObservableCollection<PostitViewModel> , INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public PostitCollection()
        {
            CreatePostitCommand = new CreatePostitCommandImpl(this);
            RemovePostitCommand = new RemovePostitCommandImpl(this);
        }

        protected override void OnCollectionChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            base.OnCollectionChanged(e);

            if(e.NewItems != null)
            {
                foreach(PostitViewModel p in e.NewItems)
                {
                    p.DeletionRequest += p_DeletionRequest;
                }
            }

            if (e.OldItems != null)
            {
                foreach (PostitViewModel p in e.OldItems)
                {
                    p.DeletionRequest -= p_DeletionRequest;
                }
            }
        }

        void p_DeletionRequest(object sender, EventArgs e)
        {
            this.Remove(sender as PostitViewModel);
        }

        private class CreatePostitCommandImpl : ICommand
        {
            PostitCollection collection;

            public CreatePostitCommandImpl(PostitCollection c)
            {
                collection = c;
            }

            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                collection.Add((PostitViewModel)parameter);
            }
        }

        private class RemovePostitCommandImpl : ICommand
        {
            PostitCollection collection;

            public RemovePostitCommandImpl(PostitCollection c)
            {
                collection = c;
            }

            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                collection.Remove((PostitViewModel)parameter);
            }
        }

        public ICommand CreatePostitCommand
        { get; private set; }

        public ICommand RemovePostitCommand
        { get; private set; }

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
    }

    
}
