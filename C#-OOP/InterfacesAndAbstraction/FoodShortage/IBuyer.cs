using System;
using System.Collections.Generic;
using System.Text;

namespace _7.Food_Shortage
{
    public interface IBuyer
    {
        public int Food { get;}
        public string Name { get; }
        public void BuyFood();
    }
}
