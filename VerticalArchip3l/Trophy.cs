using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerticalArchip3l
{
    class Trophy
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool Status { get; private set; }
        public string Image { get; private set; }
        public Bonus Bonus { get; private set; }

        public Trophy(int id, string name, string description, Bonus bonus)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.Status = false;
            this.Bonus = bonus;
            this.Image = "C:/tempConcours/trophy-emptyMedal.png";
        }
        public bool changeToObtained()
        {
            if (this.Status)
            {
                return false;
            }
            else
            {
                //if (!this.Bonus.applyBonus())
                //{
                //    return false;
                //}
                this.Status = true;
                this.Image = "C:/tempConcours/trophy-wonMedal-" + this.Id + ".png";
                return true;
            }
        }
        public bool changeToEmpty()
        {
            if(!this.Status)
            {
                return false;
            }
            else
            {
                this.Status = false;
                this.Image = "C:/tempConcours/trophy-emptyMedal.png";
                return true;
            }
        }
    }
}
