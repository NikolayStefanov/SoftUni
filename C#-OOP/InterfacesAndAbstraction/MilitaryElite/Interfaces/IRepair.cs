using System;
using System.Collections.Generic;
using System.Text;

namespace _8.MilitaryElite.Interfaces
{
    public interface IRepair
    {
        public string PartName { get; }
        public int Hours { get; }
    }
}
