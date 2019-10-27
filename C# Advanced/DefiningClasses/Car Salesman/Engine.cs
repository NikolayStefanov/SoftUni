using System;
using System.Collections.Generic;
using System.Text;

namespace _8._Car_Salesman_exe
{
    public class Engine
    {
        public Engine(string model, int power)
        {
            this.Model = model;
            this.Power = power;
        }
        public Engine(string model, int power, int displacement) : this(model, power)
        {
            this.Displacement = displacement;
        }
        public Engine(string model, int power, string efficiety) : this(model, power)
        {
            this.Efficiency = efficiety;
        }
        public Engine(string model, int power, int displacement, string efficiety)
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = displacement;
            this.Efficiency = efficiety;
        }
        public string Model { get; set; }
        public int Power { get; set; }
        public int Displacement { get; set; }
        public string Efficiency { get; set; }
    }
}
