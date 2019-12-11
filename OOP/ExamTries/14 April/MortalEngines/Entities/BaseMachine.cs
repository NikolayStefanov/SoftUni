using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MortalEngines.Entities
{
    public abstract class BaseMachine : IMachine
    {
        private string name;
        private IPilot pilot;

        public BaseMachine(string name, double attackPoints, double defensePoints, double healthPoints)
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.HealthPoints = healthPoints;
            this.Targets = new List<string>();
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Machine name cannot be null or empty.");
                }
                this.name = value;
            }
        }

        public IPilot Pilot 
        {
            get => pilot; 
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Pilot cannot be null.");
                }
                this.pilot = value;
            }
        }
        public double HealthPoints { get; set; }

        public double AttackPoints { get; protected set; }

        public double DefensePoints { get; protected set; }

        public IList<string> Targets { get; private set; }

        public void Attack(IMachine target)
        {
            if (target == null)
            {
                throw new NullReferenceException("Target cannot be null");
            }
            var attackDamage = this.AttackPoints - target.DefensePoints;
            if (attackDamage > 0)
            {
                target.HealthPoints -= attackDamage;
                if (target.HealthPoints < 0)
                {
                    target.HealthPoints = 0;
                }
            }
            this.Targets.Add(target.Name);
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"- {this.Name}" + Environment.NewLine
                    + $" *Type: {this.GetType().Name}" + Environment.NewLine
                    + $" *Health: {this.HealthPoints:f2}" + Environment.NewLine
                    + $" *Attack: {this.AttackPoints:f2}" + Environment.NewLine
                    + $" *Defense: {this.DefensePoints:f2}");
            if (!this.Targets.Any())
            {
                sb.AppendLine($" *Targets: None");
            }
            else
            {
                sb.AppendLine($" *Targets: {string.Join(", ", this.Targets)}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
