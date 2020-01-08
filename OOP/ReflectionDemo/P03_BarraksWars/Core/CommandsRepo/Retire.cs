using System;
using System.Collections.Generic;
using System.Text;
using _03BarracksFactory.Contracts;

namespace P03_BarraksWars.Core.CommandsRepo
{
    public class Retire : Command
    {
        public Retire(string[] datas, IRepository repo, IUnitFactory uFactory) 
            : base(datas, repo, uFactory)
        {
        }

        public override string Execute()
        {
            var targetType = this.Data[1];
            var message = this.Repository.RemoveUnit(targetType);
            return message;
        }
    }
}
