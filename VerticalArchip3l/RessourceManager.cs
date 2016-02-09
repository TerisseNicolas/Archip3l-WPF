using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerticalArchip3l
{
    class RessourceManager
    {
        public List<Ressource> Ressources; //list of existing ressources

        public RessourceManager()
        {
            this.Ressources = new List<Ressource>();

            this.Ressources.Add(new Ressource("Bois"));
            this.Ressources.Add(new Ressource("Or"));
            this.Ressources.Add(new Ressource("Métal"));
            this.Ressources.Add(new Ressource("Nourriture"));
        }

        //give a ressource named "name" to "island", with a stock of "quantity"
        //if the ressource didn't exist on "island", it is created
        //public void giveRessource(string name, Island island, int quantity)
        //{
        //    Ressource ressource = new Ressource(name, quantity);
        //    if (island.getRessource(name) == null)  //the island doesn't have this ressource
        //    {
        //        island.ressources.Add(new Ressource(name));
        //        island.getRessource(name).stock = quantity;
        //    }
        //    else    //the island has this ressource
        //    {
        //        island.getRessource(name).stock += quantity;
        //    }
        //}

        //withdraw a stock of "quantity" from a ressource named "name" of "island"
        //returns the effectively quantity withdrawn (if stock=5 & quantity=7, it returns 5)
        //public int withdrawRessource(string name, Island island, int quantity)
        //{
        //    Ressource ressource = island.getRessource(name);
        //    if (ressource == null)  //if the ressource doesn't exist on the island
        //        return 0;
        //    if (ressource.stock <= quantity)
        //    {
        //        int temp = ressource.stock;
        //        ressource.stock = 0;
        //        return temp;
        //    }
        //    else
        //    {
        //        ressource.stock -= quantity;
        //        return quantity;
        //    }
        //}
    }
}