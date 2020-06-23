using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public class Tank : BaseMachine, ITank
    {
        private const double tankHealth = 100;

        public Tank(string name, double attackPoints, double defensePoints) : base(name, attackPoints, defensePoints, tankHealth)
        {
            this.DefenseMode = true;
            this.AttackPoints -= 40;
            this.DefensePoints += 30;
        }

        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            if (DefenseMode)
            {
                this.DefenseMode = false;
                this.AttackPoints += 40;
                this.DefensePoints -= 30;
            }
            else
            {
                this.DefenseMode = true;
                this.AttackPoints -= 40;
                this.DefensePoints += 30;
            }
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            var onOrOff = "ON";
            if (!this.DefenseMode)
            {
                onOrOff = "OFF";
            }
            sb.AppendLine($" *Defense: {onOrOff}");
            return sb.ToString().TrimEnd();
        }
    }
}
