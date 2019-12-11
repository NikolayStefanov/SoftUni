using System;
using System.Collections.Generic;
using System.Text;

namespace _1.Vehicles
{
    public class Truck : Vehicle
    {
        private double fuelQuantity;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapa) : base(fuelQuantity, fuelConsumption, tankCapa)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption + 1.6;
            this.TankCapacity = tankCapa;
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
        public override double TankCapacity { get; protected set; }
        public override double FuelConsumption { get; protected set; }
        public override void Drive(double distance)
        {
            var result = distance * this.FuelConsumption;
            if (result <= FuelQuantity)
            {
                Console.WriteLine($"Truck travelled {distance} km");
                this.FuelQuantity -= result;
            }
            else
            {
                Console.WriteLine($"Truck needs refueling");
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
                this.FuelQuantity += fuelAmount * 0.95;
            }
        }
    }
}
