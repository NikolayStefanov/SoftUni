using System;
using System.Collections.Generic;
using System.Text;

namespace _4.PizzaCalories
{
    public class Pizza
    {
        private string name;
        private List<Topping> Toppings;
        public Pizza(string name)
        {
            this.Name = name;
            this.Toppings = new List<Topping>();
        }
        public string Name
        {
            get { return name; }
            private set 
            {
                if (string.IsNullOrEmpty(value) || value.Length < 1 || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                this.name = value;
            }
        }
        public Dough Dough { get; set; }

        public void AddTopping(Topping top)
        {
            if (this.Toppings.Count == 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            this.Toppings.Add(top);
        }
        public int NumberOfToppings()
        {
            return this.Toppings.Count;
        }
        public double GetTotalCalories()
        {
            var result = this.Dough.GetTotalCalories();
            foreach (var top in this.Toppings)
            {
                result += top.GetTotalCalories();
            }
            return result;
        }
    }
}
