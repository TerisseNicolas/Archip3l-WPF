using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archip3l
{
    class Island
    {
        public int id;      //1 : haut gauche, 2 : haut droite, 3 : bas gauche, 4 : bas droite
        public List<Building> buildings;
        public List<Ressource> ressources;

        public Island(int id)
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
            while (i <= ressources.Count)
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
        
    }
}
