using System;
using System.Collections.Generic;
using System.Text;
using _3.WildFarm.Food;

namespace _3.WildFarm.Animals.Birds
{
    public class Owl : Bird, IAnimal
    {
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override string AskForFood()
        {
            return "Hoot Hoot";
        }

        public override void Feed(IFood foodType, int quantity)
        {
            if (foodType.GetType().Name != "Meat")
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {foodType.GetType().Name}!");
            }
            this.FoodEaten += quantity;
            this.Weight += quantity * 0.25;
        }
    }
}
