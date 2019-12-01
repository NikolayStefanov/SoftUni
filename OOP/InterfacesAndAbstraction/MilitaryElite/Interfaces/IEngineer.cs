using System.Collections.Generic;

namespace _8.MilitaryElite.Interfaces
{
    public interface IEngineer : ISoldier, IPrivate, ISpecialisedSoldier
    {
        public List<IRepair> Repairs { get;}
    }
}
