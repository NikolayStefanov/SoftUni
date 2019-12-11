using System;
using System.Collections.Generic;
using System.Text;

namespace _3.WildFarm.Animals.Mammals
{
    public abstract class Feline : Mammal, IAnimal
    {
        protected Feline(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion)
        {
            this.Breed = breed;
        }
        public string Breed { get; protected set; }
        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
