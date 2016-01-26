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


        public void createBuilding(string name)
        {
            buildings.Add(new Building(name));
        }

        //give a stock of "quantity" of the ressource named "name" to "island"
        public void giveRessourceToIsland(string name, int quantity, Island island)
        {
            RessourceManager rm = new RessourceManager();
            //we give to "island" the quantity withdrawn from the current island
            rm.giveRessource(name, island, rm.withdrawRessource(name, this, quantity));
        }



    }
}
