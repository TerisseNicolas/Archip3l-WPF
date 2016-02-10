using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerticalArchip3l
{
    class Action
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public delegate bool DelegatePerform();
        public DelegatePerform PerformFuntion { get; private set; }

        public Action(string name, DelegatePerform performFunction)
        {
            this.Name = name;
            this.PerformFuntion = performFunction;
        }
        public Action(string name, DelegatePerform performFunction , string description) : this(name, performFunction)
        {
            this.Description = description;
        }
    }
}
