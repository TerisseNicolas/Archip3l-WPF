using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerticalArchip3l
{
    class BuildingManager
    {
        public Island Island { get; private set; }
        public List<Building> BuildingList { get; private set; }

        public BuildingManager(Island island)
        {
            this.Island = island;
        }
        public Building getBuilding(BuildingType buildingType)
        {
            foreach(Building item in this.BuildingList)
            {
                if(item.BuildingType == buildingType)
                {
                    return item;
                }
            }
            return null;
        }

        //public async void createBuilding(BuildingType buildingType);
        public bool createBuilding(BuildingType buildingType)
        {
            //To be implemented
            return true;
        }
        //{
        ////TODO : appeler une fonction "défi" --> réussite = création du bâtiment ; échec = rien

        ////there can't be several buidlings of the same type ("name")
        //if (getBuilding(name) != null)
        //{
        //    System.Diagnostics.Debug.WriteLine("Le batiment " + name + " existe déjà !");
        //    return;
        //}

        //Building building = new Building(name, x, y);                   //instanciation
        //buildings.Add(building);
        //await building.build(building.constructionTime, x, y, canvas);  //addition of the building's image to the map (construction time)
        //while (building.state == 1)     //consumption/production during the building's life
        //{
        //    building.consume_produce(this);
        //    if (getRessource(building.ressourceNeeded) != null)
        //    {
        //        System.Diagnostics.Debug.WriteLine(getRessource(building.ressourceNeeded).Name + " : " + getRessource(building.ressourceNeeded).Stock);
        //        System.Diagnostics.Debug.WriteLine(getRessource(building.ressourceProduced).Name + " : " + getRessource(building.ressourceProduced).Stock);
        //    }
        //    await Task.Delay(TimeSpan.FromSeconds(10));
        //}
        ////if state is 2 --> building removed
        //canvas.Children.RemoveAt(building.indexCanvas);
        //System.Diagnostics.Debug.WriteLine("Le batiment " + building.name + " a été supprimé !");
        //building = null;
        //return;
        //}
        public bool destroyBuilding(BuildingType buildingType)
        {
            //To be implemented
            return true;
        }
        //destroy
    }
}
