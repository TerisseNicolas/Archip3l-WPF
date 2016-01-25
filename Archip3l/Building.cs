using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archip3l
{
    class Building
    {
        public string name;
        public string ressourceNeeded;
        public int consumptionCost;
        public string ressourceProduced;
        public int productionCost;
        public bool state; //false: being built, true : built
        public int constructionTime;
        public string imageBeingBuilt;
        public string imageBuilt;


        public Building(string argName)     //TODO : finir case + initialiser state : démarrer TIMER pour construction
        {
            name = argName;
            switch (argName)
            {
                case "scierie":
                    ressourceNeeded = null;
                    consumptionCost = 0;
                    ressourceProduced = "bois";
                    productionCost = 0;
                    constructionTime = 0;
                    break;
                case "mine":
                    ressourceNeeded = null;
                    consumptionCost = 0;
                    ressourceProduced = "or";
                    productionCost = 0;
                    constructionTime = 0;
                    break;
                case "usine":
                    ressourceNeeded = null;
                    consumptionCost = 0;
                    ressourceProduced = "metal";
                    productionCost = 0;
                    constructionTime = 0;
                    break;
            }
            imageBeingBuilt = "building-beingbuilt-" + argName;
            imageBeingBuilt = "building-built-" + argName;
        }
        
    }
}
