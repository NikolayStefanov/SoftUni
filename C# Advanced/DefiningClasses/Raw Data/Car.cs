using System;
using System.Collections.Generic;
using System.Text;

namespace _7._Raw_Data_exe
{
    public class Car
    {
        public Car(string model, int engineSpeed, int enginePower, int cargoWeight, string cargoType, double[] tirePressure, int[] tireAge)
        {
            this.Model = model;
            this.Engine = new Engine(engineSpeed, enginePower);
            this.Cargo = new Cargo(cargoWeight, cargoType);
            this.Tires = new Tire(tirePressure, tireAge);


        }
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public Tire Tires { get; set; }
    }
}
