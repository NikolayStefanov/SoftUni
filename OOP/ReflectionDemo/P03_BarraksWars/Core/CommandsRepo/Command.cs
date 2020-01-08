using _03BarracksFactory.Contracts;

namespace P03_BarraksWars.Core.CommandsRepo
{
    public abstract class Command : IExecutable
    {
        private string[] data;
        private IRepository repository;
        private IUnitFactory unitFactory;
        public Command(string[] datas, IRepository repo, IUnitFactory uFactory)
        {
            this.Data = datas;
            this.Repository = repo;
            this.UnitFactory = uFactory;
        }
        protected string[] Data
        {
            get => this.data;
            set => this.data = value;
        }
        protected IRepository Repository
        {
            get => this.repository;
            set => this.repository = value;
        }
        protected IUnitFactory UnitFactory
        {
            get => this.unitFactory;
            set => this.unitFactory = value;
        }
        public abstract string Execute();
    }
}
