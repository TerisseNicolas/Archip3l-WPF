using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archip3l
{
    class RessourceManager
    {
        public List<Ressource> ressources;

        public RessourceManager()
        {
            ressources = new List<Ressource>()
            {
                new Ressource("bois"),
                new Ressource("or"),
                new Ressource("metal")
            };
        }

        public Ressource getRessource(string argName)
        {
            int i = 0;
            while (i <= ressources.Count)
            {
                if (ressources[i].name == argName)
                    return ressources[i];
                i++;
            }
            return null;
        }

        public void giveRessource(Island island)
        {

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
