using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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
        public string imageBeingBuilt;
        public string imageBuilt;
        public int coordX;
        public int coordY;
        public int constructionTime;


        public Building(string argName)     //TODO : finir switch + initialiser state : démarrer TIMER pour construction
        {
            name = argName;
            switch (argName)
            {
                case "scierie":
                    ressourceNeeded = null;
                    consumptionCost = 0;
                    ressourceProduced = "bois";
                    productionCost = 0;
                    coordX = 0;
                    coordY = 0;
                    constructionTime = 20;
                    break;
                case "mine":
                    ressourceNeeded = null;
                    consumptionCost = 0;
                    ressourceProduced = "or";
                    productionCost = 0;
                    coordX = 0;
                    coordY = 0;
                    constructionTime = 0;
                    break;
                case "usine":
                    ressourceNeeded = null;
                    consumptionCost = 0;
                    ressourceProduced = "metal";
                    productionCost = 0;
                    coordX = 0;
                    coordY = 0;
                    constructionTime = 0;
                    break;
            }
            imageBeingBuilt = "building-beingbuilt-" + argName + ".png";
            imageBuilt = "c:\tempConcours\building-built-" + argName + ".png";

            //ajouter image

           
        }

        private async void build(int time)
        {
            state = false;
            await Task.Delay(TimeSpan.FromSeconds(time));
            state = true;

            //actualiser image
        }

    }
}
