using _3.WildFarm.Food;
using System;
using System.Collections.Generic;
using System.Text;

namespace _3.WildFarm.Animals.Mammals
{
    public class Tiger : Feline, IAnimal
    {
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override string AskForFood()
        {
            return "ROAR!!!";
        }

        public override void Feed(IFood foodType, int quantity)
        {
            if (foodType.GetType().Name != "Meat")
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {foodType.GetType().Name}!");
            }
            this.FoodEaten += quantity;
            this.Weight += quantity * 1.00;
        }
    }
}
