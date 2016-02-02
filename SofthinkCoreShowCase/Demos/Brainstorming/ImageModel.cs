using SofthinkCoreShowCase.DemoCommon.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SofthinkCoreShowCase.Demos.Brainstorming
{
    public class ImageModel : PostitViewModel
    {
        private Uri _uri;
        public Uri URI
        {
            get { return _uri; }
            set
            {
                _uri = value;
                //if (PropertyChanged != null)
                  //  PropertyChanged(this, new PropertyChangedEventArgs("URI"));
            }
        }
       
    }
}
