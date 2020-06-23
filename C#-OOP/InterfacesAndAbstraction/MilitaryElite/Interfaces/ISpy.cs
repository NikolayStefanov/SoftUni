using System;
using System.Collections.Generic;
using System.Text;

namespace _8.MilitaryElite.Interfaces
{
    public interface ISpy : ISoldier
    {
        public int CodeNumber { get; }
    }
}
