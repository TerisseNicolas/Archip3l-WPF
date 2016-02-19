using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerticalArchip3l
{

    /// <summary>
    /// To be improved a lot
    /// </summary>
    class Building
    {
        public BuildingType BuildingType { get; private set; }
        public ResourceManager ResourceManager { get; private set; }
        public int BuildState { get; private set; }
        public int ConstructionTime { get; private set; }
        public string Name { get; private set; }
        public Island Island { get; private set; }
        private List<Tuple<ResourceType, int>> ConstructionResourceNeeded;

        public event EventHandler<BuildingConstructionStartEventArgs> BuildingConstructionStart;
        public event EventHandler<BuildingConstructionEndEventArgs> BuildingConstructionEnd;

        public Building(BuildingType buildingType, Island island)
        {
            this.BuildingType = buildingType;
            this.ResourceManager = new ResourceManager();
            this.BuildState = 0;
            this.Island = island;
            this.ConstructionResourceNeeded = new List<Tuple<ResourceType, int>>();

            this.Name = String.Empty;
            switch (buildingType)
            {
                case BuildingType.Scierie:
                    this.ConstructionResourceNeeded.Add(new Tuple<ResourceType, int>(ResourceType.Or, 3));
                    this.ResourceManager.addResource(ResourceType.Bois, "bois", 0, 4);
                    //ressourceNeeded = "or";
                    //consumptionCost = 3;
                    //ressourceProduced = "bois";
                    //productionCost = 4;
                    this.ConstructionTime = 5;
                    break;
                case BuildingType.Mine:
                    this.ResourceManager.addResource(ResourceType.Or, "Or", 0, 1);
                    this.ConstructionTime = 0;
                    break;
                case BuildingType.Usine:
                    this.ConstructionTime = 0;
                    break;
                case BuildingType.Ferme:
                    this.ConstructionTime = 0;
                    break;
            }
            //this.build();
        }
        public Building(BuildingType buildingType, Island island, string name) : this(buildingType, island)
        {
            this.Name = name;
        }

        public async Task<bool> build()
        {
            //check needed resources
            foreach(Tuple<ResourceType, int> item in this.ConstructionResourceNeeded)
            {
                //avoid null references
                Resource resource = this.Island.ResourceManager.getResource(item.Item1);
                if((resource == null) || (item.Item2 < resource.Stock))
                {
                    return false;
                }
            }

            //start construction
            this.BuildState = 0;
            foreach (Tuple<ResourceType, int> item in this.ConstructionResourceNeeded)
            {
                this.Island.ResourceManager.changeResourceStock(item.Item1, - item.Item2);
            }
            if (this.BuildingConstructionStart != null)
            {
                this.BuildingConstructionStart(this, new BuildingConstructionStartEventArgs { BuildingType = this.BuildingType, Island = this.Island });
            }
            await Task.Delay(TimeSpan.FromSeconds(this.ConstructionTime));

            //end construction
            this.BuildState = 1;
            if (this.BuildingConstructionEnd != null)
            {
                this.BuildingConstructionEnd(this, new BuildingConstructionEndEventArgs { BuildingType = this.BuildingType, Island = this.Island });
            }
            return true;
        }
        public bool changeProduction(ResourceType resourceType, int value)
        {
            return this.ResourceManager.changeResourceProduction(resourceType, value);
        }
    }
    class BuildingConstructionStartEventArgs : EventArgs
    {
        public BuildingType BuildingType;
        public Island Island;
    }
    class BuildingConstructionEndEventArgs : EventArgs
    {
        public BuildingType BuildingType;
        public Island Island;
    }
}
