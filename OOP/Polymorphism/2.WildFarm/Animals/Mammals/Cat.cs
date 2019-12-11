using _3.WildFarm.Food;
using System;
using System.Collections.Generic;
using System.Text;

namespace _3.WildFarm.Animals.Mammals
{
    public class Cat : Feline, IAnimal
    {
        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override string AskForFood()
        {
            return "Meow";
        }
        public override void Feed(IFood foodType, int quantity)
        {
            if (foodType.GetType().Name != "Meat" && foodType.GetType().Name != "Vegetable")
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {foodType.GetType().Name}!");
            }
            this.FoodEaten += quantity;
            this.Weight += quantity * 0.30;
        }
    }
}
