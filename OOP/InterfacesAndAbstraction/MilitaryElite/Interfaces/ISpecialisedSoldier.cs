using _8.MilitaryElite.Enums;

namespace _8.MilitaryElite.Interfaces
{
    public interface ISpecialisedSoldier : IPrivate, ISoldier
    {
        public Corp Corp { get; }
    }
}
