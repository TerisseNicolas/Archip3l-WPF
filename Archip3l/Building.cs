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


        public Building(string argName)
        {
            name = argName;
            ressourceNeeded = getRessourceNeeded(argName);
        }

        private string getRessourceNeeded(string name)
        {
            string ressourceNeeded = null;
            switch(name)
            {
                case "1":
                    ressourceNeeded = null;
                    break;
                case "2":
                    ressourceNeeded = null;
                    break;
                case "3":
                    ressourceNeeded = null;
                    break;
            }
            return ressourceNeeded;
        }

        private string getRessourceProduced(string name)
        {
            string ressourceProduced = null;
            switch (name)
            {
                case "1":
                    ressourceProduced = null;
                    break;
                case "2":
                    ressourceProduced = null;
                    break;
                case "3":
                    ressourceProduced = null;
                    break;
            }
            return ressourceProduced;
        }

        private string getImageBeingBuilt(string name)
        {
            return "building-beingbuilt-" + name;
        }

        private string getImageBuilt(string name)
        {
            return "building-built-" + name;
        }
    }
}
