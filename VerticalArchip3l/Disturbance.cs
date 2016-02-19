using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerticalArchip3l
{
    class Disturbance
    {
        public string Name { get; private set; }
        public string Instruction { get; private set; }
        public DisturbanceEffect DisturbanceEffect { get; private set;}
        public event EventHandler<ApplyingDisturbanceEffectEventArgs> ApplyingDisturbanceEffect;

        public Disturbance(string name, string instruction, DisturbanceEffect disturbanceEffect)
        {
            this.Name = name;
            this.Instruction = instruction;
            this.DisturbanceEffect = disturbanceEffect;
        }
        public void applyEffect()
        {
            this.DisturbanceEffect.apply();
            if(this.ApplyingDisturbanceEffect != null)
            {
                ApplyingDisturbanceEffect(this, new ApplyingDisturbanceEffectEventArgs());
            }
        }
    }
    class ApplyingDisturbanceEffectEventArgs : EventArgs { }
}
