using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        public Car(int horsePower, double fuel) : base(horsePower, fuel)
        {
            this.FuelConsumption = 3.0;
        }
        public override double FuelConsumption { get => base.FuelConsumption; set => base.FuelConsumption = value; }
        public override void Drive(double kilometers)
        {
            var fuelReduce = kilometers * this.FuelConsumption;
            this.Fuel -= fuelReduce;
        }
    }
}
