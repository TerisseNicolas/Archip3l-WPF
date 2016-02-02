using SofthinkCore.Base;
using SofthinkCore.UI.Base.Command;
using SofthinkCore.UI.Keyboard;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SofthinkCoreShowCase.Demos.WebBrowser
{
    public class WebDemoViewModel : ViewModelBase
    {
        #region UrlCollection Property
        /// <summary>
        /// Property urlCollection
        /// </summary>
        private ObservableCollection<string> urlCollection;

        /// <summary>
        /// Property UrlCollection
        /// </summary>
        public ObservableCollection<string> UrlCollection
        {
            get { return urlCollection; }
            set
            {
                if (urlCollection != value)
                {
                    urlCollection = value;
                    RaisePropertyChanged(() => this.UrlCollection);
                }
            }
        }

        #endregion

        public WebDemoViewModel()
        {
            //set url collection into webbrowser
            UrlCollection = new ObservableCollection<string>();
            UrlCollection.Add("www.microsoft.com");
            UrlCollection.Add("www.youtube.fr");
            UrlCollection.Add("www.gmail.com");
        }

    }
}
