using System;
using System.Collections.Generic;
using System.Text;

namespace _1.Vehicles
{
    public abstract class Vehicle : IRefuelabe, IDriveable
    {
        public Vehicle(double fuelQuant, double fuelConsum, double tankCapacity)
        {
            this.FuelQuantity = fuelQuant;
            this.FuelConsumption = fuelConsum;
            this.TankCapacity = tankCapacity;
        }

        public virtual double FuelQuantity { get; protected set; }
        public virtual double TankCapacity { get; protected set; }
        public virtual double FuelConsumption { get; protected set; }
        public abstract void Drive(double distance);

        public abstract void Refuel(double fuelAmount);
    }
}
