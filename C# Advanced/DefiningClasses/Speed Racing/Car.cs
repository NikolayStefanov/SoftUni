using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRacing
{
    public class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumption)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumption;
        }
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; private set; } = 0;

        public bool Move(string carModel, double amountOfKm)
        {
            var isEnough = amountOfKm * FuelConsumptionPerKilometer;
            if (FuelAmount - isEnough > 0)
            {
                FuelAmount -= isEnough;
                TravelledDistance += amountOfKm;
            }
            else
            {
                return false;
            }
            return true;
        }
    }
}
