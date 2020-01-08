using _03BarracksFactory.Contracts;

namespace P03_BarraksWars.Core.CommandsRepo
{
    public class Report : Command
    {
        public Report(string[] datas, IRepository repo, IUnitFactory uFactory) 
            : base(datas, repo, uFactory)
        {
        }

        public override string Execute()
        {
            string output = this.Repository.Statistics;
            return output;
        }
    }
}
