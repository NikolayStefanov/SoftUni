using _8.MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _8.MilitaryElite.Soldiers
{
    public class Spy : Soldier, ISpy
    {
        public Spy(int id, string firstName, string lastName, int codeNum) : base(id, firstName, lastName)
        {
            this.CodeNumber = codeNum;
        }

        public int CodeNumber { get; }
        public override string ToString()
        {
            return $"Name: {this.FirstName} {this.LastName} Id: {this.ID}"
                + Environment.NewLine +
                $"Code Number: {this.CodeNumber}";
        }
    }
}
