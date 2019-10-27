using System;
using System.Collections.Generic;
using System.Text;

namespace _7._Raw_Data_exe
{
    public class Cargo
    {
        public Cargo(int weight, string type)
        {
            this.CargoWeight = weight;
            this.CargoType = type;
        }
        public int CargoWeight { get; set; }
        public string CargoType { get; set; }
    }
}
