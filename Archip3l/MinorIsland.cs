using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archip3l
{
    class MinorIsland : Island
    {
        public int id;      //1 : haut gauche, 2 : haut droite, 3 : bas gauche, 4 : bas droite
        public string canvasName;

        public MinorIsland(int argId) : base()  //initialize ressources & buildings from Island constructor
        {
            id = argId;
            canvasName = "CanIsl" + argId.ToString();
        }
    }
}
