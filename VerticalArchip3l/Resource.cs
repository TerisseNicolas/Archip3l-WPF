using System;

namespace VerticalArchip3l
{
    class Resource
    {
        public string Name;
        public int Stock;
        public int Production { get; private set; }

        public Resource(string argName)
        {
            this.Name = argName;
            this.Stock = 0;
            this.Production = 0;
        }

        public Resource(string argName, int quantity)
        {
            this.Name = argName;
            this.Stock = quantity;
            this.Production = 0;
        }
        public bool changeProduction(int value)
        {
            if(this.Production + value >= 0)
            {
                this.Production += value;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool changeStock(int value)
        {

            if (this.Stock + value >= 0)
            {
                this.Stock += value;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}