using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut
    {
        private const double initialOxygen = 70;
        public Biologist(string name) : base(name, initialOxygen)
        {
        }
        public override void Breath()
        {
            var oxygenAfterBreath = this.Oxygen - 5;
            if (oxygenAfterBreath < 0)
            {
                 this.Oxygen = 0;
            }
            else
            {
                this.Oxygen = oxygenAfterBreath;
            }
        }
    }
}
