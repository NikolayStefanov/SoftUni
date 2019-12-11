using System;
using System.Collections.Generic;
using System.Text;

namespace _3.WildFarm.Animals.Mammals
{
    public abstract class Mammal : Animal, IAnimal
    {
        protected Mammal(string name, double weight, string livingRegion) : base(name, weight)
        {
            this.LivingRegion = livingRegion;
        }
        public string LivingRegion { get; protected set; }
    }
}
