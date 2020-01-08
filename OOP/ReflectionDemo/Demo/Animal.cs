using System;
using System.Collections.Generic;
using System.Text;

namespace Demo
{
    public abstract class Animal : IAnimal
    {
        private string name;
        public Animal(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public string Name
        {
            get { return this.name; }
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Name must be with more than 3 symbols.");
                }
                this.name = value;
            }
        }
        public int Age { get; set; }

        public abstract string ProduceSound();
    }
}
