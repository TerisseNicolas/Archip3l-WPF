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
        public int consumptionCost;     //quantity consumed every 10 seconds
        public string ressourceProduced;
        public int productionCost;      //quantity produced every 10 seconds
        public int state; //0 : being built, 1 : built, 2 : closed
        public string imageBeingBuilt;
        public string imageBuilt;
        public int coordX;
        public int coordY;
        public int constructionTime;    //time after which the building'state becomes 1


        public Building(string argName)     //TODO : finir switch + initialiser state : démarrer TIMER pour construction
        {
            name = argName;
            switch (argName)
            {
                case "scierie":
                    ressourceNeeded = "or";
                    consumptionCost = 3;
                    ressourceProduced = "bois";
                    productionCost = 4;
                    coordX = 0;
                    coordY = 0;
                    constructionTime = 5;
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
            imageBeingBuilt = "c:\tempConcours\building-beingbuilt-" + argName + ".png";
            imageBuilt = "c:\tempConcours\building-built-" + argName + ".png";

           
        }

        public async Task<bool> build(int time)
        {
            //construction


            //TODO : ajouter image being-built
            state = 0;
            System.Diagnostics.Debug.WriteLine(name + " is being constructed");
            await Task.Delay(TimeSpan.FromSeconds(time));
            System.Diagnostics.Debug.WriteLine(name + " is now constructed");
            state = 1;
            //TODO : actualiser image built

            return true;
        }


        //consume the ressourceNeedded and produce the ressourceProduced (only if there was still a stock of ressourceNeedded)
        //method called by an Island, each 10 seconds while the state of the building is 1
        public void consume_produce(Island island)
        {
            RessourceManager rm = new RessourceManager();
            //checks if the ressourceNeeded exists and if there is enough of its stock
            if ((island.getRessource(ressourceNeeded) != null) && (island.getRessource(ressourceNeeded).stock >= consumptionCost))  
            {
                rm.withdrawRessource(ressourceNeeded, island, consumptionCost); //consumption
                rm.giveRessource(ressourceProduced, island, productionCost);    //production
            }            
        }

    }
}
