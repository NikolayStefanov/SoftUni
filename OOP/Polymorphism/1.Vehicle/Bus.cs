using System;
using System.Collections.Generic;
using System.Text;

namespace _1.Vehicles
{
    public class Bus : Vehicle, IDriveable, IRefuelabe
    {
        private double fuelQuantity;

        public Bus(double fuelQuant, double fuelConsum, double tankCapacity) : base(fuelQuant, fuelConsum, tankCapacity)
        {
            this.FuelQuantity = fuelQuant;
            this.FuelConsumption = fuelConsum;
            this.TankCapacity = tankCapacity;
        }
        public override double FuelQuantity 
        {
            get => fuelQuantity;
            protected set
            {
                if (value > this.TankCapacity)
                {
                    fuelQuantity = 0;
                }
                else
                {
                    fuelQuantity = value;
                }
            }
        }
        public override double FuelConsumption { get; protected set; }
        public override double TankCapacity { get; protected set; }
        public override void Drive(double distance)
        {
            var result = distance * (this.FuelConsumption + 1.4);
            if (result <= this.FuelQuantity)
            {
                Console.WriteLine($"Bus travelled {distance} km");
                this.FuelQuantity -= result;
            }
            else
            {
                Console.WriteLine($"Bus needs refueling");
            }
        }

        public override void Refuel(double fuelAmount)
        {
            if (fuelAmount <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else if (fuelAmount + this.FuelQuantity > this.TankCapacity)
            {
                Console.WriteLine($"Cannot fit {fuelAmount} fuel in the tank");
            }
            else
            {
                this.FuelQuantity += fuelAmount;
            }
        }
        public void DriveEmpty(double distance)
        {
            var result = distance * this.FuelConsumption;
            if (result <= this.FuelQuantity)
            {
                Console.WriteLine($"Bus travelled {distance} km");
                this.FuelQuantity -= result;
            }
            else
            {
                Console.WriteLine($"Bus needs refueling");
            }
        }
    }
}
