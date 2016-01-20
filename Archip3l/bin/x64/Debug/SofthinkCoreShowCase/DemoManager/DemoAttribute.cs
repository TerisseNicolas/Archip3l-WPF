using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SofthinkCoreShowCase.DemoManager
{
    [AttributeUsage(AttributeTargets.All)]
    public class DemoAttribute : Attribute
    {
        public string Name { get; set; }

        public string Category { get; set; }
    }
}
