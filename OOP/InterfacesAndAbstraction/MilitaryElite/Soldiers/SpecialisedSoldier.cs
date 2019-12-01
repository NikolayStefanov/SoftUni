using _8.MilitaryElite.Enums;
using _8.MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _8.MilitaryElite.Soldiers
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, Corp corp) : base(id, firstName, lastName, salary)
        {
            this.Corp = corp;
        }

        public Corp Corp { get; }
    }
}
