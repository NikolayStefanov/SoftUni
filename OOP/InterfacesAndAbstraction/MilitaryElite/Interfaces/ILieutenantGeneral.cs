namespace _8.MilitaryElite.Interfaces
{
    using System.Collections.Generic;
    interface ILieutenantGeneral : IPrivate, ISoldier
    {
        public List<IPrivate> Privates { get; }

    }
}
