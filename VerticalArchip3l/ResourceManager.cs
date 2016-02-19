using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerticalArchip3l
{
    class ResourceManager
    {
        public List<Resource> Resources;
        public event EventHandler<ResourceProductionEventArgs> ResourceProduction;
        public event EventHandler<ResourceStockEventArgs> ResourceStock;

        public ResourceManager()
        {
            this.Resources = new List<Resource>();

            this.Resources.Add(new Resource(ResourceType.Bois, "Bois"));
            this.Resources.Add(new Resource(ResourceType.Or, "Or"));
            this.Resources.Add(new Resource(ResourceType.Metal, "Métal"));
            this.Resources.Add(new Resource(ResourceType.Nourriture, "Nourriture"));
        }
        public bool addResource(ResourceType resourceType, string name, int quantity, int production)
        {
            bool flag = false;
            foreach(Resource item in this.Resources)
            {
                if(item.ResourceType == resourceType)
                {
                    flag = true;
                }
            }
            if(flag == true)
            {
                return false;
            }
            else
            {
                this.Resources.Add(new Resource(resourceType, name, quantity, production));
                return true;
            }
        }
        public bool changeResourceProduction(ResourceType resourceType, int value)
        {
            Resource resource = this.getResource(resourceType);
            bool result = resource.changeProduction(value);
            if (result)
            {
                if(this.ResourceProduction != null)
                {
                    this.ResourceProduction(this, new ResourceProductionEventArgs { Resource = resource, NewProduction = resource.Production });
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool changeResourceStock(ResourceType resourceType, int value)
        {
            Resource resource = this.getResource(resourceType);
            bool result = resource.changeStock(value);
            if (result)
            {
                if (this.ResourceStock != null)
                {
                    this.ResourceStock(this, new ResourceStockEventArgs { Resource = resource, NewStock = resource.Stock });
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool checkWithdrawPossibility(ResourceType resourceType, int value)
        {
            return this.getResource(resourceType).checkChangeStockPossibility(value);
        }
        public Resource getResource(ResourceType resourceType)
        {
            foreach(Resource item in this.Resources)
            {
                if(item.ResourceType == resourceType)
                {
                    return item;
                }
            }
            return null;
        }
    }
    class ResourceProductionEventArgs : EventArgs
    {
        public Resource Resource;
        public int NewProduction;
    }
    class ResourceStockEventArgs : EventArgs
    {
        public Resource Resource;
        public int NewStock;
    }
}