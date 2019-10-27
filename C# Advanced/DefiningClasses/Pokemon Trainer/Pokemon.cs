using System;
using System.Collections.Generic;
using System.Text;

namespace _9._Pokemon_Trainer_EXE
{
    public class Pokemon
    {
        public Pokemon(string name, string ele, int health)
        {
            this.Name = name;
            this.Element = ele;
            this.Health = health;
        }
        public string Name { get; set; }
        public string Element { get; set; }
        public int Health { get; set; }
    }
}
