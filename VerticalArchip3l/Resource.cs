using System;

namespace VerticalArchip3l
{
    class Resource
    {
        public ResourceType ResourceType { get; private set;}
        public string Name { get; private set; }
        public int Stock { get; private set; }
        public int Production { get; private set; }

        public Resource(ResourceType resourceType, string argName)
        {
            this.ResourceType = resourceType;
            this.Name = argName;
            this.Stock = 0;
            this.Production = 0;
        }
        public Resource(ResourceType resourceType, string argName, int quantity) : this(resourceType, argName)
        {
            if(quantity > 0)
            {
                this.Stock = quantity;
            }
        }
        public Resource(ResourceType resourceType, string argName, int quantity, int production) : this(resourceType, argName, quantity)
        {
            this.Production = production;
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
        public bool checkChangeProductionPossibility(int value)
        {
            return this.Production + value >= 0;
        }
        public bool checkChangeStockPossibility(int value)
        {
            return this.Stock + value >= 0;
        }
    }
}