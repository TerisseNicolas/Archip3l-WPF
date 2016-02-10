using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerticalArchip3l
{
    class ActionManager
    {
        public List<Action> Actions { get; private set; }
        public event EventHandler<PerformActionEventArgs> PerformAction;

        public ActionManager()
        {
            this.Actions = new List<Action>();
        }
        public void AddAction(Action action)
        {
            this.Actions.Add(action);
        }
        public void RemoveAction(Action action)
        {
            this.Actions.Remove(action);
        }
        public void Perform(Action action)
        {
            action.PerformFuntion();
            if(PerformAction != null)
            {
                PerformAction(this, new PerformActionEventArgs { Action = action });
            }
        }
    }
    class PerformActionEventArgs : EventArgs
    {
        public Action Action;
    } 
}
