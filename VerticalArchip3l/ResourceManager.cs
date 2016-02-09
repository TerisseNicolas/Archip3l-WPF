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
        public EventHandler<ResourceProductionEventArgs> ResourceProduction;
        public EventHandler<ResourceStockEventArgs> ResourceStock;

        public ResourceManager()
        {
            this.Resources = new List<Resource>();

            this.Resources.Add(new Resource("Bois"));
            this.Resources.Add(new Resource("Or"));
            this.Resources.Add(new Resource("Métal"));
            this.Resources.Add(new Resource("Nourriture"));
        }
        public bool changeResourceProduction(Resource resource, int value)
        {
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
        public bool changeResourceStock(Resource resource, int value)
        {
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

        //give a ressource named "name" to "island", with a stock of "quantity"
        //if the ressource didn't exist on "island", it is created
        //public void giveRessource(string name, Island island, int quantity)
        //{
        //    Ressource ressource = new Ressource(name, quantity);
        //    if (island.getRessource(name) == null)  //the island doesn't have this ressource
        //    {
        //        island.ressources.Add(new Ressource(name));
        //        island.getRessource(name).stock = quantity;
        //    }
        //    else    //the island has this ressource
        //    {
        //        island.getRessource(name).stock += quantity;
        //    }
        //}

        //withdraw a stock of "quantity" from a ressource named "name" of "island"
        //returns the effectively quantity withdrawn (if stock=5 & quantity=7, it returns 5)
        //public int withdrawRessource(string name, Island island, int quantity)
        //{
        //    Ressource ressource = island.getRessource(name);
        //    if (ressource == null)  //if the ressource doesn't exist on the island
        //        return 0;
        //    if (ressource.stock <= quantity)
        //    {
        //        int temp = ressource.stock;
        //        ressource.stock = 0;
        //        return temp;
        //    }
        //    else
        //    {
        //        ressource.stock -= quantity;
        //        return quantity;
        //    }
        //}
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