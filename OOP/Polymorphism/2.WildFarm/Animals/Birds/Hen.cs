using System;
using System.Collections.Generic;
using System.Text;
using _3.WildFarm.Food;

namespace _3.WildFarm.Animals.Birds
{
    public class Hen : Bird, IAnimal
    {
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override string AskForFood()
        {
            return "Cluck";
        }
        public override void Feed(IFood foodType, int quantity)
        {
            this.FoodEaten += quantity;
            this.Weight += quantity * 0.35;
        }
    }
}
