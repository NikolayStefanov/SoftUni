using System;
using System.Collections.Generic;
using System.Text;

namespace Demo
{
    public class Cat : Animal, ICat
    {
        public Cat(string name, int age) 
            : base(name, age)
        {
        }

        public override string ProduceSound()
        {
            return "Meow Meow! I'm a sweet cat ! :P ";
        }
    }
}
