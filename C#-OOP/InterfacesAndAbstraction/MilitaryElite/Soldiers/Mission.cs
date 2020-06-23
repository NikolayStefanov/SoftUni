using _8.MilitaryElite.Enums;
using _8.MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _8.MilitaryElite.Soldiers
{
    public class Mission : IMission
    {
        public Mission(string codeName, State state)
        {
            this.CodeName = codeName;
            this.State = state;
        }
        public string CodeName { get; }

        public State State { get; private set; }

        public void CompleteMission()
        {
            this.State = State.Finished;
        }
        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State}";
        }
    }
}
