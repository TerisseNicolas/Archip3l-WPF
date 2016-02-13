using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerticalArchip3l
{
    class Building
    {
        public BuildingType BuildingType { get; private set; }
        public ResourceManager ResourceManager { get; private set; }
        public int BuildState;

        public event EventHandler<BuildingConstructionStartEventArgs> BuildingConstructionStart;
        public event EventHandler<BuildingConstructionEndEventArgs> BuildingConstructionEnd;

        public string name;
        public string ressourceNeeded;
        public int consumptionCost;     //quantity consumed every 10 seconds
        public string ressourceProduced;
        public int productionCost;      //quantity produced every 10 seconds
        public string imageBeingBuilt;
        public string imageBuilt;
        public int constructionTime;    //time after which the building'state becomes 1

        public Building(BuildingType buildingType)
        {
            this.BuildingType = buildingType;
            this.ResourceManager = new ResourceManager();
            this.BuildState = 0;

            this.name = String.Empty;
            switch (buildingType)
            {
                case BuildingType.Scierie:
                    ressourceNeeded = "or";
                    consumptionCost = 3;
                    ressourceProduced = "bois";
                    productionCost = 4;
                    constructionTime = 5;
                    break;
                case BuildingType.Mine:
                    ressourceNeeded = null;
                    consumptionCost = 0;
                    ressourceProduced = "or";
                    productionCost = 0;
                    constructionTime = 0;
                    break;
                case BuildingType.Usine:
                    ressourceNeeded = null;
                    consumptionCost = 0;
                    ressourceProduced = "metal";
                    productionCost = 0;
                    constructionTime = 0;
                    break;
                case BuildingType.Ferme:
                    ressourceNeeded = null;
                    consumptionCost = 0;
                    ressourceProduced = "metal";
                    productionCost = 0;
                    constructionTime = 0;
                    break;
            }

            imageBeingBuilt = @"c:\tempConcours\building-beingbuilt-" + this.name + ".png";
            imageBuilt = @"c:\tempConcours\building-built-" + this.name + ".png";

            //this.build();
        }
        public Building(BuildingType buildingType, string name) : this(buildingType)
        {
            this.name = name;
        }

        //public async Task<bool> build(int time, int x, int y, Canvas canvas)
        //{
        //    state = 0;
        //    System.Diagnostics.Debug.WriteLine("La construction du batiment " + name + " a commencé !");

        //    //creation of the image of the building in construction
        //    Image image = new Image
        //    {
        //        Width = 50,
        //        Height = 50,
        //        Name = this.name,
        //        Source = new BitmapImage(new Uri(imageBeingBuilt, UriKind.Absolute)),
        //    };
        //    Canvas.SetTop(image, y);
        //    Canvas.SetLeft(image, x);
        //    indexCanvas = canvas.Children.Add(image);

        //    await Task.Delay(TimeSpan.FromSeconds(time));   //construction of the building
        //    state = 1;
        //    System.Diagnostics.Debug.WriteLine("Le batiment " + name + " est construit !");

        //    //modification of the image: the building is now built
        //    image.Source = new BitmapImage(new Uri(imageBuilt, UriKind.Absolute));
        //    return true;

        //}


        //consume the ressourceNeedded and produce the ressourceProduced (only if there was still a stock of ressourceNeedded)
        //method called by an Island, each 10 seconds while the state of the building is 1
        //public void consume_produce(Island island)
        //{
        //    RessourceManager rm = new RessourceManager();
        //    //checks if the ressourceNeeded exists and if there is enough of its stock
        //    if ((island.getRessource(ressourceNeeded) != null) && (island.getRessource(ressourceNeeded).stock >= consumptionCost))
        //    {
        //        rm.withdrawRessource(ressourceNeeded, island, consumptionCost); //consumption
        //        rm.giveRessource(ressourceProduced, island, productionCost);    //production
        //        System.Diagnostics.Debug.WriteLine("Le batiment " + this.name + " utilise " + this.consumptionCost.ToString() + " " + this.ressourceNeeded + " et produit " + this.productionCost.ToString() + " " + this.ressourceProduced + " sur l'ile " + island.id.ToString());
        //    }
        //    else
        //    {
        //        System.Diagnostics.Debug.WriteLine("Le batiment " + this.name + " ne peut plus produire de " + this.ressourceProduced + " car il ne reste pas assez de " + ressourceNeeded + " sur l'ile " + island.id.ToString());
        //    }
        //}

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
