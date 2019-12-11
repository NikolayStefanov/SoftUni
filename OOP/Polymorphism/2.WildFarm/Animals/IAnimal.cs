using _3.WildFarm.Food;
using System;
using System.Collections.Generic;
using System.Text;

namespace _3.WildFarm.Animals
{
    public interface IAnimal
    {
        public string Name { get;}
        public double Weight { get;}
        public int FoodEaten { get;}
        public string AskForFood();
        public void Feed(IFood foodType,int quantity);
    }
}
