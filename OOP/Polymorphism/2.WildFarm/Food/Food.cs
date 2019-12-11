using System;
using System.Collections.Generic;
using System.Text;

namespace _3.WildFarm.Food
{
    public abstract class Food : IFood
    {
        public Food(int quantity)
        {
            this.Quantity = quantity;
        }
        public int Quantity { get; protected set; }
    }
}
