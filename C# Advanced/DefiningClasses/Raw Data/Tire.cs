using System;
using System.Collections.Generic;
using System.Text;

namespace _7._Raw_Data_exe
{
    public class Tire
    {
        public Tire(double[] pressure, int[] age)
        {
            this.Pressure = new double[4];
            this.Pressure = pressure;
            this.Age = new int[4];
            this.Age = age;
        }
        public double[] Pressure { get; set; }
        public int[] Age { get; set; }
    }
}
