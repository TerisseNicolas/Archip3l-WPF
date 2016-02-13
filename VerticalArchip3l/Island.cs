using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

/// <summary>
/// ID : 0 = Main island, 1 = top left, 2 = top right, 3 = bottom left, 4 = bottom right
/// </summary>
namespace VerticalArchip3l
{
    class Island
    {
        public int Id { get; private set; }
        public BuildingManager BuildingManager { get; private set; }
        public ResourceManager ResourceManager { get; private set; }
        public IslandControls IslandControls { get; private set; }
        public Canvas Canvas { get; private set; }


        public Island(int id, Canvas canvas)
        {
            this.Id = id;
            this.Canvas = canvas;
            this.BuildingManager = new BuildingManager(this);
            this.ResourceManager = new ResourceManager();
            
            //Creation of Initial buildings
            //Creation of initial resources            
        }

        public bool createBuilding(BuildingType buildingType)
        {
            return this.BuildingManager.createBuilding(buildingType);
        }
        public bool destroyBuilding(BuildingType buildingType)
        {
            return this.BuildingManager.destroyBuilding(buildingType);
        }        

        public void giveRessourceToIsland(ResourceType res, int quantity, Island islandDest)
        {
            //ResourceManager rm = new ResourceManager();
            //int quantityWithdrawn = rm.withdrawRessource(name, this, quantity);
            ////we give to "island" the quantity withdrawn from the current island
            //if (quantityWithdrawn != 0)
            //{
            //    rm.giveRessource(name, island, quantityWithdrawn);
            //    System.Diagnostics.Debug.WriteLine("L'ile " + this.id.ToString() + " donne " + quantityWithdrawn.ToString() + " " + name + " à l'ile " + island.id.ToString());
            //}
            //else
            //    System.Diagnostics.Debug.WriteLine("La ressource " + name + " n'est plus disponible sur l'ile " + island.id.ToString());
        }


    }
}
