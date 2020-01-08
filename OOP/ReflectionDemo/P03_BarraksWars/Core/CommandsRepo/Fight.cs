using System;
using System.Collections.Generic;
using System.Text;
using _03BarracksFactory.Contracts;

namespace P03_BarraksWars.Core.CommandsRepo
{
    public class Fight : Command
    {
        public Fight(string[] datas, IRepository repo, IUnitFactory uFactory) : base(datas, repo, uFactory)
        {
        }

        public override string Execute()
        {
            Environment.Exit(0);
            return string.Empty;
        }
    }
}
