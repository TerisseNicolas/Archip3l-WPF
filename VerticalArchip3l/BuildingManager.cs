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

        public event EventHandler<BuildingConstructionStartEventArgs> BuildingConstructionStart;
        public event EventHandler<BuildingConstructionEndEventArgs> BuildingConstructionEnd;
        public event EventHandler<BuildingDestructionEventArgs> BuildingDestruction;

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

        public bool createBuilding(BuildingType buildingType)
        {
           if(this.getBuilding(buildingType) == null)
           {
                Building newBuilding = new Building(buildingType, this.Island);
                this.BuildingList.Add(newBuilding);
                newBuilding.BuildingConstructionStart += NewBuilding_BuildingConstructionStart;
                newBuilding.BuildingConstructionEnd += NewBuilding_BuildingConstructionEnd;
                return true;
           }
           else
           {
                return false;
           }
        }
        public bool destroyBuilding(BuildingType buildingType)
        {
            if(this.BuildingList.Remove(this.getBuilding(buildingType)))
            {
                if(this.BuildingDestruction != null)
                {
                    this.BuildingDestruction(this, new BuildingDestructionEventArgs { BuildingType = buildingType, Island = this.Island });
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        //Events
        private void NewBuilding_BuildingConstructionStart(object sender, BuildingConstructionStartEventArgs e)
        {
        }
        private void NewBuilding_BuildingConstructionEnd(object sender, BuildingConstructionEndEventArgs e)
        {
        }
    }
    class BuildingDestructionEventArgs : EventArgs
    {
        public BuildingType BuildingType;
        public Island Island;
    }
}
