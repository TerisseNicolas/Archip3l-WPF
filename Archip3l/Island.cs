using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archip3l
{
    class Island
    {
        public List<Building> buildings;
        public List<Ressource> ressources;


        public Island()
        {
            buildings = new List<Building>();
            ressources = new List<Ressource>();
        }

        public Building getBuilding(string name)
        {
            int i = 0;
            while (i <= buildings.Count)
            {
                if (buildings[i].name == name)
                    return buildings[i];
                i++;
            }
            return null;
        }

        public Ressource getRessource(string name)
        {
            int i = 0;
            while (i < ressources.Count)
            {
                if (ressources[i].name == name)
                    return ressources[i];
                i++;
            }
            return null;
        }


        //creates a building, adds it to the list and starts the consumption/production of ressources (every 10 seconds)
        public async void createBuilding(string name)   
        {
            Building building = new Building(name);
            buildings.Add(building);
            await building.build(building.constructionTime);
            while (building.state == 1)
            {
                building.consume_produce(this);
                System.Diagnostics.Debug.WriteLine(getRessource(building.ressourceNeeded).name + " : " + getRessource(building.ressourceNeeded).stock);
                System.Diagnostics.Debug.WriteLine(getRessource(building.ressourceProduced).name + " : " + getRessource(building.ressourceProduced).stock);
                await Task.Delay(TimeSpan.FromSeconds(10));
            }
        }

        //give a stock of "quantity" of the ressource named "name" to "island"
        public void giveRessourceToIsland(string name, int quantity, Island island)
        {
            RessourceManager rm = new RessourceManager();
            int quantityWithdrawn = rm.withdrawRessource(name, this, quantity);
            //we give to "island" the quantity withdrawn from the current island
            if (quantityWithdrawn != 0)
                rm.giveRessource(name, island, quantityWithdrawn);
        }



    }
}
