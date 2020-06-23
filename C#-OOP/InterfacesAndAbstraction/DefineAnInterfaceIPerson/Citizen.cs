using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    public class Citizen : IPerson, IIdentifiable
    {
        public Citizen(string name, int age, string id, string birth)
        {
            this.Name = name;
            this.Age = age;
            this.Birthdate = birth;
            this.Id = id;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Birthdate { get; set ; }
        public string Id { get; set; }
    }
}
