using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _9._Pokemon_Trainer_EXE
{
    public class Trainer
    {
        public Trainer(string name, Pokemon collectionOfPokemons)
        {
            var counter = 1;
            this.Name = name;
            this.NumberOfBadges = 0;
            if (counter != 1)
            {
                this.CollectionOfPokemons.Add(collectionOfPokemons);
            }
            else
            {
                this.CollectionOfPokemons = new List<Pokemon>();
                CollectionOfPokemons.Add(collectionOfPokemons);
            }
            this.Appierence++;
        }
        public string Name { get; set; }
        public int Appierence { get; private set; }
        public int NumberOfBadges { get; set; }
        public List<Pokemon> CollectionOfPokemons { get; set; }
        public void RemovePokemons()
        {
            CollectionOfPokemons = CollectionOfPokemons.Where(x => x.Health > 0).ToList();
        }
    }
}
