using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private ICollection<IDecoration> decorations;
        private ICollection<IFish> fishes;
        public Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.decorations = new List<IDecoration>();
            this.fishes = new List<IFish>();
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Aquarium name cannot be null or empty.");
                }
                this.name = value;
            }
        }

        public int Capacity { get; }

        public int Comfort
        {
            get
            {
                var totalComfort = 0;
                foreach (var decor in this.Decorations)
                {
                    totalComfort += decor.Comfort;
                }
                return totalComfort;
            }
        }

        public ICollection<IDecoration> Decorations => this.decorations;

        public ICollection<IFish> Fish => this.fishes;

        public void AddDecoration(IDecoration decoration)
        {
            this.Decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if (this.fishes.Count == this.Capacity)
            {
                throw new InvalidOperationException("Not enough capacity.");
            }
            this.fishes.Add(fish);
        }

        public void Feed()
        {
            foreach (var fish in this.fishes)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.Name} ({this.GetType().Name}):");
            if (this.fishes.Count == 0)
            {
                sb.AppendLine("Fish: none");
            }
            else
            {
                var fishesName = new List<string>();
                foreach (var fish in this.fishes)
                {
                    fishesName.Add(fish.Name);
                }
                sb.AppendLine($"Fish: {string.Join(", ", fishesName)}");
            }
            sb.AppendLine($"Decorations: {this.decorations.Count}");
            sb.AppendLine($"Comfort: {this.Comfort}");

            return sb.ToString().TrimEnd();
        }

        public bool RemoveFish(IFish fish)
        {
            return this.fishes.Remove(fish);
        }
    }
}
