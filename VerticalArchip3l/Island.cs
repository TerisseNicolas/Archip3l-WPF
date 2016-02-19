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

        public event EventHandler<TransferResourceToIslandEventArgs> TransferResourceToIsland; 

        public Island(int id, Canvas canvas)
        {
            this.Id = id;
            this.Canvas = canvas;
            this.BuildingManager = new BuildingManager(this);
            this.ResourceManager = new ResourceManager();

            //conection to resource reception from another island
            
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

        public void giveRessourceToIsland(ResourceType resourceType, int quantity, Island islandDest)
        {
            if(this.ResourceManager.changeResourceStock(resourceType, - quantity))
            {
                islandDest.ResourceManager.changeResourceStock(resourceType, quantity);
                if(this.TransferResourceToIsland != null)
                {
                    this.TransferResourceToIsland(this, new TransferResourceToIslandEventArgs { Origin = this,
                                                                                                Destination = islandDest,
                                                                                                ResourceType = resourceType,
                                                                                                Quantity = quantity });
                }
            }
        }
    }
    class TransferResourceToIslandEventArgs : EventArgs
    {
        public Island Origin;
        public Island Destination;
        public ResourceType ResourceType;
        public int Quantity;
    }
}
