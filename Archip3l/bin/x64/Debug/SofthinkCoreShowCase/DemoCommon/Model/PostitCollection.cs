using DemoCommon.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SofthinkCoreShowCase.DemoCommon.Model
{
    public class PostitCollection : ObservableCollection<PostitViewModel>
    {
        public PostitCollection()
        {
            CreatePostitCommand = new CreatePostitCommandImpl(this);
            RemovePostitCommand = new RemovePostitCommandImpl(this);
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
    }

    
}
