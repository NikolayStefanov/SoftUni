using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public class Fighter : BaseMachine, IFighter
    {
        private const double fighterHealth = 200;
        public Fighter(string name, double attackPoints, double defensePoints) : base(name, attackPoints, defensePoints, fighterHealth)
        {
            this.AggressiveMode = true;
            this.AttackPoints += 50;
            this.DefensePoints -= 25;
        }

        public bool AggressiveMode { get; private set; }

        public void ToggleAggressiveMode()
        {
            if (this.AggressiveMode)
            {
                this.AggressiveMode = false;
                this.AttackPoints -= 50;
                this.DefensePoints += 25;
            }
            else
            {
                this.AggressiveMode = true;
                this.AttackPoints += 50;
                this.DefensePoints -= 25;
            }
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            var onOrOff = "ON";
            if (!this.AggressiveMode)
            {
                onOrOff = "OFF";
            }
            sb.AppendLine($" *Aggressive: {onOrOff}");
            return sb.ToString().TrimEnd();
        }
    }
}
