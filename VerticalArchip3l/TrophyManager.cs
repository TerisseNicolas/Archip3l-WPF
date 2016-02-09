using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerticalArchip3l
{
    class TrophyManager
    {
        public List<Trophy> Trophies { get; private set; }
        public EventHandler<TrophyObtainedEventArgs> TrophyObtained;

        public TrophyManager()
        {
            this.Trophies = new List<Trophy>();

            Trophy trophy1 = new Trophy(1, "Trophée ressources", "Gain de ressources", 50, 50, null);
            Trophy trophy2 = new Trophy(2, "Trophée innovation", "Multiplication de la productivité par 1.5", 160, 50, null);
            Trophy trophy3 = new Trophy(3, "Trophée rapidité", "Multiplication de la productivité par 1.5", 270, 50, null);
            Trophy trophy4 = new Trophy(4, "Trophée stratégie", "Une description", 380, 50, null);
            Trophy trophy5 = new Trophy(5, "Trophée légende", "Une description", 490, 50, null);

            this.Trophies.Add(trophy1);
            this.Trophies.Add(trophy2);
            this.Trophies.Add(trophy3);
            this.Trophies.Add(trophy4);
            this.Trophies.Add(trophy5);

            changeTrophyToObtained(trophy2);
            changeTrophyToObtained(trophy3);
            changeTrophyToObtained(trophy5);

            //trophy2.changeToObtained();
            //trophy3.changeToObtained();
            //trophy5.changeToObtained();
        }
        public List<Trophy> getTrophies(bool status)
        {
            List<Trophy> value = new List<Trophy>();
            if(this.Trophies.Count < 1)
            {
                return value;
            }
            for(int i = 0; i < this.Trophies.Count - 1; i++)
            {
                if(this.Trophies[i].Status == status)
                {
                    value.Add(this.Trophies[i]);
                }
            }
            return value;
        }
        public void changeTrophyToObtained(Trophy trophy)
        {
            trophy.changeToObtained();
            if(this.TrophyObtained != null)
            {
                this.TrophyObtained(this, new TrophyObtainedEventArgs { Trophy = trophy });
            }
        }
    }
    class TrophyObtainedEventArgs : EventArgs
    {
        public Trophy Trophy;
    }
}
