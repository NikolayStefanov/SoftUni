using System;
using System.Collections.Generic;
using System.Text;

namespace Rabbits
{
    class Rabbit
    {
        public Rabbit(string name, string species)
        {
            this.Name = name;
            this.Species = species;
            this.Available = true;
        }
        public string Name { get; set; }
        public string Species { get; set; }
        public bool Available { get; set; }
        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine($"Rabbit ({this.Species}): {this.Name}");
            return result.ToString().TrimEnd();
        }

    }
}
