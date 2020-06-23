using System;
using System.Collections.Generic;
using System.Text;
using _8.MilitaryElite.Enums;
using _8.MilitaryElite.Interfaces;

namespace _8.MilitaryElite.Soldiers
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(int id, string firstName, string lastName, decimal salary, Corp corp, List<IRepair> repairs) : base(id, firstName, lastName, salary, corp)
        {
            this.Repairs = repairs;
        }

        public List<IRepair> Repairs { get; }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Corps: " + $"{this.Corp}");
            sb.AppendLine($"Repairs:");
            foreach (var rep in this.Repairs)
            {
                sb.AppendLine("  " + rep.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
