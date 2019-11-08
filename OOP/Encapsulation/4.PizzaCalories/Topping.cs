using System;
using System.Collections.Generic;
using System.Text;

namespace _4.PizzaCalories
{
    public class Topping
    {
        private const double meatType = 1.2;
        private const double veggiesType = 0.8;
        private const double cheeseType = 1.1;
        private const double sauceType = 0.9;
        private int weight;
        private string type;


        public Topping(string type, int weight)
        {
            this.Type = type;
            this.Weight = weight;
        }
        public int Weight
        {
            get { return weight; }
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.Type} weight should be in the range [1..50].");
                }
                this.weight = value;
            }
        }

        public string Type
        {
            get { return type; }
            private set 
            {
                if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                this.type = value;
            }
        }

        public double GetTotalCalories()
        {
            var typeValue = GetType(this.Type);
            var result = (2.0 * this.Weight) * typeValue;
            return result;
        }
        private double GetType(string typeName)
        {
            switch (typeName.ToLower())
            {
                case "meat":
                    return meatType;
                case "veggies":
                    return veggiesType;
                case "cheese":
                    return cheeseType;
                case "sauce":
                    return sauceType;
                default:
                    throw new ArgumentException($"Cannot place {typeName} on top of your pizza.");
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
