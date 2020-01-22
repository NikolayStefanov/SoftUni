using SantaWorkshop.Models.Presents.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SantaWorkshop.Models.Presents
{
    public class Present : IPresent
    {
        private string name;
        private int energyRequired;
        public Present(string name, int energyReq)
        {
            this.Name = name;
            this.EnergyRequired = energyReq;
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Present name cannot be null or empty.");
                }
                this.name = value;
            }
        }

        public int EnergyRequired
        {
            get => this.energyRequired;
            private set
            {
                if (value<0)
                {
                    this.energyRequired = 0;
                }
                else
                {
                    this.energyRequired = value;
                }
            }
        }

        public void GetCrafted()
        {
            this.EnergyRequired -= 10;
        }

        public bool IsDone()
        {
            return this.energyRequired == 0;
        }
    }
}
