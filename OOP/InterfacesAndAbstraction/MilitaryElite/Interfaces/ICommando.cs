using System;
using System.Collections.Generic;
using System.Text;

namespace _8.MilitaryElite.Interfaces
{
    public interface ICommando : IPrivate, ISpecialisedSoldier
    {
        public List<IMission> Missions { get;}
    }
}
