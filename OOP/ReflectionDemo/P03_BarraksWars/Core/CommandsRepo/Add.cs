using _03BarracksFactory.Contracts;

namespace P03_BarraksWars.Core.CommandsRepo
{
    public class Add : Command
    {
        public Add(string[] datas, IRepository repo, IUnitFactory uFactory) 
            : base(datas, repo, uFactory)
        {
        }

        public override string Execute()
        {
            string unitType = this.Data[1];
            IUnit unitToAdd = this.UnitFactory.CreateUnit(unitType);
            this.Repository.AddUnit(unitToAdd);
            string output = unitType + " added!";
            return output;
        }
    }
}
