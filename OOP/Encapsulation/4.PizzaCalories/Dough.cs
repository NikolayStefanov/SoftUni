using System;
using System.Collections.Generic;
using System.Text;

namespace _4.PizzaCalories
{
    public class Dough
    {
        private const double whiteDough = 1.5;
        private const double wholegrainDough = 1.0;
        private const double crispyDough = 0.9;
        private const double chewyDough = 1.1;
        private const double homemadeDough = 1.0;
        private const double baseDoughCalories = 2.0;
        private string doughType;
        private int weight;
        private string bakingTehnique;

        public Dough(string type, string tehnique, int weight)
        {
            this.DoughType = type;
            this.BakingTehnique = tehnique;
            this.Weight = weight;
        }
        public string DoughType
        {
            get => doughType;
            private set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.doughType = value;
            }
        }
        public string BakingTehnique 
        {
            get => bakingTehnique;
            private set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.bakingTehnique = value;
            }
        }
        public int Weight
        {
            get => weight;
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                this.weight = value;
            }
        }

        public double GetTotalCalories()
        {
            var type = GetDoughType(this.DoughType);
            var tehnique = GetBakingTehnique(this.BakingTehnique);
            var result = (baseDoughCalories * this.Weight) * type * tehnique;
            return result;
        }
        private double GetDoughType(string doughType)
        {
            if (doughType == "White")
            {
                return whiteDough;
            }
            else
            {
                return wholegrainDough;
            }
        }
        private double GetBakingTehnique(string bakingTehnique)
        {
            switch (bakingTehnique.ToLower())
            {
                case "crispy":
                    return crispyDough;
                case "chewy":
                    return chewyDough;
                case "homemade":
                    return homemadeDough;
                default:
                    throw new ArgumentException("This baking tehnique doesn't exist!");
            }
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{GetTotalCalories():f2}");
            return sb.ToString().TrimEnd();
        }

    }
}
