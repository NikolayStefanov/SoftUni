using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        public Person(string name, decimal money)
        {
            this.Products = new List<string>();
            this.Name = name;
            this.Money = money;
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value != string.Empty && value != null && value != " ")
                {
                    this.name = value;
                }
                else
                {
                    throw new ArgumentException("Name cannot be empty");
                }
            }
        }

        public decimal Money
        {
            get
            {
                return this.money;
            }
            set
            {
                if (value >= 0)
                {
                    this.money = value;
                }
                else
                {
                    throw new ArgumentException("Money cannot be negative");
                }
            }
        }

        public List<string> Products { get; }

        public void Add(string product)
        {
            this.Products.Add(product);
        }
    }
}