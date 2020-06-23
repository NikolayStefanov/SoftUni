using System;
using System.Collections.Generic;
using System.Text;

namespace _1.Vehicles
{
    public class Car : Vehicle
    {
        private double fuelQuantity;

        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption + 0.9;
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
            var result = distance * this.FuelConsumption;
            if (result <= this.FuelQuantity)
            {
                Console.WriteLine($"Car travelled {distance} km");
                this.FuelQuantity -= result;
            }
            else
            {
                Console.WriteLine($"Car needs refueling");
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
    }
}
