using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archip3l
{
    class RessourceManager
    {
        public List<string> ressources; //list of existing ressources

        public RessourceManager()
        {
            ressources = new List<string>()
            {
                "bois",
                "or",
                "metal"
            };
        }

        //give a ressource whose name is "name" to "island", with a stock of "quantity"
        public void giveRessource(string name, Island island, int quantity)
        {
            Ressource ressource = new Ressource(name, quantity);
            if (island.getRessource(name) == null)  //the island doesn't have this ressource
            {
                island.ressources.Add(new Ressource(name));
                island.getRessource(name).stock = quantity;
            }
            else    //the island has this ressource
            {
                island.getRessource(name).stock += quantity;
            }
        }

        //withdraw a stock of "quantity" from a ressource whose name is "name" of "island"
        //returns the effectively quantity withdrawn (if stock=5 & quantity=7, it returns 5)
        public int withdrawRessource(string name, Island island, int quantity)
        {
            Ressource ressource = island.getRessource(name);
            if (ressource.stock <= quantity)
            {
                int temp = ressource.stock;
                ressource.stock = 0;
                return temp;
            }
            else
            {
                ressource.stock -= quantity;
                return quantity;
            }
        }

        public bool increaseProduction(Ressource ressource, int quantity)
        {
            ressource.production += quantity;
            return true;
        }

        public bool increaseConsumption(Ressource ressource, int quantity)
        {
            ressource.consumption += quantity;
            return true;

        }

        public bool increaseStock(Ressource ressource, int quantity)
        {
            ressource.stock += quantity;
            return true;
        }

        public bool decreaseProduction(Ressource ressource, int quantity)
        {
            if (ressource.production == 0)
                return false;
            else
            {
                ressource.production -= quantity;
                if (ressource.production < 0)
                    ressource.production = 0;
                return true;
            }
        }

        public bool decreaseConsumption(Ressource ressource, int quantity)
        {
            if (ressource.consumption == 0)
                return false;
            else
            {
                ressource.consumption -= quantity;
                if (ressource.consumption < 0)
                    ressource.consumption = 0;
                return true;
            }
        }

        public bool decreaseStock(Ressource ressource, int quantity)
        {
            if (ressource.stock == 0)
                return false;
            else
            {
                ressource.stock -= quantity;
                if (ressource.stock < 0)
                    ressource.stock = 0;
                return true;
            }
        }
        



    }
}
