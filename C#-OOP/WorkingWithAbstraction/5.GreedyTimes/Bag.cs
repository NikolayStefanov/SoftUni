using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P05_GreedyTimes
{
    public class Bag
    {
        private long currentTreasure;
        public Bag(long capacity)
        {
            this.Capacity = capacity;
            this.Gold = new Gold();
            this.Gems = new List<Gem>();
            this.Cashes = new List<Cash>();
        }
        public Gold Gold { get; set; }
        public List<Gem> Gems { get; set; }
        public List<Cash> Cashes { get; set; }
        public long Capacity { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            if (this.Gold.Value > 0)
            {
                sb.AppendLine($"<Gold> ${this.Gold.Value}");
                sb.AppendLine(this.Gold.ToString());
            }
            if (this.Gems.Count > 0)
            {
                sb.AppendLine($"<Gem> ${this.Gems.Sum(x=> x.Value)}");
                foreach (var gem in this.Gems.OrderByDescending(x=> x.Name).ThenBy(x=> x.Value))
                {
                    sb.AppendLine(gem.ToString());
                }
            }
            if (this.Cashes.Count > 0)
            {
                sb.AppendLine($"<Cash> ${this.Cashes.Sum(x => x.Value)}");
                foreach (var cash in this.Cashes.OrderByDescending(x=> x.Name).ThenBy(x=> x.Value))
                {
                    sb.AppendLine(cash.ToString());
                }
            }
            return sb.ToString().TrimEnd();
        }
        public void AddGold(long value)
        {
            if (currentTreasure + value <= this.Capacity)
            {
                this.Gold.Value += value;
                currentTreasure += value;
            }
        }
        public void AddGems(Gem gem)
        {
            if (this.Gems.All(x=> x.Name!= gem.Name) && this.Gems.Sum(x=> x.Value) + gem.Value <= this.Gold.Value && currentTreasure + gem.Value <= this.Capacity)
            {
                this.Gems.Add(gem);
                currentTreasure += gem.Value;
            }
            else if (this.Gems.Sum(x => x.Value) + gem.Value <= this.Gold.Value && currentTreasure + gem.Value <= this.Capacity)
            {
                var targetGem = this.Gems.Find(x=> x.Name == gem.Name);
                targetGem.Value += gem.Value;
                currentTreasure += gem.Value;
            }
        }
        public void AddCash(Cash cash)
        {
            if (this.Cashes.All(x => x.Name != cash.Name) && this.Cashes.Sum(x => x.Value) + cash.Value <= this.Gems.Sum(x => x.Value) && currentTreasure + cash.Value <= this.Capacity)
            {
                this.Cashes.Add(cash);
                currentTreasure += cash.Value;
            }
            else if (this.Cashes.Sum(x => x.Value) + cash.Value <= this.Gems.Sum(x => x.Value) && currentTreasure + cash.Value <= this.Capacity)
            {
                var targetCash = this.Cashes.Find(x => x.Name == cash.Name);
                targetCash.Value += cash.Value;
                currentTreasure += cash.Value;
            }
        }
    }
}
