using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SofthinkCoreShowCase.AppInfo
{
    public class StyleInfo
    {
        public Uri DicUri { get; set; }

        public string Name { get; set; }

        public ResourceDictionary GetDictionary()
        {
            return new ResourceDictionary { Source = DicUri };
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
