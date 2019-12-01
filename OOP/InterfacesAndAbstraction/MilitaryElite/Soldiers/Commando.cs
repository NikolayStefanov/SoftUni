using System;
using System.Collections.Generic;
using System.Text;
using _8.MilitaryElite.Enums;
using _8.MilitaryElite.Interfaces;

namespace _8.MilitaryElite.Soldiers
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(int id, string firstName, string lastName, decimal salary, Corp corp, List<IMission> missions) : base(id, firstName, lastName, salary, corp)
        {
            this.Missions = missions;
        }

        public List<IMission> Missions { get;  }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Corps: {this.Corp}");
            sb.AppendLine("Missions:");
            foreach (var mission in this.Missions)
            {
                sb.AppendLine("  " + mission.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
