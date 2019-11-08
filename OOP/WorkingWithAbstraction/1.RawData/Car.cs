using System;
using System.Collections.Generic;
using System.Text;

namespace P01_RawData
{
    public class Car
    {
        public Car(string model, Engine engine, Cargo cargo, TireCollection tires)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.Tires = tires;
        }

        public Engine Engine { get; set; }
        public string Model { get; set; }
        public TireCollection Tires { get; set; }
        public Cargo Cargo { get; set; }
    }
}
