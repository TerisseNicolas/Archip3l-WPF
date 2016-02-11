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

            //To be removed
            this.AddAction(new Action("Action1", TempPerformAction, "Action 1 super description, and some text, and again again etc ...."));
            this.AddAction(new Action("Action2", TempPerformAction, "Action 2 description. Do you see, this is my beautiful life, and some text ..."));
            this.AddAction(new Action("Action3", TempPerformAction, "Action 3 description: if you want, i can tell you a story. Once uppon a time, a little ... xd"));
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
        //To be removed
        public bool TempPerformAction()
        {
            return true;
        }
    }
    class PerformActionEventArgs : EventArgs
    {
        public Action Action;
    } 
}
