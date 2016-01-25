using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archip3l
{
    class Ressource
    {
        public string name;
        public int stock;
        public int production;
        public int consumption;

        public Ressource(string argName)
        {
            name = argName;
            stock = 0;
            production = 0;
            consumption = 0;
        }
        
    }
}
