using System;
using System.Collections.Generic;
using System.Text;

namespace Demo
{
    public class Dog : Animal
    {
        public Dog(string name, int age, string color) : base(name, age)
        {
        }

        public override string ProduceSound()
        {
            return "woof, woof, i am a furious doggo ! ";
        }
    }
}
