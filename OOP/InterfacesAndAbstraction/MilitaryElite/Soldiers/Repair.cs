using _8.MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _8.MilitaryElite.Soldiers
{
    public class Repair : IRepair
    {
        public Repair(string name, int hour)
        {
            this.PartName = name;
            this.Hours = hour;
        }
        public string PartName { get; }

        public int Hours { get; }
        public override string ToString()
        {
            return $"Part Name: {this.PartName} Hours Worked: {this.Hours}";
        }
    }
}
