using System;
using System.Collections.Generic;

namespace VerticalArchip3l
{
    class ActionHistoryManager
    {
        private List<string> History;
        public event EventHandler<NewActionHistoryEventArgs> NewAction;

        public ActionHistoryManager()
        {
            this.History = new List<string>();
        }
        public void AddAction(string msg)
        {
            this.History.Add(msg);
            if(this.NewAction != null)
            {
                NewAction(this, new NewActionHistoryEventArgs { Message = msg });
            }
        }
        public List<string> getLastActions(int limit)
        {
            int size = this.History.Count;
            if(limit < size)
            {
                size = limit;
            }

            List<string> values = new List<string>();
            if(size < 1)
            {
                return null;
            }
            for (int i = this.History.Count - size - 1; i < this.History.Count -1; i++)
            {
                values.Add(this.History[this.History.Count - i]);
            }
            return values;
        }
    }
    class NewActionHistoryEventArgs : EventArgs
    {
        public string Message;
    }
}
