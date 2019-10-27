using System;
using System.Collections.Generic;
using System.Text;

namespace _8._Car_Salesman_exe
{
    public class Car
    {
        public Car(string model, string engine)
        {
            this.Model = model;
            this.Engine = engine;
        }
        public Car(string model, string engine, int weight) :this(model, engine)
        {
            this.Weight = weight;
        }
        public Car(string model, string engine, string color) :this(model, engine)
        {
            this.Color = color;
        }
        public Car(string model, string engine, string color, int weight) : this(model, engine)
        {
            this.Color = color;
            this.Weight = weight;
        }
        public string Model { get; set; }
        public string Engine { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }
    }
}
