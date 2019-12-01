using System;
using System.Collections.Generic;
using System.Text;

namespace _7.Food_Shortage
{
    public class Citizen : IBuyer
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.ID = id;
            this.BirthDate = birthdate;
            this.Food = 0;
        }
        public string Name { get; private set; }
        public int Age { get; set; }
        public string ID { get; set; }
        public string BirthDate { get; set; }
        public int Food { get; private set; }

        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
