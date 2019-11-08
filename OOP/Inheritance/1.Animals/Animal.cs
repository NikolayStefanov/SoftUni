using System;
using System.Text;

namespace Animals
{
    public abstract class Animal
    {
        private int age;

        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }
        public int Age
        {
            get { return age; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid input!");
                }
                this.age = value;
            }
        }
        public string Name { get; set; }
        public string Gender { get; set; }

        public abstract string ProduceSound();
        public override string ToString()
        {
            var animalInfo = new StringBuilder();
            animalInfo.AppendLine(this.GetType().Name);
            animalInfo.AppendLine($"{this.Name} {this.Age} {this.Gender}");
            animalInfo.AppendLine($"{this.ProduceSound()}");
            return animalInfo.ToString().TrimEnd();
        }
    }
}
