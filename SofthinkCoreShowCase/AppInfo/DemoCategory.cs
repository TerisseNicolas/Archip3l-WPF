using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SofthinkCoreShowCase.AppInfo
{
    public class DemoCategory
    {
        public string Name { get; set; }

        public List<DemoInfo> DemoList { get; set; }

        public DemoCategory()
        {
            DemoList = new List<DemoInfo>();
        }
    }
}
