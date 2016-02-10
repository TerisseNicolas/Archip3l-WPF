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

            //To be removed
            this.AddAction("History action 1");
            this.AddAction("HIstory action 2");
        }
        public void AddAction(string msg)
        {
            this.History.Add(msg);
            Console.WriteLine("New action : " + msg);
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
            for (int i = this.History.Count - size; i < this.History.Count; i++)
            {
                values.Add(this.History[this.History.Count - size + i]);
            }
            return values;
        }
    }
    class NewActionHistoryEventArgs : EventArgs
    {
        public string Message;
    }
}
