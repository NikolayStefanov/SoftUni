using System;
using System.Collections.Generic;
using System.Text;
using _3.WildFarm.Food;

namespace _3.WildFarm.Animals
{
    public abstract class Animal : IAnimal
    {
        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
            FoodEaten = 0;
        }

        public string Name { get; protected set; }

        public double Weight { get; protected set; }

        public int FoodEaten { get; protected set; }

        public abstract string AskForFood();

        public abstract void Feed(IFood foodType, int quantity);
    }
}
