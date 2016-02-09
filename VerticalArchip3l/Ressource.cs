using System;

namespace VerticalArchip3l
{
    class Ressource
    {
        public string Name;
        public int Stock;
        public int Production { get; private set; }

        public Ressource(string argName)
        {
            this.Name = argName;
            this.Stock = 0;
            this.Production = 0;
        }

        public Ressource(string argName, int quantity)
        {
            this.Name = argName;
            this.Stock = quantity;
            this.Production = 0;
        }
        public bool increaseProduction(int value)
        {
            this.Production += value;
            return true;
        }
        public bool decreaseProduction(int value)
        {
            if(this.Production - value >= 0)
            {
                this.Production -= value;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool increaseStock(int value)
        {
            this.Stock += value;
            return true;
        }
        public bool decreaseStock(int value)
        {
            if(this.Stock - value >= 0)
            {
                this.Stock -= value;
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}