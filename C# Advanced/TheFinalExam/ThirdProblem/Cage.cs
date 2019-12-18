using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rabbits
{
    class Cage
    {
        private List<Rabbit> data;
        public Cage(string name, int capa)
        {
            this.Name = name;
            this.Capacity = capa;
            this.data = new List<Rabbit>();
        }

        public int Count
        {
            get { return this.data.Count; }
        }

        public string Name { get; set; }
        public int Capacity { get; set; }

        public void Add(Rabbit rabbit)
        {
            if (this.data.Count < this.Capacity)
            {
                this.data.Add(rabbit);
            }
        }
        public bool RemoveRabbit(string name)
        {
            var targetRabbit = this.data.Any(x=> x.Name == name);
            if (targetRabbit)
            {
                this.data = this.data.Where(x => x.Name != name).ToList();
                return targetRabbit;
            }
            return targetRabbit;           
        }

        public void RemoveSpecies(string species)
        {
            this.data = this.data.Where(x => x.Species != species).ToList();
        }
        public Rabbit SellRabbit(string name)
        {
            Rabbit targetRabbit = null;

            foreach (var rabbit in this.data)
            {
                if (rabbit.Name == name)
                {
                    targetRabbit = rabbit;
                    rabbit.Available = false;
                }
            }
            return targetRabbit;
        }
        public Rabbit[] SellRabbitsBySpecies(string species)
        {
            var rabbitArr = this.data.Where(x => x.Species == species);
            foreach (var rabbit in rabbitArr)
            {
                rabbit.Available = false;
            }
            return rabbitArr.ToArray();
        }
        public string Report()
        {
            var notSolded = this.data.Where(x => x.Available == true);
            var result = new StringBuilder();
            result.AppendLine($"Rabbits available at {this.Name}:");
            foreach (var rabbit in notSolded)
            {
                result.AppendLine(rabbit.ToString());
            }
            return result.ToString().TrimEnd();
        }

    }
}
