using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class SportCar : Car
    {
        public SportCar(int horsePower, double fuel) : base(horsePower, fuel)
        {
            this.FuelConsumption = 10.0;
        }
        public override double FuelConsumption { get => base.FuelConsumption; set => base.FuelConsumption = value; }
        public override void Drive(double kilometers)
        {
            var fuelReduce = kilometers * this.FuelConsumption;
            this.Fuel -= fuelReduce;
        }
    }
}
