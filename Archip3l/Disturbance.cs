using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archip3l
{
    class Disturbance
    {
        public Island location;
        public int duration;
        public int remaingTime;
        public int force;

        public Disturbance(Island argLocation, int argDuration, int argForce)
        {
            location = argLocation;
            duration = argDuration;
            remaingTime = argDuration;
            force = argForce;
        }

        
    }
}
