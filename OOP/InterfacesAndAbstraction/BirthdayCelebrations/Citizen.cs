using System;
using System.Collections.Generic;
using System.Text;

namespace _6.BirthdayCelebrations
{
    public class Citizen : IBirthable
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.ID = id;
            this.BirthDate = birthdate;
        }
        public int Age { get; private set; }
        public string Name { get; set; }
        public string ID { get; set; }
        public string BirthDate { get; set; }
    }
}
