using System;
using System.Collections.Generic;
using System.Text;

namespace P01_RawData
{
    public class TireCollection
    {
        public TireCollection(double tire1Pressure, int tire1Age, double tire2Pressure, int tire2Age, double tire3Pressure, int tire3age, double tire4Pressure, int tire4age)
        {
            this.Tires = new Dictionary<double, int>();
            this.Tires[tire1Pressure] = tire1Age;
            this.Tires[tire2Pressure] = tire2Age;
            this.Tires[tire3Pressure] = tire3age;
            this.Tires[tire4Pressure] = tire4age;
        }

        public Dictionary<double, int> Tires { get; set; }

    }
}
